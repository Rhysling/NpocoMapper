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
	[TypeScriptModel]
	[TableName("Crosses")]
	[PrimaryKey("CrossId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Cross : CrosseratorDB.Record<Cross>
	{
		private DateTime minDate = new DateTime(1910, 1, 1);

		[NPoco.Column]
		public int CrossId { get; set; }

		[NPoco.Column]
		[MustBeGreaterthanZero()]
		public int SeedPlantId { get; set; }

		[NPoco.Column]
		[MustBeGreaterthanZero()]
		public int PollenPlantId { get; set; }

		[NPoco.Column]
		public int CrossNumberYear { get; set; }

		[NPoco.Column]
		public int CrossNumber { get; set; }

		[NPoco.Column]
		public DateTime CrossDate { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string ThreadColor { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string CrossNotes { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string OutcomeNotes { get; set; }

		[NPoco.Column]
		public bool IsFailed { get; set; }

		[NPoco.Column]
		public bool IsDeleted { get; set; }

		[NPoco.Column]
		public DateTime CreateDate { get; set; }

		[NPoco.Column]
		public DateTime ModifiedDate { get; set; }


		public int GenusId { get; set; }

		[CurrentDateTime()]
		[Display(Name="Cross Date")]
		public string CrossDateDisp
		{
			get
			{
				return (this.CrossDate > minDate) ? this.CrossDate.ToShortDateString() : null;
			}

			set
			{
				DateTime d;
				if (DateTime.TryParse(value, out d))
				{
					this.CrossDate = d;
				}
				else
				{
					this.CrossDate = new DateTime(1900, 1, 1);
				}
			}
		}

		public string CreateDateDisp
		{
			get
			{
				return (this.CreateDate > minDate) ? this.CreateDate.ToShortDateString() + " - " + this.CreateDate.ToShortTimeString() : "not set";
			}
		}

		public string ModifiedDateDisp
		{
			get
			{
				return (this.ModifiedDate > minDate) ? this.ModifiedDate.ToShortDateString() + " - " + this.ModifiedDate.ToShortTimeString() : "not set";
			}
		}
	}
}
