using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AlgorithmHackerrank.Tests
{
    public class ExtraLongFactorialsTests
    {
        [Fact]
        public void Run_IfNumberIsTooBig_StillCalculate()
        {
            var result = ExtraLongFactorials.Run(25);
            var expected = "15511210043330985984000000";
            var happened = String.Join("", result);
            string.Equals(expected, happened, StringComparison.OrdinalIgnoreCase).Should().BeTrue();
        }
        [Theory]
        [InlineData(2,2,4)]
        [InlineData(3,7,21)]
        public void MultiplyByAdd_WhenDataIsSmall_ReturnsRightData(int input1, int input2, int mult)
        {
            var result = ExtraLongFactorials.MultiplyByAdd(input1, input2);
            var stringResult = String.Join("", result);
            mult.ToString().Should().Be(stringResult);
        }

        [InlineData(int.MaxValue, 2, "4294967294")]
        [Theory]
        public void MultiplyByAdd_WhenDataIsBig_ReturnsRightData(int input1, int input2, string mult)
        {
            var result = ExtraLongFactorials.MultiplyByAdd(input1, input2);
            var stringResult = String.Join("", result);
            mult.Should().Be(stringResult);
        }

        [InlineData("0110", "0010", "01000")]
        //[InlineData("10101010", "10101010", "0101110110")]
        [Theory]
        public void Add_WhenDataIsNormal_ReturnsRightData(string input1, string input2, string added)
        {
            var result = ExtraLongFactorials.Add(input1, input2);
            added.Should().Be(result);
        }
    }
}
