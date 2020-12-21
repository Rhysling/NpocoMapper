using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Models
{
	public class PocoProp
	{
		public string PropName { get; set; }
		public string PropType { get; set; }
		//public string TsType { get; set; }
		public bool IsNullable { get; set; }
		public bool IsPk { get; set; }
		public bool IsIdentity { get; set; }
		public int Seq { get; set; }
		public bool Ignore { get; set; }
	}
}
