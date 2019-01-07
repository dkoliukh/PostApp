using Microsoft.AspNetCore.Mvc;
using PostApp.Models;

namespace PostApp.Controllers
{
	#region Class : BaseEntityController
	[ApiController]
    public class BaseEntityController : ControllerBase
    {
		#region Properties : Protected
		protected virtual AppDbContext AppDbContext { get; }
		#endregion

		#region Constructor
		public BaseEntityController(AppDbContext context)
			=> this.AppDbContext = context;
		#endregion
	}
	#endregion
}