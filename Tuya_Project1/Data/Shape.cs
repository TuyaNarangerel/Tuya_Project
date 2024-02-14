using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Data
{
    public class Shape
    {
        public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Type { get; set; }
        public double Base { get; set; }
        public double Height { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }

		[Required]
		public DateTime CalculationDate { get; set; }
    }
}
