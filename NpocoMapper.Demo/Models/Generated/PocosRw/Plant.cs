
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("Plants")]
	[PrimaryKey("PlantId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Plant
	{
		[NPoco.Column]
		public int PlantId { get; set; }
		[NPoco.Column]
		public string Genus { get; set; }
		[NPoco.Column]
		public string? Species { get; set; }
		[NPoco.Column]
		public string? Common { get; set; }
		[NPoco.Column]
		public string? Description { get; set; }
		[NPoco.Column]
		public string? WebDescription { get; set; }
		[NPoco.Column]
		public string? PlantSize { get; set; }
		[NPoco.Column]
		public string? PlantType { get; set; }
		[NPoco.Column]
		public string? PlantZone { get; set; }
		[NPoco.Column]
		public DateTime LastUpdate { get; set; }
		[NPoco.Column]
		public string? Offered { get; set; }
		[NPoco.Column]
		public bool IsAvailable { get; set; }
		[NPoco.Column]
		public bool IsSoldOut { get; set; }
		[NPoco.Column]
		public bool IsFeatured { get; set; }
		[NPoco.Column]
		public bool ShowDescription { get; set; }
		[NPoco.Column]
		public string? Flag { get; set; }

	}
}