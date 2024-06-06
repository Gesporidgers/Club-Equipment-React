using Club_Equipment_React.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Club_Equipment_React.Server
{
	public class VideoCable_context : DbContext
	{
		public DbSet<Cable> video_cables { get; set; } = null!;

		public VideoCable_context(DbContextOptions<VideoCable_context> options) : base(options) {
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=VideoCbl.db");
		}
	}
}
