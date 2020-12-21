using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class PlantFormEnumPocoDb : Repositories.Core.IKeyedRepository<int, PlantFormEnumPoco>	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(PlantFormEnumPoco entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(PlantFormEnumPoco entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<PlantFormEnumPoco>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PlantFormEnumPoco>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<PlantFormEnumPoco>(id);
			return true;
		}


		public PlantFormEnumPoco FindBy(int id)
		{
			return db.SingleOrDefaultById<PlantFormEnumPoco>(id);
		}

		public IEnumerable<PlantFormEnumPoco> All()
		{
			return db.Fetch<PlantFormEnumPoco>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [PlantFormEnum]");
		}
	}
}	
	
