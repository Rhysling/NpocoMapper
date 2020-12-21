using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;

namespace Crosserator.Repositories
{ 
	public class CrossListSummaryDb
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public IEnumerable<CrossListSummary> All()
		{
			return db.Fetch<CrossListSummary>(" ");
		}

		//Example - filtered list:
		public IEnumerable<CrossListSummary> FilteredList(string str1, string str2)
		{
			return db.Fetch<CrossListSummary>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<CrossListSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<CrossListSummary>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
