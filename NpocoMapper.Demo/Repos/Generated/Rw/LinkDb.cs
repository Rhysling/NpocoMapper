using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class LinkDb : RepositoryBase
{
		public int Save(Link entity)
	{
		db.Save<Link>(entity);
		return entity.LinkId;
	}

	public bool Save(IEnumerable<Link> items)
	{
		foreach (Link item in items)
		{
			db.Save<Link>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		string sql = "UPDATE [Links] SET IsDeleted = 1 WHERE (LinkId = @0);";
		db.Execute(sql, id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<Link>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<Link>(id);
		return true;
	}

	public Link FindBy(int id)
	{
		return db.SingleOrDefaultById<Link>(id);
	}
	public IEnumerable<Link> All()
	{
		return db.Fetch<Link>("");
	}


	//Example - filtered list:
	public IEnumerable<Link> FilteredList(string str1, string str2)
	{
		return db.Fetch<Link>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<Link> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<Link>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}