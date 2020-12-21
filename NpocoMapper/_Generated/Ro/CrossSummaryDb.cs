using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class CrossSummaryDb : RepositoryBase
	{
		public CrossSummary FindById(int crossId)
		{
			return db.SingleOrDefault<CrossSummary>("WHERE (CrossId = @0);", crossId);
		}


		public IEnumerable<CrossSummary> All()
		{
			return db.Fetch<CrossSummary>(" ");
		}

		//Example - filtered list:
		public IEnumerable<CrossSummary> FilteredList(string str1, string str2)
		{
			return db.Fetch<CrossSummary>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<CrossSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<CrossSummary>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}
