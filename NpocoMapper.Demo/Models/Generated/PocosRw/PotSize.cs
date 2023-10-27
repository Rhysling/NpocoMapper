using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("PotSizes")][PrimaryKey("Id", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class PotSize
{
	[NPoco.Column]
	public int Id { get; set; }
	[NPoco.Column]
	public string PotDescription { get; set; } = "";
	[NPoco.Column]
	public string PotShorthand { get; set; } = "";
	[NPoco.Column]
	public int SortOrder { get; set; }

}
