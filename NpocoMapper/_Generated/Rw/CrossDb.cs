using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class CrossDb : RepositoryBase
	{
		public bool IsUniqueCrossNumber(int userId, int crossId, int crossNumberYear, int crossNumber)
		{
			string sql = @"
				SELECT COUNT(1)
				FROM Crosses c
				INNER JOIN Plants sp
				ON (c.SeedPlantId = sp.PlantId)
				WHERE (c.CrossId <> @0) AND (sp.UserId = @1) AND (c.CrossNumberYear = @2) AND (c.CrossNumber = @3) AND (c.IsDeleted = 0)";

			var count = db.ExecuteScalar<int>(sql, crossId, userId, crossNumberYear, crossNumber);
			return count == 0;
		}

		public int GetNextCrossNumForYear(int crossNumberYear, int userId)
		{
			string sql = @"
				SELECT isnull(MAX(CrossNumber), 0)
				FROM Crosses c
				INNER JOIN Plants p
				ON (c.SeedPlantId = p.PlantId)
				WHERE (c.CrossNumberYear = @0) AND (p.UserId = @1) AND (c.IsDeleted = 0)";

			return db.ExecuteScalar<int>(sql, crossNumberYear, userId) + 1;
		}


		// CRUD

		public int Save(Cross entity)
		{
			db.Save<Cross>(entity);
			return entity.CrossId;
		}

		public bool Save(IEnumerable<Cross> items)
		{
			foreach (Cross item in items)
			{
				db.Save<Cross>(item);
			}
			return true;
		}

		public bool Delete(int crossId)
		{
			string sql = "UPDATE Crosses SET IsDeleted = 1 WHERE (CrossId = @0);";

			db.Execute(sql, crossId);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Cross>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Cross>(id);
			return true;
		}


		public Cross FindBy(int id)
		{
			return db.SingleOrDefaultById<Cross>(id);
		}

		public IEnumerable<Cross> All()
		{
			return db.Fetch<Cross>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(CrossId) FROM Crosses; ";
			sql += "DBCC CHECKIDENT ('Crosses', RESEED, @@MaxId) WITH NO_INFOMSGS;";

			db.Execute(sql);
		}

	}
}

