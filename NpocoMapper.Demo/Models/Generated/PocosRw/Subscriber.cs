using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("Subscribers")][PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class Subscriber
	{
		[NPoco.Column]
		public int ItemId { get; set; }
		[NPoco.Column]
		public string? FirstName { get; set; }
		[NPoco.Column]
		public string? LastName { get; set; }
		[NPoco.Column]
		public string? ExtraName { get; set; }
		[NPoco.Column]
		public string? Email { get; set; }
		[NPoco.Column]
		public string? Address1 { get; set; }
		[NPoco.Column]
		public string? Address2 { get; set; }
		[NPoco.Column]
		public string? City { get; set; }
		[NPoco.Column]
		public string? State { get; set; }
		[NPoco.Column]
		public string? ZipCode { get; set; }
		[NPoco.Column]
		public bool SendNotices { get; set; }
		[NPoco.Column]
		public bool MailCalendar { get; set; }
		[NPoco.Column]
		public bool IsDeleted { get; set; }
		[NPoco.Column]
		public string? Notes { get; set; }
		[NPoco.Column]
		public DateTime? AddedDate { get; set; }
		[NPoco.Column]
		public DateTime? LastUpdate { get; set; }

	}
}