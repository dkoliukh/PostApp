using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostApp.Models.Database
{
	#region Class : Address
	public class Address : Lookup
	{
		#region Properties : Database
		public string Building { get; set; }

		[ForeignKey(nameof(Country))]
		public Guid? CountyId { get; set; }

		[ForeignKey(nameof(City))]
		public Guid? CityId { get; set; }

		[ForeignKey(nameof(Street))]
		public Guid? StreetId { get; set; }
		#endregion

		public Country Country { get; set; }

		public City City { get; set; }

		public Street Street { get; set; }
	}
	#endregion
}