using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Club_Equipment_React.Server
{
	public class Power_context : DbContext
	{
		public DbSet<Cable> powercons { get; set; } = null!;

		public Power_context(DbContextOptions<Power_context> options) : base(options) { 
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=PWR.db");
		}
	}
}
