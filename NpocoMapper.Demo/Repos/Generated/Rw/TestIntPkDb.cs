using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TestIntPkDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(TestIntPk entity)
	{
		db.Save<TestIntPk>(entity);
		return entity.Id;
	}

	public bool Save(IEnumerable<TestIntPk> items)
	{
		foreach (TestIntPk item in items)
		{
			db.Save<TestIntPk>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<TestIntPk>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<TestIntPk>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<TestIntPk>(id);
		return true;
	}

	public TestIntPk FindBy(int id)
	{
		return db.SingleOrDefaultById<TestIntPk>(id);
	}
	public IEnumerable<TestIntPk> All()
	{
		return db.Fetch<TestIntPk>("");
	}


	//Example - filtered list:
	public IEnumerable<TestIntPk> FilteredList(string str1, string str2)
	{
		return db.Fetch<TestIntPk>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TestIntPk> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TestIntPk>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}