using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Models
{
	public class Poco
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public string EntityName { get; set; }
		public string EntityType { get; set; }
		public string ClassName { get; set; }
		public string ClassType { get; set; }
		public string PrimaryKeys { get; set; }
		public bool IsAutoIncrement { get; set; }
		public bool Ignore { get; set; }
		public List<PocoProp> Props { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	}
}
