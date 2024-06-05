using Microsoft.EntityFrameworkCore;

namespace Club_Equipment_React.Server
{
	public class AD_context : DbContext
	{
		public DbSet<AudioD> audio_devices { get; set; } = null!;

		public AD_context(DbContextOptions<AD_context> options) : base(options) {
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=Audio.db");
		}
	}
}
