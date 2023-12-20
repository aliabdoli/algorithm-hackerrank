using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Others;
using Xunit;

namespace HackerRankAlgorithm.Tests
{
    public class NonDivisibleSubsetTests
    {
        [Fact]
        public void WhenThen()
        {
            var algorithm = new NonDivisibleSubset();
            var k = 3;
            var s = new[] {1, 7, 2, 4};
            var result = algorithm.Run(k, s);

            3.Should().Be(result);
        }
    }
}
