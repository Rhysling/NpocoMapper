
using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos
{
	public class PlantViewDb : RepositoryBase
	{


		public IEnumerable<PlantView> All()
		{
			return db.Fetch<PlantView>(" ");
		}


		//Example - filtered list:
		public IEnumerable<PlantView> FilteredList(string str1, string str2)
		{
			return db.Fetch<PlantView>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<PlantView> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<PlantView>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}
	}
}