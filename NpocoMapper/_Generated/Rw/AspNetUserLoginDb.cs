using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class AspNetUserLoginDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(AspNetUserLogin entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(AspNetUserLogin entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(string id)
		{
			db.Delete<AspNetUserLogin>((object)id);
			return true;
		}

		public bool Delete(IEnumerable<string> ids)
		{
			foreach (string id in ids)
			{
				db.Delete<AspNetUserLogin>(id);
			}
			return true;
		}

		public bool Destroy(string id)
		{
			db.Delete<AspNetUserLogin>((object)id);
			return true;
		}


		public AspNetUserLogin FindBy(string id)
		{
			return db.SingleOrDefaultById<AspNetUserLogin>((object)id);
		}

		public IEnumerable<AspNetUserLogin> All()
		{
			return db.Fetch<AspNetUserLogin>(" ");
		}

		public string MaxId()
		{
			return db.Single<string>("SELECT MAX(Id) FROM [AspNetUserLogins]");
		}
	}
}	
	
