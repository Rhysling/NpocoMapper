using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("WishLists")][PrimaryKey("WlId", AutoIncrement = true)]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class WishList
	{
		[NPoco.Column]
		public int WlId { get; set; }
		[NPoco.Column]
		public int UserId { get; set; }
		[NPoco.Column]
		public DateTime CreatedDate { get; set; }
		[NPoco.Column]
		public DateTime LastUpdateDate { get; set; }
		[NPoco.Column]
		public DateTime? EmailedDate { get; set; }
		[NPoco.Column]
		public bool IsClosed { get; set; }

	}
}