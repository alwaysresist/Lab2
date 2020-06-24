using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Task3
{
    public static class NumberSystem16

    {
        static private bool Check(string num)//правильно ли введено число в 16сс
        {
            Regex reg = new Regex("^[-0-9a-fA-F]+$");
            if (reg.IsMatch(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string Sum(string first, string second)//сумма чисел
        {
            if (Check(first) && Check(second))
            {
                int firstInt = Convert.ToInt32(_16To10(first));
                int secondInt = Convert.ToInt32(_16To10(second));
                return _10To16((firstInt + secondInt).ToString());
            }
            else
                throw new ArgumentException("Неверно введены исходные данные.");
        }

        static public string Sub(string first, string second)//разность чисел
        {
            if (Check(first) && Check(second))
            {
                int firstInt = Convert.ToInt32(_16To10(first));
                int secondInt = Convert.ToInt32(_16To10(second));
                return _10To16((firstInt - secondInt).ToString());
            }
            else 
                throw new ArgumentException("Неверно введены исходные данные.");
        }

        static private string _16To10(string number)//16 в 10 сс
        {
            bool isNegative = false;
            int num;
            int k = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '-')
                {
                    k++;
                }
                if (k > 1)
                {
                    throw new ArgumentException("Неверно введены исходные данные.");
                } 
            }

            if ( number[0] == '-')//если число отрицательное
            {
                isNegative = true;
                number = number.Remove(0, 1);
            }
            try
            {
                num = checked(Convert.ToInt32(number, 16));
            }
            catch
            {
                throw new OverflowException();
            }
            if (isNegative)
            {
                num = -num;
            }
            return num.ToString();
        }

        static private string _10To16(string _num)//10 в 16 cc
        {
            string result = "";
            int num = Convert.ToInt32(_num);
            bool isNegative = (num < 0) ? true : false;
            num = Math.Abs(num);
            while (num > 0)
            {
                result += DigitToChar(num % 16);
                num /= 16;
            }
            if (isNegative)
            {
                result += '-';
            }
            result = new string(result.Reverse().ToArray());
            return result;
        }

        static public string Conversation(string num, int Base)//перевод числа из одной сс в другую
        {
            if (Base == 10 && Regex.IsMatch(num, "^[-0-9]+$"))
            {
                return _10To16(num);
            }
            else if (Base == 16 && Check(num))
            {
                return num;
            }
            else throw new ArgumentException("");
        }

        static public string Conversation(int num, int Base)
        {
            return Conversation(num.ToString(), Base);
        }

        static private char DigitToChar(int num)//перевод из int в char для вывода чисел в 16сс
        {
            if (num < 10)
            {
                return Convert.ToChar('0' + num);
            }
            else
            {
                return Convert.ToChar(('A' + (num - 10)));
            }
        }

        static public string AND(string first, string second)//побитовое и
        {
            if (Check(first) && Check(second))
            {
                int _first = Convert.ToInt32(_16To10(first));
                int _second = Convert.ToInt32(_16To10(second));
                return _10To16((_first & _second).ToString());
            }
            else throw new ArgumentException("Неверно введены исходные данные.");
        }

        static public string OR(string first, string second)//побитовое или
        {
            if (Check(first) && Check(second))
            {
                int _first = Convert.ToInt32(_16To10(first));
                int _second = Convert.ToInt32(_16To10(second));
                return _10To16((_first | _second).ToString());
            }
            else throw new ArgumentException("Неверно введены исходные данные.");
        }
    }
}
