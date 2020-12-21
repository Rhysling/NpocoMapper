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
	[TableName("SeedCrossBrief")]
	[ExplicitColumns]
	public partial class SeedCrossBrief : CrosseratorDB.Record<SeedCrossBrief>
	{
		private DateTime minDate = new DateTime(1910, 1, 1);

		[NPoco.Column]
		public int CrossId { get; set; }

		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public int SeedPlantId { get; set; }

		[NPoco.Column]
		public string SeedPlantName { get; set; }

		[NPoco.Column]
		public int SeedPlantStatusId { get; set; }

		[NPoco.Column]
		public string SeedPlantStatusName { get; set; }

		[NPoco.Column]
		public int? PollenPlantId { get; set; }

		[NPoco.Column]
		public string PollenPlantName { get; set; }

		[NPoco.Column]
		public int PollenPlantStatusId { get; set; }

		[NPoco.Column]
		public string PollenPlantStatusName { get; set; }

		[NPoco.Column]
		public int? CrossNumberYear { get; set; }

		[NPoco.Column]
		public int? CrossNumber { get; set; }

		[NPoco.Column]
		public DateTime? CrossDate { get; set; }

		[NPoco.Column]
		public string ThreadColor { get; set; }

		[NPoco.Column]
		public bool? IsFailed { get; set; }


		public string CrossDateDisp
		{
			get
			{
				return (this.CrossDate.HasValue && (this.CrossDate > minDate)) ? this.CrossDate.Value.ToShortDateString() : "None";
			}
		}
	}
}
