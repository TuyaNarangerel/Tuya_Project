using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tuya_Project1.Data
{
    public class DataInitializer
	{
		public void MigrateAndSeed(AppDbContext dbContext)
		{
			dbContext.Database.Migrate();

			SeedShape(dbContext);
			dbContext.SaveChanges();
		}

		private void SeedShape(AppDbContext dbContext)
		{
			if (!dbContext.Shapes.Any()) 
			{
				var shapes = new List<Shape>
				{
					new Shape { Type = "Rectangle", Base = 64, Height = 20, Area = 1280, Perimeter = 168, CalculationDate = DateTime.Now},
					new Shape { Type = "Parallelogram", Base = 37.3, Height = 10.1, Area = 376.73, Perimeter = 99.6, CalculationDate = DateTime.Now},
					new Shape { Type = "Rhombus", Base = 17, Height = 13, Area = 221, Perimeter = 68, CalculationDate = DateTime.Now},
					new Shape { Type = "Triangel", Base = 0.34, Height = 0.16, Area = 27200, Perimeter = 1.11, CalculationDate = DateTime.Now},

				};

				dbContext.Shapes.AddRange(shapes);
			}
		}
	}
}
