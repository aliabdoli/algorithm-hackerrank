using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Strings;
using FluentAssertions;
using Xunit;

namespace AlgorithmHackerrank.Tests.Strings
{
    public class CommonChildTests
    {
        [Theory]
        [InlineData(@"WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS
FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC", 15)]
        [InlineData(@"ABCDEF
FBDAMN", 2)]
        [InlineData(@"SHINCHAN
NOHARAAA", 3)]
        [InlineData(@"AA
BB", 0)]
        [InlineData(@"HARRY
SALLY", 2)]
        public void MainFlow(string inputString, int expected)
        {
            var input = new StringReader(inputString);
            string s1 = input.ReadLine();

            string s2 = input.ReadLine();

            var algor = new CommonChild();

            int result = algor.commonChild(s1, s2);

            expected.Should().Be(result);
        }
    }
}
