using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Implementation;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.Implementation
{
    public class LarrysArrayTests
    {
        //        [InlineData(@"3
        //3
        //3 1 2
        //4
        //1 3 4 2
        //5
        //1 2 3 5 4", @"YES
        //YES
        //NO")]
        [Theory]
        [InlineData(@"5
12
9 6 8 12 3 7 1 11 10 2 5 4
21
17 21 2 1 16 9 12 11 6 18 20 7 14 8 19 10 3 4 13 5 15
15
5 8 13 3 10 4 12 1 2 7 14 6 15 11 9
13
8 10 6 11 7 1 9 12 3 5 13 4 2
18
7 9 15 8 10 16 6 14 5 13 17 12 3 11 4 1 18 2", @"NO
YES
NO
YES
NO")]
        public void Do(string input, string expected)
        {
            var expectedReader = new StringReader(expected);
            var inputReader = new StringReader(input);
            int t = Convert.ToInt32(inputReader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                var exp = expectedReader.ReadLine();
                int n = Convert.ToInt32(inputReader.ReadLine());
                int[] A = Array.ConvertAll(inputReader.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));

                string result = LarrysArrayAlgorithm.larrysArray(A.Select(x => x).ToArray());

                exp.Should().Be(result);
            }
        }
    }
}
