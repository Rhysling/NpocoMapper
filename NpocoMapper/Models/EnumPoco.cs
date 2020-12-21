using System;
using System.Collections.Generic;
using System.Text;

namespace NpocoMapper.Models
{
	public class EnumPoco
	{
		public EnumPoco()
		{
			IdColumnName = "Id";
			NameColumnName = "Name";
			DescriptionColumnName = "Description";
		}

		public string EntityName { get; set; }
		public string EnumName { get; set; }
		public string IdColumnName { get; set; }
		public string NameColumnName { get; set; }
		public string DescriptionColumnName { get; set; }
		public List<EnumPocoProp> Values { get; set; }
	}
}
