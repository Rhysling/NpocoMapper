using System.Collections.Generic;

namespace NpocoMapper.Models;

public class EnumPoco
{
	public required string EntityName { get; set; }
	public required string EnumName { get; set; }
	public string IdColumnName { get; set; } = "Id";
	public string NameColumnName { get; set; } = "Name";
	public string DescriptionColumnName { get; set; } = "Description";
	public List<EnumPocoProp> Values { get; set; } = [];
}
