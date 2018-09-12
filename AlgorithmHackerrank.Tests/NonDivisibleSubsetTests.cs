using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class NonDivisibleSubsetTests
    {
        [Test]
        public void WhenThen()
        {
            var algorithm = new NonDivisibleSubset();
            var k = 3;
            var s = new[] {1, 7, 2, 4};
            var result = algorithm.Run(k, s);

            Assert.AreEqual(3, result);
        }
    }
}
