using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class PlantDb : RepositoryBase
	{
		// Scalars

		public bool IsUniquePlantName(int plantId, int userId, string proposedName)
		{
			var count = db.ExecuteScalar<int>("SELECT COUNT(1) FROM Plants WHERE ((PlantId <> @0) AND (UserId = @1) AND (PlantName = @2) AND (IsDeleted = 0))", plantId, userId, proposedName.Trim());
			return count == 0;
		}

		public string GetName(int plantId)
		{
			return db.ExecuteScalar<string>("SELECT PlantName FROM Plants WHERE (PlantId = @0)", plantId);
		}

		// Lists

		public List<Models.Core.NameValueItem> AllIdsNamesForGenus(int genusId, int userId)
		{
			string sql = "SELECT CAST(PlantId AS varchar(50)) AS [Value], PlantName AS Name FROM Plants WHERE ((GenusId = @0) AND (UserId = @1) AND (IsDeleted = 0)) ORDER BY PlantName";
			return db.Fetch<Models.Core.NameValueItem>(sql, genusId, userId);
		}

		public List<Models.Core.NameValueItem> AllIdsNames()
		{
			string sql = "SELECT CAST(PlantId AS varchar(50)) AS [Value], PlantName AS Name FROM Plants WHERE (IsDeleted = 0) ORDER BY PlantName";
			return db.Fetch<Models.Core.NameValueItem>(sql);
		}




		// CRUD

		public int Save(Plant entity)
		{
			db.Save<Plant>(entity);
			return entity.PlantId;
		}

		public bool Save(IEnumerable<Plant> items)
		{
			foreach (Plant item in items)
			{
				db.Save<Plant>(item);
			}
			return true;
		}

		public bool Delete(int plantId)
		{
			string sql = "UPDATE Plants SET IsDeleted = 1 WHERE (PlantId = @0);";

			db.Execute(sql, plantId);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plant>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}


		public Plant FindBy(int id)
		{
			return db.SingleOrDefaultById<Plant>(id);
		}

		public IEnumerable<Plant> All()
		{
			return db.Fetch<Plant>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(PlantId) FROM Plants; ";
			sql += "DBCC CHECKIDENT ('Plants', RESEED, @@MaxId) WITH NO_INFOMSGS;";

			db.Execute(sql);
		}

	}
}

