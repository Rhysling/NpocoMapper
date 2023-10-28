using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class VwUserDetailDb : RepositoryBase
{
	
	public IEnumerable<VwUserDetail> All()
	{
		return db.Fetch<VwUserDetail>("");
	}


	//Example - filtered list:
	public IEnumerable<VwUserDetail> FilteredList(string str1, string str2)
	{
		return db.Fetch<VwUserDetail>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<VwUserDetail> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<VwUserDetail>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}