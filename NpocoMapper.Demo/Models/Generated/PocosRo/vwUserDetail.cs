using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwUserDetails")]
[ExplicitColumns]
[TypeScriptModel]
public partial class vwUserDetail
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
	[NPoco.Column]
	public int CountAll { get; set; }
	[NPoco.Column]
	public int CountPending { get; set; }
	[NPoco.Column]
	public int CountClosed { get; set; }

}
