using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class vwListedPlantDb : RepositoryBase
{
	
	public IEnumerable<vwListedPlant> All()
	{
		return db.Fetch<vwListedPlant>("");
	}


	//Example - filtered list:
	public IEnumerable<vwListedPlant> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwListedPlant>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwListedPlant> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwListedPlant>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}