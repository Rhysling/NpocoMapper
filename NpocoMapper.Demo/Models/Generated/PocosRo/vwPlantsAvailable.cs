using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwPlantsAvailable")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwPlantsAvailable
{
	[NPoco.Column]
	public int? PlantId { get; set; }
	[NPoco.Column]
	public string? PlantName { get; set; }

}
