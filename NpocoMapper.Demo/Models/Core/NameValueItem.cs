using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NpocoMapper.Demo.Models
{
	[TypeScriptModel]
	public class NameValueItem
	{
		public string Name { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
	}
}