using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
        private int sign;

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)//задаём дробь и сокращаем её
        {
            if (denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
                Reduction();
            }
            else
                throw new ArgumentException("Невозможна дробь с нулевым знаменателем.");
            if (numerator * denominator < 0)
            {
                this.sign = -1;
            }
            else
            {
                this.sign = 1;
            }
        }

        public Fraction(Fraction obj)
        {
            numerator = obj.numerator;
            denominator = obj.denominator;
        }

        public int Numerator
        {
            get => numerator;
            set
            {
                numerator = value;
                Reduction();
            }
        }
        public int Denominator => denominator;

        static private int GetNOD(int a, int b)//нод
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

        static private int GetNOK(int a, int b)//нок
        {
            return a * (b / GetNOD(a, b));
        }

        public void Exponentiation(int power)//функция возведения в степень
        {
            numerator = (int)Math.Pow(numerator, power);
            denominator = (int)Math.Pow(denominator, power);
            Reduction();
        }

        private void Reduction()//функция сокращения дроби
        {
            int max = 0;
            if (numerator > denominator)
            {
                max = Math.Abs(denominator);
            }
            else
            {
                max = Math.Abs(numerator);
            }                      
            for (int i = max; i >= 2; i--)
            {
                
                if ((numerator % i == 0) & (denominator % i == 0))
                {
                    numerator = (numerator / i);
                    denominator = (denominator / i);
                }

            }
            if ((denominator < 0))
            {
                numerator = -1 * (numerator);
                denominator = Math.Abs(denominator);
            }
        }
    
        static public Fraction operator +(Fraction first, Fraction second)
        {
            if (first.denominator != second.denominator)//если знаменатели не равны
            {
                int nok = GetNOK(first.denominator, second.denominator);//ищем нок для знаменателей
                return new Fraction(first.Numerator * (nok / first.denominator) + second.Numerator * (nok / second.denominator), nok);
            }
            else//если знаменатели равны, то складываем числители
                return new Fraction(first.Numerator + second.Numerator, first.denominator);
        }

        static public Fraction operator -(Fraction first, Fraction second)
        {
            int nok = GetNOK(first.denominator, second.denominator);//ищем нок для знаменателей
            Fraction Result = new Fraction(first.Numerator * (nok / first.denominator) - second.Numerator * (nok / second.denominator), nok);
            return Result;
        }

        static public Fraction operator *(Fraction _first, Fraction _second)
        {
            Fraction first = new Fraction(_first);
            Fraction second = new Fraction(_second);
            int NOD1 = GetNOD(first.Numerator, second.Denominator);//проверяем, равен ли числитель первой дроби знаменателю второй
            if (NOD1 != 1)//если не равен, то сокращяем их на нод
            {
                first.numerator /= NOD1;
                second.denominator /= NOD1;
            }
            int NOD2 = GetNOD(first.Denominator, second.Numerator);
            if (NOD2 != 1)
            {
                first.denominator /= NOD2;
                second.numerator /= NOD2;
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
            if (second.numerator == 0)//если числитель второй дроби равен нулю, то делить нельзя
            {
                throw new DivideByZeroException();
            }
            else//иначе проверяем, равны ли числители знаменателям противоположных дробей
            {
                int NOD1 = GetNOD(first.Numerator, second.Numerator);
                if (NOD1 != 1)
                {//если не равны, то сокращаем на нод
                    first.numerator /= NOD1;
                    second.numerator /= NOD1;
                }
                int NOD2 = GetNOD(first.Denominator, second.Denominator);
                if (NOD2 != 1)
                {
                    first.denominator /= NOD2;
                    second.denominator /= NOD2;
                }
                try
                {
                    return new Fraction(checked(first.numerator * second.denominator), checked(first.denominator * second.numerator));
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
                return Numerator.ToString() + "/" + denominator.ToString();
            }
            else
            {
                return Numerator.ToString();
            }
        }


        public override bool Equals(object obj)
        {
            Fraction b = (Fraction)obj;
            return (this.Numerator == b.Numerator && this.Denominator == b.Denominator && this.sign==b.sign) ? true : false;
        }
        public override int GetHashCode()
        {
            return this.sign * (this.numerator * this.numerator + this.denominator * this.denominator);
        }

        //операторы сравнения
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
