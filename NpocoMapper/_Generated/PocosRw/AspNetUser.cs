using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using NPoco;

namespace Crosserator.Models
{
	[TableName("AspNetUsers")]
	[PrimaryKey("Id", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class AspNetUser : CrosseratorDB.Record<AspNetUser>, IUser<int>
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Email { get; set; }

		[NPoco.Column]
		public bool EmailConfirmed { get; set; }

		[NPoco.Column]
		public string PasswordHash { get; set; }

		[NPoco.Column]
		public string SecurityStamp { get; set; }

		[NPoco.Column]
		public string PhoneNumber { get; set; }

		[NPoco.Column]
		public bool PhoneNumberConfirmed { get; set; }

		[NPoco.Column]
		public bool TwoFactorEnabled { get; set; }

		[NPoco.Column]
		public DateTime? LockoutEndDateUtc { get; set; }

		[NPoco.Column]
		public bool LockoutEnabled { get; set; }

		[NPoco.Column]
		public int AccessFailedCount { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string UserName { get; set; }

	}
}
