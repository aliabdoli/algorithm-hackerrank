using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Recursion;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.Recursion
{
    public class KFactorizationTests
    {
        [Theory]
        [InlineData(12,
        @"2 3 4",
        "1 3 12")]
        [InlineData(72,
        "2 4 6 9 3 7 16 10 5",
        "1 2 8 72")]
        [InlineData(15,
        "2 10 6 9 11",
        "-1")]
        [InlineData(175840877,
        "4 5 6 7 8 10 12 17 18 19",
        "-1"
        )]

        [InlineData(231000000,
            "2 3 5 7 11 13 17 19",
            "1 2 4 8 16 32 64 192 960 4800 24000 120000 600000 3000000 21000000 231000000"
        )]

        [InlineData(357000000,
            "2 3 5 7 11 13 17 19",
            "1 2 4 8 16 32 64 192 960 4800 24000 120000 600000 3000000 21000000 357000000"
        )]

        [InlineData(429000000,
            "2 3 5 7 11 13 17 19",
            "1 2 4 8 16 32 64 192 960 4800 24000 120000 600000 3000000 33000000 429000000"
        )]


        public void MainFlow(int target, string multipliers, string expectedMultiplierPath)
        {
            var A = multipliers.Split(' ')
                .Select(x => int.Parse(x.Trim()))
                .ToList();
            var n = target;
            var result = kFactorization.Do(n, A);

            var resultString = string.Join(" ", result);
            resultString.Should().Be(expectedMultiplierPath);
        }
    }
}
