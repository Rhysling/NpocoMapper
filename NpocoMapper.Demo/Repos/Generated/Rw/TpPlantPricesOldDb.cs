using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using NpocoMapper.Demo.Models;
using NpocoMapper.Demo.Repos.Core;

namespace NpocoMapper.Demo.Repos;

public class TpPlantPricesOldDb(string connStr) : RepositoryBase(connStr)
{
		public int Save(TpPlantPricesOld entity)
	{
		db.Save<TpPlantPricesOld>(entity);
		return entity.PlantId;
	}

	public bool Save(IEnumerable<TpPlantPricesOld> items)
	{
		foreach (TpPlantPricesOld item in items)
		{
			db.Save<TpPlantPricesOld>(item);
		}
		return true;
	}

	public bool Delete(int id)
	{
		
		db.Delete<TpPlantPricesOld>(id);
		return true;
	}

	public bool Delete(IEnumerable<int> ids)
	{
		foreach (int id in ids)
		{
			db.Delete<TpPlantPricesOld>(id);
		}
		return true;
	}

	public bool Destroy(int id)
	{
		db.Delete<TpPlantPricesOld>(id);
		return true;
	}

	public TpPlantPricesOld FindBy(int id)
	{
		return db.SingleOrDefaultById<TpPlantPricesOld>(id);
	}
	public IEnumerable<TpPlantPricesOld> All()
	{
		return db.Fetch<TpPlantPricesOld>("");
	}


	//Example - filtered list:
	public IEnumerable<TpPlantPricesOld> FilteredList(string str1, string str2)
	{
		return db.Fetch<TpPlantPricesOld>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}

	//Example - paged & filtered list:
	public Page<TpPlantPricesOld> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
	{
		return db.Page<TpPlantPricesOld>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
	}
}