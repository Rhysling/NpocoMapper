using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwPlantsAvailableDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<VwPlantsAvailable> All()
	{
		return db.Fetch<VwPlantsAvailable>("");
	}


	//Example - filtered list:
	public IEnumerable<VwPlantsAvailable> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwPlantsAvailable>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwPlantsAvailable> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwPlantsAvailable>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}