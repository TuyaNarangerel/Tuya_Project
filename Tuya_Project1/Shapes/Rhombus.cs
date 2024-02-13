using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Shapes
{
    public class Rhombus
    {
        public double Side { get; set; }
        public Rhombus(double side)
        {
            Side = side;
        }
        public double CalculateArea()
        {
            return Side * Side / 2;
        }

        public double CalculatePerimeter()
        {
            return Side * 4;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Type: Rhombus, Side: {Side}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }
    }
}
