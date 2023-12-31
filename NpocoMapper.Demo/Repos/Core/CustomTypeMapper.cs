﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FalahCapital2.Models.Core;

namespace FalahCapital2.Repositories.Core
{
	public class CustomTypeMapper : NPoco.DefaultMapper
	{
		// Mapper exmple

		public override Func<object, object> GetFromDbConverter(Type DestType, Type SourceType)
		{
			if (DestType == typeof(SampleCustomType))
			{
				return x => new SampleCustomType((DateTime)x);
			}
			return base.GetFromDbConverter(DestType, SourceType);
		}

		public override Func<object, object> GetToDbConverter(Type DestType, Type SourceType)
		{
			if (SourceType == typeof(SampleCustomType))
			{
				return x => ((SampleCustomType)x).Value;
			}
			return base.GetToDbConverter(DestType, SourceType);
		}
	}
}
