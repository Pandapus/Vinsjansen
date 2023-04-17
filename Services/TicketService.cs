using Microsoft.EntityFrameworkCore;
using Vinsjansen.Data;

namespace Vinsjansen.Services
{
	public class TicketService
	{
		private IDbContextFactory<VinsjansenDbContext> _dbContextFactory;

		public TicketService(IDbContextFactory<VinsjansenDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<List<Ticket>>  GetAllTickets()
		{
			using (var context = _dbContextFactory.CreateDbContext())
			{
				var tickets = context.Tickets.ToList();
				return tickets;
			}
		}

		public void BuyTickets(string name, List<int> tickets)
		{
			if (name == null)
			{
				throw new Exception("Inget navn oppgitt");
			}

			using (var context = _dbContextFactory.CreateDbContext())
			{
				foreach (var ticket in tickets)
				{
					var ticketToBuy = context.Tickets.SingleOrDefault(t => t.Id == ticket);
					if (ticketToBuy != null)
					{
						ticketToBuy.Owner = name;
						ticketToBuy.IsTaken = true;
					}
					context.Update(ticketToBuy);
				}
				context.SaveChanges();
			}
		}
	}
}
