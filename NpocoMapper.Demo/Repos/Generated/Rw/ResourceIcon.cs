
using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStore.Models;
using BotanicaStore.Repos.Core;

namespace BotanicaStore.Repos
{
	public class ResourceIconDb : RepositoryBase
	{

		public string Save(ResourceIcon entity)
		{
			db.Save<ResourceIcon>(entity);
			return entity.FileType;
		}

		public bool Save(IEnumerable<ResourceIcon> items)
		{
			foreach (ResourceIcon item in items)
			{
				db.Save<ResourceIcon>(item);
			}
			return true;
		}

		public bool Delete(string id)
		{
			//string sql = "UPDATE [ResourceIcons] SET IsDeleted = 1 WHERE (FileType = @0);";

			db.Execute(sql, id);
			return true;
		}

		public bool Delete(IEnumerable<string> ids)
		{
			foreach (string id in ids)
			{
				db.Delete<ResourceIcon>(id);
			}
			return true;
		}

		public bool Destroy(string id)
		{
			db.Delete<ResourceIcon>(id);
			return true;
		}

		public ResourceIcon FindBy(string id)
		{
			return db.SingleOrDefaultById<ResourceIcon>(id);
		}


		public IEnumerable<ResourceIcon> All()
		{
			return db.Fetch<ResourceIcon>(" ");
		}


		//Example - filtered list:
		public IEnumerable<ResourceIcon> FilteredList(string str1, string str2)
		{
			return db.Fetch<ResourceIcon>("WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}

		//Example - paged & filtered list:
		public Page<ResourceIcon> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<ResourceIcon>(page, itemsPerPage, "WHERE(v1 = @p1) AND(v2 = @p2)", new {p1 = str1, p2 = str2});
		}
	}
}