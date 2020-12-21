using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;

namespace Crosserator.Models
{
	[TableName("PlantStatus")]
	[PrimaryKey("PlantStatusId", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class PlantStatus : CrosseratorDB.Record<PlantStatus>
	{
		[NPoco.Column]
		public int PlantStatusId { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string PlantStatusName { get; set; }

	}
}
