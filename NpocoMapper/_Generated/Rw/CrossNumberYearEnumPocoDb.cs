using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class CrossNumberYearEnumPocoDb : Repositories.Core.IKeyedRepository<int, CrossNumberYearEnumPoco>	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(CrossNumberYearEnumPoco entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(CrossNumberYearEnumPoco entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<CrossNumberYearEnumPoco>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<CrossNumberYearEnumPoco>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<CrossNumberYearEnumPoco>(id);
			return true;
		}


		public CrossNumberYearEnumPoco FindBy(int id)
		{
			return db.SingleOrDefaultById<CrossNumberYearEnumPoco>(id);
		}

		public IEnumerable<CrossNumberYearEnumPoco> All()
		{
			return db.Fetch<CrossNumberYearEnumPoco>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [CrossNumberYearEnum]");
		}
	}
}	
	
