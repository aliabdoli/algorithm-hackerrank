using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class BiggerIsGreaterTests
    {
        [Test]
        public void WhenThen()
        {
            var s = @"5
ab
bb
hefg
dhck
dkhc";
            var input = new StringReader(s);
            var algorithm = new BiggerIsGreater();
            int T = Convert.ToInt32(input.ReadLine());
            var results = new List<string>();
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = input.ReadLine();

                var result = algorithm.Do(w);
                results.Add(result);
            }

            var expected = @"ba
no answer
hegf
dhkc
hcdk";

            var actual = string.Join(Environment.NewLine, results);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenThen1()
        {
            
             var s = @"C:\Users\ali.abdoli\source\repos\AlgorithmHackerrank\AlgorithmHackerrank.Tests\BiggerIsGreaterTestCase1Input.txt";
            var expectedDir = @"C:\Users\ali.abdoli\source\repos\AlgorithmHackerrank\AlgorithmHackerrank.Tests\BiggerIsGreaterTestCase1Expected.txt";

            var inputReader = new StreamReader(s);
            var expectedReader = new StreamReader(expectedDir);
            var algorithm = new BiggerIsGreater();
            int T = Convert.ToInt32(inputReader.ReadLine());
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = inputReader.ReadLine();

                var result = algorithm.Do(w);
                var expected = expectedReader.ReadLine();
                Assert.AreEqual(expected, result);
            }

        }

        [Test]
        public void WhenThen3()
        {

            var s = @"C:\Users\ali.abdoli\source\repos\AlgorithmHackerrank\AlgorithmHackerrank.Tests\BiggerIsGreaterTestCase3Input.txt";
            var expectedDir = @"C:\Users\ali.abdoli\source\repos\AlgorithmHackerrank\AlgorithmHackerrank.Tests\BiggerIsGreaterTestCase3Expected.txt";

            var inputReader = new StreamReader(s);
            var expectedReader = new StreamReader(expectedDir);
            var algorithm = new BiggerIsGreater();
            int T = Convert.ToInt32(inputReader.ReadLine());
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = inputReader.ReadLine();

                var result = algorithm.Do(w);
                var expected = expectedReader.ReadLine();
                //if (!string.Equals(expected, result))
                //{
                //    var ss = "wrong";
                //}
                Assert.AreEqual(expected, result);
            }

        }
    }
}
