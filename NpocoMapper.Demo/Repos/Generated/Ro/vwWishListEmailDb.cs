using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwWishListEmailDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<VwWishListEmail> All()
	{
		return db.Fetch<VwWishListEmail>("");
	}


	//Example - filtered list:
	public IEnumerable<VwWishListEmail> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwWishListEmail>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwWishListEmail> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwWishListEmail>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}