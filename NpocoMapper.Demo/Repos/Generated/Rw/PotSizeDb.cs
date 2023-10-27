using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class PotSizeDb : RepositoryBase
{
		public int Save(PotSize entity)
	{
		db.Save<PotSize>(entity);
		return entity.Id;
	}

	public bool Save(IEnumerable<PotSize> items)
	{
		foreach (PotSize item in items)
		{
			db.Save<PotSize>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<PotSize>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<PotSize>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<PotSize>(id);
		return true;
	}

	public PotSize FindBy(int id)
	{
		return db.SingleOrDefaultById<PotSize>(id);
	}
	public IEnumerable<PotSize> All()
	{
		return db.Fetch<PotSize>("");
	}


	//Example - filtered list:
	public IEnumerable<PotSize> FilteredList(string str1, string str2)
	{
		return db.Fetch<PotSize>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<PotSize> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<PotSize>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}