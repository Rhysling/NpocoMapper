using System;
using System.Collections.Generic;
using BotanicaStore.Models.Core;

namespace BotanicaStore.Models
{
	public enum PlantStatusEnum
	{
	}

	public static partial class ApLists
	{
		public static List<NameValueItem> GetPlantStatusEnumList(string zeroItemText, string negOneItemText)
		{
			var lst = new List<NameValueItem>();
			if (!String.IsNullOrWhiteSpace(negOneItemText)) lst.Add(new NameValueItem { Name = negOneItemText, Value = "-1" });
			if (!String.IsNullOrWhiteSpace(zeroItemText)) lst.Add(new NameValueItem { Name = zeroItemText, Value = "0" });



			return lst;
		}

	}
}