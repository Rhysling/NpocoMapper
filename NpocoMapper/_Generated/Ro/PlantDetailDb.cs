using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class PlantDetailDb : RepositoryBase
	{
		public PlantDetail FindBy(int plantId)
		{
			return db.FirstOrDefault<PlantDetail>("WHERE (PlantId = @0);", plantId);
		}


		public IEnumerable<PlantDetail> All()
		{
			return db.Fetch<PlantDetail>(" ");
		}

		//Example - filtered list:
		public IEnumerable<PlantDetail> FilteredList(string str1, string str2)
		{
			return db.Fetch<PlantDetail>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<PlantDetail> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<PlantDetail>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}
