using FluentAssertions;
using HackerRankAlgorithm.DynamicProgramming;


namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class HackerRankCityRunnerTests
    {
        [Theory]
        [InlineData(@"1
1", 29)]
        public void MainFlow(string inputString, int expected)
        {
            //arrange
            var input = new StringReader(inputString);
            int ACount = Convert.ToInt32(input.ReadLine());
            var A = Array.ConvertAll(input.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp)).ToList();

            //act
            int result = HackerRankCityRunner.hackerrankCity(A);

            //assert
            result.Should().Be(expected);
        }
    }
}
