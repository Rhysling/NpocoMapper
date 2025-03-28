using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("Users")][PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class User
{
	[NPoco.Column]
	public int Id { get; set; }
	[NPoco.Column]
	public string FullName { get; set; } = "";
	[NPoco.Column]
	public string? NullableString { get; set; }
	[NPoco.Column]
	public string LastUpdate { get; set; } = "";
	[NPoco.Column]
	public bool IsDeleted { get; set; }

}
