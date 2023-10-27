using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos;

public class UserDb : RepositoryBase
{
		public int Save(User entity)
	{
		db.Save<User>(entity);
		return entity.UserId;
	}

	public bool Save(IEnumerable<User> items)
	{
		foreach (User item in items)
		{
			db.Save<User>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<User>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<User>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<User>(id);
		return true;
	}

	public User FindBy(int id)
	{
		return db.SingleOrDefaultById<User>(id);
	}
	public IEnumerable<User> All()
	{
		return db.Fetch<User>("");
	}


	//Example - filtered list:
	public IEnumerable<User> FilteredList(string str1, string str2)
	{
		return db.Fetch<User>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<User> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<User>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}