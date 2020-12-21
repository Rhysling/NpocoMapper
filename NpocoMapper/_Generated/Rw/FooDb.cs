using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class FooDb : Repositories.Core.IIdentityRepository<Foo>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(Foo entity)
		{
			db.Save<Foo>(entity);
			return entity.Id;
		}

		public bool Save(IEnumerable<Foo> items)
		{
			foreach (Foo item in items)
			{
				db.Save<Foo>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Foo>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Foo>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Foo>(id);
			return true;
		}


		public Foo FindBy(int id)
		{
			return db.SingleOrDefaultById<Foo>(id);
		}

		public IEnumerable<Foo> All()
		{
			return db.Fetch<Foo>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(Id) FROM Foo; ";
			sql += "DBCC CHECKIDENT ('Foo', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

