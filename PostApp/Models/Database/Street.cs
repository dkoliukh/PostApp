using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostApp.Models.Database
{
	#region Class : Street
	public class Street : Lookup
	{
		[ForeignKey(nameof(City))]
		public Guid? CityId { get; set; }

		public City City { get; set; }
	}
	#endregion
}