
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("PlantView")]
	[ExplicitColumns]
	public partial class PlantView
	{
		[NPoco.Column]
		public string Genus { get; set; }
		[NPoco.Column]
		public string? Species { get; set; }
		[NPoco.Column]
		public string? Common { get; set; }

	}
}