

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using Crosserator.Models.Core;

namespace Crosserator.Models
{
	public enum GeneraEnum
	{
				Hellebore = 1,
				Cyclamen = 2,
				Lilium = 3,
				Primula = 4,
				misc = 5,
				Trillium = 6,
				Hepatica = 7,
				Iris = 8
	}


	public static partial class ApLists
	{
		public static List<NameValueItem> GetGeneraEnumList(string zeroItemText, string negOneItemText)
		{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem { Name = negOneItemText, Value = "-1" });
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem { Name = zeroItemText, Value = "0" });

			lst.Add(new NameValueItem { Name = "Hellebore", Value = "1" });
			lst.Add(new NameValueItem { Name = "Cyclamen", Value = "2" });
			lst.Add(new NameValueItem { Name = "Lilium", Value = "3" });
			lst.Add(new NameValueItem { Name = "Primula", Value = "4" });
			lst.Add(new NameValueItem { Name = "misc", Value = "5" });
			lst.Add(new NameValueItem { Name = "Trillium", Value = "6" });
			lst.Add(new NameValueItem { Name = "Hepatica", Value = "7" });
			lst.Add(new NameValueItem { Name = "Iris", Value = "8" });

			return lst;
		}

		public static List<SelectListItem> GetGeneraEnumPocoSL(string zeroItemText, string negOneItemText)
		{
			return GetGeneraEnumList(zeroItemText, negOneItemText).Select(a => new System.Web.Mvc.SelectListItem { Value = a.Value, Text = a.Name }).ToList();
		}

		
	}
}
