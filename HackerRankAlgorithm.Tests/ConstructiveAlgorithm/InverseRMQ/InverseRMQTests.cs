using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.ConstructiveAlgorithm;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.ConstructiveAlgorithm
{
    public class InverseRMQTests
    {
        [Theory]
        [InlineData(@"4
        3 1 3 1 2 4 1",
            @"YES
        1 1 3 1 2 3 4")]

        [InlineData(@"2
                1 1 1",
                    @"NO
                 ")]
        [InlineData(@"4
                3 1 3 1 2 4 1",
                    @"YES
                1 1 3 1 2 3 4")]
        [InlineData(@"2
                1 2 1",
                    @"YES
                1 1 2")]
        [InlineData(@"1
                100500",
            @"YES
                100500")]

        [InlineData(@"8
    -381858837 -460552444 -381858837 95397836 -460552444 855898381 -242860726 405278568 -460552444 982130115 -381858837 -460552444 95397836 981764727 855898381",
            @"YES
    -460552444 -460552444 -381858837 -460552444 95397836 -381858837 855898381 -460552444 -242860726 95397836 405278568 -381858837 981764727 855898381 982130115")]
        [InlineData(@"16
    853983969 -978042718 -978042718 450604419 -165623018 -978042718 547711710 -73146423 -978042718 385413807 70205259 547711710 -298759545 70205259 -165623018 -165623018 754254573 836644654 263361326 253722771 298624814 263361326 -978042718 -165623018 -335447872 -31265955 -335447872 -31265955 70205259 298624814 -335447872",
            @"YES
    -978042718 -978042718 -165623018 -978042718 -335447872 -165623018 70205259 -978042718 -31265955 -335447872 263361326 -165623018 298624814 70205259 547711710 -978042718 -298759545 -31265955 253722771 -335447872 -73146423 263361326 385413807 -165623018 450604419 298624814 754254573 70205259 836644654 547711710 853983969")]

        public void WhenThen(string inputString, string expectedString)
        {
            //arrange
            var inputReader = new StringReader(inputString);
            var expectedReader = new StringReader(expectedString);

            var input = new string [2];
            

            var expectedDoable = expectedReader.ReadLine().Trim();
            var expectedTreeString = expectedReader.ReadLine().Trim();
            var expectedRmqTree = new List<long>();
            if (!string.IsNullOrEmpty(expectedTreeString.Trim()))
            {
                expectedRmqTree = Array.ConvertAll(expectedTreeString.Trim().Split(' '), long.Parse).ToList();

            }

            for (int i = 0; i < 2; i++)
            {
                input[i] = inputReader.ReadLine().Trim();
            }

            var algo = new InverseRMQ();
            var len = int.Parse(input[0]);
            var inputs = Array.ConvertAll(input[1].Trim().Split(' '), long.Parse);

            //act
            var result = algo.Create(len, inputs);

            //assert
            expectedDoable.Should().Be(result.IsDoable);
            expectedRmqTree.Should().BeEquivalentTo(result.TreeSnapshot);

        }

        [Theory]
        [InlineData("C:\\work\\chapter\\algorithm-hackerrank\\HackerRankAlgorithm.Tests\\ConstructiveAlgorithm\\InverseRMQ\\LoadTestCase14.txt")]
        public void LoadTest(string inputFilePath)
        {
            var inputString = File.ReadAllText(inputFilePath);
            var inputReader = new StringReader(inputString);

            var input = new string[2];
            for (int i = 0; i < 2; i++)
            {
                input[i] = inputReader.ReadLine().Trim();
            }

            var algo = new InverseRMQ();
            var len = int.Parse(input[0]);
            var inputs = Array.ConvertAll(input[1].Trim().Split(' '), long.Parse);

            //act
            var result = algo.Create(len, inputs);



        }

        [Fact]
        public void TestRunner()
        {
            var algo = new InverseRMQRunner();
            algo.MainRunner(null);
        }
    }
}
