using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class ResourceItemDb : RepositoryBase
{
		public int Save(ResourceItem entity)
	{
		db.Save<ResourceItem>(entity);
		return entity.ItemId;
	}

	public bool Save(IEnumerable<ResourceItem> items)
	{
		foreach (ResourceItem item in items)
		{
			db.Save<ResourceItem>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		string sql = "UPDATE [ResourceItems] SET IsDeleted = 1 WHERE (ItemId = @0);";
		db.Execute(sql, id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<ResourceItem>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<ResourceItem>(id);
		return true;
	}

	public ResourceItem FindBy(int id)
	{
		return db.SingleOrDefaultById<ResourceItem>(id);
	}
	public IEnumerable<ResourceItem> All()
	{
		return db.Fetch<ResourceItem>("");
	}


	//Example - filtered list:
	public IEnumerable<ResourceItem> FilteredList(string str1, string str2)
	{
		return db.Fetch<ResourceItem>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<ResourceItem> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<ResourceItem>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}