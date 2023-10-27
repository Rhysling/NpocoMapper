using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpocoMapper.Demo.Models;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class TypeScriptModelAttribute : Attribute
{
	public string ExcludeMembersByName { get; set; } = "";
	public string OptionalMembersByName { get; set; } = "";
	public bool IsInterface { get; set; } = false;
}