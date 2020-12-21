using System.Collections.Generic;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class SeedCrossBriefDb : RepositoryBase
	{
		public SeedCrossBrief FindById(int crossId)
		{
			return db.SingleOrDefault<SeedCrossBrief>("WHERE (CrossId = @0);", crossId);
		}


		public List<SeedCrossBrief> ForCrossYear(int userId, int crossYear)
		{
			return db.Fetch<SeedCrossBrief>("WHERE (UserId = @0) AND (CrossNumberYear = @1) ORDER BY CrossNumber DESC;", userId, crossYear);
		}

		//Example - filtered list:
		public IEnumerable<SeedCrossBrief> FilteredList(string str1, string str2)
		{
			return db.Fetch<SeedCrossBrief>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		//Example - paged & filtered list:
		public Page<SeedCrossBrief> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<SeedCrossBrief>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		// More methods here ***
	}
}
