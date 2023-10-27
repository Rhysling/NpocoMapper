using System;
using NPoco;

namespace BotanicaStore.Models
{
	[TableName("DummyTestTable")][PrimaryKey("FirstKey,SecondKey", AutoIncrement = false)]
	[ExplicitColumns]
	[TypeScriptModel]
	public partial class DummyTestTable
	{
		[NPoco.Column]
		public int FirstKey { get; set; }
		[NPoco.Column]
		public string SecondKey { get; set; } = "";
		[NPoco.Column]
		public DateTime LastThing { get; set; }
		[NPoco.Column]
		public string? Info { get; set; }
		[NPoco.Column]
		public string? MoreStuff { get; set; }
		[NPoco.Column]
		public byte[] ByteThing { get; set; }
		[NPoco.Column]
		public byte[]? BigByteThing { get; set; }

	}
}