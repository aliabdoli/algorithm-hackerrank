using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public class ConnectedCellsInAGrid
    {
        // 5:26
        public int connectedCell(int[][] matrix)
        {
            var data = matrix.Select(x => x.Select(y => y).ToArray()).ToArray();
          
            var regions = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    var region = DFS(data, i,j, 0);
                    regions.Add(region);
                }
            }

            var result = regions.Max();

            return result;
        }

        public static int DFS(int[][] data, int rind, int cind, int regionLength)
        {
            var rowLength = data.Length;
            var colLength = data[0].Length;
            if (rind < 0 || rind >= rowLength || cind < 0 || cind >= colLength || data[rind][cind] <= 0)
            {
                return regionLength;
            }
            
            data[rind][cind] = -1;
            var x1 = DFS(data, rind - 1, cind -1, regionLength);
            var x2 = DFS(data, rind - 1, cind, regionLength);
            var x3 = DFS(data, rind - 1, cind +1, regionLength);
            var x4 = DFS(data, rind, cind - 1, regionLength);
            var x5 = DFS(data, rind, cind + 1, regionLength);
            var x6 = DFS(data, rind + 1, cind -1, regionLength);
            var x7 = DFS(data, rind + 1, cind, regionLength);
            var x8 = DFS(data, rind + 1, cind +1, regionLength);
            regionLength = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + 1;
            return regionLength;

        }

       
    }
}
