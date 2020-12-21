using System;
using System.ComponentModel.DataAnnotations;
using NPoco;
using Microsoft.AspNet.Identity;

namespace Crosserator.Models
{
	[TableName("AspNetRoles")]
	[PrimaryKey("Id", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class AspNetRole : CrosseratorDB.Record<AspNetRole>, IRole<int>
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		[Required()]
		public string Name { get; set; }

	}
}
