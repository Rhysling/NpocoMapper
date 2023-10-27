using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class DummyTestTableDb : RepositoryBase
{
		public int Save(DummyTestTable entity)
	{
		db.Save<DummyTestTable>(entity);
		return entity.FirstKey;
	}

	public bool Save(IEnumerable<DummyTestTable> items)
	{
		foreach (DummyTestTable item in items)
		{
			db.Save<DummyTestTable>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<DummyTestTable>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<DummyTestTable>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<DummyTestTable>(id);
		return true;
	}

	public DummyTestTable FindBy(int id)
	{
		return db.SingleOrDefaultById<DummyTestTable>(id);
	}
	public IEnumerable<DummyTestTable> All()
	{
		return db.Fetch<DummyTestTable>("");
	}


	//Example - filtered list:
	public IEnumerable<DummyTestTable> FilteredList(string str1, string str2)
	{
		return db.Fetch<DummyTestTable>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<DummyTestTable> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<DummyTestTable>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}