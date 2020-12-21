using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class CrossCountDb
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public IEnumerable<CrossCount> All()
		{
			return db.Fetch<CrossCount>(" ");
		}

		//Example - filtered list:
		public IEnumerable<CrossCount> FilteredList(string str1, string str2)
		{
			return db.Fetch<CrossCount>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<CrossCount> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<CrossCount>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
