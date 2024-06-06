using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Club_Equipment_React.Server
{
	public class SoundC_context : DbContext
	{
		public DbSet<Cable> sound_cables { get; set; } = null!;

		public SoundC_context(DbContextOptions<SoundC_context> options) : base(options) { 
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=snd_cable.db");
		}
	    public DbSet<Club_Equipment_React.Server.Models.Device> Device { get; set; } = default!;
	}
}
