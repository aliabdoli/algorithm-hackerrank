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
    public class SherlockAndCostTests
    {
        [Test]
        [TestCase(@"1
5
100 2 100 2 100", 396)]
        public void SherlockAndCostWhenThen(string input, int expected)
        {
            var reader = new StringReader(input);

            int t = Convert.ToInt32(reader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(reader.ReadLine());

                int[] B = Array.ConvertAll(reader.ReadLine().Split(' '), BTemp => Convert.ToInt32(BTemp));
                var algor = new SherlockAndCost();
                int result = algor.cost(B);

                Assert.AreEqual(expected, result);

            }
        }
    }

}
