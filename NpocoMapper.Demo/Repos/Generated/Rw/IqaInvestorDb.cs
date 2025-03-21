using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class IqaInvestorDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(IqaInvestor entity)
	{
		db.Save<IqaInvestor>(entity);
		return entity.Seq;
	}

	public bool Save(IEnumerable<IqaInvestor> items)
	{
		foreach (IqaInvestor item in items)
		{
			db.Save<IqaInvestor>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<IqaInvestor>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<IqaInvestor>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<IqaInvestor>(id);
		return true;
	}

	public IqaInvestor FindBy(int id)
	{
		return db.SingleOrDefaultById<IqaInvestor>(id);
	}
	public IEnumerable<IqaInvestor> All()
	{
		return db.Fetch<IqaInvestor>("");
	}


	//Example - filtered list:
	public IEnumerable<IqaInvestor> FilteredList(string str1, string str2)
	{
		return db.Fetch<IqaInvestor>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<IqaInvestor> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<IqaInvestor>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}