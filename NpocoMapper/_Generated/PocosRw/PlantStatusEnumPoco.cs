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
	[TableName("PlantStatusEnum")]
	[PrimaryKey("Id", false)]
	[ExplicitColumns]
	public partial class PlantStatusEnumPoco : CrosseratorDB.Record<PlantStatusEnumPoco>, Repositories.Core.IKeyed<int>
	{
		[NPoco.Column] 
		public int Id { get; set; }
		
		[NPoco.Column] 
		[StringLength(50)]
		[Required()]
		public string Name { get; set; }
		
		[NPoco.Column] 
		[StringLength(50)]
		public string Description { get; set; }
		
	}
}
