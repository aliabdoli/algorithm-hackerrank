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
        [Fact]
        public void WhenThen()
        {
            var algorithm = new TheTimeInTheWords();
            var input = @"5
47";
            var textWriter = new StringReader(input);

            int h = Convert.ToInt32(textWriter.ReadLine());

            int m = Convert.ToInt32(textWriter.ReadLine());

            string result = algorithm.timeInWords(h, m);
            "thirteen minutes to six".Should().Be(result);
        }

        [Fact]
        public void WhenThen1()
        {
            var algorithm = new TheTimeInTheWords();
            var input = @"3
00";
            var textWriter = new StringReader(input);

            int h = Convert.ToInt32(textWriter.ReadLine());

            int m = Convert.ToInt32(textWriter.ReadLine());

            string result = algorithm.timeInWords(h, m);
            "three o' clock".Should().Be(result);
        }
    }
}
