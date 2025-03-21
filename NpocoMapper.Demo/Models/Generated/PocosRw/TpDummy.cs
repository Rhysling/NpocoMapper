using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("TpDummy")][PrimaryKey("IdKeyNoIncrement", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class TpDummy
{
	[NPoco.Column]
	public int IdKeyNoIncrement { get; set; }
	[NPoco.Column]
	public string? FullName { get; set; }

}
