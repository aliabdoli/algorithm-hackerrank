using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.GraphTheory;
using FluentAssertions;
using Xunit;


namespace HackerRankAlgorithm.Tests.GraphTheory
{
    public class RoadsAndLibrariesTests
    {
        [Theory]
        [InlineData(@"2
        3 3 2 1
        1 2
        3 1
        2 3
        6 6 2 5
        1 3
        3 4
        2 4
        1 2
        2 3
        5 6", @"4
        12")]
        [InlineData(@"1
        5 3 6 1
        1 2
        1 3
        1 4", @"15")]


        public void MainFlow(string inputString, string expectedString)
        {
            var input = new StringReader(inputString);
            var expeted = new StringReader(expectedString);

            int q = Convert.ToInt32(input.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] nmC_libC_road = input.ReadLine().Trim().Split(' ');

                int n = Convert.ToInt32(nmC_libC_road[0]);

                int m = Convert.ToInt32(nmC_libC_road[1]);

                int c_lib = Convert.ToInt32(nmC_libC_road[2]);

                int c_road = Convert.ToInt32(nmC_libC_road[3]);

                var cities = new List<List<int>>();

                for (int i = 0; i < m; i++)
                {
                    cities.Add(Array.ConvertAll(input.ReadLine().Trim().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp)).ToList());
                }

                long result = RoadsAndLibraries.roadsAndLibraries(n, c_lib, c_road, cities);
                var exp = long.Parse(expeted.ReadLine());
                result.Should().Be(exp);

            }
        }
    }
}
