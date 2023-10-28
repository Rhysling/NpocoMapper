using System;
using NPoco;

namespace NpocoMapper.Demo.Models;

[TableName("vwListedPlants")]
[ExplicitColumns]
[TypeScriptModel]
public partial class VwListedPlant
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
	public bool IsFeatured { get; set; }
	[NPoco.Column]
	public string Slug { get; set; } = "";
	[NPoco.Column]
	public string Availability { get; set; } = "";

}
