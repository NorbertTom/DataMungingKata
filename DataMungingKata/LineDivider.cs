using System;

namespace DataMungingKata
{
    class LineDivider
    {
        public LineDivider(string line)
        {
            line = EraseMultipleSpaces(line);
            ChopLine(line);
        }

        public string GetElement(int elementNumber)
        {
            if (elementNumber >= _choppedLine.Length || elementNumber < 0)
            {
                throw new Exception("Invalid elementNumber: " + elementNumber);
            }
            return _choppedLine[elementNumber];
        }

        private string EraseMultipleSpaces(string line)
        {
            line = line.Trim();
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == ' ' && line[i - 1] == ' ')
                {
                    line = line.Remove(i, 1);
                    i--;
                }
            }
            return line;
        }

        private void ChopLine(string line)
        {
            _choppedLine = line.Split(" ");
        }

        private string[] _choppedLine;
    }
}
