using System;
using System.Collections.Generic;
using Xunit;
using DataMungingKata;

namespace DataMungingKataTests
{
    public class LowestGoalDifferenceFinderTests
    {
        [Fact]
        public void GivenValidData_ReturnsNameOfTeamWithLowestGoalDifference()
        {
            string[] inputData = { "2. Team1 32 2 3 2 45 - 3 654", "5. Team2 22 3 1 2 33 - 0 32",
                                    "1. Team3 123 54 343 234 55 - 56 8"} ; //7th and 9th are goals
            var expectedResult = new List<string>() { "Team3" };
            var lowestGoalDifferenceFinder = new LowestGoalDifferenceFinder(inputData);
            Assert.Equal(expectedResult, lowestGoalDifferenceFinder.ReturnTeams());
        }

        [Fact]
        public void GivenValidData_ReturnsNameOfTeamWithLowestGoalDifference_Case2()
        {
            string[] inputData = { "2. Team1 32 2 3 2 45 - 43 654", "5. Team2 22 3 1 2 33 - 31 32",
                                    "1. TeamX 123 54 343 234 55 - 56 8"}; //7th and 9th are goals
            var expectedResult = new List<string>() { "TeamX" };
            var lowestGoalDifferenceFinder = new LowestGoalDifferenceFinder(inputData);
            Assert.Equal(expectedResult, lowestGoalDifferenceFinder.ReturnTeams());
        }

        [Fact]
        public void GivenValidDataWithFewTeamsHavingSameGoalDifference_ReturnsTeamsWithLowestGoalDifference()
        {
            string[] inputData = { "2. TeamA 32 2 3 2 45 - 44 654", "5. TeamB 22 3 1 2 33 - 0 32",
                                    "1. TeamC 123 54 343 234 55 - 56 8"}; //7th and 9th are goals
            var expectedResult = new List<string>() { "TeamA", "TeamC" };
            var lowestGoalDifferenceFinder = new LowestGoalDifferenceFinder(inputData);
            Assert.Equal(expectedResult, lowestGoalDifferenceFinder.ReturnTeams());
        }

        [Fact]
        public void GivenInvalidData_ThrowsProperException()
        {
            string[] inputData = { "2 sa s a d s 2 z 3 s d f s asd f sa ds f", "a a s d s s z 4" };
            string expectedErrorMessage = "Data error, invalid intigers in line: 1";
            var lowestGoalDifferenceFinder = new LowestGoalDifferenceFinder(inputData);
            string actualErrorMessage = String.Empty;
            try
            {
                lowestGoalDifferenceFinder.ReturnTeams();
            }
            catch (Exception error)
            {
                actualErrorMessage = error.Message;
            }
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
    }
}
