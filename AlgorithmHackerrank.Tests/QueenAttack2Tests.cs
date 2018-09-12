using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class QueenAttack2Tests
    {

        [Test]
        public void WhenThen1()
        {
            var algorithm = new QueenAttack2();
            var n = 5;
            var k = 3;
            var r_q = 4;
            var c_q = 3;
            var input = @"5 5
4 2
2 3";

            var obstacles = CreateObstacles(input, k);

            var result = algorithm.QueensAttack(n, k, r_q, c_q, obstacles);
            Assert.AreEqual(10, result);

        }


        [Test]
        public void WhenNoObstaclesThen()
        {
            var algorithm = new QueenAttack2();
            var n = 4;
            var k = 0;
            var r_q = 4;
            var c_q = 4;
            //obstacles[0] = new[] { 4 };
            //obstacles[1] = new[] { 1 };
            //obstacles[2] = new int[0];
            //obstacles[3] = new[] { 2 };
            //obstacles[4] = new int[0];

            var result = algorithm.QueensAttack(n, k, r_q, c_q, null);
            Assert.AreEqual(9, result);

        }
        [Test]
        public void WhenThen3()
        {
            var algorithm = new QueenAttack2();
            var n = 100000;
            var k = 0;
            var r_q = 4187;
            var c_q = 5068;
            //obstacles[0] = new[] { 4 };
            //obstacles[1] = new[] { 1 };
            //obstacles[2] = new int[0];
            //obstacles[3] = new[] { 2 };
            //obstacles[4] = new int[0];

            var result = algorithm.QueensAttack(n, k, r_q, c_q, null);
            Assert.AreEqual(308369, result);

        }

        [Test]
        public void WhenThen6()
        {
            var algorithm = new QueenAttack2();
            var n = 100;
            var k = 100;
            var r_q = 48;
            var c_q = 81;
            var inputString = 
                @"54 87
64 97
42 75
32 65
42 87
32 97
54 75
64 65
48 87
48 75
54 81
42 81
45 17
14 24
35 15
95 64
63 87
25 72
71 38
96 97
16 30
60 34
31 67
26 82
20 93
81 38
51 94
75 41
79 84
79 65
76 80
52 87
81 54
89 52
20 31
10 41
32 73
83 98
87 61
82 52
80 64
82 46
49 21
73 86
37 70
43 12
94 28
10 93
52 25
50 61
52 68
52 23
60 91
79 17
93 82
12 18
75 64
69 69
94 74
61 61
46 57
67 45
96 64
83 89
58 87
76 53
79 21
94 70
16 10
50 82
92 20
40 51
49 28
51 82
35 16
15 86
78 89
41 98
70 46
79 79
24 40
91 13
59 73
35 32
40 31
14 31
71 35
96 18
27 39
28 38
41 36
31 63
52 48
81 25
49 90
32 65
25 45
63 94
89 50
43 41";
            var obstacles = CreateObstacles(inputString, k);

            var result = algorithm.QueensAttack(n, k, r_q, c_q, obstacles);
            Assert.AreEqual(40, result);

        }

        private static int[][] CreateObstacles(string inputString, int k)
        {
            var input = inputString.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            int[][] obstacles = new int[k][];

            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(input[i].Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }

            return obstacles;
        }
    }
}
