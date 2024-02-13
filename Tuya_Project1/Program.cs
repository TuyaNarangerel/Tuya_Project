using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tuya_Project1.Data;
using Tuya_Project1.Menu;

namespace Tuya_Project1
{
	public class Program
	{
		static void Main()
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			var startUp = new StartUp(configuration);
			var services = new ServiceCollection();
			startUp.ConfigureServices(services);

			var serviceProvider = services.BuildServiceProvider();	

			var mainMenu = new MainMenu(serviceProvider.GetRequiredService<AppDbContext>());
			mainMenu.Show();
			}
		}
	}
