using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuya_Project1.Moduls
{
	public class CalculatorFormula
	{
		public double Add(double a, double b)
		{
			return a + b;
		}

		public double Subtract(double a, double b)
		{
			return a - b;
		}

		public double Multiply(double a, double b)
		{
			return a * b;
		}

		public double Divide(double a, double b)
		{
			return a / b;
		}

		public double Power(double a, double b) 
		{
			return Math.Pow(a, b);
		}

		public double Modulus(double a, double b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Divider can't be zero for modulus operation.");
			}
			return a % b;
		}
	}
}
