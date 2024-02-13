using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Shapes
{
    public class Parallelogram
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Parallelogram(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        public double CalculateArea()
        {
            return Base * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Base + Height);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Type: Parallelogram, Base: {Base}, Height: {Height}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }
    }
}
