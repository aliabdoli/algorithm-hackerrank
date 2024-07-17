using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.DynamicProgramming;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class ConstructTheArrayTests
    {
        [Theory]
        [InlineData(4, 3, 2, 3)]
        //[InlineData(761, 99, 1, 236568308)]
        //[InlineData(10, 5, 1, -10)]
        public void WhenThen(int n, int k, int x, long expectedCount)
        {
            //arrange
            var algo = new ConstructTheArray();
            //act
            var result = algo.CountArray(n, k, x);
            //assert
            result.Should().Be(expectedCount);
        }
    }
}
