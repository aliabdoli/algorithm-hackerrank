using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Sorting;
using Xunit;


namespace HackerRankAlgorithm.Tests.Sorting
{
    
    public class CountLuckTests
    {
        [Theory]
//        [InlineData(@"3
//2 3
//*.M
//.X.
//1
//4 11
//.X.X......X
//.X*.X.XXX.X
//.XX.X.XM...
//......XXXX.
//3
//4 11
//.X.X......X
//.X*.X.XXX.X
//.XX.X.XM...
//......XXXX.
//4")]
        [InlineData(@"3
3 3
*.X
X.X
X.M
0
3 3
*.X
X.X
..M
1
3 3
*..
X.X
..M
1")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);
            var algor = new CountLuck();

            int t = Convert.ToInt32(input.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nm = input.ReadLine().Split(' ');

                int n = Convert.ToInt32(nm[0]);

                int m = Convert.ToInt32(nm[1]);

                string[] matrix = new string[n];

                for (int i = 0; i < n; i++)
                {
                    string matrixItem = input.ReadLine();
                    matrix[i] = matrixItem;
                }

                int k = Convert.ToInt32(input.ReadLine());

                string result = algor.countLuck(matrix, k);

                //textWriter.WriteLine(result);
            }
        }

    }
}
