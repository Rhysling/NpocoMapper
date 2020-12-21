using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using Crosserator.Models;
using Crosserator.Models.Core;
using Crosserator.Models.ViewModels;
using Crosserator.Repositories.Core;

namespace Crosserator.Repositories
{
	public class SeedCrossSummaryDb : RepositoryBase
	{
		public SeedPollenListVM FilteredList(PlantListFilter filter, int userId)
		{
			int ROW_LIMIT = 100;

			var sql = new System.Text.StringBuilder();

			sql.Append($@"SELECT TOP {ROW_LIMIT}
				 [GenusId]
				,[UserId]
				,[PlantId]
				,[PlantName]
				,[PlantStatusId]
				,[PictureIds]
				,[PollenCount]
				FROM SeedListSummary ");

			// WHERE
			List<string> withClauses = new List<string>();

			// GenusId
			withClauses.Add($"(GenusId = {filter.GenusId})");

			// UserId
			withClauses.Add($"(UserId = {userId})");

			// Filter on Name
			if (!String.IsNullOrWhiteSpace(filter.PlantNameLike))
				withClauses.Add($"(PlantName LIKE '{filter.PlantNameLike}%')");

			// Status
			if (filter.Status > 0)
				withClauses.Add($"(PlantStatusId = {filter.Status})");

			if (withClauses.Any())
				sql.Append("WHERE " + UtilitiesMaster.Sql.MakeSql.JoinClausesWith("AND", withClauses.ToArray<string>()));

			sql.Append("ORDER BY PlantName;");

			var seedList = db.Fetch<SeedListSummary>(sql.ToString());
			int seedCount = seedList.Count;

			if (seedCount == 0)
				return new SeedPollenListVM();

			string seedIds = String.Join(",", seedList.Select(a => a.PlantId.ToString()));


			sql = new System.Text.StringBuilder();

			sql.Append($@"SELECT
				[CrossId]
				,[SeedPlantId]
				,[PollenPlantId]
				,[PollenPlantName]
				,[CrossNumberYear]
				,[CrossNumber]
				,[CrossDate]
				,[ThreadColor]
				,[IsFailed]
				FROM CrossSummary ");

			withClauses = new List<string>();

			// Include Failed
			if (!filter.IncludeFailed)
				withClauses.Add("((IsFailed = 0) OR (IsFailed IS NULL))");

			// Limit to SeedPlantIds
			withClauses.Add($"(SeedPlantId IN ({ seedIds }))");

			sql.Append("WHERE " + UtilitiesMaster.Sql.MakeSql.JoinClausesWith("AND", withClauses.ToArray<string>()));

			var crossList = db.Fetch<CrossSummary>(sql.ToString());


			// Map Crosses to SeedPlants
			foreach (var s in seedList)
				s.CrossSummaries = crossList.Where(a => a.SeedPlantId == s.PlantId).OrderBy(a => a.PollenPlantName).ToList();

			return new SeedPollenListVM {
				SeedSummaries = seedList,
				IsRowLimited = (seedCount == ROW_LIMIT)
			};
		}



		public List<SeedCrossSummary> ForPollenPlant(int pollenPlantId)
		{
			return db.Fetch<SeedCrossSummary>("WHERE (PollenPlantId = @0) ORDER BY SeedPlantName;", pollenPlantId);
		}

	}
}
