using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class AspNetUserDb : Repositories.Core.IIdentityRepository<AspNetUser>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(AspNetUser entity)
		{
			db.Save<AspNetUser>(entity);
			return entity.Id;
		}

		public bool Save(IEnumerable<AspNetUser> items)
		{
			foreach (AspNetUser item in items)
			{
				db.Save<AspNetUser>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<AspNetUser>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<AspNetUser>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<AspNetUser>(id);
			return true;
		}


		public AspNetUser FindBy(int id)
		{
			return db.SingleOrDefaultById<AspNetUser>(id);
		}

		public IEnumerable<AspNetUser> All()
		{
			return db.Fetch<AspNetUser>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(Id) FROM AspNetUsers; ";
			sql += "DBCC CHECKIDENT ('AspNetUsers', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

