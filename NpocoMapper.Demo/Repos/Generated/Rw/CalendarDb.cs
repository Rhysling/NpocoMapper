using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class CalendarDb : RepositoryBase
{
		public int Save(Calendar entity)
	{
		db.Save<Calendar>(entity);
		return entity.ItemId;
	}

	public bool Save(IEnumerable<Calendar> items)
	{
		foreach (Calendar item in items)
		{
			db.Save<Calendar>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<Calendar>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<Calendar>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<Calendar>(id);
		return true;
	}

	public Calendar FindBy(int id)
	{
		return db.SingleOrDefaultById<Calendar>(id);
	}
	public IEnumerable<Calendar> All()
	{
		return db.Fetch<Calendar>("");
	}


	//Example - filtered list:
	public IEnumerable<Calendar> FilteredList(string str1, string str2)
	{
		return db.Fetch<Calendar>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<Calendar> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<Calendar>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}