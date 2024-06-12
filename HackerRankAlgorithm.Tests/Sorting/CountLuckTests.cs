using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Sorting;
using Xunit;


namespace HackerRankAlgorithm.Tests.Sorting
{
    
    public class CountLuckTests
    {
        [Theory]
        [InlineData(@"3
                    2 3
                    *.M
                    .X.
                    1
                    4 11
                    .X.X......X
                    .X*.X.XXX.X
                    .XX.X.XM...
                    ......XXXX.
                    3
                    4 11
                    .X.X......X
                    .X*.X.XXX.X
                    .XX.X.XM...
                    ......XXXX.
                    4", "Impressed,Impressed,Oops!")]

        [InlineData(@"3
        3 41
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        M.......................................*
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        20
        5 11
        ..........*
        .XXXXXXXXXX
        ...........
        XXXXXXXXXX.
        M..........
        0
        5 17
        XXXXXXXXXXXXXXXXX
        XXX.XX.XXXXXXXXXX
        XX.*..M.XXXXXXXXX
        XXX.XX.XXXXXXXXXX
        XXXXXXXXXXXXXXXXX
        1", "Impressed,Impressed,Impressed")]

        [InlineData(@"2
        41 41
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        M........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .*.......................................
        280
        5 17
        XXXXXXXXXXXXXXXXX
        XXX.XX.XXXXXXXXXX
        XX.*..M.XXXXXXXXX
        XXX.XX.XXXXXXXXXX
        XXXXXXXXXXXXXXXXX
        10", "Impressed,Oops!")]

        [InlineData(@"1
        41 41
        .X.XXXXXXXXXXXXXXXXXXX.X.X.X.X.X.X.X.X.X.
        ...XXXXXXXXXXXXXXXXXXX...................
        .X..X.X.X.X.X.X.X..XXXX*X.X.X.X.X.X.X.XX.
        .XXXX.X.X.X.X.X.X.XX.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .XX.X.X.X.XX.X.XX.X.X.X.X.X.X.X.X.X.X.X.X
        .X.X.X.X.X.XXX.X.X.X.X.X.X.X.X.X.X.X.X.X.
        X........................................
        X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        .X.XX.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.XX
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XMX.
        .X....................................X..
        ..X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .X...................................X...
        .XX.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.XX.XXXX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.XX.
        .X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.X.
        .........................................
        294", "Impressed")]
        public void MainFlow(string inputString, string expectedString)
        {
            var expecteds = expectedString.Split(',').ToList();

            var input = new StringReader(inputString);
            var algor = new CountLuck();

            int t = Convert.ToInt32(input.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nm = input.ReadLine().Trim().Split(' ');

                int n = Convert.ToInt32(nm[0]);

                int m = Convert.ToInt32(nm[1]);

                string[] matrix = new string[n];

                for (int i = 0; i < n; i++)
                {
                    string matrixItem = input.ReadLine().Trim();
                    matrix[i] = matrixItem;
                }

                int k = Convert.ToInt32(input.ReadLine());

                string result = algor.countLuck(matrix.ToList(), k);

                result.Should().Be(expecteds[tItr]);

                //textWriter.WriteLine(result);
            }
        }

    }
}
