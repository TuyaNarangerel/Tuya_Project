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
						Console.WriteLine("Invalid selection. Please try again.");
						break;
				}

				if (running)
				{
					Console.WriteLine("Press any key to continue...");
					
				}
			}
		}
			private void PlayStenSaxPåse()
			{
				Console.WriteLine("Choose Sten, Sax, or Påse: ");
				string userChoice = Console.ReadLine()?.ToLower();
				string computerChoice = GetComputerChoice();

				Console.WriteLine($"Computer choose {computerChoice}");

				string result = DetermineWinner(userChoice, computerChoice);
				Console.WriteLine(result);

				SaveStenSaxPåseGame(userChoice, computerChoice, result);

				
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}

		private void ShowAllGames()
		{
			var games = _context.StenSaxPåseGames.ToList();
			if (!games.Any())
			{
				Console.WriteLine("No games found.");
				return;
			}

			Console.WriteLine($"{"Player's Choice",-15} {"Computer's Choice",-18} {"Outcome",-12} {"Date",-20}");
			Console.WriteLine(new string('-', 72));

			foreach (var game in games)
			{
				Console.WriteLine($"{game.PlayerChoice,-15} {game.ComputerChoice,-18} {game.Outcome,-12} {game.GameDate.ToString("dd/MM/yyyy HH:mm:ss"),-20}");
			}

			CalculateAndDisplayWinRates(games);

			Console.WriteLine("Press any key to return the menu...");
			Console.ReadKey();

		}

		private void CalculateAndDisplayWinRates(List<StenSaxPåse> games)

		{ 
			int playerWins = games.Count(game => game.Outcome == "You win!");
			int computerWins = games.Count(game => game.Outcome.Contains("Computer wins"));
			int totalGames = games.Count;

			double averageWinRateAgainstComputer = playerWins / (double)totalGames;
			double averageWinRateAgainstPlayer = computerWins / (double)totalGames;

			Console.WriteLine($"\nAverage win rate against the computer: {averageWinRateAgainstComputer:P}");
			Console.WriteLine($"Average win rate against the player: {averageWinRateAgainstPlayer:P}");

        }

			private string GetComputerChoice()
			{
				int choice = _random.Next(3);
				switch (choice)
				{
					case 0:
						return "sten";
					case 1:
						return "sax";
					case 2:
						return "påse";
					default:
						return "sten";
				}
			}

			private string DetermineWinner(string user, string computer)
			{
				if (user == computer)
				{
					return "It's a Tie!";
				}

				string winningOutcome;
				if (_winningOutComes.TryGetValue(user, out winningOutcome))
				{
					if (computer == winningOutcome)
					{
						return "You win!";
					}
				}

				return "Computer wins!";
			}

			private void SaveStenSaxPåseGame(string playerChoice, string computerChoice, string outcome)
			{
				var game = new StenSaxPåse
				{
					PlayerChoice = playerChoice,
					ComputerChoice = computerChoice,
					Outcome = outcome,
					GameDate = DateTime.Now,
				};

				_context.StenSaxPåseGames.Add(game);
				_context.SaveChanges();

				Console.WriteLine("Game result saved in the database.");
			}
		}
	}
