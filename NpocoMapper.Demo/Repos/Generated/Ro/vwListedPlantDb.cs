using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwListedPlantDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<VwListedPlant> All()
	{
		return db.Fetch<VwListedPlant>("");
	}


	//Example - filtered list:
	public IEnumerable<VwListedPlant> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwListedPlant>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwListedPlant> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwListedPlant>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}