using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models
{
	[TypeScriptModel]
	[TableName("SeedListSummary")]
	[ExplicitColumns]
	public partial class SeedListSummary : CrosseratorDB.Record<SeedListSummary>
	{
		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public string PlantName { get; set; }

		[NPoco.Column]
		public int PlantStatusId { get; set; }

		[NPoco.Column]
		public string PictureIds { get; set; }

		[NPoco.Column]
		public int PollenCount { get; set; }


		public List<CrossSummary> CrossSummaries { get; set; }

		public string ViewMode { get; set; } = ""; // "display" | "edit" | "" (normal)

		public int[] PictureIdsArray
		{
			get
			{
				if (String.IsNullOrEmpty(this.PictureIds))
					return null;

				return PictureIds.Split(',').Select(a => Int32.Parse(a)).ToArray();
			}
		}
	}
}