using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("Links")][PrimaryKey("LinkId", AutoIncrement = true)]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class Link
	{
		[NPoco.Column]
		public int LinkId { get; set; }
		[NPoco.Column]
		public string Title { get; set; } = "";
		[NPoco.Column]
		public string Description { get; set; } = "";
		[NPoco.Column]
		public string Url { get; set; } = "";
		[NPoco.Column]
		public int SortOrder { get; set; }
		[NPoco.Column]
		public bool IsDeleted { get; set; }

	}
}