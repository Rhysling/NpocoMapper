
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("ResourceItems")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class ResourceItem
	{
		[NPoco.Column]
		public int ItemId { get; set; }
		[NPoco.Column]
		public string? KeyString { get; set; }
		[NPoco.Column]
		public string? Description { get; set; }
		[NPoco.Column]
		public string? FileName { get; set; }
		[NPoco.Column]
		public string? FileType { get; set; }
		[NPoco.Column]
		public byte[]? FileData { get; set; }
		[NPoco.Column]
		public int? FileDataByteLength { get; set; }
		[NPoco.Column]
		public string? FileSize { get; set; }
		[NPoco.Column]
		public int? IconGroup { get; set; }
		[NPoco.Column]
		public DateTime? LastUpdate { get; set; }
		[NPoco.Column]
		public int? UpdatedBy { get; set; }
		[NPoco.Column]
		public bool? IsDeleted { get; set; }

	}
}