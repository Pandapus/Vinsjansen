using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vinsjansen.Data
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly IDbContextFactory<VinsjansenDbContext> _dbContextFactory;

		public TicketController(IDbContextFactory<VinsjansenDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		// GET: api/<TicketController>
		[HttpGet]
		public async Task<ActionResult<List<Ticket>>> Get()
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				var tickets = context.Tickets.ToList();
				return tickets;
			}
		}

		// GET api/<TicketController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<TicketController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<TicketController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<TicketController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
