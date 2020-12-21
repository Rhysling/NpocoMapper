using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models
{
	[TypeScriptModel]
	[TableName("PlantDetail")]
	[ExplicitColumns]
	public partial class PlantDetail : Plant
	{
		public PlantDetail()
		{
			PictureIds = "";
		}

		[NPoco.Column]
		public string PictureIds { get; set; }

		[NPoco.Column]
		public int CrossCount { get; set; }

		[NPoco.Column]
		public int PollenCount { get; set; }


		public int[] PictureIdsArray
		{
			get
			{
				if (String.IsNullOrWhiteSpace(PictureIds))
					return new int[0];

				return PictureIds.Split(',').Select(a => Int32.Parse(a)).ToArray();
			}
		}
	}
}
