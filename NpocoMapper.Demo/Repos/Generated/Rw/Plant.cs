
using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos
{
	public class PlantDb : RepositoryBase
	{

		public int Save(Plant entity)
		{
			db.Save<Plant>(entity);
			return entity.PlantId;
		}

		public bool Save(IEnumerable<Plant> items)
		{
			foreach (Plant item in items)
			{
				db.Save<Plant>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			//string sql = "UPDATE [Plants] SET IsDeleted = 1 WHERE (PlantId = @0);";

			db.Execute(sql, id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plant>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}

		public Plant FindBy(int id)
		{
			return db.SingleOrDefaultById<Plant>(id);
		}


		public IEnumerable<Plant> All()
		{
			return db.Fetch<Plant>(" ");
		}


		//Example - filtered list:
		public IEnumerable<Plant> FilteredList(string str1, string str2)
		{
			return db.Fetch<Plant>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<Plant> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<Plant>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}
	}
}