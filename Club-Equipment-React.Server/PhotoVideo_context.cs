using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Club_Equipment_React.Server
{
	public class PhotoVideo_context : DbContext
	{
		public DbSet<Device> photo_video { get; set; } = null!;

		public PhotoVideo_context(DbContextOptions<PhotoVideo_context> options) : base(options) { 
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=PH_Vid.db");
		}
	}
}
