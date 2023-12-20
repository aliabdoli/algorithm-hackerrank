using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public static class CutTheTree
    {
        public static int cutTheTree(List<int> data, List<List<int>> edges)
        {
            edges.ForEach(x =>
            {
                x[0]--;
                x[1]--;
            });

            var newEdges = new List<List<int>>();
            foreach (var edge in edges)
            {
                newEdges.Add(new List<int>() { edge[0], edge[1] });
                newEdges.Add(new List<int>(){ edge[1], edge[0]});
            }

            var edgesDic = newEdges.Select(x => new {src = x[0], dest = x[1]})
                .GroupBy(x => x.src)
                .ToDictionary(x => x.Key, y => y.Select(x => x.dest).ToList());
            var summedNode = new Dictionary<int, int>();
            FindSummed(edgesDic, data, summedNode, 0, -1);
            var minCut = int.MaxValue;
            var wholeSum = summedNode.Max(x => x.Value);

            foreach (var edge in newEdges)
            {
                
                var src = edge[0];
                var des = edge[1];

                var childId = summedNode[src] < summedNode[des] ? src : des;
                var parent = wholeSum;
                var child = summedNode[childId];

                var newCut = Math.Abs((parent - child) - child);
                if (newCut < minCut)
                {
                    minCut = newCut;
                }
            }

            return minCut;
        }

        private static int FindSummed(Dictionary<int, List<int>> edgesDic, List<int> data, Dictionary<int, int> summedNodes, int currentNode, int parent)
        {
            var sum = data[currentNode];

            if (edgesDic.ContainsKey(currentNode))
            {
                foreach (var child in edgesDic[currentNode])
                {
                    if(child == parent)
                        continue;
                    var subTree = FindSummed(edgesDic, data, summedNodes, child, currentNode);
                    sum += subTree;
                }
            }

            if (!summedNodes.ContainsKey(currentNode))
            {
                summedNodes.Add(currentNode, 0);
            }

            summedNodes[currentNode] = sum;
            return sum;

        }
    }
}
