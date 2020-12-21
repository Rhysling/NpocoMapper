using System;

namespace BotanicaStore.Services.FiltersAttributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class TypeScriptModelAttribute : Attribute
	{
		public string ExcludeMembersByName { get; set; }
		public string OptionalMembersByName { get; set; }
	}
}