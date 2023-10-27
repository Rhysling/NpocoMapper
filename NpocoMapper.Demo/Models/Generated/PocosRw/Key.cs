using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("Keys")][PrimaryKey("KeyName", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class Key
{
	[NPoco.Column]
	public string KeyName { get; set; } = "";
	[NPoco.Column]
	public string? KeyValue { get; set; }

}
