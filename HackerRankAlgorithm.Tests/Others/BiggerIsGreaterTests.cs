using FluentAssertions;

namespace HackerRankAlgorithm.Tests.Others
{
    
    public class BiggerIsGreaterTests
    {
        [Theory]
        [InlineData("ab", "ba")]
        [InlineData("bb", "no answer")]
        [InlineData("hefg", "hegf")]
        [InlineData("dhck", "dhkc")]
        [InlineData("dkhc", "hcdk")]
        [InlineData("fjzeye", "fjzyee")]
        public void WhenThen(string input, string expected)
        {
           
            var algorithm = new BiggerIsGreater();
            var result = algorithm.Do(input);
            result.Should().Be(expected);
        }

        [Fact]
        public void WhenThen1()
        {
            
             var s = @"C:\work\chapter\algorithm-hackerrank\HackerRankAlgorithm.Tests\Others\BiggerIsGreaterTestCase1Input.txt";
            var expectedDir = @"C:\work\chapter\algorithm-hackerrank\HackerRankAlgorithm.Tests\Others\BiggerIsGreaterTestCase1Expected.txt";

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

            var s = @"C:\work\chapter\algorithm-hackerrank\HackerRankAlgorithm.Tests\Others\BiggerIsGreaterTestCase3Input.txt";
            var expectedDir = @"C:\work\chapter\algorithm-hackerrank\HackerRankAlgorithm.Tests\Others\BiggerIsGreaterTestCase3Expected.txt";

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
