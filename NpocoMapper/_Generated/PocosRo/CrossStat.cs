using NPoco;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models
{
	[TypeScriptModel]
	[TableName("CrossStats")]
	[ExplicitColumns]
	public partial class CrossStat : CrosseratorDB.Record<CrossStat>
	{
		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		public string Genus { get; set; }

		[NPoco.Column]
		public int CrossNumberYear { get; set; }

		[NPoco.Column]
		public int OkCount { get; set; }

		[NPoco.Column]
		public int FailedCount { get; set; }
	}
}
