using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;

namespace subway_project.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAnyOrigin", policy =>
				{
					policy.AllowAnyOrigin()   // Allow any origin
						.AllowAnyHeader()   // Allow any header
						.AllowAnyMethod();  // Allow any HTTP method (GET, POST, etc.)
				});
			});
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();
				DbSeeder.Seed(db);
			}

			app.UseDefaultFiles();
			app.MapStaticAssets();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			//<img :src="'https://yourapi.com' + product.ImageUrl" alt="Product Image">
			//https://localhost:5001/images/no-image-available.jpg
			app.UseStaticFiles();

			app.UseCors("AllowAnyOrigin");

			app.UseAuthorization();


			app.MapControllers();

			app.MapFallbackToFile("/index.html");
			Console.WriteLine("Program is about to run");
			Console.WriteLine("");



			app.Run();
		}
	}
}
