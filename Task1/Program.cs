using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Fraction a = new Fraction(8, 4);
				Fraction b = new Fraction(2, 2);

				Fraction c = new Fraction(24, 6);
				Fraction d = new Fraction(3, 5);

				Fraction Sum = a + b;
				Console.WriteLine(Sum.ToString());
				Console.WriteLine(Sum);

				Fraction Sub = c - d;
				Console.WriteLine(Sub.ToString());

				Fraction Mult = c * d;
				Console.WriteLine(Mult.ToString());

				Fraction exp = new Fraction(4, 8);
				exp.Exponentiation(3);
				Console.WriteLine(exp);

			}
			catch (Exception e)
			{
				Console.WriteLine($"Произошла ошибка: {e.Message}");
			}

		}
	}
}
