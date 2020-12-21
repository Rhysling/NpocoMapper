using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class AspNetUserRoleDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(AspNetUserRole entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(AspNetUserRole entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<AspNetUserRole>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<AspNetUserRole>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<AspNetUserRole>(id);
			return true;
		}


		public AspNetUserRole FindBy(int id)
		{
			return db.SingleOrDefaultById<AspNetUserRole>(id);
		}

		public IEnumerable<AspNetUserRole> All()
		{
			return db.Fetch<AspNetUserRole>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [AspNetUserRoles]");
		}
	}
}	
	
