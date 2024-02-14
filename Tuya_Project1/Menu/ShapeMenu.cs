using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Tuya_Project1.Data;
using Tuya_Project1.Shapes;

namespace Tuya_Project1.Menu
{
	public class ShapeMenu
	{
		private readonly AppDbContext _context;

		public ShapeMenu(AppDbContext context)
		{
			_context = context;
		}

		public void ShowMenu()
		{
			bool running = true;
			while (running)
			{
				Console.Clear();
				Console.WriteLine("SHAPE MENU");
				Console.WriteLine("1. Create Shape");
				Console.WriteLine("2. Read Shapes");
				Console.WriteLine("3. Update Shape");
				Console.WriteLine("4. Delete Shape");
				Console.WriteLine("0. Exit");

				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.Clear();
						CreateShape();
						break;
					case "2":
						ViewShapes();
						break;
					case "3":
						UpdateShape();
						break;
					case "4":
						DeleteShape();
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Oopsie! Looks like that wasn't the right move. Give it another go, and let's make it right this time!");
						break;
				}
			}
		}

		private void CreateShape()
		{
			Console.WriteLine("FORM MENU");
			Console.WriteLine("1. Rectangle");
			Console.WriteLine("2. Parallelogram");
			Console.WriteLine("3. Rhombus");
			Console.WriteLine("4. Triangle");
			Console.WriteLine("0. Back to Shape Menu");


			string shapeChoice = Console.ReadLine();

			switch (shapeChoice)
			{
				case "1":
					AddRectangle();
					break;
				case "2":
					AddParallelogram();
					break;
				case "3":
					AddRhombus();
					break;
				case "4":
					AddTriangle();
					break;
				case "0":
					return;
				default:
					Console.WriteLine("Invalid selection. Please try again.");
					break;
			}
		}

		private void DeleteShape()
		{
			Console.Clear();
			ViewShapes();

			Console.Write("Enter shape ID to delete: ");
			if (!int.TryParse(Console.ReadLine(), out int shapeId))
			{
				Console.WriteLine("Invalid input. Please enter a valid ID.");
				Console.ReadKey();
				return;
			}

			var shape = _context.Shapes.Find(shapeId);
			if (shape == null)
			{
				Console.WriteLine("Shape not found.");
				Console.ReadKey();
				return;
			}

			_context.Shapes.Remove(shape);
			_context.SaveChanges();

			Console.WriteLine("Shape deleted successfully!");
			Console.ReadKey();
		}

