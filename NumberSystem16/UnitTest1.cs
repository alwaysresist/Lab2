using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace NumberSystem16Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CorrectConversationFromString()
        {
            string a = "123";
            Assert.AreEqual("7B", NumberSystem16.Conversation(a, 10));
        }

        [TestMethod]
        public void CorrectConversationFromInt()
        {
            int a = 123;
            Assert.AreEqual("7B", NumberSystem16.Conversation(a, 10));
        }

        [TestMethod]
        public void CorrectConversationFrom16()
        {
            string a="7B";
            Assert.AreEqual("7B", NumberSystem16.Conversation(a, 16));
        }

        [TestMethod]
        public void CorrectAND()
        {
            string a = "3F";
            string b = "5B";
            Assert.AreEqual("1B", NumberSystem16.AND(a, b));
        }

        [TestMethod]
        public void CorrectOR()
        {
            string a = "3F";
            string b = "5B";
            Assert.AreEqual("7F", NumberSystem16.OR(a, b));
        }

        [TestMethod]
        public void CorrectSum()
        {
            string a = "3F";
            string b = "5B";
            Assert.AreEqual("9A", NumberSystem16.Sum(a, b));
        }

        [TestMethod]
        public void CorrectSub1()
        {
            string a = "3F";
            string b = "5B";
            Assert.AreEqual("-1C", NumberSystem16.Sub(a, b));
        }

        [TestMethod]
        public void CorrectSub2()
        {
            string a = "3F";
            string b = "-5B";
            Assert.AreEqual("9A", NumberSystem16.Sub(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputError1()
        {
            string a = "123";
            Assert.Equals(typeof(ArgumentException), NumberSystem16.Conversation(a, 8));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputError2()
        {
            string a = "3F";
            Assert.Equals(typeof(ArgumentException), NumberSystem16.Conversation(a, 10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputError3()
        {
            string a = "3F.";
            Assert.Equals(typeof(ArgumentException), NumberSystem16.Conversation(a, 16));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailSum()
        {
            string a = "-3Z";
            string b = "456-";
            Assert.Equals(typeof(ArgumentException), NumberSystem16.Sum(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailSub()
        {
            string a = "-3F,";
            string b = "5B.";
            Assert.Equals(typeof(ArgumentException), NumberSystem16.Sub(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FailWithBigNumberForInt()
        {
            string a = "3FFFFFFFFFFFFFFFFFFFF";
            string b = "123";
            Assert.Equals(typeof(OverflowException), NumberSystem16.Sum(a, b));
        }
    }
}
