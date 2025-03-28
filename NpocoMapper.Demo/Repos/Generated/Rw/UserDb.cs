using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class UserDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(User entity)
	{
		db.Save<User>(entity);
		return entity.Id;
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
		string sql = "UPDATE [Users] SET IsDeleted = 1 WHERE (Id = @0);";
		db.Execute(sql, id);
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