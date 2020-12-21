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
	[TableName("Keys")]
	[PrimaryKey("KeyId", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class Key : CrosseratorDB.Record<Key>
	{
		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string KeyId { get; set; }

		[NPoco.Column]
		[StringLength(4095)]
		[Required()]
		public string Value { get; set; }

	}
}
