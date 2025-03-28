using NpocoMapper.Models;
using System;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace NpocoMapper.Ops;

public static class Writer
{
	public static string WriteEnum(EnumPoco enumPoco, string namespaceName)
	{
		var sb1 = new StringBuilder();
		var sb2 = new StringBuilder();
		int ic = enumPoco.Values.Count - 1;
		int i;

		for (i = 0; i <= ic; i += 1)
		{
			sb1.AppendLine($"{t(2)}{enumPoco.Values[i].Name} = {enumPoco.Values[i].Id}{(i < ic ? "," : "")}");
			sb2.AppendLine($@"{t(3)}lst.Add(new NameValueItem {{ Name = ""{enumPoco.Values[i].Name}"",Value = ""{enumPoco.Values[i].Id}"" }});");
		}


		return $@"using System;
using System.Collections.Generic;
using {namespaceName};

namespace {namespaceName}
{{
	public enum {enumPoco.EnumName}
	{{
{sb1}	}}

	public static partial class ApLists
	{{
		public static List<NameValueItem> Get{enumPoco.EnumName}List(string zeroItemText, string negOneItemText)
		{{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem {{ Name = negOneItemText, Value = ""-1"" }});
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem {{ Name = zeroItemText, Value = ""0"" }});

{sb2}

			return lst;
		}}

	}}
}}";
	}

	public static string WritePoco(Poco poco, string modelNamespace, bool includeTsModel)
	{
		string pk = "";
		if (!String.IsNullOrWhiteSpace(poco.PrimaryKeys))
		{
			pk = $$"""
				[PrimaryKey("{{poco.PrimaryKeys}}", AutoIncrement = {{(poco.IsAutoIncrement ? "true" : "false")}})]
				""";
		}

		string tsm = includeTsModel ? "\r\n[TypeScriptModel]" : "";

		var sb = new StringBuilder();
		foreach (var p in poco.Props)
		{
			sb.AppendLine($"{t(1)}[NPoco.Column]");
			sb.AppendLine($"{t(1)}public {p.PropType + (p.IsNullable ? "?" : "")} {p.PropName} {{ get; set; }}{((p.PropType == "string" && !p.IsNullable) ? " = \"\";" : "")}");
		}
		string props = sb.ToString();

		return $$"""
			using System;
			using NPoco;

			namespace {{modelNamespace}};
			
			[TableName("{{poco.EntityName}}")]{{pk}}
			[ExplicitColumns]{{tsm}}
			public partial class {{poco.ClassName}}
			{
			{{props}}
			}
			
			""";
	}

	public static string WriteRepo(Poco poco, string modelNamespace, string repoNamespace)
	{
		bool hasIsDeleted = poco.Props.Any(a => a.PropName == "IsDeleted");
		

		string rw = "";
		if (poco.Props[0].IsPk)
		{
			string keyName = poco.Props[0].PropName;
			string keyType = poco.Props[0].PropType;

			string del1 = hasIsDeleted ? $"string sql = \"UPDATE [{poco.EntityName}] SET IsDeleted = 1 WHERE ({keyName} = @0);\";" : "";
			string del2 = hasIsDeleted ? "db.Execute(sql, id);" : $"db.Delete<{poco.ClassName}>(id);";

			rw = $$"""
				public {{keyType}} Save({{poco.ClassName}} entity)
				{
					db.Save<{{poco.ClassName}}>(entity);
					return entity.{{keyName}};
				}

				public bool Save(IEnumerable<{{poco.ClassName}}> items)
				{
					foreach ({{poco.ClassName}} item in items)
					{
						db.Save<{{poco.ClassName}}>(item);
					}
					return true;
				}

				public bool Delete({{keyType}} id)
				{
					{{del1}}
					{{del2}}
					return true;
				}

				public bool Delete(IEnumerable<{{keyType}}> ids)
				{
					foreach ({{keyType}} id in ids)
					{
						db.Delete<{{poco.ClassName}}>(id);
					}
					return true;
				}

				public bool Destroy({{keyType}} id)
				{
					db.Delete<{{poco.ClassName}}>(id);
					return true;
				}

				public {{poco.ClassName}} FindBy({{keyType}} id)
				{
					return db.SingleOrDefaultById<{{poco.ClassName}}>(id);
				}
			""";
		}

		return $$"""
			using System;
			using System.Collections.Generic;
			using System.Linq;
			using NPoco;
			using {{modelNamespace}};
			using {{repoNamespace}}.Core;

			namespace {{repoNamespace}};
			
			public class {{poco.ClassName}}Db(string connStr) : RepositoryBase(connStr)
			{
				{{rw}}
				public IEnumerable<{{poco.ClassName}}> All()
				{
					return db.Fetch<{{poco.ClassName}}>("");
				}


				//Example - filtered list:
				public IEnumerable<{{poco.ClassName}}> FilteredList(string str1, string str2)
				{
					return db.Fetch<{{poco.ClassName}}>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
				}

				//Example - paged & filtered list:
				public Page<{{poco.ClassName}}> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
				{
					return db.Page<{{poco.ClassName}}>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
				}
			}
			""";
	}

	public static string WriteRepoBase(string repoNamespace, DbType dbType)
	{
		string factoryTypeName = dbType switch
		{
			DbType.Sqlite => "Microsoft.Data.Sqlite.SqliteFactory.Instance",
			DbType.MsSql => "Microsoft.Data.SqlClient.SqlClientFactory.Instance",
			_ => "Microsoft.Data.SqlClient.SqlClientFactory.Instance"
		};

		string dbTypeName = dbType switch
		{
			DbType.Sqlite => "SQLite",
			DbType.MsSql => "SqlServer2012",
			_ => "SqlServer2012"
		};

		return $$"""
			using NPoco;
			using System;
			using System.Data.Common;

			namespace {{repoNamespace}}.Core;
			
			public abstract class RepositoryBase : IDisposable
			{
				protected Database db;
				bool _disposed = false;

				public RepositoryBase(string connStr)
				{
					DbProviderFactory factory = {{factoryTypeName}};
					db = new Database(connStr, DatabaseType.{{dbTypeName}}, factory);
					//db.Execute("PRAGMA journal_mode=WAL;");
				}

				public void Dispose()
				{
					Dispose(true);
					GC.SuppressFinalize(this);
				}

				~RepositoryBase()
				{
					Dispose(false);
				}

				protected virtual void Dispose(bool disposing)
				{
					if (_disposed)
						return;

					if (disposing)
					{
						// free other managed objects that implement, IDisposable only

						db?.Dispose();
					}

					// Release any unmanaged objects. Set the object references to null
			#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
					db = null;
			#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

					_disposed = true;
				}
				
			}
			""";
	}


	private static string t(int n = 1)
	{
		if (n < 1) return "";
		return new String('\t', n);
	}

	//private static string hr(int n = 1)
	//{
	//	return n switch
	//	{
	//		< 1 => "",
	//		1 => "\r\n",
	//		_ => string.Concat(Enumerable.Repeat("\r\n", n))
	//	};
	//}

}
