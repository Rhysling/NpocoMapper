using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator2.Models;

namespace Crosserator2.Repositories
{ 
	public class PollenCountDb
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public IEnumerable<PollenCount> All()
		{
			return db.Fetch<PollenCount>(" ");
		}

		//Example - filtered list:
		public IEnumerable<PollenCount> FilteredList(string str1, string str2)
		{
			return db.Fetch<PollenCount>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<PollenCount> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<PollenCount>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
