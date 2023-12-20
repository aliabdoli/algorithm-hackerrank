using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests
{
    
    public class BiggerIsGreaterTests
    {
        [Fact]
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

            actual.Should().Be(expected);
        }

        [Fact]
        public void WhenThen1()
        {
            
             var s = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\BiggerIsGreaterInlineData1Input.txt";
            var expectedDir = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\BiggerIsGreaterInlineData1Expected.txt";

            var inputReader = new StreamReader(s);
            var expectedReader = new StreamReader(expectedDir);
            var algorithm = new BiggerIsGreater();
            int T = Convert.ToInt32(inputReader.ReadLine());
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = inputReader.ReadLine();

                var result = algorithm.Do(w);
                var expected = expectedReader.ReadLine();
                result.Should().Be(expected);
            }

        }

        [Fact]
        public void WhenThen3()
        {

            var s = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\BiggerIsGreaterInlineData3Input.txt";
            var expectedDir = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\BiggerIsGreaterInlineData3Expected.txt";

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
                result.Should().Be(expected);
            }

        }
    }
}
