using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;

namespace AlgorithmHackerrank.GraphTheory
{
    public static class BreadthFirstSearchShortestReach
    {
        public static int[] bfs(int nodeCount, int edgeCount, int[][] edgesArray, int startIndex)
        {
            var distMultiplier = 6;
            var sEdges = edgesArray.Select(x => new Edge() {Start = x[0] - 1, End = x[1] - 1});
            var eEdges = edgesArray.Select(x => new Edge() { End = x[0] - 1, Start = x[1] - 1});
            var allEdges = sEdges.Concat(eEdges);

            var edges = allEdges.GroupBy(x => x.Start)
                .ToDictionary(x => x.Key, y =>
                {
                    return y.Select(z => z.End).Distinct().OrderBy(x => x).ToList();
                });
            

            var distances = Enumerable.Range(0, nodeCount).ToDictionary(x => x, y => int.MaxValue);
            
            var start = startIndex - 1;
            distances[start] = 0;
            //var queue = new RedKnightsShortestPath.UniqueQueue<int>();
            var queue = new Queue<int>();

            var visited = new HashSet<int>();

            queue.Enqueue(start);

            while (queue.Any())
            {

                var node = queue.Dequeue();
                if (visited.Contains(node))
                {
                    continue;
                }

                visited.Add(node);

                List<int> childs;
                if (edges.TryGetValue(node, out childs))
                {
                    foreach (var child in childs)
                    {
                        var newDist = distances[node] + 1;
                        if (newDist < distances[child])
                        {
                            distances[child] = newDist;
                        }

                        queue.Enqueue(child);
                    }
                }
            }

            var result = distances.Where(x => x.Key != start).Select(x => x.Value == int.MaxValue ? -1 : distMultiplier * x.Value).ToArray();
            return result;
        }

        public class Edge
        {
            public int Start { get; set; }
            public int End { get; set; }
        }
    }
}
