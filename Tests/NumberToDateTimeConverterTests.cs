using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RPN.Tests
{
    [TestClass()]
    public class NumberToDateTimeConverterTests
    {
        private double myBirthDate = 18.021992;
        private double years23 = 0.000023;

        private double simpleTime = 11.4023; // 11:30:23
        private double shortTime = 11.40; // 11:30:23


        [TestMethod()]
        public void getNumberOfDaysTest()
        {
            Assert.AreEqual(18, NumberToDateTimeConverter.getNumberOfDays(myBirthDate));
        }

        [TestMethod()]
        public void getNumberOfDays_ZeroDays()
        {
            Assert.AreEqual(0, NumberToDateTimeConverter.getNumberOfDays(years23));
        }

        [TestMethod()]
        public void getNumberOfMonthsTest()
        {
            Assert.AreEqual(2, NumberToDateTimeConverter.getNumberOfMonths(myBirthDate));
        }

        [TestMethod()]
        public void getNumberOfMonths_ZeroMonths()
        {
            Assert.AreEqual(0, NumberToDateTimeConverter.getNumberOfMonths(years23));
        }

        [TestMethod()]
        public void getNumberOfYearsTest()
        {
            Assert.AreEqual(1992, NumberToDateTimeConverter.getNumberOfYears(myBirthDate));
        }

        [TestMethod()]
        public void getNumberOfYears_23Years()
        {
            Assert.AreEqual(23, NumberToDateTimeConverter.getNumberOfYears(years23));
        }



        [TestMethod()]
        public void NumberToDateTime_FromValidDate()
        {
            Assert.AreEqual(new DateTime(1992,2,18), NumberToDateTimeConverter.NumberToDate(myBirthDate));
        }


        [TestMethod()]
        public void NumberToDateTime_FromNotValidDay()
        {
            Assert.IsNull(NumberToDateTimeConverter.NumberToDate(42.021992));
        }

        [TestMethod()]
        public void NumberToDateTime_FromNotValidMonth()
        {
            Assert.IsNull(NumberToDateTimeConverter.NumberToDate(18.151992));
        }

        [TestMethod()]
        public void NumberToDateTime_FromNotValidFormat()
        {
            Assert.IsNull(NumberToDateTimeConverter.NumberToDate(18));
        }

        [TestMethod()]
        public void NumberFromDate_ValidDate()
        {
            Assert.AreEqual(myBirthDate,NumberToDateTimeConverter.NumberFromDate(new DateTime(1992,2,18)));
        }

        [TestMethod()]
        public void getNumberOfHoursTest()
        {
            Assert.AreEqual(11,NumberToDateTimeConverter.getNumberOfHours(simpleTime));
        }

        [TestMethod()]
        public void getNumberOfMinutesTest()
        {
            Assert.AreEqual(40, NumberToDateTimeConverter.getNumberOfMinutes(simpleTime));
        }

        [TestMethod()]
        public void getNumberOfSecondsTest()
        {
            Assert.AreEqual(23, NumberToDateTimeConverter.getNumberOfSeconds(simpleTime));
        }


        [TestMethod()]
        public void getNumberOfHoursFromShortTime()
        {
            Assert.AreEqual(11, NumberToDateTimeConverter.getNumberOfHours(shortTime));
        }

        [TestMethod()]
        public void getNumberOfMinutesFromShortTime()
        {
            Assert.AreEqual(40, NumberToDateTimeConverter.getNumberOfMinutes(shortTime));
        }

        [TestMethod()]
        public void getNumberOfSeconds_FromShortTime()
        {
            Assert.AreEqual(00, NumberToDateTimeConverter.getNumberOfSeconds(shortTime));
        }

        [TestMethod()]
        public void NumberFromTimeTest()
        {
            Assert.AreEqual(11.4023, NumberToDateTimeConverter.NumberFromTime(new DateTime(1970, 1, 1, 11, 40, 23)));
        }

        [TestMethod()]
        public void NumberToTimeTest()
        {
            Assert.AreEqual(new DateTime(1970,1,1,11,40,23),NumberToDateTimeConverter.NumberToTime(simpleTime));
        }
    }
}
