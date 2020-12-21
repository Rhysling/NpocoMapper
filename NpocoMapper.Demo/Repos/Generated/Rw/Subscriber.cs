
using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos
{
	public class SubscriberDb : RepositoryBase
	{

		public int Save(Subscriber entity)
		{
			db.Save<Subscriber>(entity);
			return entity.ItemId;
		}

		public bool Save(IEnumerable<Subscriber> items)
		{
			foreach (Subscriber item in items)
			{
				db.Save<Subscriber>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			//string sql = "UPDATE [Subscribers] SET IsDeleted = 1 WHERE (ItemId = @0);";

			db.Execute(sql, id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Subscriber>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Subscriber>(id);
			return true;
		}

		public Subscriber FindBy(int id)
		{
			return db.SingleOrDefaultById<Subscriber>(id);
		}


		public IEnumerable<Subscriber> All()
		{
			return db.Fetch<Subscriber>(" ");
		}


		//Example - filtered list:
		public IEnumerable<Subscriber> FilteredList(string str1, string str2)
		{
			return db.Fetch<Subscriber>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<Subscriber> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<Subscriber>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}
	}
}