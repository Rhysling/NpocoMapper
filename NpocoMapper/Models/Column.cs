using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Models
{
	public class Column
	{
		public string EntityName { get; set; }
		public string EntityType { get; set; }
		public int ColumnSeq { get; set; }
		public string ColumnName { get; set; }
		public string SqlDataType { get; set; }
		public bool IsNullable { get; set; }
		public int MaxLength { get; set; }
		public int Precision { get; set; }
		public bool IsPk { get; set; }
		public string ConstraintName { get; set; }
		public bool IsIdentity { get; set; }
		public bool IsComputed { get; set; }

	}
}
