
using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("Keys")]
	[PrimaryKey("KeyName", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class Key
	{
		[NPoco.Column]
		public string KeyName { get; set; }
		[NPoco.Column]
		public string? KeyValue { get; set; }

	}
}