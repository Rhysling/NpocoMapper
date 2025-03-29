using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("TestIntPk")]
[PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class TestIntPk
{
	[NPoco.Column]
	public int Id { get; set; }
	[NPoco.Column]
	public string FullName { get; set; } = "";
	[NPoco.Column]
	public string DateAsText { get; set; } = "";
	[NPoco.Column]
	public DateTime DateAsDateTime { get; set; }

}
