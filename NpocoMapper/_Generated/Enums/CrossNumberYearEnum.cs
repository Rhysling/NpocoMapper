using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Crosserator.Models.Core;

namespace Crosserator.Models
{
	//public enum CrossNumberYearEnum
	//{
	//			Empty = 0,
	//			Yr2010 = 2010,
	//			Yr2011 = 2011,
	//			Yr2012 = 2012,
	//			Yr2013 = 2013,
	//			Yr2014 = 2014,
	//			Yr2015 = 2015,
	//			Yr2016 = 2016
	//}


	public static partial class ApLists
	{
		public static List<NameValueItem> GetCrossNumberYearEnumList()
		{
			var lst = new List<NameValueItem>();

			var yrs = Enumerable.Range(2010, DateTime.Now.Year - 2009).OrderByDescending(a => a).Select(a => new NameValueItem { Name = "Yr" + a.ToString(), Value = a.ToString() });
			lst.AddRange(yrs);

			lst.Add(new NameValueItem { Name = "Empty", Value = "0" });

			return lst;
		}

		public static List<SelectListItem> GetCrossNumberYearEnumPocoSL()
		{
			return GetCrossNumberYearEnumList().Select(a => new System.Web.Mvc.SelectListItem { Value = a.Value, Text = a.Name }).ToList();
		}
	}
}
