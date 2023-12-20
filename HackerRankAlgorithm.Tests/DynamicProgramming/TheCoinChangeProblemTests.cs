using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.DynamicProgramming;
using Xunit;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class TheCoinChangeProblemTests
    {
        [Theory]
        //        [InlineData(@"10 4
        //2 5 3 6")]
        //        [InlineData(@"166 23
        //5 37 8 39 33 17 22 32 13 7 10 35 40 2 43 49 46 19 41 1 12 11 28")]
        [InlineData(@"75 27
25 10 11 29 49 31 33 39 12 36 40 22 21 16 37 8 18 4 27 17 26 32 6 38 2 30 34")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);
            var algor = new TheCoinChangeProblem();

            string[] nm = input.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            long[] c = Array.ConvertAll(input.ReadLine().Split(' '), cTemp => Convert.ToInt64(cTemp))
                ;
            // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

            long ways = algor.getWays(n, c);
        }
    }
}
