using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("TestTableNoIncrement")][PrimaryKey("IdKeyNoIncrement", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class TestTableNoIncrement
{
	[NPoco.Column]
	public int IdKeyNoIncrement { get; set; }
	[NPoco.Column]
	public string? FullName { get; set; }

}
