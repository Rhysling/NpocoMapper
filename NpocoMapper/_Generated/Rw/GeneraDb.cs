using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class GeneraDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) {
			//Mapper = new Core.CustomTypeMapper()
		};

		// Alternate Return Types

		public List<SelectListItem> GetSL(string zeroItemText, string negOneItemText)
		{
			var lst = db.Fetch<Genera>("ORDER BY GenusId");
			var sl = lst.Select(a => new System.Web.Mvc.SelectListItem { Value = a.GenusId.ToString(), Text = a.GenusName }).ToList();

			if (!String.IsNullOrWhiteSpace(zeroItemText)) sl.Insert(0, new SelectListItem{ Value = "0", Text = zeroItemText });
			if (!String.IsNullOrWhiteSpace(negOneItemText)) sl.Insert(0, new SelectListItem { Value = "-1", Text = negOneItemText });

			return sl;
		}


		// CRUD

		public bool Insert(Genera entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(Genera entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Genera>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Genera>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Genera>(id);
			return true;
		}


		public Genera FindBy(int id)
		{
			return db.SingleOrDefaultById<Genera>(id);
		}

		public IEnumerable<Genera> All()
		{
			return db.Fetch<Genera>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [Genera]");
		}
	}
}	
	
