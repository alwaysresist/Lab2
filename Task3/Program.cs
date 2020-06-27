using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "-3а-F";
            string second = "5b";

            string sum = NumberSystem16.Sum(first, second);
            Console.WriteLine(sum);

            Console.WriteLine(NumberSystem16.Conversation(15, 10));

            string temp = NumberSystem16.AND(first, second);
            Console.WriteLine(temp);
        }
    }
}
