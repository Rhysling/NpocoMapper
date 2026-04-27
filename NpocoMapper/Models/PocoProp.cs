namespace NpocoMapper.Models;

public class PocoProp
{
	public required string PropName { get; set; }
	public required string PropType { get; set; }
	//public string TsType { get; set; }
	public bool IsNullable { get; set; }
	public bool IsPk { get; set; }
	public bool IsIdentity { get; set; }
	public int Seq { get; set; }
	public bool Ignore { get; set; }
}
