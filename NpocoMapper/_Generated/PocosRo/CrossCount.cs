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
	[TableName("CrossCount")]
	[ExplicitColumns]
	public partial class CrossCount : CrosseratorDB.Record<CrossCount>
	{
		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column("ItemCount")]
		public int ItemCount { get; set; }

	}
}
