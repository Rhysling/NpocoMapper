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
	public enum PlantFormEnum
	{
				Undetermined = 0,
				Double = 1,
				SemiDouble = 2,
				Single = 3,
				Other = 99
	}


	public static partial class ApLists
	{
		public static List<NameValueItem> GetPlantFormEnumList(string zeroItemText, string negOneItemText)
		{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem { Name = negOneItemText, Value = "-1" });
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem { Name = zeroItemText, Value = "0" });

			lst.Add(new NameValueItem { Name = "Undetermined", Value = "0" });
			lst.Add(new NameValueItem { Name = "Double", Value = "1" });
			lst.Add(new NameValueItem { Name = "SemiDouble", Value = "2" });
			lst.Add(new NameValueItem { Name = "Single", Value = "3" });
			lst.Add(new NameValueItem { Name = "Other", Value = "99" });

			return lst;
		}

		public static List<SelectListItem> GetPlantFormEnumPocoSL(string zeroItemText, string negOneItemText)
		{
			return GetPlantFormEnumList(zeroItemText, negOneItemText).Select(a => new System.Web.Mvc.SelectListItem { Value = a.Value, Text = a.Name }).ToList();
		}
	}
}
