using System;
using System.Collections.Generic;

namespace DataMungingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> DaysWithLowestTempSpread = FindDaysWithLowestTempSpread();
            foreach (string day in DaysWithLowestTempSpread)
            {
                Console.WriteLine(day);
            }
            List<string> TeamsWithSmallestGoalDifference = FindTeamsWithSmallestGoalDifference();
            foreach (string team in TeamsWithSmallestGoalDifference)
            {
                Console.WriteLine(team);
            }
        }

        static private List<string> FindDaysWithLowestTempSpread()
        {
            string filePath = "C:\\Projects\\Games\\DataMungingKata\\!Data\\weather.dat";
            string[] lines = LoadFileToArrayOfStrings(filePath);
            string[] linesWithTemperature = GetLinesForCalculations(lines, "temp");

            var lowestTempSpreadFinder = new LowestTempSpreadFinder(linesWithTemperature);
            return lowestTempSpreadFinder.ReturnDays();
        }

        static private List<string> FindTeamsWithSmallestGoalDifference()
        {
            string filePath = "C:\\Projects\\Games\\DataMungingKata\\!Data\\football.dat";
            string[] lines = LoadFileToArrayOfStrings(filePath);
            string[] linesToCalculate = GetLinesForCalculations(lines, "goals");
            var lowestGoalDifferenceFinder = new LowestGoalDifferenceFinder(linesToCalculate);
            return lowestGoalDifferenceFinder.ReturnTeams();
        }

        static private string[] LoadFileToArrayOfStrings(string filePath)
        {
            var norStringReader = new NorStringReader(filePath);
            string wholeFile = norStringReader.ReadFileToString();
            return wholeFile.Split('\n');
        }

        static private string[] GetLinesForCalculations(string[] lines, string temperatureOrGoals)
        {
            string[] returnString = new string[lines.Length - 3];
            int returnStringIterator = 0;
            int dataStartingLine = temperatureOrGoals == "goals" ? 1 : 2;
            int lineToOmmit = temperatureOrGoals == "goals" ? 18 : 0;

            for (int i = dataStartingLine; i < lines.Length; i++)
            {
                if (i != lineToOmmit && returnStringIterator < returnString.Length)
                {
                    returnString[returnStringIterator] = lines[i];
                    returnStringIterator++;
                }
            }
            return returnString;
        }
    }
}