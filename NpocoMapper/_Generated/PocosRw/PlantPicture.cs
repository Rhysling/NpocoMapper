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
	[TableName("PlantPictures")]
	[PrimaryKey("Id", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class PlantPicture : CrosseratorDB.Record<PlantPicture>, Repositories.Core.IIdentity
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public bool IsDeleted { get; set; }

	}
}
