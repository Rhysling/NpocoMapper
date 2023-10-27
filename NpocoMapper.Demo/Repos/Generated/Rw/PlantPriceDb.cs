using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class PlantPriceDb : RepositoryBase
{
		public int Save(PlantPrice entity)
	{
		db.Save<PlantPrice>(entity);
		return entity.PlantId;
	}

	public bool Save(IEnumerable<PlantPrice> items)
	{
		foreach (PlantPrice item in items)
		{
			db.Save<PlantPrice>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<PlantPrice>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<PlantPrice>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<PlantPrice>(id);
		return true;
	}

	public PlantPrice FindBy(int id)
	{
		return db.SingleOrDefaultById<PlantPrice>(id);
	}
	public IEnumerable<PlantPrice> All()
	{
		return db.Fetch<PlantPrice>("");
	}


	//Example - filtered list:
	public IEnumerable<PlantPrice> FilteredList(string str1, string str2)
	{
		return db.Fetch<PlantPrice>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<PlantPrice> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<PlantPrice>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}