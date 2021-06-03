using System;
using System.Collections.Generic;

namespace DataMungingKata
{
    public class LowestGoalDifferenceFinder
    {
        public LowestGoalDifferenceFinder(string[] linesOfData)
        {
            _lines = linesOfData;
            _teamsWithLowestGoalDifference = new List<string>();
        }

        public List<string> ReturnTeams()
        {
            for (int i=0;i<_lines.Length;i++)
            {
                int goalDifference = CalculateGoalDifference(i);
                UpdateTeamWithLowestGoalDifference(goalDifference, i);
            }
            return _teamsWithLowestGoalDifference;
        }

        private int CalculateGoalDifference(int lineNr)
        {
            int goalsFor, goalsAgainst;
            var lineDivider = new LineDivider(_lines[lineNr]);

            if (Int32.TryParse(lineDivider.GetElement(6), out goalsFor)
               && Int32.TryParse(lineDivider.GetElement(8), out goalsAgainst))
            {
                return goalsFor - goalsAgainst < 0 ? goalsAgainst - goalsFor : goalsFor - goalsAgainst;
            }
            else
            {
                throw new Exception("Data error, invalid intigers in line: " + lineNr);
            }
        }

        private void UpdateTeamWithLowestGoalDifference(int goalDifference, int lineNr)
        {
            if (goalDifference > _lowestGoalDifference)
            {
                return;
            }
            if (goalDifference < _lowestGoalDifference)
            {
                _lowestGoalDifference = goalDifference;
                _teamsWithLowestGoalDifference = new List<string>();
            }
            var lineDivider = new LineDivider(_lines[lineNr]);
            _teamsWithLowestGoalDifference.Add(lineDivider.GetElement(1));
        }

        private readonly string[] _lines;
        private int _lowestGoalDifference = Int32.MaxValue;
        private List<string> _teamsWithLowestGoalDifference;
    }
}
