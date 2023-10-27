using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class vwWishListFlatDb : RepositoryBase
{
	
	public IEnumerable<vwWishListFlat> All()
	{
		return db.Fetch<vwWishListFlat>("");
	}


	//Example - filtered list:
	public IEnumerable<vwWishListFlat> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwWishListFlat>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwWishListFlat> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwWishListFlat>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}