﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NpocoMapper.Models
{
	public class EnumPocoProp
	{
		public int Id;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public string Name;
		public string Description;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	}
}
