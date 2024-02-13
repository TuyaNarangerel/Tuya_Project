using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Data
{
    public class Shape
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Base { get; set; }
        public double Height { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
