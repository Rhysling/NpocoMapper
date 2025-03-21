using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("tpPlantPricesOld")][PrimaryKey("PlantId", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class TpPlantPricesOld
{
	[NPoco.Column]
	public int PlantId { get; set; }
	[NPoco.Column]
	public string Offered { get; set; } = "";

}
