using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using Crosserator.Models.Validators;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models
{
	[TableName("Plants")]
	[PrimaryKey("PlantId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Plant : CrosseratorDB.Record<Plant>
	{
		private DateTime minDate = new DateTime(1910, 1, 1);

		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		[Required()]
		[UniquePlantName()]
		public string PlantName { get; set; }

		[NPoco.Column]
		public int GenusId { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Photo { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Origin { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Sepals { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Reverse { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Nectaries { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Other { get; set; }

		[NPoco.Column]
		public int FormId { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string FormNote { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Foliage { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Notes { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string AcquiredFrom { get; set; }

		[NPoco.Column]
		public int PlantStatusId { get; set; }

		[NPoco.Column]
		public bool IsDeleted { get; set; }

		[NPoco.Column]
		public DateTime AcquiredDate { get; set; }

		[NPoco.Column]
		public DateTime CreateDate { get; set; }

		[NPoco.Column]
		public DateTime ModifiedDate { get; set; }


		[CurrentDateTime()]
		public string AcquiredDateDisp
		{
			get
			{
				return (this.AcquiredDate > minDate) ? this.AcquiredDate.ToShortDateString() : null;
			}

			set
			{
				DateTime d;
				if (DateTime.TryParse(value, out d))
				{
					this.AcquiredDate = d;
				}
				else
				{
					this.AcquiredDate = new DateTime(1900, 1, 1);
				}
			}
		}

		public string CreateDateDisp
		{
			get
			{
				return (this.CreateDate > minDate) ? this.CreateDate.ToShortDateString() + " - " + this.CreateDate.ToShortTimeString() : "new";
			}
		}

		public string ModifiedDateDisp
		{
			get
			{
				return (this.ModifiedDate > minDate) ? this.ModifiedDate.ToShortDateString() + " - " + this.ModifiedDate.ToShortTimeString() : "new";
			}
		}

	}
}
