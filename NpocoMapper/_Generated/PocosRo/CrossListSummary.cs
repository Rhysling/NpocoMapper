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
	[TableName("CrossListSummary")]
	[ExplicitColumns]
	public partial class CrossListSummary : CrosseratorDB.Record<CrossListSummary>
	{
		[NPoco.Column] 
		public int CrossId { get; set; }

		[NPoco.Column] 
		public int SeedPlantId { get; set; }

		[NPoco.Column] 
		public int PollenPlantId { get; set; }

		[NPoco.Column] 
		public string PollenPlantName { get; set; }

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

	}
}
