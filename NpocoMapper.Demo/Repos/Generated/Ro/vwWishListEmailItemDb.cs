using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwWishListEmailItemDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<VwWishListEmailItem> All()
	{
		return db.Fetch<VwWishListEmailItem>("");
	}


	//Example - filtered list:
	public IEnumerable<VwWishListEmailItem> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwWishListEmailItem>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwWishListEmailItem> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwWishListEmailItem>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}