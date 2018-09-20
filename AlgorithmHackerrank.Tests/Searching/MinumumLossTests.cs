using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Searching
{
    [TestFixture]
    public class MinumumLossTests
    {
        [Test]
//        [TestCase(@"3
//5 10 3", 2)]
        [TestCase(@"5
20 7 8 2 5", 2)]
        public void WhenThen(string input, int expected)
        {
            var reader = new StringReader(input);
            int n = Convert.ToInt32(reader.ReadLine());

            long[] price = Array.ConvertAll(reader.ReadLine().Split(' '), priceTemp => Convert.ToInt64(priceTemp));

            var algorighm = new MinimumLoss();
            int result = algorighm.minimumLoss(price);
            
            Assert.AreEqual(expected, result);

        }
    }
}
