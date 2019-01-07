using System;
using System.Threading.Tasks;

namespace PostApp.Logic
{
	public class DeliveryTermsCalculator : IDeliveryTermsCalculator
	{
		public DateTime Calculate(Guid fromCityId, Guid toCityId, DateTime sendingDate, Guid routeTypeId)
		{
			throw new NotImplementedException();
		}

		public async Task<DateTime> CalculateAsync(Guid fromCityId, Guid toCityId, DateTime sendingDate, Guid routeTypeId)
		{
			throw new NotImplementedException();
		}
	}
}