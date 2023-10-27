using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class vwPlantPriceSummaryDb : RepositoryBase
{
	
	public IEnumerable<vwPlantPriceSummary> All()
	{
		return db.Fetch<vwPlantPriceSummary>("");
	}


	//Example - filtered list:
	public IEnumerable<vwPlantPriceSummary> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwPlantPriceSummary>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwPlantPriceSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwPlantPriceSummary>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}