using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace Club_Equipment_React.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<LD_context>(options => options.UseSqlite("Data Source = Light.db"));
			builder.Services.AddDbContext<AD_context>(options => options.UseSqlite("Data Source = Audio.db"));
			builder.Services.AddDbContext<PhotoVideo_context>(options => options.UseSqlite("Data Source = PH_Vid.db"));
			builder.Services.AddDbContext<Power_context>(options => options.UseSqlite("Data Source = PWR.db"));
			builder.Services.AddDbContext<DMX_context>(options => options.UseSqlite("Data Source = DMX.db"));
			builder.Services.AddDbContext<SoundC_context>(options => options.UseSqlite("Data Source = snd_cable.db"));
			builder.Services.AddDbContext<VideoCable_context>(options => options.UseSqlite("Data Source = VideoCbl.db"));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();
			
			app.MapFallbackToFile("/index.html");

			app.Run();
		}
	}
}
