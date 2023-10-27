using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("WishListItems")][PrimaryKey("WlId,PlantId,PotSizeId", AutoIncrement = false)]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class WishListItem
	{
		[NPoco.Column]
		public int WlId { get; set; }
		[NPoco.Column]
		public int PlantId { get; set; }
		[NPoco.Column]
		public int PotSizeId { get; set; }
		[NPoco.Column]
		public decimal Price { get; set; }
		[NPoco.Column]
		public int Qty { get; set; }

	}
}