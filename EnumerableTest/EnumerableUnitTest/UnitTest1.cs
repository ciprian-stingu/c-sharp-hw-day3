using EnumerableTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnumerableUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Int_Test_Sum()
        {
            List<int> ints = new List<int> { 1, 2, 3 };
            Assert.AreEqual(6, ints.Sum());
        }

        [TestMethod]
        public void Char_Test_Min()
        {
            List<char> chars = new List<char> { '2', 'a', '+', (char)0x20 };
            Assert.AreEqual(' ', chars.Min());
        }

        [TestMethod]
        public void SByte_Test_Max()
        {
            List<sbyte> bytes = new List<sbyte> { -126, 0, 4, 127 };
            Assert.AreEqual(127, bytes.Max());
        }

        [TestMethod]
        public void Double_Test_Average()
        {
            List<double> doubles = new List<double> { -1.0, 2.0, 5.0, 25 };
            Assert.AreEqual(7.75, doubles.Average());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid type!")]
        public void String_Test_Min()
        {
            List<string> strings = new List<string> { "aaa", "b", "dddd" };
            strings.Min();
        }
    }
}
