using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using PostApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostApp.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : BaseEntityController
    {
		#region Constructor
		public PaymentCardController(AppDbContext context) : base(context) { }
		#endregion

		#region Public API
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PaymentCard>>> Get()
			=> await AppDbContext.PaymentCard.Include(x => x.PaymentSystem).ToListAsync();
		

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PaymentCard>> Get(Guid id)
        {
			PaymentCard paymentCard = await AppDbContext.PaymentCard.FindAsync(id);
			if (paymentCard == null)
				return NotFound();
			return paymentCard;
		}
		
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaymentCard paymentCard)
        {
			AppDbContext.Entry(paymentCard.PaymentSystem).State = EntityState.Unchanged;
			await AppDbContext.PaymentCard.AddAsync(paymentCard);
			try
			{
				await AppDbContext.SaveChangesAsync();
				return Created(paymentCard.Id.ToString(), paymentCard);
			}
			catch (Exception ex)
			{
				Response.StatusCode = 500;
				return new JsonResult(new BaseErrorResponse
				{
					ErrorMessage = ex.Message,
					StackTrace = ex.StackTrace
				});
			}
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] PaymentCard value)
        {
			AppDbContext.PaymentCard.Update(value);
			return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
			PaymentCard paymentCard = await AppDbContext.PaymentCard.FindAsync(id);
			if (paymentCard == null)
				return NotFound();
			AppDbContext.PaymentCard.Remove(paymentCard);
			return Ok();
        }
		#endregion
	}
}