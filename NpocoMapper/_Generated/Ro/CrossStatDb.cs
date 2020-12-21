using System.Collections.Generic;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class CrossStatDb : RepositoryBase
	{
		public List<CrossStat> FindForUserId(int userId)
		{
			return db.Fetch<CrossStat>("WHERE (UserId = @0);", userId);
		}


		public List<CrossStat> All()
		{
			return db.Fetch<CrossStat>(" ");
		}

		//Example - filtered list:
		public IEnumerable<CrossStat> FilteredList(string str1, string str2)
		{
			return db.Fetch<CrossStat>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		//Example - paged & filtered list:
		public Page<CrossStat> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<CrossStat>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		// More methods here ***
	}
}
