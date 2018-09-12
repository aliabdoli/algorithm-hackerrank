using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class TheTimeInTheWordsTests
    {
        [Test]
        public void WhenThen()
        {
            var algorithm = new TheTimeInTheWords();
            var input = @"5
47";
            var textWriter = new StringReader(input);

            int h = Convert.ToInt32(textWriter.ReadLine());

            int m = Convert.ToInt32(textWriter.ReadLine());

            string result = algorithm.timeInWords(h, m);
            Assert.AreEqual("thirteen minutes to six", result);
        }

        [Test]
        public void WhenThen1()
        {
            var algorithm = new TheTimeInTheWords();
            var input = @"3
00";
            var textWriter = new StringReader(input);

            int h = Convert.ToInt32(textWriter.ReadLine());

            int m = Convert.ToInt32(textWriter.ReadLine());

            string result = algorithm.timeInWords(h, m);
            Assert.AreEqual("three o' clock", result);
        }
    }
}
