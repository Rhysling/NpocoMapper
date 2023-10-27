using System;
using System.Collections.Generic;
using NpocoMapper.Demo.Models;

namespace NpocoMapper.Demo.Models
{
	public enum PlantStatusEnum
	{
		Live = 1,
		Sold = 2,
		Dead = 3,
		Missing = 4
	}

	public static partial class ApLists
	{
		public static List<NameValueItem> GetPlantStatusEnumList(string zeroItemText, string negOneItemText)
		{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem { Name = negOneItemText, Value = "-1" });
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem { Name = zeroItemText, Value = "0" });

			lst.Add(new NameValueItem { Name = "Live",Value = "1" });
			lst.Add(new NameValueItem { Name = "Sold",Value = "2" });
			lst.Add(new NameValueItem { Name = "Dead",Value = "3" });
			lst.Add(new NameValueItem { Name = "Missing",Value = "4" });


			return lst;
		}

	}
}