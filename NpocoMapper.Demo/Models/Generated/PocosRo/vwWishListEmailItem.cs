using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwWishListEmailItems")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwWishListEmailItem
{
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
	public decimal Price { get; set; }
	[NPoco.Column]
	public int Qty { get; set; }

}
