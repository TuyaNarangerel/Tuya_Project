using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuya_Project1.Data;

namespace Tuya_Project1.Menu
{
	public class MainMenu
	{
		private readonly AppDbContext _context;

		public MainMenu(AppDbContext context)
		{
			_context = context;
		}
		public void Show()
		{
			bool running = true;
			while (running)
			{
				Console.Clear();
				Console.WriteLine("Main Menu");
				Console.WriteLine("1. Shapes");
				Console.WriteLine("2. Calculator");
				Console.WriteLine("3. Game");
				Console.WriteLine("0. Exit");

                Console.WriteLine("Please select an option: ");
                var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						var shapeMenu = new ShapeMenu(_context);
						shapeMenu.ShowMenu();
						break;
					case "2":
						var calculatorMenu = new CalculatorMenu(_context);
						calculatorMenu.ShowMenu();
						break;
					case "3":
						var gameMenu = new GameMenu(_context);
						gameMenu.ShowMenu();
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Invalid selection. Please try again.");
						break;
				}

                Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
            }
		}
	}
}

