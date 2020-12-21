using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class GeneraEnumPocoDb : Repositories.Core.IKeyedRepository<int, GeneraEnumPoco>	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(GeneraEnumPoco entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(GeneraEnumPoco entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<GeneraEnumPoco>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<GeneraEnumPoco>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<GeneraEnumPoco>(id);
			return true;
		}


		public GeneraEnumPoco FindBy(int id)
		{
			return db.SingleOrDefaultById<GeneraEnumPoco>(id);
		}

		public IEnumerable<GeneraEnumPoco> All()
		{
			return db.Fetch<GeneraEnumPoco>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [GeneraEnum]");
		}
	}
}	
	
