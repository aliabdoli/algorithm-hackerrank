using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Searching
{
    public static class RedKnightsShortestPath
    {
       
        public static void printShortestPath(int n, int i_start, int j_start, int i_end, int j_end)
        {
            //Print the distance along with the sequence of moves.
            
           var path = PrepareAndFindPath(n, i_start, j_start, i_end, j_end, out var isAnswer);
            if (!isAnswer)
            {
                Console.WriteLine("Impossible");
                return;
            }
            Console.WriteLine(path.Count);
            var result = String.Join(" ", path);
            Console.WriteLine(result);
        }

        private static Dictionary<string, Tuple<int, int>> _movesMap = new Dictionary<string, Tuple<int, int>>()
        {
            {"UL", new Tuple<int, int>(-2,-1)},
            {"UR", new Tuple<int, int>(-2,1)},
            {"R", new Tuple<int, int>(0,2)},
            {"LR", new Tuple<int, int>(2,1)},
            {"LL", new Tuple<int, int>(2,-1)},
            {"L", new Tuple<int, int>(0,-2)}
        };

        public static List<string> PrepareAndFindPath(int n, int i_start, int j_start, int i_end, int j_end, out bool isAnswer)
        {
            var startNode = $"{i_start}-{j_start}";

            var visited = new HashSet<string>();
            var notVisited = new UniqueQueue<string>();
            notVisited.Enqueue(startNode);
            var shortestPaths = new Dictionary<string, Path>()
            {
                {
                    startNode, new Path() {cost = 0, PreviousNode = startNode, Move = ""}
                }
            };
            isAnswer = FindPath(n,  i_end, j_end, shortestPaths, visited,notVisited );

            if (!isAnswer)
            {
                return new List<string>();
            }
            var endNode = $"{i_end}-{j_end}";
            var cost = 0;
            var path = new List<string>();

            var currentNode = endNode;
            while (currentNode != startNode)
            {
                cost += shortestPaths[currentNode].cost;
                path.Add(shortestPaths[currentNode].Move);
                currentNode = shortestPaths[currentNode].PreviousNode;
            }

            path.Reverse();
            return path;
        }

        public class Path
        {
            public string PreviousNode { get; set; }
            public string Move { get; set; }
            public int cost { get; set; } = int.MaxValue;
        }

        public static bool FindPath(int size, int iEnd, int jEnd, 
            Dictionary<string, Path> paths,
            HashSet<string> visited,
            UniqueQueue<string> notVisited
            )
        {

            while (notVisited.Any())
            {
                var currentNode = notVisited.Dequeue();
                var ijCurrent = currentNode.Split('-').Select(x => int.Parse(x)).ToList();
                var iStart = ijCurrent[0];
                var jStart = ijCurrent[1];

                if (iStart == iEnd && jStart == jEnd)
                {
                    return true;
                }

                //if (visited.Count >= size)
                //{
                //    ifImpossible = true;
                //    return false;
                //}

                //if (iStart >= size || iStart < 0
                //                   || jStart >= size || jStart < 0
                //)
                //{
                //    return false;
                //}

                //var currentNode = $"{iStart}-{jStart}";
                
                visited.Add(currentNode);


                if (!paths.ContainsKey(currentNode))
                {
                    paths.Add(currentNode, new Path());
                }

                foreach (var move in _movesMap)
                {
                    var newIStart = move.Value.Item1 + iStart;
                    var newJStart = move.Value.Item2 + jStart;
                    var newNode = $"{newIStart}-{newJStart}";

                    if (newIStart >= size || newIStart < 0
                                          || newJStart >= size || newJStart < 0
                                          || visited.Contains(newNode))
                    {
                        continue;
                    }

                    if (!paths.ContainsKey(newNode))
                    {
                        paths.Add(newNode, new Path());
                    }

                    notVisited.Enqueue(newNode);
                    var newCost = paths[currentNode].cost == int.MaxValue ? int.MaxValue : paths[currentNode].cost + 1;
                    var cost = paths[newNode].cost;
                    if (newCost < cost)
                    {
                        paths[newNode].cost = newCost;
                        paths[newNode].PreviousNode = currentNode;
                        paths[newNode].Move = move.Key;
                    }


                }

                //foreach (var neighborNode in notVisited)
                //{
                //    var ij = neighborNode.Split('-').Select(x => int.Parse(x)).ToList();
                //    var isFound = FindPath(size, ij[0], ij[1], iEnd, jEnd, paths, visited, out ifImpossible);
                //    if (isFound)
                //    {
                //        return true;
                //    }

                //    if (ifImpossible)
                //    {
                //        ifImpossible = true;
                //        return false;
                //    }
                //}

            }

            return false;
        }
        public class UniqueQueue<T> : IEnumerable<T>
        {
            private HashSet<T> hashSet;
            private Queue<T> queue;


            public UniqueQueue()
            {
                hashSet = new HashSet<T>();
                queue = new Queue<T>();
            }


            public int Count
            {
                get
                {
                    return hashSet.Count;
                }
            }

            public void Clear()
            {
                hashSet.Clear();
                queue.Clear();
            }


            public bool Contains(T item)
            {
                return hashSet.Contains(item);
            }


            public void Enqueue(T item)
            {
                if (hashSet.Add(item))
                {
                    queue.Enqueue(item);
                }
            }

            public T Dequeue()
            {
                T item = queue.Dequeue();
                hashSet.Remove(item);
                return item;
            }


            public T Peek()
            {
                return queue.Peek();
            }


            public IEnumerator<T> GetEnumerator()
            {
                return queue.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return queue.GetEnumerator();
            }
        }


    }
}
