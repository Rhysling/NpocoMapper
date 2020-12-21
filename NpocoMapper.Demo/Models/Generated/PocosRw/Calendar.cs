
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("Calendar")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Calendar
	{
		[NPoco.Column]
		public int ItemId { get; set; }
		[NPoco.Column]
		public DateTime? BeginDate { get; set; }
		[NPoco.Column]
		public DateTime? EndDate { get; set; }
		[NPoco.Column]
		public string? EventTime { get; set; }
		[NPoco.Column]
		public string? Title { get; set; }
		[NPoco.Column]
		public string? Location { get; set; }
		[NPoco.Column]
		public string? Description { get; set; }
		[NPoco.Column]
		public bool? IsSpecial { get; set; }

	}
}