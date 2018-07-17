using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class ExtraLongFactorialsTests
    {
        [Test]
        public void Run_IfNumberIsTooBig_StillCalculate()
        {
            var result = ExtraLongFactorials.Run(25);
            var expected = "15511210043330985984000000";
            var happened = String.Join("", result);
            Assert.IsTrue(string.Equals(expected, happened, StringComparison.OrdinalIgnoreCase));
        }

        [TestCase(2,2,4)]
        [TestCase(3,7,21)]
        [Test]
        public void MultiplyByAdd_WhenDataIsSmall_ReturnsRightData(int input1, int input2, int mult)
        {
            var result = ExtraLongFactorials.MultiplyByAdd(input1, input2);
            var stringResult = String.Join("", result);
            Assert.AreEqual(mult.ToString(), stringResult);
        }

        [TestCase(int.MaxValue, 2, "4294967294")]
        [Test]
        public void MultiplyByAdd_WhenDataIsBig_ReturnsRightData(int input1, int input2, string mult)
        {
            var result = ExtraLongFactorials.MultiplyByAdd(input1, input2);
            var stringResult = String.Join("", result);
            Assert.AreEqual(mult, stringResult);
        }

        [TestCase("0110", "0010", "01000")]
        //[TestCase("10101010", "10101010", "0101110110")]
        [Test]
        public void Add_WhenDataIsNormal_ReturnsRightData(string input1, string input2, string added)
        {
            var result = ExtraLongFactorials.Add(input1, input2);
            Assert.AreEqual(added, result);
        }
    }
}
