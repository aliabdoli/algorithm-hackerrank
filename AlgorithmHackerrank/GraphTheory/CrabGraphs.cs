using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.GraphTheory
{
    public static class CrabGraphs
    {
        public static int crabGraphs(int nodeCount, int t, int[][] graph)
        {
            var sEdges = graph.Select(x => new Edge() {Start = x[0] - 1, End = x[1] - 1});
            var eEdges = graph.Select(x => new Edge() {End = x[0] - 1, Start = x[1] - 1});

            var allEdge = sEdges.Concat(eEdges);
            var edge = allEdge.GroupBy(x => x.Start, y => y).ToDictionary(x => x.Key, y => y.Select(z => z.End).ToList());

            var visited = new HashSet<int>();
            var inCrab = new HashSet<int>();

            var queue = new Queue<int>();
            var crabs = new List<List<int>>();

            queue.Enqueue(0);
            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (visited.Contains(node))
                {
                    continue;
                }
                visited.Add(node);
                 var newCrab = edge[node].Where(x => (edge[x].Count < t || visited.Contains(x)) && !inCrab.Contains(x)).Take(t).ToList();
                if (newCrab.Count() == t)
                {
                    inCrab.Add(newCrab);
                    inCrab.Add(node);
                    newCrab.Add(node);
                    crabs.Add(newCrab);
                }

                var toCheck = edge[node].Where(x => edge[x].Count >= t).ToList();
                queue.Enqueue(toCheck);
               
            }

            var result = inCrab.Count();
            return result;
        }

        public static void Enqueue<T>(this Queue<T> queue, List<T> list)
        {
            foreach (var item in list)
            {
                queue.Enqueue(item);
            }
        }

        public static void Add<T>(this HashSet<T> set, List<T> list)
        {
            foreach (var item in list)
            {
                set.Add(item);
            }
        }

        public class Edge
        {
            public int Start { get; set; }
            public int End { get; set; }
        }
    }
}
