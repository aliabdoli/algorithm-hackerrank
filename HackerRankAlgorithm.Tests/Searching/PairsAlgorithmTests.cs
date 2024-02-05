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
    
    public class PairsAlgorithmTests
    {
        [Theory]
        [InlineData(@"5 2  
1 5 3 4 2", 3)]

        [InlineData(@"7 2
    1 3 5 8 6 4 2", 5)]
        public void MainFlow(string inputString, int expected)
        {
            var algor = new PairsAlgorithm();
            var input = new StringReader(inputString);
            string[] nk = input.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            var arr = Array.ConvertAll(
                    input.ReadLine().Trim().Split(' '), arrTemp => Convert.ToInt32(arrTemp)).ToList()
                ;
            int result = algor.pairs(k, arr);
            result.Should().Be(expected);

        }
    }
}
