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
        public void WhenSimpleInput_ThenReturnScores()
        {
            //arrange
            var algo = new CompareTheTriplets();
            var aScores = new List<int>() { 1, 2, 3 };
            var bScores = new List<int>() { 1, 2, 3 };

            var expected = new List<int>() { 1, 1 };

            //act
            var pointSummary =  algo.Solve(aScores, bScores);
            
            //assert
            Assert.AreEqual(expected, pointSummary);
        }
    }
}
