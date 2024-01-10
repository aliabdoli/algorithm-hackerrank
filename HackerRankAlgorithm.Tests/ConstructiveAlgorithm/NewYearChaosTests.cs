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
    public class NewYearChaosTests
    {
        [Theory]
        //[InlineData(@"2
        //5
        //2 1 5 3 4
        //5
        //2 5 1 3 4", "3,Too chaotic")]
        //[InlineData(@"2
        //8
        //5 1 2 3 7 8 6 4
        //8
        //1 2 5 3 7 8 6 4", "Too chaotic,7")]

        [InlineData(@"2 1 5 3 4", "3")]
        [InlineData(@"2 5 1 3 4", "Too chaotic")]
        [InlineData(@"5 1 2 3 7 8 6 4", "Too chaotic")]
        [InlineData(@"1 2 5 3 7 8 6 4", "7")]
        public void WhenThen(string input, string expected)
        {
            var algorithm = new NewYearChaos();

            var q = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var result = algorithm.minimumBribes(q);

            result.Should().Be(expected);
        }


        // the actual program on hackerrank website is wrong, change it to this
        //public static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);


        //    int t = Convert.ToInt32(Console.ReadLine().Trim());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine().Trim());

        //        List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

        //        string result = Result.minimumBribes(q);
        //        textWriter.WriteLine(result);
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }
}
