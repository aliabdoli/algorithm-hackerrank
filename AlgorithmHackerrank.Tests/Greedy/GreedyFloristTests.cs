using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Greedy;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Greedy
{
    [TestFixture]
    public class GreedyFloristTests
    {
//        [TestCase(@"3 3
//2 5 6", 13)]
//        [TestCase(@"3 2
//2 5 6", 15)]
[TestCase(@"5 3
1 3 5 7 9", 29)]
        public void MainFlow(string inputString, int output)
        {
            var input  = new StringReader(inputString);
            string[] nk = input.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] c = Array.ConvertAll(input.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
                ;
            int minimumCost = GreedyFlorist.getMinimumCost(k, c);
            Assert.AreEqual(output, minimumCost);
        }
    }
}
