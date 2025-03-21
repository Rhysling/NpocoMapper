using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TpDummyDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(TpDummy entity)
	{
		db.Save<TpDummy>(entity);
		return entity.IdKeyNoIncrement;
	}

	public bool Save(IEnumerable<TpDummy> items)
	{
		foreach (TpDummy item in items)
		{
			db.Save<TpDummy>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<TpDummy>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<TpDummy>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<TpDummy>(id);
		return true;
	}

	public TpDummy FindBy(int id)
	{
		return db.SingleOrDefaultById<TpDummy>(id);
	}
	public IEnumerable<TpDummy> All()
	{
		return db.Fetch<TpDummy>("");
	}


	//Example - filtered list:
	public IEnumerable<TpDummy> FilteredList(string str1, string str2)
	{
		return db.Fetch<TpDummy>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TpDummy> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TpDummy>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}