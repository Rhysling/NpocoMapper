using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;

namespace Crosserator.Models
{
	[TableName("AspNetUserRoles")]
	[PrimaryKey("UserId,RoleId", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class AspNetUserRole : CrosseratorDB.Record<AspNetUserRole>
	{
		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public int RoleId { get; set; }

	}
}
