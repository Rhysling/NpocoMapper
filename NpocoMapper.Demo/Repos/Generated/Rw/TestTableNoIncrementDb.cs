using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TestTableNoIncrementDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(TestTableNoIncrement entity)
	{
		db.Save<TestTableNoIncrement>(entity);
		return entity.IdKeyNoIncrement;
	}

	public bool Save(IEnumerable<TestTableNoIncrement> items)
	{
		foreach (TestTableNoIncrement item in items)
		{
			db.Save<TestTableNoIncrement>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<TestTableNoIncrement>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<TestTableNoIncrement>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<TestTableNoIncrement>(id);
		return true;
	}

	public TestTableNoIncrement FindBy(int id)
	{
		return db.SingleOrDefaultById<TestTableNoIncrement>(id);
	}
	public IEnumerable<TestTableNoIncrement> All()
	{
		return db.Fetch<TestTableNoIncrement>("");
	}


	//Example - filtered list:
	public IEnumerable<TestTableNoIncrement> FilteredList(string str1, string str2)
	{
		return db.Fetch<TestTableNoIncrement>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TestTableNoIncrement> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TestTableNoIncrement>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}