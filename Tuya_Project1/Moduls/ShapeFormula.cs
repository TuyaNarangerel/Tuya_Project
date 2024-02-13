using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuya_Project1.Data;

namespace Tuya_Project1.Moduls
{
	public class ShapeFormula
	{
		public static void CalculateRectangleStats(AppDbContext context, double lenght, double width)
		{
			double area = lenght * width;

			double perimeter = 2 * (lenght + width);

			SaveToDatabase(context, "Rectangle", lenght, width, area, perimeter);

		}

		public static void CalculateParallelogramStats(AppDbContext context, double base1, double base2, double height)
		{
			double area = base1 * height;
			double perimeter = 2 * (base1 + base2);

			SaveToDatabase(context, "Parallelogram", base1, height, area, perimeter);

		}

		public static void CalculateTriangleStats(AppDbContext context, double base1, double height)
		{
			double area = (base1 * height) / 2;
			double perimeter = base1 + (2 * height);

			SaveToDatabase(context, "Triangle", base1, height, area, perimeter);
		}

		public static void CalculateRhombusStats(AppDbContext context, double side)
		{
			double area = (side * side) / 2;
			double perimeter = side * 4;

			SaveToDatabase(context, "Rhombus", side, side, area, perimeter);
		}

		public static void SaveToDatabase(AppDbContext context, string type, double baseValue, double height, double area, double perimeter)
		{
			var shape = new Shape
			{
				Type = type,
				Base = baseValue,
				Height = height,
				Area = area,
				Perimeter = perimeter,
				CalculationDate = DateTime.Now,
			};

			context.Shapes.Add(shape);
			context.SaveChanges();

			Console.WriteLine($"Area: {area}");
			Console.WriteLine($"Perimeter: {perimeter}");
			Console.WriteLine("Saved to database.");
		}
	}
}
