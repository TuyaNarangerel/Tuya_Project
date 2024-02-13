using System;
using System.Linq;
using System.Threading.Channels;
using Microsoft.IdentityModel.Tokens;
using Tuya_Project1.Data;

namespace Tuya_Project1.Menu
{
	public class CalculatorMenu
	{
		private readonly AppDbContext _context;

		public CalculatorMenu(AppDbContext context)
		{
			_context = context;
		}

		public void ShowMenu()
		{
			bool running = true;
			while (running)
			{
				Console.Clear();
				Console.WriteLine("CALCULATOR MENU");
				Console.WriteLine("1. Create Calculation");
				Console.WriteLine("2. Read Calculations");
				Console.WriteLine("3. Update Calculation");
				Console.WriteLine("4. Delete Calculation");
				Console.WriteLine("0. Back to main menu");

				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						CreateCalculation();
						break;
					case "2":
						ShowAllCalculations();
						break;
					case "3":
						UpdateCalculation();
						break;
					case "4":
						DeleteCalculation();
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Invalid selection. Please try again.");
						break;
				}

				if (running)
				{
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}
		}

		private void CreateCalculation()
		{
			Console.Clear();
			Console.WriteLine("CREATE CALCULATION");
			Console.WriteLine("1. Addition (+)");
			Console.WriteLine("2. Subtraction (-)");
			Console.WriteLine("3. Multiplication (*)");
			Console.WriteLine("4. Division (/)");
			Console.WriteLine("5. Square Root (√)");
			Console.WriteLine("6. Modulus (%)");
			Console.WriteLine("0. Back to Main Menu");

			Console.WriteLine("Select the number of the action you want to create:");
			var choice = Console.ReadLine();
			HandleCalculationType(choice, isUpdating: false);
		}

		private void HandleCalculationType(string calculationType, bool isUpdating, Data.Calculator existingCalculation = null)
			{
				Func<double, double, double> operation = null;
				Func<double, double> unaryOperation = null;
				string operationName = string.Empty;
				bool isUnary = false;

			switch (calculationType)
			{
				case "1":
					operation = (a, b) => a + b;
					operationName = "Addition";
					break;
				case "2":
					operation = (a, b) => a - b;
					operationName = "Substraction";
					break;
				case "3":
					operation = (a, b) => a * b;
					operationName = "Multiplication";
					break;
				case "4":
					operation = (a, b) => b !=0 ? a / b : double.NaN;
					operationName = "Division";
					break;
				case "5":
					unaryOperation = Math.Sqrt;
					operationName = "Square Root";
					isUnary = true;
					break;
				case "6":
					operation = (a, b) => a % b;
					operationName = "Modulus";
					break;
				case "0":
					return;
				default:
					Console.WriteLine("Invalid selection. Please try again.");
					return;
			}
			
			if (isUpdating)
			{
				UpdateCalculation(operationName, operation, unaryOperation, existingCalculation, isUnary);
			}
			else
			{
				PerformCalculation(operationName, operation, unaryOperation, isUnary);
			}
		}

		private void PerformCalculation(string operationName, Func<double, double, double> operation, Func<double, double> unaryOperation, bool isUnary)
		{
			double num1 = 0, num2 = 0, result = 0;

			Console.Write($"Enter operand 1: ");
			if (!double.TryParse(Console.ReadLine(), out num1))
			{
                Console.WriteLine("Invalid input. Please enter a valid number.");
				return;
            }

			if (!isUnary)
			{
				Console.Write($"Enter operand 2: ");
				if (!double.TryParse(Console.ReadLine(), out num2))
				{
                    Console.WriteLine("Invalid input. Please enter a valid number");
					return;
                }
				result = operation(num1, num2);
			}
			else
			{
				result = unaryOperation(num1);
			}

			SaveToDatabase(operationName, num1, num2, result);
            Console.WriteLine($"{operationName} Result: {result:F2}");
        }

		private void SaveToDatabase(string operation, double num1, double num2, double result)
		{
			var calculator = new Data.Calculator
			{
				Operation = operation,
				Num1 = num1,
				Num2 = num2,
				Result = result,
				CalculationDate = DateTime.Now
			};

			_context.Calculators.Add(calculator);
			_context.SaveChanges();
		}

