using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.DynamicProgramming;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class KingdomDivisionTests
    {
        [Theory]
        [InlineData(5, 
                @"1 2
                            1 3
                            3 4
                            3 5", 
                4 )]
        public void WhenThen(int cityCount, string roadsString, int expected)
        {
            //arrange
            var roadsTupples = roadsString.Split('\n').Select(x => x.Trim());

            var roads = new List<List<int>>();
            foreach (var roadTupple in roadsTupples)
            {
                var road = roadTupple.Split(" ").Select(x => int.Parse(x)).ToList();
                roads.Add(road);
            }

            //act
            var result = KingdomDivision.kingdomDivision(cityCount, roads);

            //assert
            result.Should().Be(expected);

        }
        
    }
}
