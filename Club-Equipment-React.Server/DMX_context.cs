using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Club_Equipment_React.Server
{
	public class DMX_context : DbContext
	{
		public DbSet<Cable> cables_dmx { get; set; } = null!;

		public DMX_context(DbContextOptions<DMX_context> options) : base(options) { 
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=DMX.db");
		}
	}
}
