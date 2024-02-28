using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Others;
using Xunit;


namespace HackerRankAlgorithm.Tests
{
    
    public class TheTimeInTheWordsTests
    {
        [Theory]
        [InlineData("5 47", "thirteen minutes to six")]
        [InlineData("3 00", "three o' clock")]
        [InlineData("7 29", "twenty nine minutes past seven")]
        [InlineData("5 30", "half past five")]
        public void WhenThen(string input, string expected)
        {
            var algorithm = new TheTimeInTheWords();

            var timeArray = input.Split(' ').Select(x => int.Parse(x)).ToList();


            int h = timeArray[0];

            int m = timeArray[1];

            string result = algorithm.timeInWords(h, m);
            result.Should().Be(expected);
        }
    }
}
