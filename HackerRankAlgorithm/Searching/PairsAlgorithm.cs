using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public class PairsAlgorithm
    {
        public int pairs(int k, List<int> arr)
        {
            if (arr.Any(x => x < 0))
                throw new Exception("Array must be positive");

            var sortedNums = arr.Select(x => x).ToList();
            sortedNums.Sort();
            List<int> sortedNeighbourDifferences = CalculateNeighbourDifferences(sortedNums);

            var itemsWithKDifferenceCount = CalculatePairsWithK(k, sortedNeighbourDifferences);

            return itemsWithKDifferenceCount;

        }

        private static int CalculatePairsWithK(int k, List<int> sortedNeighbourDifferences)
        {
            var queue = new SummedQueue();
            var itemsWithKDifferenceCount = 0;
            for (int i = 0; i < sortedNeighbourDifferences.Count; i++)
            {
                var item = sortedNeighbourDifferences[i];
                var newSum = queue.CurrentSum + item;
                if (newSum == k)
                {
                    itemsWithKDifferenceCount++;
                    queue.Enqueue(item);
                    queue.Dequeue();
                }
                if (newSum > k)
                {
                    queue.Enqueue(item);
                    while (queue.CurrentSum > k)
                    { 
                        queue.Dequeue();
                    }

                    if (queue.CurrentSum == k)
                    {
                        queue.Dequeue();
                        itemsWithKDifferenceCount++;
                    }
                }

                if (newSum < k)
                {
                    queue.Enqueue(item);
                }
            }

            //if (queue.CurrentSum == k)
            //{
            //    itemsWithKDifferenceCount++;
            //}

            return itemsWithKDifferenceCount;
        }

        private static List<int> CalculateNeighbourDifferences(List<int> sortedNums)
        {
            var sortedNeighbourDifferences = new List<int>();
            for (int i = 0; i < sortedNums.Count - 1; i++)
            {
                var item = sortedNums[i + 1] - sortedNums[i];
                sortedNeighbourDifferences.Add(item);
            }

            return sortedNeighbourDifferences;
        }
    }

    public class SummedQueue
    {
        private readonly Queue<int> _queue;
        private int _sum;

        public SummedQueue()
        {
            _queue = new Queue<int>();
            _sum = 0;
        }

        public int CurrentSum => _sum;

        public void Enqueue(int item)
        {
            _queue.Enqueue(item);
            _sum += item;
        }

        public int Dequeue()
        {
            var item = _queue.Dequeue();
            _sum -= item;
            return item;
        }
    }

}
