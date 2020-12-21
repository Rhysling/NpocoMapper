
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("ResourceIcons")]
	[PrimaryKey("FileType", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class ResourceIcon
	{
		[NPoco.Column]
		public string FileType { get; set; }
		[NPoco.Column]
		public int IconGroup { get; set; }

	}
}