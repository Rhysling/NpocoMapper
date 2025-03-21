using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class WishListDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(WishList entity)
	{
		db.Save<WishList>(entity);
		return entity.WlId;
	}

	public bool Save(IEnumerable<WishList> items)
	{
		foreach (WishList item in items)
		{
			db.Save<WishList>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<WishList>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<WishList>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<WishList>(id);
		return true;
	}

	public WishList FindBy(int id)
	{
		return db.SingleOrDefaultById<WishList>(id);
	}
	public IEnumerable<WishList> All()
	{
		return db.Fetch<WishList>("");
	}


	//Example - filtered list:
	public IEnumerable<WishList> FilteredList(string str1, string str2)
	{
		return db.Fetch<WishList>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<WishList> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<WishList>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}