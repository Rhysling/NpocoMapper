using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class SeedPlantSummaryDb : RepositoryBase
	{
		public SeedPlantSummary FindById(int plantId)
		{
			return db.SingleOrDefault<SeedPlantSummary>("WHERE (PlantId = @0);", plantId);
		}

		//Example - filtered list:
		public IEnumerable<SeedPlantSummary> FilteredList(string str1, string str2)
		{
			return db.Fetch<SeedPlantSummary>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<SeedPlantSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<SeedPlantSummary>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}

