using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.GraphTheory;
using FluentAssertions;
using Xunit;

namespace AlgorithmHackerrank.Tests.GraphTheory
{
    public class JourneyToTheMoonTests
    {
        //        [InlineData(@"5 3
        //0 1
        //2 3
        //0 4", "6")]
        //        [InlineData(@"4 1
        //0 2", "5")]
        [Theory]
        [InlineData(@"100000 2
1 2
3 4", "4999949998")]
        public void MainFlow(string inputString, string expectedString)
        {
            var inputReader = new StringReader(inputString);
            var expectedReader = new StringReader(expectedString);

            string[] np = inputReader.ReadLine().Split(' ');

            int n = Convert.ToInt32(np[0]);

            int p = Convert.ToInt32(np[1]);

            int[][] astronaut = new int[p][];

            for (int i = 0; i < p; i++)
            {
                astronaut[i] = Array.ConvertAll(inputReader.ReadLine().Split(' '), astronautTemp => Convert.ToInt32(astronautTemp));
            }

            var result = JourneyToTheMoon.journeyToMoon(n, astronaut);

            var expected = expectedReader.ReadLine();

            expected.Should().Be(result.ToString());
        }
    }
}
