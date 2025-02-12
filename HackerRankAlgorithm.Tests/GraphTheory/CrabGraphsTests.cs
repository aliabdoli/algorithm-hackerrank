using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.GraphTheory;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.GraphTheory
{
    public class CrabGraphsTests
    {
        [Theory]
        [InlineData(@"2
8 2 7
1 4
2 4
3 4
5 4
5 8
5 7
5 6
6 3 8
1 2
2 3
3 4
4 5
5 6
6 1
1 4
2 5", @"6
6")]
        public void MainFlow(string inputString, string expectedString)
        {
            var input = new StringReader(inputString);
            var expected = new StringReader(expectedString);

            int c = Convert.ToInt32(input.ReadLine());

            for (int cItr = 0; cItr < c; cItr++)
            {
                string[] ntm = input.ReadLine().Split(' ');

                int n = Convert.ToInt32(ntm[0]);

                int t = Convert.ToInt32(ntm[1]);

                int m = Convert.ToInt32(ntm[2]);

                var graph = new List<List<int>>();

                for (int graphRowItr = 0; graphRowItr < m; graphRowItr++)
                {
                    graph[graphRowItr] = Array.ConvertAll(input.ReadLine().Split(' '), graphTemp => Convert.ToInt32(graphTemp)).ToList();
                }

                int result = CrabGraphs.crabGraphs(n, t, graph);
                var expectedResult = expected.ReadLine();

                expectedResult.Should().Be(result.ToString());
            }
        }
    }
}
