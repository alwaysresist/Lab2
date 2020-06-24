using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polynomial
    {
        private List<double> coef=new List<double>();//список коэффициентов при переменных

        public int degree => this.coef.Count - 1;

        public Polynomial()
        {
            coef = new List<double>();
        }

        public Polynomial(double[] coeff)
        {
            this.coef = new List<double>(coeff);
            Normalization();
        }

        public Polynomial(Polynomial other)
        {
            coef = new List<double>(other.coef);
        }

        private void Add(double val)
        {
            coef.Add(val);
        }

        public double this[int index]
        {
            get
            {
                if (CheckIndex(index))//проверка выхода за границы
                {
                    return coef[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (CheckIndex(index))
                {
                    coef[index] = value;
                    Normalization();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        

        public double Calculate(double x)
        {
            double result = 0;
            for (int i = 0; i <= degree; i++)
            {
                if (double.IsInfinity(result))
                {
                    throw new OverflowException();
                }
                else
                {
                    result += coef[i] * Math.Pow(x, i);
                }
            }
            return result;
        }

        public override string ToString()//вывод многочлена
        {
            string result = "";
            for (int i = degree; i > 0; i--)
            {
                if (coef[i] != 0)
                {
                    result += coef[i].ToString() + "x^" + i.ToString();
                }
                if (coef[i - 1] > 0)
                {
                    result += '+';
                }
            }
            if (coef[0] != 0 && degree >= 1)
            {
                result += coef[0].ToString();
            }
            else if (degree == 0)
            {
                result += '0';
            }
            return result;
        }

        private void Normalization()//удаление переменных с нулевым коэффициентом 
        {
            int i = degree;
            while (coef[i] == 0 && i > 0)
            {
                coef.RemoveAt(i);
                --i;
            }
        }

        //операторы
        static public Polynomial operator +(Polynomial _first, Polynomial _second)
        {
            Polynomial first = new Polynomial(_first);
            Polynomial second = new Polynomial(_second);

            int MaxDegree = Math.Max(first.degree, second.degree);//максимальная степень двух многочленов
            Polynomial result = new Polynomial();

            while (first.degree < MaxDegree)
            {
                first.Add(0);
            }
            while (second.degree < MaxDegree)
            {
                second.Add(0);
            }
            for (int i = 0; i <= MaxDegree; i++)
            {
                if (double.IsInfinity(first[i] + second[i]))
                {
                    throw new OverflowException();
                }
                else
                {
                    result.Add(first[i] + second[i]);
                }
            }
            result.Normalization();
            return result;
        }

        static public Polynomial operator -(Polynomial _first, Polynomial _second)
        {
            Polynomial first = new Polynomial(_first);
            Polynomial second = new Polynomial(_second);
            int MaxDegree = Math.Max(first.degree, second.degree);
            Polynomial result = new Polynomial();

            while (first.degree < MaxDegree)
            {
                first.Add(0);
            }
            while (second.degree < MaxDegree)
            {
                second.Add(0);
            }
            for (int i = 0; i <= MaxDegree; i++)
            {
                if (double.IsInfinity(first[i] - second[i]))
                {
                    throw new OverflowException();
                }
                else
                {
                    result.Add(first[i] - second[i]);
                }
            }
            result.Normalization();
            return result;
        }

        static public Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resDegree = first.degree + second.degree;
            double[] result = new double[resDegree + 1];
            for (int i = 0; i <= first.degree; i++)
            {
                for (int j = 0; j <= second.degree; j++)
                {
                    double tmp = first[i] * second[j];
                    if (double.IsInfinity(tmp))
                    {
                        throw new OverflowException();
                    }
                    else
                    {
                        result[i + j] += tmp;
                    }
                }
            }
            return new Polynomial(result);
        }
        

        public override bool Equals(object obj)//проверяем, равны ли многочлены.
        {
            Polynomial el = (Polynomial)obj;
            if (degree != el.degree)
                return false;
            else
            {
                for (int i = el.degree; i >= 0; i--)
                {
                    if (this[i] != el[i])
                        return false;
                }
                return true;
            }
        }

        static public bool operator <(Polynomial first, Polynomial second)//первый многочлен меньше второго. С функцией equals импользуется для задания остальных операторов сравнения
        {
            if (first.degree > second.degree)
            {
                return false;
            }
            else if (first.degree < second.degree)
            {
                return true;
            }
            else
            {
                for (int i = first.degree; i >= 0; i--)
                {
                    if (first[i] < second[i])
                    {
                        return true;
                    }
                    else if (first[i] > second[i])
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        private bool CheckIndex(int index)
        {
            if (index < 0 || index > degree)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        //операторы сравнения
        static public bool operator ==(Polynomial first, Polynomial second) => first.Equals(second);
        static public bool operator !=(Polynomial first, Polynomial second) => !(first == second);
        static public bool operator >(Polynomial first, Polynomial second) => (second < first);
        static public bool operator >=(Polynomial first, Polynomial second) => !(first < second);
        static public bool operator <=(Polynomial first, Polynomial second) => !(second < first);  
       
    }
}
