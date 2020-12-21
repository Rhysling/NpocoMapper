using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;

namespace Crosserator.Models
{
	[TableName("AspNetUserLogins")]
	[PrimaryKey("LoginProvider,ProviderKey,UserId")]
	[ExplicitColumns]
	public partial class AspNetUserLogin : CrosseratorDB.Record<AspNetUserLogin>
	{
		[NPoco.Column]
		[StringLength(127)]
		public string LoginProvider { get; set; }

		[NPoco.Column]
		[StringLength(127)]
		public string ProviderKey { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

	}
}
