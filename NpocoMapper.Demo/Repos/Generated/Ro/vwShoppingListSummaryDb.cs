using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwShoppingListSummaryDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<VwShoppingListSummary> All()
	{
		return db.Fetch<VwShoppingListSummary>("");
	}


	//Example - filtered list:
	public IEnumerable<VwShoppingListSummary> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwShoppingListSummary>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwShoppingListSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwShoppingListSummary>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}