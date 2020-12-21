using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class FooViewDb
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public IEnumerable<FooView> All()
		{
			return db.Fetch<FooView>(" ");
		}

		//Example - filtered list:
		public IEnumerable<FooView> FilteredList(string str1, string str2)
		{
			return db.Fetch<FooView>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<FooView> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<FooView>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
