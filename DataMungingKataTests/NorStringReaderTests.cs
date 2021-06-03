using System;
using Xunit;
using System.IO;
using DataMungingKata;

namespace DataMungingKataTests
{
    public class NorStringReaderTests
    {
        [Theory]
        [InlineData("ABCDEFG ABCDEFG")]
        [InlineData("Lol")]
        [InlineData("Many\r\nMany\r\nMany\r\nMany\r\nLines\r\nOf\r\ntextTextText")]
        public void GivenFilepath_ReadsContentToSingleString(string data)
        {
            string filePath = "filename.txt";
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(data);
            }

            var norStringReader = new NorStringReader(filePath);
            string actualData = norStringReader.ReadFileToString();

            File.Delete(filePath);
            Assert.Equal(data, actualData);
        }
    }
}
