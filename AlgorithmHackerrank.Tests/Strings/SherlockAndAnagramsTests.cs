using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using AlgorithmHackerrank.Strings;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Strings
{
    public class SherlockAndAnagramsTests
    {
        [Test]
        [TestCase(@"2
abba
abcd", @"4,0")]
        [TestCase(@"2
kkkk
ifailuhkqq", @"10,3")]
        public void MainFlow(string inputString, string expectedString)
        {
            var expected = expectedString.Split(',');
            var algor = new SherlockAndAnagrams();
            var input = new StringReader(inputString);
            int q = Convert.ToInt32(input.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = input.ReadLine();

                int result = algor.sherlockAndAnagrams(s);
                Assert.AreEqual(expected[qItr], result.ToString());
            }

        }
    }
}
