namespace NpocoMapper.Models;

public class PocoProp
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	public string PropName { get; set; }
	public string PropType { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	//public string TsType { get; set; }
	public bool IsNullable { get; set; }
	public bool IsPk { get; set; }
	public bool IsIdentity { get; set; }
	public int Seq { get; set; }
	public bool Ignore { get; set; }
}
