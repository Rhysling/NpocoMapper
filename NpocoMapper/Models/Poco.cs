using System.Collections.Generic;

namespace NpocoMapper.Models;

public class Poco
{
	public required string EntityName { get; set; }
	public required string EntityType { get; set; }
	public required string ClassName { get; set; }
	public required string ClassType { get; set; }
	public required string PrimaryKeys { get; set; }
	public bool IsAutoIncrement { get; set; }
	public bool Ignore { get; set; }
	public List<PocoProp> Props { get; set; } = [];
}
