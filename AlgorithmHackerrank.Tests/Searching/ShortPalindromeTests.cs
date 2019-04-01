using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.Searching
{
    [TestFixture]
    public class ShortPalindromeTests
    {
        public void MainTest(string inputString)
        {
            var algor = new ShortPalindrome();
            var input = new StringReader(inputString);

            string s = input.ReadLine();

            int result = algor.shortPalindrome(s);
            
        }
    }
}
