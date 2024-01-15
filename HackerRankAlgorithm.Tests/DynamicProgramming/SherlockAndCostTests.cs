using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.DynamicProgramming;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class SherlockAndCostTests
    {
        [Theory]
        [InlineData("1 2 3", 2)]
        [InlineData("10 1 10 1 10", 36)]
        [InlineData("100 2 100 2 100", 396)]
        [InlineData("4 7 9", 12)]
        [InlineData("3 15 4 12 10", 50)]
        [InlineData("59 61 78 94", 213)]
        [InlineData("69 19 15 81 93 100 35 18 81 16 65 20 4 45 81 83 90 14 82 85 43 7 64 76 33 47 95 12 78 93 14 22 97 36 65 66 36 26 59 81 81 82 44 79 89 94 32 94 22 33 19 46 46 62 19 47 70 91 97 62 17 43 11 25 74 73 64 98 73 7 40 8 2 96 89 81 80 17 88 13 31 44 64", 5001)]
        [InlineData("10 62 30 19 71 49 13 40 16 44 28", 426)]
        public void SherlockAndCostWhenThen(string input, int expected)
        {
            var B = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var algor = new SherlockAndCost();
            int result = algor.cost(B);

            result.Should().Be(expected);
        }
    }

}
