using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.ConstructiveAlgorithm;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.ConstructiveAlgorithm
{
    [TestFixture]
    public class InverseRMQTests
    {
        //        [TestCase(@"4
        //3 1 3 1 2 4 1",
        //            @"YES
        //1 1 3 1 2 3 4")]

        //        [TestCase(@"2
        //        1 1 1",
        //                    @"NO
        //         ")]
        //        [TestCase(@"4
        //        3 1 3 1 2 4 1",
        //                    @"YES
        //        1 1 3 1 2 3 4")]
        //        [TestCase(@"2
        //        1 2 1",
        //                    @"YES
        //        1 1 2")]

        [TestCase(@"8
        -381858837 -460552444 -381858837 95397836 -460552444 855898381 -242860726 405278568 -460552444 982130115 -381858837 -460552444 95397836 981764727 855898381",
            @"YES
        -460552444 -460552444 -381858837 -460552444 95397836 -381858837 855898381 -460552444 -242860726 95397836 405278568 -381858837 981764727 855898381 982130115")]
        [Test]
        public void WhenThen(string inputString, string expectedString)
        {
            var inputReader = new StringReader(inputString);
            var expectedReader = new StringReader(expectedString);

            var input = new string [2];
            var expected = new string[2];

            for (int i = 0; i < 2; i++)
            {
                input[i] = inputReader.ReadLine().Trim();
                expected[i] = expectedReader.ReadLine().Trim();
            }

            var result = InverseRMQ.Create(input);
            Assert.AreEqual(expected[0], result[0]);
            if (result[0] != "NO")
            {
                Assert.AreEqual(expected[1], result[1]);
            }

        }
    }
}
