using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostApp.Models.Database
{
	#region Class : City
	public class City : Lookup
	{
		[ForeignKey(nameof(Country))]
		public Guid? CountryId { get; set; }

		public Country Country { get; set; }
	}
	#endregion
}