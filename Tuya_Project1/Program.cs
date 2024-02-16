using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tuya_Project1.Data;
using Tuya_Project1;
using Microsoft.EntityFrameworkCore;

class Program
{
	static void Main()
	{
		var configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		var services = new ServiceCollection();
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		services.AddTransient<Application>();

		var serviceProvider = services.BuildServiceProvider();
				
		var app = serviceProvider.GetService<Application>();
		app.Run();
	}
}