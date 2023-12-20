using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Searching;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.Searching
{
    public class CutTheTreeTests
    {
        [Theory]
        [InlineData(@"6
100 200 100 500 100 600
1 2
2 3
2 5
4 5
5 6", "400")]
        public void MainFlow(string inputString, string expectedString)
        {
            var input = new StringReader(inputString);

            int n = Convert.ToInt32(input.ReadLine().Trim());

            List<int> data = input.ReadLine().TrimEnd().Split(' ').ToList().Select(dataTemp => Convert.ToInt32(dataTemp)).ToList();

            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < n - 1; i++)
            {
                edges.Add(input.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
            }

            int result = CutTheTree.cutTheTree(data, edges);

            expectedString.Should().Be(result.ToString());
        }
    }
}
