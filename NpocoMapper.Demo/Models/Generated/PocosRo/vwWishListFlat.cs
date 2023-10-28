using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwWishListFlat")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwWishListFlat
{
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
	[NPoco.Column]
	public int WlId { get; set; }
	[NPoco.Column]
	public int PlantId { get; set; }
	[NPoco.Column]
	public string PlantName { get; set; } = "";
	[NPoco.Column]
	public int PotSizeId { get; set; }
	[NPoco.Column]
	public string PotDescription { get; set; } = "";
	[NPoco.Column]
	public int SortOrder { get; set; }
	[NPoco.Column]
	public decimal Price { get; set; }
	[NPoco.Column]
	public int Qty { get; set; }
	[NPoco.Column]
	public decimal? CurrentPrice { get; set; }
	[NPoco.Column]
	public bool? IsCurrentlyAvailable { get; set; }

}
