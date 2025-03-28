using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("TestTableUnkeyed")]
[ExplicitColumns]
[TypeScriptModel]
public partial class TestTableUnkeyed
{
	[NPoco.Column]
	public int IdKeyNoIncrement { get; set; }
	[NPoco.Column]
	public string? FullName { get; set; }
	[NPoco.Column]
	public string LastUpdate { get; set; } = "";

}
