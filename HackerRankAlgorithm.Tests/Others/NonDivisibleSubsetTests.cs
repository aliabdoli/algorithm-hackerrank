using FluentAssertions;
using HackerRankAlgorithm.Others;

namespace HackerRankAlgorithm.Tests.Others
{
    public class NonDivisibleSubsetTests
    {
        [Theory]
        [InlineData("1 7 2 4", 3, 3)]
        [InlineData("9 7 11 21", 10, 3)]
        [InlineData("19 10 12 10 24 25 22", 4, 3)]
        public void When_Then(string s, int k, int expected)
        {
            var algorithm = new NonDivisibleSubset();
            var superSet = s.Split(' ').Select(x => int.Parse(x)).ToList() ;
            var result = algorithm.Run(k, superSet);

            result.Should().Be(expected);
        }


        [Theory]
        [InlineData(100)]
        public void Performance_Test(int supersetSize)
        {
            var k = 3;
            var algorithm = new NonDivisibleSubset();
            var superSet = Enumerable.Range(1, supersetSize).ToList();
            var _ = algorithm.Run(k, superSet);
        }
    }
}
