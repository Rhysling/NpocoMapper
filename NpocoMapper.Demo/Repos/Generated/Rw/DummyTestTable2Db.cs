using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class DummyTestTable2Db(string connStr) : RepositoryBase(connStr)
{
		public int Save(DummyTestTable2 entity)
	{
		db.Save<DummyTestTable2>(entity);
		return entity.FirstKey;
	}

	public bool Save(IEnumerable<DummyTestTable2> items)
	{
		foreach (DummyTestTable2 item in items)
		{
			db.Save<DummyTestTable2>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<DummyTestTable2>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<DummyTestTable2>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<DummyTestTable2>(id);
		return true;
	}

	public DummyTestTable2 FindBy(int id)
	{
		return db.SingleOrDefaultById<DummyTestTable2>(id);
	}
	public IEnumerable<DummyTestTable2> All()
	{
		return db.Fetch<DummyTestTable2>("");
	}


	//Example - filtered list:
	public IEnumerable<DummyTestTable2> FilteredList(string str1, string str2)
	{
		return db.Fetch<DummyTestTable2>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<DummyTestTable2> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<DummyTestTable2>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}