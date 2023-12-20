using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Recursion;
using Xunit;

namespace AlgorithmHackerrank.Tests.Recursion
{
    public class SimplifiedChessEngineTests
    {
        [Theory]
        [InlineData(@"1
2 1 1
N B 2
Q B 1
Q A 4
")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);

            int g = Convert.ToInt32(input.ReadLine());

            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] wbm = input.ReadLine().Split(' ');

                int w = Convert.ToInt32(wbm[0]);

                int b = Convert.ToInt32(wbm[1]);

                int m = Convert.ToInt32(wbm[2]);

                char[][] whites = new char[w][];

                for (int whitesRowItr = 0; whitesRowItr < w; whitesRowItr++)
                {
                    whites[whitesRowItr] = Array.ConvertAll(input.ReadLine().Split(' '), whitesTemp => whitesTemp[0]);
                }

                char[][] blacks = new char[b][];

                for (int blacksRowItr = 0; blacksRowItr < b; blacksRowItr++)
                {
                    blacks[blacksRowItr] = Array.ConvertAll(input.ReadLine().Split(' '), blacksTemp => blacksTemp[0]);
                }

                var result = SimplifiedChessEngineSolver.simplifiedChessEngine(whites, blacks, m);
            }
        }
    }
}
