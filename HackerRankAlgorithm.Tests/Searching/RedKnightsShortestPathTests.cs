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
    public class RedKnightsShortestPathTests
    {
        [Theory]
        //        [InlineData(@"7
        //0 3 4 3", "LR LL")]
        //        [InlineData(@"7
        //6 6 0 1", "UL UL UL L")]
        //        [InlineData(@"6
        //5 1 0 5", "Impossible")]
        [InlineData(@"5
4 1 0 3", "UR UR")]

        public void MainFlow(string inputString, string outputString)
        {
            
            var input = new StringReader(inputString);
            int n = Convert.ToInt32(input.ReadLine());

            string[] i_startJ_start = input.ReadLine().Split(' ');

            int i_start = Convert.ToInt32(i_startJ_start[0]);

            int j_start = Convert.ToInt32(i_startJ_start[1]);

            int i_end = Convert.ToInt32(i_startJ_start[2]);

            int j_end = Convert.ToInt32(i_startJ_start[3]);

            bool result = false;
            var path = RedKnightsShortestPath.PrepareAndFindPath(n, i_start, j_start, i_end, j_end, out result);
            var resultPath = string.Join(" ", path);
            if (result)
            {
                outputString.Should().Be(resultPath);
            }
            else
            {
                "Impossible".Should().Be(outputString);
            }
        }
    }
}
