using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("Plants")][PrimaryKey("PlantId", AutoIncrement = true)]
[ExplicitColumns]
[TypeScriptModel]
public partial class Plant
{
	[NPoco.Column]
	public int PlantId { get; set; }
	[NPoco.Column]
	public string Genus { get; set; } = "";
	[NPoco.Column]
	public string Species { get; set; } = "";
	[NPoco.Column]
	public string? Family { get; set; }
	[NPoco.Column]
	public string? Description { get; set; }
	[NPoco.Column]
	public string? Notes { get; set; }
	[NPoco.Column]
	public string? PlantSize { get; set; }
	[NPoco.Column]
	public string? PlantType { get; set; }
	[NPoco.Column]
	public string? PlantZone { get; set; }
	[NPoco.Column]
	public string? PictureLocation { get; set; }
	[NPoco.Column]
	public bool IsNwNative { get; set; }
	[NPoco.Column]
	public string Pics { get; set; } = "";
	[NPoco.Column]
	public bool IsListed { get; set; }
	[NPoco.Column]
	public bool IsFeatured { get; set; }
	[NPoco.Column]
	public string Slug { get; set; } = "";
	[NPoco.Column]
	public string LastUpdate { get; set; } = "";
	[NPoco.Column]
	public string? Flag { get; set; }
	[NPoco.Column]
	public bool IsDeleted { get; set; }

}
