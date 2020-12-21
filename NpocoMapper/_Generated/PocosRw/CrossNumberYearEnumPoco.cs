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
	[TableName("CrossNumberYearEnum")]
	[PrimaryKey("Id", false)]
	[ExplicitColumns]
	public partial class CrossNumberYearEnumPoco : CrosseratorDB.Record<CrossNumberYearEnumPoco>, Repositories.Core.IKeyed<int>
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
