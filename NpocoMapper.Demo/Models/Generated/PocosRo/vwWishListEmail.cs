using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwWishListEmail")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwWishListEmail
{
	[NPoco.Column]
	public int WlId { get; set; }
	[NPoco.Column]
	public int UserId { get; set; }
	[NPoco.Column]
	public DateTime CreatedDate { get; set; }
	[NPoco.Column]
	public DateTime LastUpdateDate { get; set; }
	[NPoco.Column]
	public DateTime? EmailedDate { get; set; }
	[NPoco.Column]
	public bool IsClosed { get; set; }
	[NPoco.Column]
	public string Email { get; set; } = "";
	[NPoco.Column]
	public string? FullName { get; set; }

}
