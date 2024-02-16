using Microsoft.EntityFrameworkCore;
using Tuya_Project1.Data;
using Tuya_Project1.Menu;

public class Application
{
	private readonly AppDbContext _context;

	public Application(AppDbContext context)
	{
		_context = context;
	}

	public void Run()
	{
		InitializeDatabase();

		var mainMenu = new MainMenu(_context);
		mainMenu.Show();
	}

	private void InitializeDatabase()
	{

		_context.Database.Migrate();
		var dataInitializer = new DataInitializer();
		dataInitializer.MigrateAndSeed(_context);
	}
}