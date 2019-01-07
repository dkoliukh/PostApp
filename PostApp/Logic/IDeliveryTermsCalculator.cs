using System;
using System.Threading.Tasks;

namespace PostApp.Logic
{
	public interface IDeliveryTermsCalculator
	{
		DateTime Calculate(Guid fromCityId, Guid toCityId, DateTime sendingDate, Guid routeTypeId);

		Task<DateTime> CalculateAsync(Guid fromCityId, Guid toCityId, DateTime sendingDate, Guid routeTypeId);
	}
}
