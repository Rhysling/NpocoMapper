using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class KeyDb(string connStr) : RepositoryBase(connStr)
{
		public string Save(Key entity)
	{
		db.Save<Key>(entity);
		return entity.KeyName;
	}

	public bool Save(IEnumerable<Key> items)
	{
		foreach (Key item in items)
		{
			db.Save<Key>(item);
		}
		return true;
	}

	public bool Delete(string id)
	{
		
		db.Delete<Key>(id);
		return true;
	}

	public bool Delete(IEnumerable<string> ids)
	{
		foreach (string id in ids)
		{
			db.Delete<Key>(id);
		}
		return true;
	}

	public bool Destroy(string id)
	{
		db.Delete<Key>(id);
		return true;
	}

	public Key FindBy(string id)
	{
		return db.SingleOrDefaultById<Key>(id);
	}
	public IEnumerable<Key> All()
	{
		return db.Fetch<Key>("");
	}


	//Example - filtered list:
	public IEnumerable<Key> FilteredList(string str1, string str2)
	{
		return db.Fetch<Key>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<Key> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<Key>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}