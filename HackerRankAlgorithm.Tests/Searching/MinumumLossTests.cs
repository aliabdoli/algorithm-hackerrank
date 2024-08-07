﻿using System;
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
    
    public class MinumumLossTests
    {
        [Theory]
//        [InlineData(@"3
//5 10 3", 2)]
        [InlineData(@"5
20 7 8 2 5", 2)]
        public void WhenThen(string input, int expected)
        {
            var reader = new StringReader(input);
            int n = Convert.ToInt32(reader.ReadLine());

            var price = Array.ConvertAll(reader.ReadLine().Split(' '), priceTemp => Convert.ToInt64(priceTemp)).ToList();

            var algorighm = new MinimumLoss();
            int result = algorighm.minimumLoss(price);

            expected.Should().Be(result);
        }
    }
}
