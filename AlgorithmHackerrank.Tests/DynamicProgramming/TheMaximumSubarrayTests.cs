using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.DynamicProgramming;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.DynamicProgramming
{
    [TestFixture]
    public class TheMaximumSubarrayTests
    {
        [Test]
        //        [TestCase(@"1
        //6
        //-1 2 3 -4 5 10")]
        [TestCase(@"2
4
1 2 3 4
6
2 -1 2 3 4 -5")]
        //        [TestCase(@"1
        //5
        //-2 -3 -1 -4 -6")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);

            int t = Convert.ToInt32(input.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(input.ReadLine());

                int[] arr = Array.ConvertAll(input.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

                int[] result = TheMaximumSubarray.maxSubarray(arr);

            }

        }
    }
}
