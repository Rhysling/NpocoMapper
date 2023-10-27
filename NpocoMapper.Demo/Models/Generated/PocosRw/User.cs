using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("Users")][PrimaryKey("UserId", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class User
{
	[NPoco.Column]
	public int UserId { get; set; }
	[NPoco.Column]
	public string Email { get; set; } = "";
	[NPoco.Column]
	public string? FullName { get; set; }
	[NPoco.Column]
	public bool IsAdmin { get; set; }
	[NPoco.Column]
	public DateTime CreatedDate { get; set; }
	[NPoco.Column]
	public DateTime LastLoginDate { get; set; }
	[NPoco.Column]
	public int LoginCount { get; set; }

}
