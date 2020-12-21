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
	public enum PlantStatusEnum
	{
				Live = 1,
				Sold = 2,
				Dead = 3
	}


	public static partial class ApLists
	{
		public static List<NameValueItem> GetPlantStatusEnumList(string zeroItemText, string negOneItemText)
		{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem { Name = negOneItemText, Value = "-1" });
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem { Name = zeroItemText, Value = "0" });

			lst.Add(new NameValueItem { Name = "Live", Value = "1" });
			lst.Add(new NameValueItem { Name = "Sold", Value = "2" });
			lst.Add(new NameValueItem { Name = "Dead", Value = "3" });

			return lst;
		}

		public static List<SelectListItem> GetPlantStatusEnumPocoSL(string zeroItemText, string negOneItemText)
		{
			return GetPlantStatusEnumList(zeroItemText, negOneItemText).Select(a => new System.Web.Mvc.SelectListItem { Value = a.Value, Text = a.Name }).ToList();
		}
	}
}
