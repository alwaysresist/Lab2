using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double[] a = { 3, 2, 1 };
                double[] b = { 1, 5 };

                Polynomial pol1 = new Polynomial(a);
                Polynomial pol2 = new Polynomial(b);

                Console.WriteLine((pol1+pol2).ToString());

               // Polynomial mult = pol1 * pol2;
               // Console.WriteLine(mult.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }
    }
}
