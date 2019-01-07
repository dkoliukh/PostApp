using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostApp.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class LookupController : BaseEntityController
    {
		#region Constructor
		public LookupController(AppDbContext context) : base(context) { }
		#endregion

		// GET: api/Lookup
		[HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Lookup>>> Get(string name)
        {
			DbSet<Lookup> lookupValues = AppDbContext.GetLookupByName(name);
			if (lookupValues == null)
				return NotFound();
			return await lookupValues?.ToListAsync();
        }

        // GET: api/Lookup/5
        [HttpGet("{name}/{id}", Name = "LookupGet")]
        public string Get(string name, int id)
        {
            return "value";
        }

        // POST: api/Lookup
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Lookup/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
