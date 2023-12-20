﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.ConstructiveAlgorithm;
using FluentAssertions;
using Xunit;

namespace AlgorithmHackerrank.Tests.ConstructiveAlgorithm
{
    public class NewYearChaosTests
    {
        [Theory]
        //[InlineData(@"2
        //5
        //2 1 5 3 4
        //5
        //2 5 1 3 4", "3,Too chaotic")]
        //[InlineData(@"2
        //8
        //5 1 2 3 7 8 6 4
        //8
        //1 2 5 3 7 8 6 4", "Too chaotic,7")]

        [InlineData(@"2
8
5 1 2 3 7 8 6 4
8
1 2 5 3 7 8 6 4", "Too chaotic,7")]
        public void WhenThen(string input, string expected)
        {
            var reader = new StringReader(input);
            var expectedArr = expected.Split(',');
            var algorithm = new NewYearChaos();

            int t = Convert.ToInt32(reader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(reader.ReadLine());

                int[] q = Array.ConvertAll(reader.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));
                var result = algorithm.minimumBribes(q);

                expectedArr[tItr].Should().Be(result);
            }
        }
    }
}
