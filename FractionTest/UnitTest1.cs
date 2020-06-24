using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
namespace FractionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetNumerator()
        {
            Fraction a = new Fraction(2, 3);
            Assert.AreEqual(2, a.Numerator);
        }

        [TestMethod]
        public void GetDenominator()
        {
            Fraction a = new Fraction(5, 9);
            Assert.AreEqual(9, a.Denominator);
        }

        [TestMethod]
        public void FractionCopy()
        {
            Fraction a = new Fraction(5, 9);
            Fraction b = new Fraction(a);
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReductionCheck()
        {
            Fraction a = new Fraction(6, 9);
            Assert.AreEqual(new Fraction(2, 3), a);
        }
        [TestMethod]
        public void ReductionAfterChangeNumerator()
        {
            Fraction a = new Fraction(5, 9);
            a.Numerator = 3;//после этого дробь должна сократиться
            Assert.AreEqual(new Fraction(1, 3), a);
        }

        [TestMethod]
        public void SumFractions()
        {
            Fraction a = new Fraction(5, 9);
            Fraction b = new Fraction(3, 7);
            Assert.AreEqual(new Fraction(62, 63), a + b);
        }

        [TestMethod]
        public void SubFractions()
        {
            Fraction a = new Fraction(5, 9);
            Fraction b = new Fraction(3, 7);
            Assert.AreEqual(new Fraction(8, 63), a - b);
        }

        [TestMethod]
        public void MultFractions()
        {
            Fraction a = new Fraction(5, 9);
            Fraction b = new Fraction(3, 5);
            Assert.AreEqual(new Fraction(1, 3), a * b);
        }

        [TestMethod]
        public void DivFractions()
        {
            Fraction a = new Fraction(5, 9);
            Fraction b = new Fraction(3, 5);
            Assert.AreEqual(new Fraction(25, 27), a / b);
        }

        [TestMethod]
        public void ToStringFraction1()
        {
            Fraction a = new Fraction(5, 9);
            Assert.AreEqual("5/9", a.ToString());
        }

        [TestMethod]
        public void ToStringFraction2()
        {
            Fraction a = new Fraction(5, 1);
            Assert.AreEqual("5", a.ToString());
        }

        [TestMethod]
        public void CompareFractions1()//>
        {
            Fraction a = new Fraction(3,7);
            Fraction b = new Fraction(4, 9);
            Assert.AreEqual(false, a>b);
        }

        [TestMethod]
        public void CompareFractions2()//<
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(4, 9);
            Assert.AreEqual(false, a < b);
        }

        [TestMethod]
        public void CompareFractions3()//<=
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(3, 5);
            Assert.AreEqual(true, a <= b);
        }

        [TestMethod]
        public void CompareFractions4()//<=
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(3, 4);
            Assert.AreEqual(true, a <= b);
        }

        [TestMethod]
        public void CompareFractions5()//>=
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(3, 7);
            Assert.AreEqual(true, a >= b);
        }

        [TestMethod]
        public void CompareFractions6()//!=
        {
            Fraction a = new Fraction(1, 5);
            Fraction b = new Fraction(3, 4);
            Assert.AreEqual(true, a != b);
        }

        [TestMethod]
        public void CompareFractions7()//==
        {
            Fraction a = new Fraction(3, 5);
            Fraction b = new Fraction(3, 5);
            Assert.AreEqual(true, a == b);
        }

        [TestMethod]
        public void ExplicitInt()
        {
            Fraction a = new Fraction(7, 3);
            Assert.AreEqual(2, (int)a);
        }

        [TestMethod]
        public void ImplicitDouble()
        {
            Fraction a = new Fraction(8, 4);
            Assert.AreEqual(2.0, a);
        }

        [TestMethod]
        public void ExponentationFraction()
        {
            Fraction a = new Fraction(3, 4);
            a.Exponentiation(3);
            Assert.AreEqual(new Fraction(27,64), a);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivWithWrongFractions()
        {
            Fraction a = new Fraction(3, 4);
            Fraction b = new Fraction(0, 145);
            Assert.Equals(typeof(DivideByZeroException), a / b);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void MultBigFraction()
        {
            Fraction a = new Fraction(2135235235, 4);
            Fraction b = new Fraction(2105235237, 3);
            Assert.Equals(typeof(OverflowException), a * b);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void DivBigFraction()
        {
            Fraction a = new Fraction(2135235235, 4);
            Fraction b = new Fraction(34,2105235237);
            Assert.Equals(typeof(OverflowException), a / b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailWithWrongArguments()
        {
            Assert.Equals(typeof(ArgumentException), new Fraction(3, 0));
        }
    }
}
