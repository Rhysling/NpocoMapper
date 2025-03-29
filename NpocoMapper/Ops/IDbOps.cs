using NpocoMapper.Models;
using System.Collections.Generic;

namespace NpocoMapper.Ops;

public interface IDbOps
{
	List<Column> LoadColumns();
	List<EnumPocoProp> LoadEnumValues(EnumPoco enumPoco);
}