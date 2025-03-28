using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("TestTable")][PrimaryKey("FirstKey", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class TestTable
{
	[NPoco.Column]
	public int FirstKey { get; set; }
	[NPoco.Column]
	public string? SecondNullable { get; set; }
	[NPoco.Column]
	public DateTime DateThing { get; set; }
	[NPoco.Column]
	public string? InfoNullable { get; set; }
	[NPoco.Column]
	public string? MoreStuff { get; set; }
	[NPoco.Column]
	public bool BoolThing { get; set; }
	[NPoco.Column]
	public bool BitThing { get; set; }

}
