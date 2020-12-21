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
	[TableName("SeedCrossSummary")]
	[ExplicitColumns]
	public partial class SeedCrossSummary : CrosseratorDB.Record<SeedCrossSummary>
	{
		private DateTime minDate = new DateTime(1910, 1, 1);

		[NPoco.Column] 
		public int GenusId { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column] 
		public int SeedPlantId { get; set; }

		[NPoco.Column] 
		public string SeedPlantName { get; set; }

		[NPoco.Column] 
		public int PlantStatusId { get; set; }

		[NPoco.Column] 
		public string SeedPlantPictureIds { get; set; }

		[NPoco.Column] 
		public string PollenPlantPictureIds { get; set; }

		[NPoco.Column] 
		public int SeedPlantPollenCount { get; set; }

		[NPoco.Column] 
		public int? CrossId { get; set; }

		[NPoco.Column] 
		public int? PollenPlantId { get; set; }

		[NPoco.Column] 
		public string PollenPlantName { get; set; }

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


		public int[] SeedPlantPictureIdsArray
		{
			get
			{
				if (String.IsNullOrEmpty(this.SeedPlantPictureIds))
					return null;

				return SeedPlantPictureIds.Split(',').Select(a => Int32.Parse(a)).ToArray();
			}
		}

		public int[] PollenPlantPictureIdsArray
		{
			get
			{
				if (String.IsNullOrEmpty(this.PollenPlantPictureIds))
					return null;

				return PollenPlantPictureIds.Split(',').Select(a => Int32.Parse(a)).ToArray();
			}
		}

		public string CrossDateDisp
		{
			get
			{
				return (this.CrossDate.HasValue && (this.CrossDate > minDate)) ? this.CrossDate.Value.ToShortDateString() : "None";
			}
		}
	}
}
