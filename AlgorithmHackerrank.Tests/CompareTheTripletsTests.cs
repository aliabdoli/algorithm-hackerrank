using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class CompareTheTripletsTests
    {
        [Test]
        public void WhenEveryThingIsValid_ThenReturnWrite()
        {
           var algorithm = new CompareTheTriplets();
            var input1 = new [] {5, 6, 7};
            var input2 = new [] {3, 6, 10};
            var result = algorithm.Solve(input1, input2);
           Assert.AreEqual(result[0], result[1]);
            Assert.AreEqual(result[0], 1);
        }
    }
}
