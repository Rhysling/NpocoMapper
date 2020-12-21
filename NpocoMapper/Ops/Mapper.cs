using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpocoMapper.Models;
using static NpocoMapper.UtilNameTransform;

namespace NpocoMapper.Ops
{
	public static class Mapper
	{
		public static List<Poco> MapColumnsToPocos (List<Column> cols)
		{

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
				ClassName = MakeSingular(CleanName(s[0])),
				ClassType = MapClassType(s[0], s[1], props),
				PrimaryKeys = string.Join(',', props.Where(a => a.IsPk).Select(a => a.PropName)),
				IsAutoIncrement = props.First().IsIdentity,
				Ignore = false,
				Props = props.OrderBy(a => a.Seq).ToList()
				};
			}

		}

		public static List<EnumPoco> MapPocosToEnums(List<Poco> pocos, List<EnumPoco> forceEnumList, string connString)
		{
			var epl = pocos.Where(a => a.ClassType == "Enum")
				.Select(a => new EnumPoco {
					EntityName = a.EntityName,
					EnumName = a.ClassName
				}).ToList();

			// TODO: Handle forceEnumList

			foreach (var e in epl)
				e.Values = DbOps.LoadEnumValus(connString, e);

			return epl;
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
				"int" => "int",
				"uniqueidentifier" => "Guid",

				"smalldatetime" => "DateTime",
				"datetime" => "DateTime",
				"date" => "DateTime",
				"time" => "DateTime",

				"float" => "double",
				"real" => "float",

				"numeric" => "decimal",
				"smallmoney" => "decimal",
				"decimal" => "decimal",
				"money" => "decimal",

				"tinyint" => "byte",
				"bit" => "bool",

				"image" => "byte[]",
				"binary" => "byte[]",
				"varbinary" => "byte[]",
				"timestamp" => "byte[]",

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
