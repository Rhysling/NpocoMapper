using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class Plants_OrigDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(Plants_Orig entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(Plants_Orig entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Plants_Orig>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plants_Orig>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plants_Orig>(id);
			return true;
		}


		public Plants_Orig FindBy(int id)
		{
			return db.SingleOrDefaultById<Plants_Orig>(id);
		}

		public IEnumerable<Plants_Orig> All()
		{
			return db.Fetch<Plants_Orig>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [Plants_Orig]");
		}
	}
}	
	
