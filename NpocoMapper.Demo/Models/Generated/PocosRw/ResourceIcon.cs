using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("ResourceIcons")][PrimaryKey("FileType", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class ResourceIcon
{
	[NPoco.Column]
	public string FileType { get; set; } = "";
	[NPoco.Column]
	public int IconGroup { get; set; }

}
