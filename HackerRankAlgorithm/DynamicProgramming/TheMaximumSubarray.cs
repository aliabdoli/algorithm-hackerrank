using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    public class TheMaximumSubarray
    {
        public static List<int> maxSubarray(List<int> arr)
        {
            var subSequenceSum = FindMaxSubsequanceSum(arr);

            var subArraySum = FindMaxSubArraySum(arr);

            var result = MapToResult(subArraySum, subSequenceSum);

            return result;
        }

        private static int FindMaxSubArraySum(List<int> arr)
        {
            var alternatePosNegSums = CreateAlternatePosNegSums(arr);

            if (alternatePosNegSums.Count == 1)
            {
                if (arr.Last() >= 0)
                {
                    return arr.Sum();
                }
                else
                {
                    return arr.Max();
                }

            }

            var maxSum = 0;
            var positiveSum = 0;
            for (int i = 0; i < alternatePosNegSums.Count; i++)
            {
                var item = alternatePosNegSums[i];
                var addedToSum = item + positiveSum;

                if (addedToSum > 0)
                {
                    positiveSum = addedToSum;
                }
                else
                {
                    positiveSum = 0;
                }

                if (positiveSum > maxSum)
                {
                    maxSum = positiveSum;
                }
            }

            return maxSum;
        }

        private static List<int> CreateAlternatePosNegSums(List<int> arr)
        {
            var alternatePosNegSums = new List<int>();
            var sum = 0;
            for (int i = 0; i < arr.Count-1; i++)
            {
                sum += arr[i];
                if ( arr[i] >= 0 & arr[i+1] >=0)
                {
                    continue;
                }

                if (arr[i] < 0 & arr[i + 1] < 0)
                {
                    continue;
                }
                
                alternatePosNegSums.Add(sum);
                sum = 0;
            }
            
            alternatePosNegSums.Add(sum+arr.Last());
            return alternatePosNegSums;
        }

        private static List<int> MapToResult(int subArraySum, int subSequenceSum)
        {
            return new List<int>()
            {
                subArraySum,
                subSequenceSum,
            };
        }

        private static int FindMaxSubsequanceSum(List<int> arr)
        {
            var subSequenceSum = int.MinValue;
            if (arr.Any(x => x >= 0))
            {
                subSequenceSum = arr.Where(x => x > 0).Sum();
            }
            
            else
            {
                subSequenceSum = arr.Max();
            }

            return subSequenceSum;
        }


        //public static void Testy()
        //{
        //    var arr = new List<int>() { 1, 2, -3, -2, 4, 5, -9};
        //    var alternates = new PosNegAlternateList(arr);
        //}
    }



    //public class PosNegAlternateEnumerator : IEnumerator<int>
    //{
    //    private readonly PosNegAlternateList _list;
    //    private int _current;

    //    public PosNegAlternateEnumerator(PosNegAlternateList list)
    //    {
    //        _list = list;
    //        _current = 0;
    //    }
    //    public bool MoveNext()
    //    {
    //        while (_list[_current] > 0)
    //        {
    //            _current++;
    //        }
            
    //    }

    //    public void Reset()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Current { get; } = 0;

    //    object IEnumerator.Current => Current;

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class PosNegAlternateList : IList<int>
    //{
    //    private List<int> _list;

    //    public PosNegAlternateList(List<int> list)
    //    {
    //        _list = list;
    //    }
    //    public IEnumerator<int> GetEnumerator()
    //    {
    //        new PosNegAlternateEnumerator(this);
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    public void Add(int item)
    //    {
    //        _list.Add(item);
    //    }

    //    public void Clear()
    //    {
    //        _list.Clear();
    //    }

    //    public bool Contains(int item)
    //    {
    //        return _list.Contains(item);
    //    }

    //    public void CopyTo(int[] array, int arrayIndex)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Remove(int item)
    //    {
    //        _list.Remove(item);
    //    }

    //    public int Count { get; } => _list.Count;
    //    public bool IsReadOnly { get; }
    //    public int IndexOf(int item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Insert(int index, int item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int this[int index]
    //    {
    //        get => throw new NotImplementedException();
    //        set => throw new NotImplementedException();
    //    }
    //}
}