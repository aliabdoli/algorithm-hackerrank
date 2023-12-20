using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Recursion
{
    public static class kFactorization
    {
        public static int[] Do(int n, int[] A)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(new Node()
            {
                Value = 1,
                Path = "1",
                Depth = 1
            });

            var noResult = new int[] {-1};
            var dividables = A.Where(x => n % x == 0).OrderBy(x => x).ToList();
           
            Node answer = null;
            var foundOnLevel = false;
            while (queue.Count > 0 && !foundOnLevel)
            {
                var current = queue.Dequeue();
                for (int i = 0; i < dividables.Count; i++)
                {
                    var newValue = current.Value * dividables[i];
                    if (newValue > n)
                    {
                        continue;
                    }
                    var newNode = new Node()
                    {
                        Value = newValue,
                        Path = $"{current.Path}-{newValue}",
                        Depth = current.Depth + 1
                    };
                    queue.Enqueue(newNode);

                    if (newValue == n)
                    {
                        foundOnLevel = true;
                        answer = newNode;
                    }
                }
            }

            if (answer == null)
            {
                return noResult;
            }

            var result = answer.Path.Split('-').Select(x => int.Parse(x)).ToArray();
            return result;

        }

        public class Node
        {
            public int Value { get; set; }
            public string Path { get; set; }
            public int Depth { get; set; }

    }

        //public static int[] Do(int n, int[] A)
        //{
        //    var dividable = new List<int>();
        //    var result = new List<int>();
        //    var temp = 1;
        //    var falseResult = new int[] { -1 };

        //    for (int i = 0; i < A.Count(); i++)
        //    {
        //        if (n % A[i] == 0)
        //        {
        //            dividable.Add(A[i]);
        //        }
        //    }

        //    if (dividable.Count == 0)
        //    {
        //        return falseResult;
        //    }
        //    dividable = dividable.OrderBy(x => x).ToList();

        //    var remain = n;
        //    for (int i = 0; i < dividable.Count; i++)
        //    {
        //        var item = dividable[i];
        //        if (n % item == 0)
        //        {
        //            while (remain % item == 0)
        //            {
        //                result.Add(item);
        //                temp = temp * item;
        //                remain = remain / item;
        //            }
        //        }
        //    }

        //    if (result.Last() != temp)
        //    {
        //        return falseResult;
        //    }

        //    return result.ToArray();

        //}

        //o(n)
        private static bool Compare(List<int> first, List<int> second)
        {
            var smaller = (first.Count >= second.Count) ? second : first;
            var bigger = (first.Count < second.Count) ? second : first;
            var ifSmallerIsFirst = first.Count < second.Count;

            var smallerCount = smaller.Count;
            int ind = 0;
            while (ind < smallerCount)
            {
                if (smaller[ind] == bigger[ind])
                {
                    ind++;
                }
                else
                {
                    break;
                }
            }

            if (ind == smallerCount - 1)
            {
                return ifSmallerIsFirst;
            }

            if (ind < smallerCount - 1)
            {
                if (smaller[ind] < bigger[ind])
                {
                    return ifSmallerIsFirst;
                }
                else
                {
                    return !ifSmallerIsFirst;
                }
            }

            return ifSmallerIsFirst;
        }

        private static List<int> TheBestAnswer;

        public static void FindMultiple(int n, int[] A, List<int> path)
        {
            if (!path.Any())
            {
                path.Add(1);
            }

            if (TheBestAnswer != null && path.Count > TheBestAnswer.Count)
            {
                return;
            }

            if (n == 1)
            {
                if (TheBestAnswer == null)
                {
                    TheBestAnswer = new List<int>();
                }

                if (!TheBestAnswer.Any())
                {
                    TheBestAnswer = path;
                }
                else if (Compare(path, TheBestAnswer))
                {
                    TheBestAnswer = path;
                }

                return;
            }
           

            for (int i = 0; i < A.Length; i++)
            {
                if (n % A[i] == 0)
                {
                    var newPath = new List<int>(path);
                    newPath.Add(newPath.Last() * A[i]);
                    var newN = n / A[i];
                    FindMultiple(newN, A, newPath);
                }
            }
        }
    }
}
