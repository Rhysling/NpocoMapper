using System.Collections.Generic;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class SeedPlantStatDb : RepositoryBase
	{
		public List<SeedPlantStat> FindForUserId(int userId)
		{
			return db.Fetch<SeedPlantStat>("WHERE (UserId = @0);", userId);
		}


		public List<SeedPlantStat> All()
		{
			return db.Fetch<SeedPlantStat>(" ");
		}

		//Example - filtered list:
		public IEnumerable<SeedPlantStat> FilteredList(string str1, string str2)
		{
			return db.Fetch<SeedPlantStat>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		//Example - paged & filtered list:
		public Page<SeedPlantStat> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<SeedPlantStat>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}

		// More methods here ***
	}
}
