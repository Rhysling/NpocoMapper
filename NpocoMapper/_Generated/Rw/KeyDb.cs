using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{
	public class KeyDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008);


		// Plant Filter

		public Models.Core.PlantListFilter GetPlantListFilter()
		{
			return JsonConvert.DeserializeObject<Models.Core.PlantListFilter>(db.ExecuteScalar<string>("SELECT [Value] FROM [dbo].[Keys] WHERE KeyId = 'FilterPlantList';"));
		}
		public void SavePlantListFilter(Models.Core.PlantListFilter filter)
		{
			var k = new Key
			{
				KeyId = "FilterPlantList",
				Value = JsonConvert.SerializeObject(filter)
			};
			Update(k);
		}


		// CRUD

		public bool Insert(Key entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(Key entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(string id)
		{
			db.Delete<Key>((object)id);
			return true;
		}

		public bool Delete(IEnumerable<string> ids)
		{
			foreach (string id in ids)
			{
				db.Delete<Key>(id);
			}
			return true;
		}

		public bool Destroy(string id)
		{
			db.Delete<Key>((object)id);
			return true;
		}


		public Key FindBy(string id)
		{
			return db.SingleOrDefaultById<Key>((object)id);
		}

		public IEnumerable<Key> All()
		{
			return db.Fetch<Key>(" ");
		}

		public string MaxId()
		{
			return db.Single<string>("SELECT MAX(Id) FROM [Keys]");
		}
	}
}	
	
