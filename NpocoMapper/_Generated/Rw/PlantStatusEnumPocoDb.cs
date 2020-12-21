using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class PlantStatusEnumPocoDb : Repositories.Core.IKeyedRepository<int, PlantStatusEnumPoco>	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(PlantStatusEnumPoco entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(PlantStatusEnumPoco entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<PlantStatusEnumPoco>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PlantStatusEnumPoco>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<PlantStatusEnumPoco>(id);
			return true;
		}


		public PlantStatusEnumPoco FindBy(int id)
		{
			return db.SingleOrDefaultById<PlantStatusEnumPoco>(id);
		}

		public IEnumerable<PlantStatusEnumPoco> All()
		{
			return db.Fetch<PlantStatusEnumPoco>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [PlantStatusEnum]");
		}
	}
}	
	
