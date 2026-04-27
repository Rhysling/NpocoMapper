namespace NpocoMapper.Models;

public class Column
{
	public required string EntityName { get; set; }
	public required string EntityType { get; set; }
	public int ColumnSeq { get; set; }
	public required string ColumnName { get; set; }
	public required string SqlDataType { get; set; }
	public bool IsNullable { get; set; }
	public int MaxLength { get; set; }
	public int Precision { get; set; }
	public bool IsPk { get; set; }
	public required string ConstraintName { get; set; }
	public bool IsIdentity { get; set; }
	public bool IsComputed { get; set; }

}
