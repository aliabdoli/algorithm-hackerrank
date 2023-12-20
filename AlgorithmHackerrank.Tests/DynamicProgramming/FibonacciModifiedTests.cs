﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.DynamicProgramming;
using Xunit;

namespace AlgorithmHackerrank.Tests.DynamicProgramming
{
    public class FibonacciModifiedTests
    {
        [Theory]
        [InlineData(@"0 1 5")]
        //[InlineData(@"1 1 20")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);
            var algor = new FibonacciModified();

            string[] t1T2n = input.ReadLine().Split(' ');

            int t1 = Convert.ToInt32(t1T2n[0]);

            int t2 = Convert.ToInt32(t1T2n[1]);

            int n = Convert.ToInt32(t1T2n[2]);

            string result = algor.fibonacciModified(t1, t2, n);

        }
    }
}
