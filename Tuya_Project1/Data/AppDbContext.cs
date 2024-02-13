using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tuya_Project1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Calculator> Calculators { get; set; }
        public DbSet<StenSaxPåse> StenSaxPåseGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Shape>()
                .Property(s => s.Type)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Shape>()
                .Property(s => s.CalculationDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Calculator>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Calculator>()
                .Property(c => c.Operation)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Calculator>()
                .Property(c => c.CalculationDate)
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<StenSaxPåse>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<StenSaxPåse>()
                .Property(g => g.PlayerChoice)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<StenSaxPåse>()
                .Property(g => g.Outcome)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<StenSaxPåse>()
                .Property(b => b.GameDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Shape>().HasData(
                 new Shape { Id = -1, Type = "Rectangle", Base = 64, Height = 20, Area = 1280, Perimeter = 168, CalculationDate = DateTime.Now },
                 new Shape { Id = -2, Type = "Parallelogram", Base = 37.3, Height = 10.1, Area = 376.73, Perimeter = 99.6, CalculationDate = DateTime.Now },
                 new Shape { Id = -3, Type = "Rhombus", Base = 17, Height = 13, Area = 221, Perimeter = 68, CalculationDate = DateTime.Now },
                 new Shape { Id = -4, Type = "Triangel", Base = 0.34, Height = 0.16, Area = 27200, Perimeter = 1.11, CalculationDate = DateTime.Now }
                 );
                
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost;Database=Tuya_Project1;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
			}
		}
	}
}
