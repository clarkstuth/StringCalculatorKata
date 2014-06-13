using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorKataTest
{
    [TestClass]
    public class CalculatorTest
    {

        public void RunAdd(int expected, string numbers = null)
        {
            var calc = new Calculator();
            Assert.AreEqual(expected, calc.Add(numbers));
        }

        [TestMethod]
        public void AddShouldReturn0WithNoParameters()
        {
            var expected = 0;

            RunAdd(expected);
        }

        [TestMethod]
        public void AddShouldReturnOneIfGivenOne()
        {
            var expected = 1;
            var numbers = "1";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturnTwoIfGivenTwo()
        {
            var expected = 2;
            var numbers = "2";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn3IfGivenOneAndTwo()
        {
            var expected = 3;
            var numbers = "1,2";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn4IfGiven2And2()
        {
            var expected = 4;
            var numbers = "2,2";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGiven1And2And3()
        {
            var expected = 6;
            var numbers = "1,2,3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn10IfGiven1And2And3And4()
        {
            var expected = 10;
            var numbers = "1,2,3,4";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn21IfGiven1And2And3And4And5And6()
        {
            var expected = 21;
            var numbers = "1,2,3,4,5,6";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGiven1And2And3WithDifferentLineBreaks()
        {
            var expected = 6;
            var numbers = "1,2\n3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGivenOneAndTwoAndThreeWithOnlyLineBreaks()
        {
            var expected = 6;
            var numbers = "1\n2\n3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGiven1And2And3WithSemicolonDelimeterAtStart()
        {
            var expected = 6;
            var numbers = "//;\n1;2;3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGiven1And2And3WithBDelimeterAtStart()
        {
            var expected = 6;
            var numbers = "//B\n1B2B3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        public void AddShouldReturn6IfGiven1And2And3WithLeftParenDelimeterAtStartAndNormalDelimeters()
        {
            var expected = 6;
            var numbers = "//(\n1,2\n3";
            RunAdd(expected, numbers);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AddShouldThrowAnExceptionIfADelimeterIsGivenWithoutTheHeader()
        {
            var numbers = "1,2;3";
            RunAdd(0, numbers);
        }

        [TestMethod]
        [ExpectedException(typeof (NegativesNotAllowedException))]
        public void AddShouldThrowAnExceptionIfGivenNegativeOne()
        {
            var numbers = "-1";
            var expected = "Negatives Not Allowed: -1";
            try
            {
                RunAdd(0, numbers);
            }
            catch (NegativesNotAllowedException e)
            {
                Assert.AreEqual(expected, e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void AddShouldThrowAnExceptionIfGivenNegativeTwentyAndMultipleGoodNumbers()
        {
            var expected = "Negatives Not Allowed: -20";
            var numbers = "-20,3,4,5";
            try
            {
                RunAdd(0, numbers);
            }
            catch (NegativesNotAllowedException e)
            {
                Assert.AreEqual(expected, e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof (NegativesNotAllowedException))]
        public void AddShouldThrowAnExceptionIfGivenMultipleNegativeNumbersListingAllNegativeNumbers()
        {
            var expected = "Negatives Not Allowed: -20, -30";
            var numbers = "-20,3,4,5,-30";
            try
            {
                RunAdd(0, numbers);
            }
            catch (NegativesNotAllowedException e)
            {
                Assert.AreEqual(expected, e.Message);
                throw;
            }
        }

    }
}
