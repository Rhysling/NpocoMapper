using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwFlagSummary")]
[ExplicitColumns]
[TypeScriptModel]
public partial class vwFlagSummary
{
	[NPoco.Column]
	public string? Flag { get; set; }
	[NPoco.Column]
	public int? PlantCount { get; set; }
	[NPoco.Column]
	public DateTime? LastUpdate { get; set; }

}
