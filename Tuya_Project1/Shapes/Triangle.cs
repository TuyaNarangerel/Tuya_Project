using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Shapes
{
    public class Triangle
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        public double CalculateArea()
        {
            return Base * Height / 2;
        }

        public double CalculatePerimeter()
        {
            double hypotenuse = Math.Sqrt(Base * Base + Height + Height);
            return Base + Height + hypotenuse;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Type: Triangle, Base: {Base}, Height: {Height}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }
    }
}
