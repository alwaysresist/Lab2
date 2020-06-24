using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace PolynomialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HaveCorrectDegree()
        {
            double[] a = { 1, 2, 3, 4, 0 };
            Polynomial y = new Polynomial(a);
            Assert.AreEqual(3, y.degree);
        }

        [TestMethod]
        public void GetCorrectly()
        {
            double[] a = { 1, 2, 3, 4 };
            Polynomial y = new Polynomial(a);
            Assert.AreEqual(3, y[2]);
            Assert.AreEqual(1, y[0]);
        }

        [TestMethod]
        public void SetCorrectly()
        {
            double[] a = { 1, 2, 3, 4, 5, 6 };
            Polynomial y = new Polynomial(a);
            y[3] = 7;
            Assert.AreEqual(7, y[3]);
        }

        [TestMethod]
        public void CopyPolynomial()
        {
            double[] a = { 1, 2, 3, 4, 5, 6 };
            Polynomial y = new Polynomial(a);
            Polynomial b = new Polynomial(y);
            Assert.AreEqual(6, y[5]);
        }

        [TestMethod]
        public void NormalizationAfterSetZeroToHighOrder()
        {
            double[] a = { 1, 2, 3, 4, 5, 6, 7 };
            Polynomial y = new Polynomial(a);
            Assert.AreEqual(6, y.degree);
            y[6] = 0;
            Assert.AreEqual(5, y.degree);
        }

        [TestMethod]
        public void RightValueCalculation()
        {
            double[] a = { 3, 2, 1 };
            Polynomial y = new Polynomial(a);
            Assert.AreEqual(11, y.Calculate(2));
        }

        [TestMethod]
        public void RightPrintPolynomial()//правильный вывод
        {
            double[] a = { 4,3,2,1 };
            Polynomial y = new Polynomial(a);
            Assert.AreEqual("1x^3+2x^2+3x^1+4", y.ToString());
        }

        //тесты операций над многочленами
        [TestMethod]
        public void SumPolynomials()
        {
            double[] a = { 1,2,3 };
            double[] b = { 4, 3, 2, 1 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Polynomial sum = y1 + y2;
            Assert.AreEqual("1x^3+5x^2+5x^1+5", sum.ToString());
        }

        [TestMethod]
        public void SubPolynomials()
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 3, 2, 1 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Polynomial sub = y1 - y2;
            Assert.AreEqual("-1x^3+1x^2-1x^1-3", sub.ToString());
        }

        [TestMethod]
        public void MultPolynomials()
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 5 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Polynomial mult = y1 * y2;
            Assert.AreEqual("15x^3+22x^2+13x^1+4", mult.ToString());
        }

        //тесты операторов сравнения

        [TestMethod]
        public void ComparePolynomials1()//<
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 5, 6 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(true, y1 < y2);
        }

        [TestMethod]
        public void ComparePolynomials2()//<=
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 5, 6 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(true, y1 <= y2);
        }

        [TestMethod]
        public void ComparePolynomials3()//>
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 2, 0 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(false, y2 > y1);
        }

        [TestMethod]
        public void ComparePolynomials4()//>=
        {
            double[] a = { 1, 2, 4 };
            double[] b = { 4, 1, 0 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(true, y1 >= y2);
        }

        [TestMethod]
        public void ComparePolynomials5()//==
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 1, 2, 3 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(true, y1 == y2);
        }

        [TestMethod]
        public void ComparePolynomials6()//!=
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 4, 5, 6 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.AreEqual(true, y1 != y2);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FailBigValueCalculation()
        {
            double[] a = { 1, 2, 3, 4 };
            Polynomial y = new Polynomial(a);
            Assert.Equals(typeof(OverflowException), y.Calculate(Double.MaxValue));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FailBigCoeffSum()
        {
            double[] a = { Double.MaxValue, 1, 2, 3 };
            double[] b = { Double.MaxValue, 4, 5 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.Equals(typeof(OverflowException), y1+y2);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FailBigCoeffSub()
        {
            double[] a = { Double.MaxValue, 1, 2, 3 };
            double[] b = { -Double.MaxValue, 4, 5 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.Equals(typeof(OverflowException), y1 - y2);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FailBigCoeffMult()
        {
            double[] a = { Double.MaxValue, 1, 2, 3 };
            double[] b = { Double.MaxValue, 4, 5 };
            Polynomial y1 = new Polynomial(a);
            Polynomial y2 = new Polynomial(b);
            Assert.Equals(typeof(OverflowException), y1 * y2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithWrongIndexing1()
        {
            double[] a = { 1, 2, 3, 4 };
            Polynomial y = new Polynomial(a);
            Assert.Equals(typeof(IndexOutOfRangeException), y[-1]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithWrongIndexing2()
        {
            double[] a = { 1, 2, 3, 4 };
            Polynomial y = new Polynomial(a);
            Assert.Equals(typeof(IndexOutOfRangeException), y[10]);
        }
    }
}
