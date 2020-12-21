using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class PlantSupplementalDb : RepositoryBase
	{
		public List<PlantSupplemental> ForPlantIds(int[] plantIds)
		{
			if (plantIds == null || plantIds.Length == 0)
				return new List<PlantSupplemental>();

			string ids = String.Join(",", plantIds);
			string sql = $"WHERE (PlantId IN ({ ids }))";

			return db.Fetch<PlantSupplemental>(sql);
		}


	}
}
