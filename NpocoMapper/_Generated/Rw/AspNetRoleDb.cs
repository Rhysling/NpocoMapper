

using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class AspNetRoleDb : Repositories.Core.IIdentityRepository<AspNetRole>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(AspNetRole entity)
		{
			db.Save<AspNetRole>(entity);
			return entity.Id;
		}

		public bool Save(IEnumerable<AspNetRole> items)
		{
			foreach (AspNetRole item in items)
			{
				db.Save<AspNetRole>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<AspNetRole>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<AspNetRole>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<AspNetRole>(id);
			return true;
		}


		public AspNetRole FindBy(int id)
		{
			return db.SingleOrDefaultById<AspNetRole>(id);
		}

		public IEnumerable<AspNetRole> All()
		{
			return db.Fetch<AspNetRole>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(Id) FROM AspNetRoles; ";
			sql += "DBCC CHECKIDENT ('AspNetRoles', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

