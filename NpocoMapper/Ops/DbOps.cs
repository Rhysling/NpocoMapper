using NpocoMapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NpocoMapper.Ops
{
	public static class DbOps
	{
		public static List<Column> LoadColumns(string connString)
		{
			var cols = new List<Column>();

			using (var conn = new SqlConnection(connString))
			using (var cmd = new SqlCommand(COLUMN_SQL, conn))
			{
				conn.Open();
				var rdr = cmd.ExecuteReader();

				// Call Read before accessing data.
				while (rdr.Read())
				{
					Column col = new Column();

					col.EntityName = rdr["EntityName"].ToString();
					col.EntityType = rdr["EntityType"].ToString();
					col.ColumnSeq = int.Parse(rdr["ColumnSeq"].ToString());
					col.ColumnName = rdr["ColumnName"].ToString();
					col.SqlDataType = rdr["SqlDataType"].ToString();
					col.IsNullable = rdr["IsNullable"].ToString() == "True";
					col.MaxLength = int.Parse(rdr["MaxLength"].ToString());
					col.Precision = int.Parse(rdr["Precision"].ToString());
					col.IsPk = rdr["IsPk"].ToString() == "True";
					col.ConstraintName = rdr["ConstraintName"].ToString();
					col.IsIdentity = rdr["IsIdentity"].ToString() == "True";
					col.IsComputed = rdr["IsComputed"].ToString() == "True";

					cols.Add(col);
				}
			}

			return cols;
		}

		public static List<EnumPocoProp> LoadEnumValus(string connString, EnumPoco enumPoco)
		{
			var vals = new List<EnumPocoProp>();

			string sql = $@"
				SELECT
					[{enumPoco.IdColumnName}],
					[{enumPoco.NameColumnName}],
					[{enumPoco.DescriptionColumnName}]
				FROM
					[{enumPoco.EntityName}]
				ORDER BY
					[{enumPoco.IdColumnName}];";

			using (var conn = new SqlConnection(connString))
			using (var cmd = new SqlCommand(sql, conn))
			{
				conn.Open();
				var rdr = cmd.ExecuteReader();

				// Call Read before accessing data.
				while (rdr.Read())
				{
					var val = new EnumPocoProp();

					val.Id = int.Parse(rdr[enumPoco.IdColumnName].ToString());
					val.Name = UtilNameTransform.CleanName(rdr[enumPoco.NameColumnName].ToString());
					val.Description = rdr[enumPoco.DescriptionColumnName].ToString();

					vals.Add(val);
				}
			}

			return vals;
		}


		private const string COLUMN_SQL = @"
			SELECT
				object_name(c.object_id) as EntityName,

				CASE
					WHEN (t.object_id IS NOT NULL) AND (v.object_id IS NULL) THEN 'Table'
					WHEN (t.object_id IS NULL) AND (v.object_id IS NOT NULL) THEN 'View'
					ELSE 'Unknown'
				END AS EntityType,

				c.column_id AS ColumnSeq,
				c.[name] as ColumnName,
				type_name(user_type_id) as SqlDataType,
				c.is_nullable AS IsNullable,
				c.[max_length] AS MaxLength,
				c.[precision] AS [Precision],

				CAST(CASE
					WHEN (kt.ConstraintName IS NOT NULL) THEN 1
					ELSE 0
				END AS bit) AS IsPk,

				kt.ConstraintName,

				CAST(COLUMNPROPERTY(c.object_id, c.[name], 'IsIdentity') AS bit) AS IsIdentity,
				CAST(COLUMNPROPERTY(c.object_id, c.[name], 'IsComputed') AS bit) as IsComputed

			FROM
				[sys].[columns] c

				LEFT OUTER JOIN [sys].[views] v 
				ON (c.object_id = v.object_id)

				LEFT OUTER JOIN [sys].[tables] t 
				ON (c.object_id = t.object_id)

				LEFT OUTER JOIN
				(
					SELECT 
						K.TABLE_NAME AS TableName,
						K.COLUMN_NAME AS ColumnName,
						K.CONSTRAINT_NAME AS ConstraintName
					FROM
						INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C

						JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K
						ON C.TABLE_NAME = K.TABLE_NAME
							AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG
							AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA
							AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME

					WHERE
						C.CONSTRAINT_TYPE = 'PRIMARY KEY'
				) kt
				ON (object_name(c.object_id) = kt.TableName) AND (c.[name] = kt.ColumnName)

			WHERE
				CASE
					WHEN (t.object_id IS NOT NULL) AND (v.object_id IS NULL) THEN 'Table'
					WHEN (t.object_id IS NULL) AND (v.object_id IS NOT NULL) THEN 'View'
					ELSE 'Unknown'
				END <> 'Unknown'

			ORDER BY
				EntityType,
				EntityName,
				ColumnSeq;";

	}
}
