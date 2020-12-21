using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class PlantStatusDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(PlantStatus entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(PlantStatus entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<PlantStatus>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PlantStatus>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<PlantStatus>(id);
			return true;
		}


		public PlantStatus FindBy(int id)
		{
			return db.SingleOrDefaultById<PlantStatus>(id);
		}

		public IEnumerable<PlantStatus> All()
		{
			return db.Fetch<PlantStatus>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [PlantStatus]");
		}
	}
}	
	
