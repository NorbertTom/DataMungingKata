using System;
using Xunit;
using DataMungingKata;

namespace DataMungingKataTests
{
    public class LineDividerTests
    {
        [Fact]
        public void GivenString_GetElementReturnsCorrectElement()
        {
            string testString = "    I    have many   spaces in that text     ";
            var lineDivider = new LineDivider(testString);
            Assert.Equal("I", lineDivider.GetElement(0));
            Assert.Equal("have", lineDivider.GetElement(1));
            Assert.Equal("many", lineDivider.GetElement(2));
            Assert.Equal("spaces", lineDivider.GetElement(3));
            Assert.Equal("in", lineDivider.GetElement(4));
            Assert.Equal("that", lineDivider.GetElement(5));
            Assert.Equal("text", lineDivider.GetElement(6));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(2)]
        [InlineData(-1)]
        [InlineData(10)]
        public void GivenInvalidElementNumber_ThrowsException(int elementNr)
        {
            string testString = "  Some message";
            string errorMessage = "";
            var lineDivider = new LineDivider(testString);
            try
            {
                lineDivider.GetElement(elementNr);
            }
            catch (Exception error)
            {
                errorMessage = error.Message;
            }
            Assert.Equal("Invalid elementNumber: " + elementNr, errorMessage); // test negative numbers as well
        }

    }
}
