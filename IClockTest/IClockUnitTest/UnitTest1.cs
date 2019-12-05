using System;
using IClockTest;
using IClockTest.Struct;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace IClockUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void New_Clock_ReturnsObject()
        {
            Clock clk = new Clock();

            Assert.IsNotNull(clk);
        }

        [TestMethod]
        public void Now_Clock_ReturnsDateTimeNow()
        {
            Clock clk = new Clock();

            DateTime clkNow = clk.Now;
            DateTime now = DateTime.Now;

            Assert.AreEqual(clkNow.Year, now.Year);
            Assert.AreEqual(clkNow.Month, now.Month);
            Assert.AreEqual(clkNow.Day, now.Day);
            Assert.AreEqual(clkNow.Hour, now.Hour);
            Assert.AreEqual(clkNow.Minute, now.Minute);
            Assert.AreEqual(clkNow.Second, now.Second);
        }

        [TestMethod]
        public void NowUtc_Clock_ReturnsDateTimeNowUtc()
        {
            Clock clk = new Clock();

            DateTime clkNow = clk.UtcNow;
            DateTime now = DateTime.UtcNow;

            Assert.AreEqual(clkNow.Year, now.Year);
            Assert.AreEqual(clkNow.Month, now.Month);
            Assert.AreEqual(clkNow.Day, now.Day);
            Assert.AreEqual(clkNow.Hour, now.Hour);
            Assert.AreEqual(clkNow.Minute, now.Minute);
            Assert.AreEqual(clkNow.Second, now.Second);
        }

        [TestMethod]
        public void Today_Clock_ReturnsBusiness()
        {
            Clock clk = new Clock();

            BusinessDate clkNow = clk.Today;
            DateTime now = DateTime.Now;

            Assert.AreEqual(clkNow.Date.Year, now.Year);
            Assert.AreEqual(clkNow.Date.Month, now.Month);
            Assert.AreEqual(clkNow.Date.Day, now.Day);
            Assert.AreEqual(clkNow.Date.Hour, 0);
            Assert.AreEqual(clkNow.Date.Minute, 0);
            Assert.AreEqual(clkNow.Date.Second, 0);
            Assert.AreEqual(clkNow.Date.Millisecond, 0);
        }
    }
}
