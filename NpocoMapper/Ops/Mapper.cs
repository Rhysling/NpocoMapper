using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpocoMapper.Models;
using static NpocoMapper.Ops.UtilNameTransform;

namespace NpocoMapper.Ops
{
	public static class Mapper
	{
		public static List<Poco> MapColumnsToPocos (List<Column> cols)
		{
			foreach (var c in cols)
				c.EntityType = MakeInitialCaps(c.EntityType, lowerRest: false);

			var pocos = cols.GroupBy(a => a.EntityName + "|" + a.EntityType, mapColToPocoProp, mapKeyPropsToPoco).ToList();
			//TODO - set other poco values


			return pocos;


			PocoProp mapColToPocoProp(Column col)
			{
				return new PocoProp
				{
					PropName = col.ColumnName,
					PropType = MapSqlTypeToPocoPropType(col.SqlDataType),
					//TsType = MapSqlTypeToTsType(col.SqlDataType),
					IsNullable = col.IsNullable,
					IsPk = col.IsPk,
					IsIdentity = col.IsIdentity,
					Seq = col.ColumnSeq,
					Ignore = false
				};
			}

			Poco mapKeyPropsToPoco(string key, IEnumerable<PocoProp> props)
			{
				var s = key.Split('|');

				return new Poco {
				EntityName = s[0],
				EntityType = s[1],
				ClassName = MakeInitialCaps(MakeSingular(CleanName(s[0])), lowerRest: false),
				ClassType = MapClassType(s[0], s[1], props),
				PrimaryKeys = string.Join(',', props.Where(a => a.IsPk).Select(a => a.PropName)),
				IsAutoIncrement = props.First().IsIdentity,
				Ignore = false,
				Props = props.OrderBy(a => a.Seq).ToList()
				};
			}

		}

		private static string MapClassType(string entityName, string entityType, IEnumerable<PocoProp> props)
		{
			if (entityName.EndsWith("Enum"))
				return "Enum";

			if (entityType == "Table" && props.Any(a => a.IsPk))
				return "Rw";

			return "Ro";
		}

		private static string MapSqlTypeToPocoPropType(string sqlType)
		{
			return sqlType switch
			{
				"bigint" => "long",
				"smallint" => "short",

				string a when a.Contains("int", StringComparison.CurrentCultureIgnoreCase) => "int",

				"uniqueidentifier" => "Guid",

				"smalldatetime" => "DateTime",
				"datetime" => "DateTime",
				"date" => "DateTime",
				"time" => "DateTime",

				string a when a.Contains("float", StringComparison.CurrentCultureIgnoreCase) => "double",
				string a when a.Contains("real", StringComparison.CurrentCultureIgnoreCase) => "double",
				string a when a.Contains("doub", StringComparison.CurrentCultureIgnoreCase) => "double",

				"numeric" => "decimal",
				"smallmoney" => "decimal",
				"decimal" => "decimal",
				"money" => "decimal",

				"tinyint" => "byte",
				"bit" => "bool",
				string a when a.Contains("bool", StringComparison.CurrentCultureIgnoreCase) => "bool",

				"image" => "byte[]",
				"timestamp" => "byte[]",
				string a when a.Contains("binary", StringComparison.CurrentCultureIgnoreCase) => "byte[]",
				string a when a.Contains("blob", StringComparison.CurrentCultureIgnoreCase) => "byte[]",

				//"geography" => "Microsoft.SqlServer.Types.SqlGeography",
				//"geometry" => "Microsoft.SqlServer.Types.SqlGeometry",

				_ => "string"
			};
		}

		// Better to handle Ts in app
		//private static string MapSqlTypeToTsType(string sqlType)
		//{
		//	return sqlType switch
		//	{
		//		"bigint" => "any",
		//		"smallint" => "number",
		//		"int" => "number",
		//		"uniqueidentifier" => "any",

		//		"smalldatetime" => "any",
		//		"datetime" => "any",
		//		"date" => "any",
		//		"time" => "any",

		//		"float" => "number",
		//		"real" => "number",

		//		"numeric" => "number",
		//		"smallmoney" => "number",
		//		"decimal" => "number",
		//		"money" => "number",

		//		"tinyint" => "number",
		//		"bit" => "boolean",

		//		"image" => "number[]",
		//		"binary" => "number[]",
		//		"varbinary" => "number[]",
		//		"timestamp" => "number[]",

		//		//"geography" => "Microsoft.SqlServer.Types.SqlGeography",
		//		//"geometry" => "Microsoft.SqlServer.Types.SqlGeometry",

		//		_ => "string"
		//	};
		//}

	}
}
