using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("IqaInvestors")][PrimaryKey("Seq", AutoIncrement = false)]
[ExplicitColumns]
[TypeScriptModel]
public partial class IqaInvestor
{
	[NPoco.Column]
	public int Seq { get; set; }
	[NPoco.Column]
	public string StakeholderName { get; set; } = "";
	[NPoco.Column]
	public int TotalShares { get; set; }
	[NPoco.Column]
	public double ShareCash { get; set; }
	[NPoco.Column]
	public double NotePrin { get; set; }
	[NPoco.Column]
	public double TotalCash { get; set; }
	[NPoco.Column]
	public bool IsSend { get; set; }
	[NPoco.Column]
	public bool CloseNoticeSent { get; set; }
	[NPoco.Column]
	public string? Relationship { get; set; }
	[NPoco.Column]
	public string? Address { get; set; }
	[NPoco.Column]
	public string? City { get; set; }
	[NPoco.Column]
	public string? State { get; set; }
	[NPoco.Column]
	public string? ZipCode { get; set; }
	[NPoco.Column]
	public string? Email { get; set; }
	[NPoco.Column]
	public string? EmailOrig { get; set; }
	[NPoco.Column]
	public string DearName { get; set; } = "";
	[NPoco.Column]
	public string? LastName { get; set; }
	[NPoco.Column]
	public string? FullAddress { get; set; }

}
