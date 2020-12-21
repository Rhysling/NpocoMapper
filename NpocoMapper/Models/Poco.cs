using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Models
{
	public class Poco
	{
		public string EntityName { get; set; }
		public string EntityType { get; set; }
		public string ClassName { get; set; }
		public string ClassType { get; set; }
		public string PrimaryKeys { get; set; }
		public bool IsAutoIncrement { get; set; }
		public bool Ignore { get; set; }
		public List<PocoProp> Props { get; set; }
	}
}
