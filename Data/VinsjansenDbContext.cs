using Microsoft.EntityFrameworkCore;

namespace Vinsjansen.Data
{
	public class VinsjansenDbContext : DbContext
	{		
		public VinsjansenDbContext(DbContextOptions<VinsjansenDbContext> options) : base(options)
		{

		}
		public DbSet<Ticket> Tickets { get; set; }
	}
}
