using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class AspNetUserClaimDb : Repositories.Core.IIdentityRepository<AspNetUserClaim>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(AspNetUserClaim entity)
		{
			db.Save<AspNetUserClaim>(entity);
			return entity.Id;
		}

		public bool Save(IEnumerable<AspNetUserClaim> items)
		{
			foreach (AspNetUserClaim item in items)
			{
				db.Save<AspNetUserClaim>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<AspNetUserClaim>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<AspNetUserClaim>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<AspNetUserClaim>(id);
			return true;
		}


		public AspNetUserClaim FindBy(int id)
		{
			return db.SingleOrDefaultById<AspNetUserClaim>(id);
		}

		public IEnumerable<AspNetUserClaim> All()
		{
			return db.Fetch<AspNetUserClaim>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(Id) FROM AspNetUserClaims; ";
			sql += "DBCC CHECKIDENT ('AspNetUserClaims', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

