using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Shapes
{
    public class Rectangle
    {
        public double Lenght { get; set; }
        public double Width { get; set; }

        public Rectangle(double lenght, double width)
        {
            Lenght = lenght;
            Width = width;
        }

        public double CalculateArea()
        {
            return Lenght * Width;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Lenght + Width);
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Type: Rectangle, Length: {Lenght}, Width: {Width}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }
    }
}
