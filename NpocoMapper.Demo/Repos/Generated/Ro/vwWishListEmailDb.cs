using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class vwWishListEmailDb : RepositoryBase
{
	
	public IEnumerable<vwWishListEmail> All()
	{
		return db.Fetch<vwWishListEmail>("");
	}


	//Example - filtered list:
	public IEnumerable<vwWishListEmail> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwWishListEmail>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwWishListEmail> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwWishListEmail>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}