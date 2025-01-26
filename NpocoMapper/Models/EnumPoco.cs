using System;
using System.Collections.Generic;
using System.Text;

namespace NpocoMapper.Models;

public class EnumPoco
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	public string EntityName { get; set; }
	public string EnumName { get; set; }
	public string IdColumnName { get; set; } = "Id";
	public string NameColumnName { get; set; } = "Name";
	public string DescriptionColumnName { get; set; } = "Description";
	public List<EnumPocoProp> Values { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
