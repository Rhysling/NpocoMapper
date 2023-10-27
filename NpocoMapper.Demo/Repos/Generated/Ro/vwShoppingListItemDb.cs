using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class vwShoppingListItemDb : RepositoryBase
{
	
	public IEnumerable<vwShoppingListItem> All()
	{
		return db.Fetch<vwShoppingListItem>("");
	}


	//Example - filtered list:
	public IEnumerable<vwShoppingListItem> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwShoppingListItem>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwShoppingListItem> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwShoppingListItem>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}