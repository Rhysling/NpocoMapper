using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class WishListItemDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(WishListItem entity)
	{
		db.Save<WishListItem>(entity);
		return entity.WlId;
	}

	public bool Save(IEnumerable<WishListItem> items)
	{
		foreach (WishListItem item in items)
		{
			db.Save<WishListItem>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<WishListItem>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<WishListItem>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<WishListItem>(id);
		return true;
	}

	public WishListItem FindBy(int id)
	{
		return db.SingleOrDefaultById<WishListItem>(id);
	}
	public IEnumerable<WishListItem> All()
	{
		return db.Fetch<WishListItem>("");
	}


	//Example - filtered list:
	public IEnumerable<WishListItem> FilteredList(string str1, string str2)
	{
		return db.Fetch<WishListItem>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<WishListItem> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<WishListItem>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}