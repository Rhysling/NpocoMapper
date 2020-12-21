using NPoco;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models
{
	[TypeScriptModel]
	[TableName("SeedPlantStats")]
	[ExplicitColumns]
	public partial class SeedPlantStat : CrosseratorDB.Record<SeedPlantStat>
	{
		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		public string Genus { get; set; }

		[NPoco.Column]
		public int Live { get; set; }

		[NPoco.Column]
		public int Sold { get; set; }

		[NPoco.Column]
		public int Dead { get; set; }

		[NPoco.Column]
		public int LivePics { get; set; }

		[NPoco.Column]
		public int SoldPics { get; set; }

		[NPoco.Column]
		public int DeadPics { get; set; }
	}
}
