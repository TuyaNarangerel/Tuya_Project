using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuya_Project1.Data;

namespace Tuya_Project1.Data
{
	public class GameMenu
	{
		private readonly AppDbContext _context;
		private readonly Random _random = new Random();

		private readonly Dictionary<string, string> _winningOutComes = new Dictionary<string, string>
		{
			{"sten", "sax"},
			{"sax", "påse"},
			{"påse", "sten"},
		};

		public GameMenu(AppDbContext context)
		{
			_context = context;
		}

		public void ShowMenu()
		{
			bool running = true;
			while (running)
			{
				Console.Clear();
				Console.WriteLine("Game Menu");
				Console.WriteLine("(Sten vinner över sax, sax vinner över påse och påse vinner över sten.)");

				Console.WriteLine("1. Play Sten Sax Påse");
				Console.WriteLine("2. Show All Games");
				Console.WriteLine("3. Back to Main Menu");
				Console.WriteLine("0. Exit");

				Console.WriteLine("Please select an option: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						PlayStenSaxPåse();
						break;
					case "2":
						ShowAllGames();
						break;
					case "3":
						running = false;
						break;
					case "0":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Whoops! Seems like that wasn't the right choice. Let's give it another shot, shall we?");
						break;
				}

				if (running)
				{
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}
		}

		private void PlayStenSaxPåse()
		{
			Console.Clear();
			Console.WriteLine("Choose Sten, Sax, or Påse:");
			Console.WriteLine("1. Sten");
			Console.WriteLine("2. Sax");
			Console.WriteLine("3. Påse");

			var playerChoice = Console.ReadLine();

			if (!int.TryParse(playerChoice, out int choiceNumber) || choiceNumber < 1 || choiceNumber > 3)
			{
				Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
				return;
			}

			string[] choices = { "Sten", "Sax", "Påse" };
			string playerChoiceString = choices[choiceNumber - 1];

			string[] computerChoices = { "Sten", "Sax", "Påse" };
			Random random = new Random();
			int computerChoiceIndex = random.Next(computerChoices.Length);
			string computerChoice = computerChoices[computerChoiceIndex];

			string outcome = DetermineOutcome(playerChoiceString, computerChoice);

			SaveGame(playerChoiceString, computerChoice, outcome);

			Console.WriteLine($"Player choice: {playerChoiceString}");
			Console.WriteLine($"Computer choice: {computerChoice}");
			Console.WriteLine($"Outcome: {outcome}");
		}

		private string DetermineOutcome(string playerChoice, string computerChoice)
		{
			if ((playerChoice == "Sten" && computerChoice == "Sax") ||
				(playerChoice == "Sax" && computerChoice == "Påse") ||
				(playerChoice == "Påse" && computerChoice == "Sten"))
			{
				return "Player wins!";
			}
			else if ((computerChoice == "Sten" && playerChoice == "Sax") ||
					 (computerChoice == "Sax" && playerChoice == "Påse") ||
					 (computerChoice == "Påse" && playerChoice == "Sten"))
			{
				return "Computer wins!";
			}
			else
			{
				return "It's a draw!";
			}
		}

		private void SaveGame(string playerChoice, string computerChoice, string outcome)
		{
			var game = new StenSaxPåse
			{
				PlayerChoice = playerChoice,
				ComputerChoice = computerChoice,
				Outcome = outcome,
				GameDate = DateTime.Now
			};

			_context.StenSaxPåseGames.Add(game);
			_context.SaveChanges();
		}

		private void ShowAllGames()
		{
			var games = _context.StenSaxPåseGames.ToList();

			Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-15} {4,-20}", "Id", "Player Choice", "Computer Choice", "Outcome", "Date");
			Console.WriteLine("------------------------------------------------------------------");

			foreach (var game in games)
			{
				Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-15} {4,-20}",
					game.Id,
					game.PlayerChoice,
					game.ComputerChoice,
					game.Outcome,
					game.GameDate.ToString("yyyy-MM-dd HH:mm:ss"));
			}

			if (!games.Any())
			{
				Console.WriteLine("No games found.");
			}
		}
	}
}
