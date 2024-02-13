using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Data
{
	public class Calculator
	{
		public int Id { get; set; }
		public string Operation { get; set; }
		public double Num1 { get; set; }
		public double Num2 { get; set; }		
		public double Result { get; set; }
		public DateTime CalculationDate { get; set; }
	}
}
