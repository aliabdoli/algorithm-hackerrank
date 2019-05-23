using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Strings;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Strings
{
    public class CommonChildTests
    {
        [Test]
        [TestCase(@"WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS
FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC", 15)]
        [TestCase(@"ABCDEF
FBDAMN", 2)]
        [TestCase(@"SHINCHAN
NOHARAAA", 3)]
        [TestCase(@"AA
BB", 0)]
        [TestCase(@"HARRY
SALLY", 2)]
        public void MainFlow(string inputString, int expected)
        {
            var input = new StringReader(inputString);
            string s1 = input.ReadLine();

            string s2 = input.ReadLine();

            var algor = new CommonChild();

            int result = algor.commonChild(s1, s2);

            Assert.AreEqual(expected, result);

        }
    }
}
