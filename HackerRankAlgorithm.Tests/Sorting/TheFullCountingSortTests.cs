using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Sorting;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.Sorting
{
    
    public class TheFullCountingSortTests
    {
        [Theory]
        [InlineData(@"20
            0 ab
        6 cd
        0 ef
        6 gh
        4 ij
        0 ab
        6 cd
        0 ef
        6 gh
        0 ij
        4 that
        3 be
        0 to
        1 be
        5 question
        1 or
        2 not
        4 is
        2 to
        4 the", "- - - - - to be or not to be - that is the question - - - -")]
        [InlineData(@"10
    1 e
    2 a
    1 b
    3 a
    4 f
    1 f
    2 a
    1 e
    1 b
    1 c", "- - f e b c - a - -")]
        public void BasicShouldPass(string input, string expected)
        {
            
          
            var inputString = new StringReader(input);
            int n = Convert.ToInt32(inputString.ReadLine().Trim());

            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(inputString.ReadLine().Trim().Split(' ').ToList());
            }


            var algor = new TheFullCountingSort();
            var result = algor.countSort(arr);
            result.Should().Be(expected);
        }
    }
}
