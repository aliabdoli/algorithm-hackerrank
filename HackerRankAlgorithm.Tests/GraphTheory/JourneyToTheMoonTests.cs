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
    public class JourneyToTheMoonTests
    {
        [Theory]
        //[InlineData(@"5 3
        //0 1
        //2 3
        //0 4", "6")]
        //[InlineData(@"4 1
        //0 2", "5")]
        //[InlineData(@"100000 2
        //1 2
        //3 4", "4999949998")]

//        [InlineData(@"10 7
//0 2
//1 8
//1 4
//2 8
//2 6
//3 5
//6 9", "23")]

        [InlineData(@"100 70
0 11
2 4
2 95
3 48
4 85
4 95
5 67
5 83
5 42
6 76
9 31
9 22
9 55
10 61
10 38
11 96
11 41
12 60
12 69
14 80
14 99
14 46
15 42
15 75
16 87
16 71
18 99
18 44
19 26
19 59
19 60
20 89
21 69
22 96
22 60
23 88
24 73
27 29
30 32
31 62
32 71
33 43
33 47
35 51
35 75
37 89
37 95
38 83
39 53
41 84
42 76
44 85
45 47
46 65
47 49
47 94
50 55
51 99
53 99
56 78
66 99
71 78
73 98
76 88
78 97
80 90
83 95
85 92
88 99
88 94", "3984")]
        public void MainFlow(string inputString, string expectedString)
        {
            var inputReader = new StringReader(inputString);
            var expectedReader = new StringReader(expectedString);

            string[] np = inputReader.ReadLine().Split(' ');

            int n = Convert.ToInt32(np[0]);

            int p = Convert.ToInt32(np[1]);

            List<List<int>> astronaut = new List<List<int>>();

            for (int i = 0; i < p; i++)
            {
                astronaut.Add(inputReader.ReadLine().Trim().Split(' ').ToList().Select(astronautTemp => Convert.ToInt32(astronautTemp)).ToList());
            }

            var result = JourneyToTheMoon.journeyToMoon(n, astronaut);

            var expected = expectedReader.ReadLine();

            result.Should().Be(long.Parse(expected));
        }
    }
}