		private void UpdateCalculation()
		{
			Console.Clear();
			ShowAllCalculations();

			Console.Write("Enter the calculator ID you want to update (or 0 to cancel): ");
			var choice = Console.ReadLine();

			if (choice == "0")
				return;

			if (!int.TryParse(choice, out int calculatorId) || calculatorId <= 0)
			{
				Console.WriteLine("Invalid input. Please enter a valid calculator ID.");
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return;
			}

			var existingCalculation = _context.Calculators.Find(calculatorId);

			if (existingCalculation == null)
			{
				Console.WriteLine($"No calculation found with ID: {calculatorId}");
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				return;
			}

			Console.WriteLine("Select the operation to update:");
			Console.WriteLine("1. Addition (+)");
			Console.WriteLine("2. Subtraction (-)");
			Console.WriteLine("3. Multiplication (*)");
			Console.WriteLine("4. Division (/)");
			Console.WriteLine("5. Square Root (√)");
			Console.WriteLine("6. Modulus (%)");

			var updateChoice = Console.ReadLine();

			switch (updateChoice)
			{
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
					Console.Clear();
					PerformUpdateOperation(existingCalculation, updateChoice);
					break;
				default:
					Console.WriteLine("Invalid selection. Please try again.");
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
					break;
			}
		}

		private void PerformUpdateOperation(Data.Calculator existingCalculation, string operationChoice)
		{
			HandleCalculationType(operationChoice, isUpdating: true, existingCalculation);
		}

		private void UpdateCalculation(string operationName, Func<double, double, double> operation, Func<double, double> unaryOperation, Data.Calculator existingCalculation, bool isUnary)
		{
			Console.Write($"Enter operand 1 ({operationName}): ");
			if (!double.TryParse(Console.ReadLine(), out double num1))
			{
				Console.WriteLine("Invalid input. Please enter a valid number.");
				return;
			}

			if (!isUnary)
			{
				Console.Write($"Enter operand 2 ({operationName}): ");
				if (!double.TryParse(Console.ReadLine(), out double num2))
				{
					Console.WriteLine("Invalid input. Please enter a valid number.");
					return;
				}

				double result = operation(num1, num2);

				existingCalculation.Operation = operationName;
				existingCalculation.Num1 = num1;
				existingCalculation.Num2 = num2;
				existingCalculation.Result = result;
				existingCalculation.CalculationDate = DateTime.Now;

				_context.SaveChanges();

				Console.WriteLine($"{operationName} Result: {result:F2}");
			}
			else
			{
				double result = unaryOperation(num1);

				existingCalculation.Operation = operationName;
				existingCalculation.Num1 = num1;
				existingCalculation.Num2 = 0;
				existingCalculation.Result = result;
				existingCalculation.CalculationDate = DateTime.Now;

				_context.SaveChanges();

				Console.WriteLine($"{operationName} Result: {result:F2}");
			}
		}

		private void DeleteCalculation()
		{
			Console.Clear();
			ShowAllCalculations();

			Console.WriteLine("Enter the calculator ID you want to delete (or 0 to cancel): ");

			if (!int.TryParse(Console.ReadLine(), out int calculatorId) || calculatorId < 0)
			{
				Console.WriteLine("Invalid input. Please enter a valid calculator ID.");
				return;
			}

			if (calculatorId == 0)
			{
				Console.WriteLine("Delete operation canceled.");
				return;
			}

			var existingCalculation = _context.Calculators.Find(calculatorId);

			if (existingCalculation == null)
			{
				Console.WriteLine($"No calculation found with ID: {calculatorId}");
				return;
			}

			Console.WriteLine($"Are you sure you want to delete the calculation with ID {calculatorId}? (Y/N)");
			var confirmation = Console.ReadLine();

			if (confirmation.ToUpper() == "Y")
			{
				_context.Calculators.Remove(existingCalculation);
				_context.SaveChanges();
				Console.WriteLine($"Calculation with ID {calculatorId} deleted successfully.");
			}
			else
			{
				Console.WriteLine("Delete operation canceled.");
			}
		}

		private void ShowAllCalculations()
		{
			var calculations = _context.Calculators.ToList();

			
			Console.WriteLine("{0,-4} {1,-15} {2,-8} {3,-8} {4,-8} {5,-20}", "Id", "Operation", "Num1", "Num2", "Result", "Date");
			Console.WriteLine("------------------------------------------------------");

			foreach (var calculation in calculations)
			{
				Console.WriteLine("{0,-4} {1,-15} {2,-8} {3,-8} {4,-8} {5,-20}",
					calculation.Id,
					calculation.Operation,
					calculation.Num1,
					calculation.Num2,
					calculation.Result.ToString("F2"),
					calculation.CalculationDate.ToString("yyyy-MM-dd HH:mm:ss"));
			}

			if (!calculations.Any())
			{
				Console.WriteLine("No calculations found.");
			}
		}
	}
}