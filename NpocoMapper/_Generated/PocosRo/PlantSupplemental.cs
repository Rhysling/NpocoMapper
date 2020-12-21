using NPoco;

namespace Crosserator.Models
{
	[TableName("PlantSupplemental")]
	[ExplicitColumns]
	public partial class PlantSupplemental : CrosseratorDB.Record<PlantSupplemental>
	{
		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public string PlantName { get; set; }

		[NPoco.Column]
		public bool IsDeletedPlant { get; set; }

		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		public string GenusName { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public string DisplayName { get; set; }

	}
}
