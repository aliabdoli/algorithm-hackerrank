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
    public class ClimbingTheLeaderboardTests
    {
        [Test]
        public void WhenThen()
        {
            var algorithm = new ClimbingTheLeaderboard();
            var scores = new [] {100, 100, 50, 40, 40, 20, 10};
            var alice = new [] { 5, 10, 25, 50, 120, 100 };
            
            var result = algorithm.FindTheRank(scores, alice);
            Assert.AreEqual(result[0], 6);
            Assert.AreEqual(result[1], 5);
            Assert.AreEqual(result[2], 4);
            Assert.AreEqual(result[3], 2);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 1);
        }

        [Test]
        public void WhenThen2()
        {
            var algorithm = new ClimbingTheLeaderboard();
            var scores = new[] { 100, 100, 50, 40, 40, 20, 10 };
            var alice = new[] { 5, 25, 50, 120};

            var result = algorithm.FindTheRank(scores, alice);
            Assert.AreEqual(result[0], 6);
            Assert.AreEqual(result[1], 4);
            Assert.AreEqual(result[2], 2);
            Assert.AreEqual(result[3], 1);
        }
    }
}
