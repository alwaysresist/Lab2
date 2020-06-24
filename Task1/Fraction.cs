using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Fraction
    {
        private int num;
        private int den;

        public Fraction()
        {
            num = 0;
            den = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator != 0)
            {
                this.num = numerator;
                this.den = denominator;
                Reduction();
            }
            else
                throw new ArgumentException("Невозможна дробь с нулевым знаменателем.");
        }

        public Fraction(Fraction obj)
        {
            num = obj.num;
            den = obj.den;
        }

        public int Numerator
        {
            get => num;
            set
            {
                num = value;
                Reduction();
            }
        }
        public int Denominator => den;

        public void Exponentiation(int power)//функция возведения в степень
        {
            num = (int)Math.Pow(num, power);
            den = (int)Math.Pow(den, power);
            Reduction();
        }

        static private int GetNOD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a + b;
        }

        static private int GetNOK(int a, int b)
        {
            return a * (b / GetNOD(a, b));
        }

        private void Reduction()//функция сокращения дроби
        {
            int NOD = GetNOD(num, den);
            if (NOD != 1)
            {
                num /= NOD;
                den /= NOD;
            }
            if ((num < 0 && den < 0) || den < 0)
            {
                num = -num;
                den = -den;
            }
        }

        static public Fraction operator +(Fraction first, Fraction second)
        {
            if (first.den != second.den)//если знаменатели не равны
            {
                int nok = GetNOK(first.den, second.den);//ищем нок для знаменателей
                return new Fraction(first.Numerator * (nok / first.den) + second.Numerator * (nok / second.den), nok);
            }
            else//если знаменатели равны, то складываем числители
                return new Fraction(first.Numerator + second.Numerator, first.den);
        }

        static public Fraction operator -(Fraction first, Fraction second)
        {
            int nok = GetNOK(first.den, second.den);//ищем нок для знаменателей
            Fraction Result = new Fraction(first.Numerator * (nok / first.den) - second.Numerator * (nok / second.den), nok);
            return Result;
        }

        static public Fraction operator *(Fraction _first, Fraction _second)
        {
            Fraction first = new Fraction(_first);
            Fraction second = new Fraction(_second);
            int NOD1 = GetNOD(first.Numerator, second.Denominator);//проверяем, равен ли числитель первой дроби знаменателю второй
            if (NOD1 != 1)
            {//если не равен, то сокращяем их на нод
                first.num /= NOD1;
                second.den /= NOD1;
            }
            int NOD2 = GetNOD(first.Denominator, second.Numerator);
            if (NOD2 != 1)
            {
                first.den /= NOD2;
                second.num /= NOD2;
            }
            try
            {
                return new Fraction(checked(first.Numerator * second.Numerator), checked(first.Denominator * second.Denominator));
            }
            catch
            {
                throw new OverflowException();
            }
        }

        static public Fraction operator /(Fraction _first, Fraction _second)
        {
            Fraction first = new Fraction(_first);
            Fraction second = new Fraction(_second);
            if (second.num == 0)//если числитель второй дроби равен нулю, то делить нельзя
            {
                throw new DivideByZeroException();
            }
            else//иначе проверяем, равны ли числители знаменателям противоположных дробей
            {
                int NOD1 = GetNOD(first.Numerator, second.Numerator);
                if (NOD1 != 1)
                {//если не равны, то сокращаем на нод
                    first.num /= NOD1;
                    second.num /= NOD1;
                }
                int NOD2 = GetNOD(first.Denominator, second.Denominator);
                if (NOD2 != 1)
                {
                    first.den /= NOD2;
                    second.den /= NOD2;
                }
                try
                {
                    return new Fraction(checked(first.num * second.den), checked(first.den * second.num));
                }
                catch
                {
                    throw new OverflowException();
                }
            }

        }

        //вывод обычной дроби
        public override string ToString()
        {
            if (Denominator != 1)
            {
                return Numerator.ToString() + "/" + den.ToString();
            }
            else
            {
                return Numerator.ToString();
            }
        }

        public override bool Equals(object obj)
        {
            Fraction b = (Fraction)obj;
            return (this.Numerator == b.Numerator && this.Denominator == b.Denominator) ? true : false;
        }
      
        public static bool operator ==(Fraction first, Fraction second)
        { 
            return first.Equals(second);
        }

        public static bool operator !=(Fraction first, Fraction second) => (first == second) ? false : true;

        public static bool operator <(Fraction first, Fraction second)
        {
            if (((double)first.Numerator / (double)first.Denominator) < ((double)second.Numerator / (double)second.Denominator)) return true;
            else return false;
        }

        public static bool operator >(Fraction first, Fraction second)
        {
            return second < first;
        }

        public static bool operator <=(Fraction first, Fraction second)
        {
            return !(first > second);
        }

        public static bool operator >=(Fraction first, Fraction second)
        {
            return !(first < second);
        }

        //представление дроби в десятичном виде
        public static explicit operator int(Fraction num) => num.Numerator / num.Denominator;

        public static implicit operator double(Fraction num) => ((double)num.Numerator / (double)num.Denominator);
    }
}
