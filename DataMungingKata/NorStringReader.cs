using System;
using System.Text;
using System.IO;

namespace DataMungingKata
{
    class NorStringReader
    {
        public NorStringReader(string path)
        {
            _path = path;
        }

        public string ReadFileToString()
        {
            string result = String.Empty;

            using (var reader = new StreamReader(_path))
            {
                var builder = new StringBuilder();
                string line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    builder.AppendLine(line);
                }
                result = builder.ToString();
            }
            return result.TrimEnd();
        }

        private readonly string _path;
    }
}