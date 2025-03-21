using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("DummyTestTable2")][PrimaryKey("FirstKey", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class DummyTestTable2
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
