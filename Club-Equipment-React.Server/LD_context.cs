//using Microsoft.EntityFrameworkCore.Sqlite;
using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Club_Equipment_React.Server
{
    public class LD_context : DbContext
	{
		public DbSet<Device> light_devices { get; set; } = null!;

		public LD_context(DbContextOptions<LD_context> options) : base(options) { 
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=Light.db");
		}
	}
}