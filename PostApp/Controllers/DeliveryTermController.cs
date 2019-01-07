using Microsoft.AspNetCore.Mvc;
using PostApp.Logic;
using System;
using System.Threading.Tasks;

namespace PostApp.Controllers
{
	#region Class : DeliveryTermController
	[Route("api/[controller]")]
    [ApiController]
    public class DeliveryTermController : ControllerBase
    {
		#region Fields : Private
		private IDeliveryTermsCalculator _deliveryTermsCalculator;
		#endregion

		#region Constructor
		public DeliveryTermController(IDeliveryTermsCalculator deliveryTermsCalculator)
			=> this._deliveryTermsCalculator = deliveryTermsCalculator;
		#endregion

		#region Public API
		public async Task<DateTime> Get(Guid fromCityId, Guid toCityId, DateTime sendingDate, Guid routeTypeId)
			=> await _deliveryTermsCalculator.CalculateAsync(fromCityId, toCityId, sendingDate, routeTypeId);
		#endregion
	}
	#endregion
}