using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class PlantPictureDb : RepositoryBase, IIdentityRepository<PlantPicture>
	{
		// Custom Selects

		public int[] GetPictureIdsForPlantId(int plantId)
		{
			return db.Fetch<int>("SELECT [Id] FROM [PlantPictures] WHERE (PlantId = @0) AND (IsDeleted = 0) ORDER BY Id;", plantId).ToArray();
		}


		// CRUD

		public int Save(PlantPicture item)
		{
			db.Execute("DELETE FROM PlantPictures WHERE ((Id = @Id) AND (PlantId = @PlantId));", item);

			db.Save<PlantPicture>(item);
			return item.Id;
		}

		public bool Save(IEnumerable<PlantPicture> items)
		{
			foreach (PlantPicture item in items)
			{
				db.Save<PlantPicture>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Execute("UPDATE PlantPictures SET IsDeleted = 1 WHERE (Id = @0);", id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PlantPicture>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<PlantPicture>(id);
			return true;
		}


		public PlantPicture FindBy(int id)
		{
			return db.SingleOrDefaultById<PlantPicture>(id);
		}

		public IEnumerable<PlantPicture> All()
		{
			return db.Fetch<PlantPicture>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(Id) FROM PlantPictures; ";
			sql += "DBCC CHECKIDENT ('PlantPictures', RESEED, @@MaxId) WITH NO_INFOMSGS;";

			db.Execute(sql);
		}

	}
}

