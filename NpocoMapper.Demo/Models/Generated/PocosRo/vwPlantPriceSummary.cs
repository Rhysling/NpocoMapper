using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("vwPlantPriceSummary")]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class vwPlantPriceSummary
	{
		[NPoco.Column]
		public int PlantId { get; set; }
		[NPoco.Column]
		public string Genus { get; set; } = "";
		[NPoco.Column]
		public string Species { get; set; } = "";
		[NPoco.Column]
		public string? Available { get; set; }
		[NPoco.Column]
		public string? NotAvailable { get; set; }

	}
}