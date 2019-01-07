using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostApp.Controllers
{
	#region Class : ContactController
	[Route("api/contact")]
	[ApiController]
	public class ContactController : BaseEntityController
	{
		#region Constructor
		public ContactController(AppDbContext context) : base(context) { }
		#endregion

		#region Public API
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Contact>>> Get()
			=> await AppDbContext.Contact.ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<Contact>> Get(Guid id)
		{
			Contact contact = await AppDbContext.Contact.FindAsync(id);
			if (contact == null)
				return NotFound();
			return contact;
		}

		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		#endregion
	}
	#endregion
}