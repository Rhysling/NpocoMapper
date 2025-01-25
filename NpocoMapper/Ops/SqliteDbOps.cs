using Microsoft.Data.Sqlite;
using NpocoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NpocoMapper.Ops;

public class SqliteDbOps(string connString) : IDbOps
{
	public List<Column> LoadColumns()
	{
		var cols = new List<Column>();
		var slObjs = new List<SqliteObj>();
		//var slObjCols = new List<SqliteObjCol>();

		using var connection = new SqliteConnection(connString);
		connection.Open();

		var command = connection.CreateCommand();
		command.CommandText =
		@"
			SELECT
				type,
				name
				--sql
			FROM sqlite_schema
			WHERE
				(name <> 'sqlite_sequence')
				AND (type IN ('table', 'view'))
			ORDER BY
				type,
				name;
			";

		using (var reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				slObjs.Add(new SqliteObj
				{
					Type = reader.GetString(0),
					Name = reader.GetString(1)
				});
			}
		}


		foreach (var o in slObjs)
		{
			command.CommandText = $"PRAGMA table_info('{o.Name}')";
				using (var rdr = command.ExecuteReader())
				{
					while (rdr.Read())
					{
						cols.Add(new Column
						{
							EntityName = o.Name,
							EntityType = o.Type,
							ColumnSeq = rdr.GetInt32(0),
							ColumnName = rdr.GetString(1),
							SqlDataType = rdr.GetString(2),
							IsNullable = !rdr.GetBoolean(3),
							MaxLength = 0,
							Precision = 0,
							IsPk = rdr.GetInt32(5) > 0,
							ConstraintName = "",
							IsIdentity = false,
							IsComputed = false
							//DefaultValue = !rdr.IsDBNull(4) ? rdr.GetString(4) : null,
						});
					}
				}
		}

		var pkNames = new List<string>();

		command.CommandText = "SELECT * FROM SQLITE_SEQUENCE";
		using (var reader = command.ExecuteReader())
		{
			while (reader.Read())
			{
				pkNames.Add(reader.GetString(0));
			}
		}

		var autoIncCols = cols.Where(a => pkNames.Contains(a.EntityName) && a.IsPk).ToList();

		foreach (var c in autoIncCols)
		{
			c.IsIdentity = true;
		}

		SqliteConnection.ClearAllPools();

		return cols;
	}

	public List<EnumPocoProp> LoadEnumValus(EnumPoco enumPoco)
	{
		throw new NotImplementedException();
	}
}
