using System;
using System.Collections.Generic;
using Xunit;
using DataMungingKata;

namespace DataMungingKataTests
{
    public class LowestTempSpreadFinderTests
    {

        [Fact]
        public static void GivenArrayOfValidStrings_ReturnsDayNumberWithLowestTempSpread_Case1()
        {
            string[] linesOfData = { "1 32 25", "2 33 32", "3 10 100" };
            var expectedResult = new List<string>() { "2" };
            var lowestTempSpreadFinder = new LowestTempSpreadFinder(linesOfData);
            Assert.Equal(expectedResult, lowestTempSpreadFinder.ReturnDays());
        }

        [Fact]
        public static void GivenArrayOfValidStrings_ReturnsDayNumberWithLowestTempSpread_Case2()
        {
            string[] linesOfData = { "1 37 25", "2 34 32", "3 10 100", "4 55 57", "5 64 63" };
            var expectedResult = new List<string>() { "5" };
            var lowestTempSpreadFinder = new LowestTempSpreadFinder(linesOfData);
            Assert.Equal(expectedResult, lowestTempSpreadFinder.ReturnDays());
        }


        [Fact]
        public static void GivenArrayOfValidStrings_ReturnsDayNumbersWithLowestTempSpread()
        {
            string[] linesOfData = { "1 37 25", "2 34 32", "3 10 100", "4 55 57" };
            var expectedResult = new List<string>() { "2", "4" };
            var lowestTempSpreadFinder = new LowestTempSpreadFinder(linesOfData);
            Assert.Equal(expectedResult, lowestTempSpreadFinder.ReturnDays());
        }

        [Fact]
        public static void GivenFileAsArrayOfInvalidStrings_ThrowsException()
        {
            string[] linesOfData = { "1 32 25", "2 cx 32", "3 10 w" };
            string errorMessage = String.Empty;
            var lowestTempSpreadFinder = new LowestTempSpreadFinder(linesOfData);
            try
            {
                lowestTempSpreadFinder.ReturnDays();
            }
            catch (Exception error)
            {
                errorMessage = error.Message;
            }
            Assert.Equal("Data error, invalid intigers in line: 1", errorMessage);
        }
    }
}