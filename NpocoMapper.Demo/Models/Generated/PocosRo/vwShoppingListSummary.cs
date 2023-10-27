using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwShoppingListSummary")]
[ExplicitColumns]
[TypeScriptModel]
public partial class vwShoppingListSummary
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
	public string? UserFullName { get; set; }
	[NPoco.Column]
	public string Email { get; set; } = "";
	[NPoco.Column]
	public int? TotalCount { get; set; }
	[NPoco.Column]
	public decimal? TotalPretax { get; set; }

}