		private void DisplayShapeTable(List<Shape> shapes)
		{
			Console.Clear();

			Console.WriteLine("ID\tType\t\tBase\tHeight\tArea\t\tPerimeter\tDate");
			Console.WriteLine("---------------------------------------------------------------------------------------");

			foreach (var shape in shapes)
			{
				Console.WriteLine($"{shape.Id}\t{shape.Type,-15}\t{shape.Base,-5}\t{shape.Height,-5}\t{shape.Area,-10}\t{shape.Perimeter,-15}\t{shape.CalculationDate}");
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();

		}
		private void UpdateShape()
		{
			Console.Clear();
			ViewShapes();

			Console.Write("Enter shape ID to update: ");
			if (!int.TryParse(Console.ReadLine(), out int shapeId))
			{
				Console.WriteLine("Whoops! That ID seems to be playing hide and seek. Please enter a valid one, and let's keep the game going!");
				Console.ReadKey();
				return;
			}

			var shape = _context.Shapes.Find(shapeId);
			if (shape == null)
			{
				Console.WriteLine("Shape not found.");
				Console.ReadKey();
				return;
			}

			Console.Write("Enter new shape base: ");
			string newBaseInput = Console.ReadLine();
			if (IsValidInput(newBaseInput))
			{
				double newBase = double.Parse(newBaseInput);

				Console.Write("Enter new height: ");
				string newHeightInput = Console.ReadLine();
				if (IsValidInput(newHeightInput))
				{
					double newHeight = double.Parse(newHeightInput);

					if (newBase <= 0 || newHeight <= 0)
					{
						Console.WriteLine("Oops! Need valid positive base and height values.");
					}
					else
					{
						shape.Base = newBase;
						shape.Height = newHeight;

						shape.Area = CalculateArea(shape.Type, shape.Base, shape.Height);
						shape.Perimeter = CalculatePerimeter(shape.Type, shape.Base, shape.Height);

						_context.SaveChanges();

						Console.WriteLine("Shape updated successfully!");
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid positive number for height.");
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid positive number for base.");

			}
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}

		private void ViewShapes()
		{
			var shapes = _context.Shapes.ToList();
			if (!shapes.Any())
			{
				Console.WriteLine("No shapes found.");
				Console.ReadKey();
				return;
			}

			DisplayShapeTable(shapes);

		}
		private static bool IsValidInput(string input)
		{
			if (!double.TryParse(input, out double value) || value <= 0)
			{
				Console.WriteLine("Invalid input. Please enter a valid positive number.");
				Console.ReadKey();
				return false;
			}
			else { return true; }
			
		}

		private double CalculateArea(string type, double baseLength, double height)
		{
			switch (type)
			{
				case "Rectangle":
				case "Parallelogram":
				case "Rhombus":
					return baseLength * height;
				case "Triangle":
					return 0.5 * baseLength * height;
				default:
					Console.WriteLine("Unsupported shape type for area calculation.");
					return 0;
			}
		}
		private bool CheckValid(double length, double width) 
		{
		if ( width <= 0 || length <= 0 )
		{
				Console.WriteLine("Invalid input. Please enter valid positive values for width and height.");
				return true;
		}
		else { return false; }
}
		private double CalculatePerimeter(string type, double baseLength, double height)
		{
			
				switch (type)
				{
					case "Rectangle":
					case "Parallelogram":
						return 2 * (baseLength + height);
					case "Rhombus":
						return 4 * baseLength;
					case "Triangle":
						return baseLength + height + Math.Sqrt(baseLength * baseLength + height * height);
					default:
						Console.WriteLine("Unsupported shape type for perimeter calculation.");
						return 0;
				}
			
			
				
		}

		private void AddRectangle()
		{
			Console.Write("Enter rectangle width: ");
			string widthInput = Console.ReadLine();

			if (IsValidInput(widthInput))
			{
				double width = double.Parse(widthInput);

				Console.Write("Enter rectangle height: ");
				string heightInput = Console.ReadLine();
				if (IsValidInput(heightInput))
				{
					double height = double.Parse(heightInput);
					
					if (width == height)
					{
                        Console.WriteLine("The base and height of a rectangle cannot be the same.");
						return;
                    }

					var rectangle = new Shape
					{
						Type = "Rectangle",
						Base = width,
						Height = height,
						Area = CalculateArea("Rectangle", width, height),
						Perimeter = CalculatePerimeter("Rectangle", width, height),
						CalculationDate = DateTime.Now
					};

					_context.Shapes.Add(rectangle);
					_context.SaveChanges();

					DisplayShapeInfo(rectangle);
					Console.WriteLine("Rectangle added successfully!");
					Console.ReadKey();
				}
				
			}
		}

		private void AddParallelogram()
		{
			Console.WriteLine("Enter parallelogram base: ");
			string baseInput = Console.ReadLine();

			if (IsValidInput(baseInput))
			{
				double baseLength = double.Parse(baseInput);


				Console.Write("Enter parallelogram height: ");
				string heightInput = Console.ReadLine();
				if (IsValidInput(heightInput))
				{
					double height = double.Parse(heightInput);

					var existingParallelogram = _context.Shapes.FirstOrDefault(s => s.Type == "Parallelogram" && s.Base == baseLength && s.Height == height);

					if (existingParallelogram != null)
					{
						Console.WriteLine("The base and height of a parallelogram cannot be the same.");
					}

					else
					{

						var parallelogram = new Shape
						{
							Type = "Parallelogram",
							Base = baseLength,
							Height = height,
							Area = CalculateArea("Parallelogram", baseLength, height),
							Perimeter = CalculatePerimeter("Parallelogram", baseLength, height),
							CalculationDate = DateTime.Now
						};

						_context.Shapes.Add(parallelogram);
						_context.SaveChanges();

						DisplayShapeInfo(parallelogram);
						Console.WriteLine("Parallelogram added successfully!");
					}
					Console.ReadKey();
				}
				else
				{
                    Console.WriteLine("Invalid input. Please enter a valid positive number");
				}
			}
		}

		private void AddTriangle()
		{
			Console.WriteLine("Enter triangle base: ");
			string baseInput = Console.ReadLine();
			if (IsValidInput(baseInput))
			{
				double baseLength = double.Parse(baseInput);

				Console.Write("Enter triangle height: ");
				string heightInput = Console.ReadLine();
				if (IsValidInput(heightInput))
				{
					double height = double.Parse(heightInput);


					var triangle = new Shape
					{
						Type = "Triangle",
						Base = baseLength,
						Height = height,
						Area = CalculateArea("Triangle", baseLength, height),
						Perimeter = CalculatePerimeter("Triangle", baseLength, height),
						CalculationDate = DateTime.Now
					};

					_context.Shapes.Add(triangle);
					_context.SaveChanges();


					DisplayShapeInfo(triangle);
					Console.WriteLine("Triangle added successfully!");
					Console.ReadKey();
				}
				else
				{
                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
				}
			}
		}

		private void AddRhombus()
		{
			Console.Write("Enter rhombus diagnol 1: ");
			string diagonal1Input = Console.ReadLine();
			if (IsValidInput(diagonal1Input))
			{
				double diagonal1 = double.Parse(diagonal1Input);

				Console.Write("Enter rhombus diagonal 2: ");
				string diagonal2Input = Console.ReadLine();
				if (IsValidInput(diagonal2Input))
				{
					double diagonal2 = double.Parse(diagonal2Input);

					var rhombus = new Shape
					{
						Type = "Rhombus",
						Base = diagonal1,
						Height = diagonal2,
						Area = CalculateArea("Rhombus", diagonal1, diagonal2),
						Perimeter = CalculatePerimeter("Rhombus", diagonal1, diagonal2),
						CalculationDate = DateTime.Now
					};

					_context.Shapes.Add(rhombus);
					_context.SaveChanges();

					DisplayShapeInfo(rhombus);
					Console.WriteLine("Rhombus added successfully!");
					Console.ReadKey();

				}
				else
				{
                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
				}
			}
		}

		private void DisplayShapeInfo(Shape shape)
		{
			Console.WriteLine($"Area: {shape.Area}");
			Console.WriteLine($"Perimeter: {shape.Perimeter}");
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}
}

