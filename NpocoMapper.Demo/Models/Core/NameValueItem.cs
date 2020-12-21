using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotanicaStore.Services.FiltersAttributes;

namespace BotanicaStore.Models.Core
{
	[TypeScriptModel]
	public class NameValueItem
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}