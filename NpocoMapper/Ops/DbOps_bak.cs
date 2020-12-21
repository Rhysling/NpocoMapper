using NpocoMapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NpocoMapper.Db
{
	public class DbOps
	{
		string connString;

		public DbOps(string connString)
		{
			this.connString = connString;
		}


		Tables LoadTables()
		{

			{
				Tables result;
				using (var conn = _factory.CreateConnection())
				{
					conn.ConnectionString = ConnectionString;
					conn.Open();

					SchemaReader reader = null;

					if (_factory.GetType().Name == "MySqlClientFactory")
					{
						// MySql
						reader = new MySqlSchemaReader();
					}
					else if (_factory.GetType().Name == "SqlCeProviderFactory")
					{
						// SQL CE
						reader = new SqlServerCeSchemaReader();
					}
					else if (_factory.GetType().Name == "NpgsqlFactory")
					{
						// PostgreSQL
						reader = new PostGreSqlSchemaReader();
					}
					else if (_factory.GetType().Name == "OracleClientFactory")
					{
						// Oracle
						reader = new OracleSchemaReader();
					}
					else
					{
						// Assume SQL Server
						reader = new SqlServerSchemaReader();
					}

					reader.outer = this;
					result = reader.ReadSchema(conn, _factory);

					// Remove unrequired tables/views
					for (int i = result.Count - 1; i >= 0; i--)
					{
						if (SchemaName != null && string.Compare(result[i].Schema, SchemaName, true) != 0)
						{
							result.RemoveAt(i);
							continue;
						}
						//if (!IncludeViews && result[i].IsView)
						//{
						//	result.RemoveAt(i);
						//	continue;
						//}
					}

					// If DefaultToExcludeTables, set Ignore = true for all

					if (DefaultToExcludeTables)
					{
						foreach (var tbl in result)
						{
							tbl.Ignore = true;
						}
					}

					conn.Close();


					var rxClean = new Regex("^(Equals|GetHashCode|GetType|ToString|repo|Save|IsNew|Insert|Update|Delete|Exists|SingleOrDefault|Single|First|FirstOrDefault|Fetch|Page|Query)$");
					foreach (var t in result)
					{
						t.ClassName = ClassPrefix + t.ClassName + ClassSuffix;
						foreach (var c in t.Columns)
						{
							c.PropertyName = rxClean.Replace(c.PropertyName, "_$1");

							// Make sure property name doesn't clash with class name
							if (c.PropertyName == t.ClassName)
								c.PropertyName = "_" + c.PropertyName;
						}
					}

					return result;
				}
			}
			catch (Exception x)
			{
				var error = x.Message.Replace("\r\n", "\n").Replace("\n", " ");
				Warning(string.Format("Failed to read database schema - {0}", error));
				WriteLine("");
				WriteLine("// -----------------------------------------------------------------------------------------");
				WriteLine("// Failed to read database schema - {0}", error);
				WriteLine("// -----------------------------------------------------------------------------------------");
				WriteLine("");
				return new Tables();
			}


		}

		abstract class SchemaReader
		{
			public abstract Tables ReadSchema(DbConnection connection, DbProviderFactory factory);
			public GeneratedTextTransformation outer;
			public void WriteLine(string o)
			{
				outer.WriteLine(o);
			}

		}

		class SqlServerSchemaReader : SchemaReader
		{
			// SchemaReader.ReadSchema
			public override Tables ReadSchema(DbConnection connection, DbProviderFactory factory)
			{
				var result = new Tables();

				_connection = connection;
				_factory = factory;

				var cmd = _factory.CreateCommand();
				cmd.Connection = connection;
				// *** Changed to Construct Sql function
				cmd.CommandText = ConstructTableSelectSql();
				// ***

				//pull the tables in a reader
				using (cmd)
				{

					using (var rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							Table tbl = new Table();
							tbl.Name = rdr["TABLE_NAME"].ToString();
							tbl.Schema = rdr["TABLE_SCHEMA"].ToString();
							//tbl.IsView=string.Compare(rdr["TABLE_TYPE"].ToString(), "View", true)==0;
							tbl.CleanName = CleanUp(tbl.Name);
							tbl.ClassName = Inflector.MakeSingular(tbl.CleanName);
							if (tbl.Name.EndsWith("Enum"))
							{
								tbl.EnumName = tbl.ClassName;
								tbl.IsEnum = true;
								tbl.ClassName += "Poco";
							}
							else
							{
								tbl.EnumName = null;
								tbl.IsEnum = false;
							}
							tbl.RepoName = tbl.ClassName + "Db";
							result.Add(tbl);
						}
					}
				}

				foreach (var tbl in result)
				{
					tbl.Columns = LoadColumns(tbl);

					// Mark the primary key(s)
					string[] pkNames = GetPK(tbl.Name);
					if (pkNames != null)
					{
						var pkCols = tbl.Columns.Where(a => pkNames.Contains(a.Name));
						foreach (var c in pkCols)
						{
							c.IsPK = true;
						}
					}
				}


				return result;
			}

			DbConnection _connection;
			DbProviderFactory _factory;


			List<Column> LoadColumns(Table tbl)
			{

				using (var cmd = _factory.CreateCommand())
				{
					cmd.Connection = _connection;
					cmd.CommandText = COLUMN_SQL;

					var p = cmd.CreateParameter();
					p.ParameterName = "@tableName";
					p.Value = tbl.Name;
					cmd.Parameters.Add(p);

					p = cmd.CreateParameter();
					p.ParameterName = "@schemaName";
					p.Value = tbl.Schema;
					cmd.Parameters.Add(p);

					var result = new List<Column>();
					using (IDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							Column col = new Column();
							col.Name = rdr["ColumnName"].ToString();
							col.PropertyName = CleanUp(col.Name);
							col.PropertyType = GetPropertyType(rdr["DataType"].ToString());
							Int32.TryParse(rdr["MaxLength"].ToString(), out col.StringLength);
							col.IsNullable = rdr["IsNullable"].ToString() == "YES";
							col.IsAutoIncrement = ((int)rdr["IsIdentity"]) == 1;
							result.Add(col);
						}
					}

					return result;
				}
			}

			string[] GetPK(string table)
			{

				string sql = @"SELECT c.name AS ColumnName
				FROM sys.indexes AS i 
				INNER JOIN sys.index_columns AS ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id 
				INNER JOIN sys.objects AS o ON i.object_id = o.object_id 
				LEFT OUTER JOIN sys.columns AS c ON ic.object_id = c.object_id AND c.column_id = ic.column_id
				WHERE (i.type = 1) AND (o.name = @tableName)";

				using (var cmd = _factory.CreateCommand())
				{
					cmd.Connection = _connection;
					cmd.CommandText = sql;

					var p = cmd.CreateParameter();
					p.ParameterName = "@tableName";
					p.Value = table;
					cmd.Parameters.Add(p);

					var pkColNames = new List<string>();
					using (IDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							pkColNames.Add(rdr["ColumnName"].ToString());
						}
					}

					if (!pkColNames.Any()) return null;

					return pkColNames.ToArray();
				}
			}

			string GetPropertyType(string sqlType)
			{
				string sysType = "string";
				switch (sqlType)
				{
					case "bigint":
						sysType = "long";
						break;
					case "smallint":
						sysType = "short";
						break;
					case "int":
						sysType = "int";
						break;
					case "uniqueidentifier":
						sysType = "Guid";
						break;
					case "smalldatetime":
					case "datetime":
					case "date":
					case "time":
						sysType = "DateTime";
						break;
					case "float":
						sysType = "double";
						break;
					case "real":
						sysType = "float";
						break;
					case "numeric":
					case "smallmoney":
					case "decimal":
					case "money":
						sysType = "decimal";
						break;
					case "tinyint":
						sysType = "byte";
						break;
					case "bit":
						sysType = "bool";
						break;
					case "image":
					case "binary":
					case "varbinary":
					case "timestamp":
						sysType = "byte[]";
						break;
					case "geography":
						sysType = "Microsoft.SqlServer.Types.SqlGeography";
						break;
					case "geometry":
						sysType = "Microsoft.SqlServer.Types.SqlGeometry";
						break;
				}
				return sysType;
			}


			// *** Moved Table_Sql definition to top for insertion of custom select SQL ****
			//	const string TABLE_SQL = @"SELECT *
			//		FROM  INFORMATION_SCHEMA.TABLES
			//		WHERE TABLE_TYPE='BASE TABLE'";
			// ***

			const string COLUMN_SQL = @"SELECT 
				TABLE_CATALOG AS [Database],
				TABLE_SCHEMA AS Owner, 
				TABLE_NAME AS TableName, 
				COLUMN_NAME AS ColumnName, 
				ORDINAL_POSITION AS OrdinalPosition, 
				COLUMN_DEFAULT AS DefaultSetting, 
				IS_NULLABLE AS IsNullable, DATA_TYPE AS DataType, 
				CHARACTER_MAXIMUM_LENGTH AS MaxLength, 
				DATETIME_PRECISION AS DatePrecision,
				COLUMNPROPERTY(object_id('[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']'), COLUMN_NAME, 'IsIdentity') AS IsIdentity,
				COLUMNPROPERTY(object_id('[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']'), COLUMN_NAME, 'IsComputed') as IsComputed
				FROM  INFORMATION_SCHEMA.COLUMNS
				WHERE TABLE_NAME=@tableName
				ORDER BY OrdinalPosition ASC";

		}

		private static string TableSelectSql() =>
			@"SELECT *
			FROM  INFORMATION_SCHEMA.TABLES
			WHERE (TABLE_NAME <> 'sysdiagrams')
			ORDER BY TABLE_TYPE, TABLE_NAME";




	}
}
