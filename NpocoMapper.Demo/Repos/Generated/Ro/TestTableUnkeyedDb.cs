using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TestTableUnkeyedDb(string connStr) : RepositoryBase(connStr)
{
	
	public IEnumerable<TestTableUnkeyed> All()
	{
		return db.Fetch<TestTableUnkeyed>("");
	}


	//Example - filtered list:
	public IEnumerable<TestTableUnkeyed> FilteredList(string str1, string str2)
	{
		return db.Fetch<TestTableUnkeyed>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TestTableUnkeyed> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TestTableUnkeyed>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}