using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.Searching
{
    [TestFixture]
    public class ConnectedCellsInAGridTests
    {
        [Test]
        [TestCase(@"4
4
1 1 0 0
0 1 1 0
0 0 1 0
1 0 0 0")]
        public void MainFlow(string inputString)
        {
            var algor = new ConnectedCellsInAGrid();
            var input = new StringReader(inputString);
            int n = Convert.ToInt32(input.ReadLine());

            int m = Convert.ToInt32(input.ReadLine());

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Array.ConvertAll(input.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
            }

            int result = algor.connectedCell(matrix);
        }
    }
}
