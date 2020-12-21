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
	[TableName("CrossSummary")]
	[ExplicitColumns]
	public partial class CrossSummary : CrosseratorDB.Record<CrossSummary>
	{
		public CrossSummary()
		{
			ViewMode = "";
		}

		private DateTime minDate = new DateTime(1910, 1, 1);

		[NPoco.Column]
		public int CrossId { get; set; }

		[NPoco.Column]
		public int SeedPlantId { get; set; }

		[NPoco.Column]
		public int PollenPlantId { get; set; }

		[NPoco.Column]
		public string PollenPlantName { get; set; }

		[NPoco.Column]
		public string PollenPlantPictureIds { get; set; }

		[NPoco.Column]
		public int CrossNumberYear { get; set; }

		[NPoco.Column]
		public int CrossNumber { get; set; }

		[NPoco.Column]
		public DateTime CrossDate { get; set; }

		[NPoco.Column]
		public string ThreadColor { get; set; }

		[NPoco.Column]
		public bool IsFailed { get; set; }

		public string ViewMode { get; set; } = ""; // "display" | "edit" | "" (normal)

		public int[] PollenPlantPictureIdsArray {
			get
			{
				if (String.IsNullOrEmpty(PollenPlantPictureIds))
					return Array.Empty<int>();

				return PollenPlantPictureIds.Split(',').Select(a => Int32.Parse(a)).ToArray();
			}
		}

		public string CrossDateDisp
		{
			get
			{
				return (CrossDate > minDate) ? CrossDate.ToShortDateString() : null;
			}
		}
	}
}
