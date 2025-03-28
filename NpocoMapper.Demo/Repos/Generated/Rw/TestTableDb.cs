using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TestTableDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(TestTable entity)
	{
		db.Save<TestTable>(entity);
		return entity.FirstKey;
	}

	public bool Save(IEnumerable<TestTable> items)
	{
		foreach (TestTable item in items)
		{
			db.Save<TestTable>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<TestTable>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<TestTable>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<TestTable>(id);
		return true;
	}

	public TestTable FindBy(int id)
	{
		return db.SingleOrDefaultById<TestTable>(id);
	}
	public IEnumerable<TestTable> All()
	{
		return db.Fetch<TestTable>("");
	}


	//Example - filtered list:
	public IEnumerable<TestTable> FilteredList(string str1, string str2)
	{
		return db.Fetch<TestTable>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TestTable> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TestTable>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}