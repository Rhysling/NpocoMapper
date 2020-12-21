using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;

namespace Crosserator.Models
{
	[TableName("AspNetUserClaims")]
	[PrimaryKey("Id", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class AspNetUserClaim : CrosseratorDB.Record<AspNetUserClaim>
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		[Required()]
		public int UserId { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string ClaimType { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string ClaimValue { get; set; }

	}
}
