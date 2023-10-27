using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class vwShoppingListSummaryDb : RepositoryBase
{
	
	public IEnumerable<vwShoppingListSummary> All()
	{
		return db.Fetch<vwShoppingListSummary>("");
	}


	//Example - filtered list:
	public IEnumerable<vwShoppingListSummary> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwShoppingListSummary>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwShoppingListSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwShoppingListSummary>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}