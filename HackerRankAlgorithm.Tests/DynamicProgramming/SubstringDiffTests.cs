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
    public class SubstringDiffTests
    {
        [Theory]
        [InlineData(@"1
2 tabriz torino")]
//        [InlineData(@"1
//3 helloworld yellomarin")]
        //        [InlineData(@"1
        //0 abacba abcaba")]
        //        [InlineData(@"1
        //0 abc cab")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);
            int t = Convert.ToInt32(input.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] kS1S2 = input.ReadLine().Split(' ');

                int k = Convert.ToInt32(kS1S2[0]);

                string s1 = kS1S2[1];

                string s2 = kS1S2[2];

                int result = SubstringDiff.substringDiff(k, s1, s2);

            }

        }
    }
}
