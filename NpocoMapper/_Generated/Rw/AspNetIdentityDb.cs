using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class AspNetIdentityDb : RepositoryBase
	{
		public bool IsUniqueCrossNumber(int crossId, int crossNumberYear, int crossNumber)
		{
			var count = db.ExecuteScalar<int>("SELECT COUNT(1) FROM Crosses WHERE ((CrossId <> @0) AND (CrossNumberYear = @1) AND (CrossNumber = @2) AND (IsDeleted = 0))", crossId, crossNumberYear, crossNumber);
			return count == 0;
		}


		// CRUD

		public int Save(Cross entity)
		{
			db.Save<Cross>(entity);
			return entity.CrossId;
		}

		public bool Save(IEnumerable<Cross> items)
		{
			foreach (Cross item in items)
			{
				db.Save<Cross>(item);
			}
			return true;
		}

		public bool Delete(int crossId)
		{
			string sql = "UPDATE Crosses SET IsDeleted = 1 WHERE (CrossId = @0);";

			db.Execute(sql, crossId);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Cross>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Cross>(id);
			return true;
		}


		public Cross FindBy(int id)
		{
			return db.SingleOrDefaultById<Cross>(id);
		}

		public IEnumerable<Cross> All()
		{
			return db.Fetch<Cross>(" ");
		}

		

	}
}

