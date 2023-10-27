using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class vwFlagSummaryDb : RepositoryBase
{
	
	public IEnumerable<vwFlagSummary> All()
	{
		return db.Fetch<vwFlagSummary>("");
	}


	//Example - filtered list:
	public IEnumerable<vwFlagSummary> FilteredList(string str1, string str2)
	{
		return db.Fetch<vwFlagSummary>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<vwFlagSummary> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<vwFlagSummary>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}