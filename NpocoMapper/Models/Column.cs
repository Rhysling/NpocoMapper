using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Models
{
	public class Column
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public bool IsIdentity { get; set; }
		public bool IsComputed { get; set; }

	}
}
