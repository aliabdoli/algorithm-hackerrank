using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Implementation;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Implementation
{
    public class AbsolutePermutationTests
    {
        //        [TestCase(@"3
        //2 1
        //3 0
        //3 2", @"2 1
        //1 2 3
        //-1")]
        [TestCase(@"10
10 0
10 1
7 0
10 9
9 0
10 3
8 2
8 0
7 0
10 1",
    @"1 2 3 4 5 6 7 8 9 10
2 1 4 3 6 5 8 7 10 9
1 2 3 4 5 6 7
-1
1 2 3 4 5 6 7 8 9
-1
3 4 1 2 7 8 5 6
1 2 3 4 5 6 7 8
1 2 3 4 5 6 7
2 1 4 3 6 5 8 7 10 9")]
        public void MainFlow(string inputString, string expectedString)
        {
            var input = new StringReader(inputString);
            var expected = new StringReader(expectedString);

            int t = Convert.ToInt32(input.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nk = input.ReadLine().Split(' ');

                int n = Convert.ToInt32(nk[0]);

                int k = Convert.ToInt32(nk[1]);

                int[] result = AbsolutePermutation.absolutePermutation(n, k);

                var finalResult = string.Join(" ", result);
                var fExpected = expected.ReadLine(); 
                Assert.AreEqual(fExpected, finalResult);
            }

        }
    }
}
