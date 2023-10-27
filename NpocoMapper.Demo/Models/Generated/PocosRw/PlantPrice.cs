using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("PlantPrices")][PrimaryKey("PlantId,PotSizeId", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class PlantPrice
{
	[NPoco.Column]
	public int PlantId { get; set; }
	[NPoco.Column]
	public int PotSizeId { get; set; }
	[NPoco.Column]
	public decimal Price { get; set; }
	[NPoco.Column]
	public bool IsAvailable { get; set; }

}
