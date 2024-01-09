using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.DynamicProgramming;
using Xunit;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class TheMaximumSubarrayTests
    {
        [Theory]
        [InlineData("1 2 3 4", 10, 10)]
        [InlineData("2 -1 2 3 4 -5", 10, 11)]
        [InlineData("-2 -3 -1 -4 -6", -1, -1)]
        [InlineData("-1 2 3 -4 5 10", 16, 20)]
        public void MainFlow(string inputArrayString, int expectedSubarray, int expectedSubseq)
        {
            //arrange
            var inputArray = inputArrayString.Split(' ').Select(x => int.Parse(x)).ToList();
            
            //act
            var result = TheMaximumSubarray.maxSubarray(inputArray);
            
            // assert
            result[0].Should().Be(expectedSubarray);
            result[1].Should().Be(expectedSubseq);
        }
    }
}
