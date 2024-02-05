using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Searching;
using Xunit;

namespace HackerRankAlgorithm.Tests.Searching
{
    public class ConnectedCellsInAGridTests
    {
        [Theory]
        [InlineData(@"4
4
1 1 0 0
0 1 1 0
0 0 1 0
1 0 0 0", 5)]


        [InlineData(@"    5
    4
    0 0 1 1
    0 0 1 0
    0 1 1 0
    0 1 0 0
    1 1 0 0", 8)]
        public void MainFlow(string inputString, int expected)
        {
            var algor = new ConnectedCellsInAGrid();
            var input = new StringReader(inputString);
            int n = Convert.ToInt32(input.ReadLine());

            int m = Convert.ToInt32(input.ReadLine());

            var matrix = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                var item = Array.ConvertAll(input.ReadLine().Trim().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp)).ToList();
                matrix.Add(item);
            }

            int result = algor.connectedCell(matrix);

            result.Should().Be(expected);
        }
    }
}
