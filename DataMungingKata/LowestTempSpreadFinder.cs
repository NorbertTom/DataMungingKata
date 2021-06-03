using System;
using System.Collections.Generic;

namespace DataMungingKata
{
    public class LowestTempSpreadFinder
    {
        public LowestTempSpreadFinder(string[] lines)
        {
            _lines = lines;
            _daysWithLowestTempSpread = new List<string>();
        }

        public List<string> ReturnDays()
        {
            for (int i = 0; i < _lines.Length; i++)
            {
                int tempDiff = CalculateLinesTempDifference(i);
                UpdateDaysWithLowestTempSpread(tempDiff, i);
            }
            return _daysWithLowestTempSpread;
        }

        private int CalculateLinesTempDifference(int lineNr)
        {
            var lineDivider = new LineDivider(_lines[lineNr]);
            string temp1String = lineDivider.GetElement(1);
            string temp2String = lineDivider.GetElement(2);

            temp1String = temp1String.Replace('*', ' ');
            temp2String = temp2String.Replace('*', ' ');

            int temp1, temp2;

            if (Int32.TryParse(temp1String, out temp1)
                && Int32.TryParse(temp2String, out temp2))
            {
                return temp1-temp2 < 0 ? temp2-temp1 : temp1-temp2;
            }
            else
            {
                throw new Exception("Data error, invalid intigers in line: " + lineNr);
            }
        }

        private void UpdateDaysWithLowestTempSpread(int tempDiff, int lineNr)
        {
            if (tempDiff > _lowestTempDiff)
            {
                return;
            }
            if (tempDiff < _lowestTempDiff)
            {
                _lowestTempDiff = tempDiff;
                _daysWithLowestTempSpread = new List<string>();
            }
            var lineDivider = new LineDivider(_lines[lineNr]);
            _daysWithLowestTempSpread.Add(lineDivider.GetElement(0));
        }

        private readonly string[] _lines;
        int _lowestTempDiff = Int32.MaxValue;
        List<string> _daysWithLowestTempSpread;
    }
}