using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwPlantsAvailable")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwPlantsAvailable
{
	[NPoco.Column]
	public int PlantId { get; set; }
	[NPoco.Column]
	public string PlantName { get; set; } = "";
	[NPoco.Column]
	public int PotSizeId { get; set; }
	[NPoco.Column]
	public string PotDescription { get; set; } = "";
	[NPoco.Column]
	public string PotShorthand { get; set; } = "";
	[NPoco.Column]
	public int SortOrder { get; set; }
	[NPoco.Column]
	public decimal Price { get; set; }

}
