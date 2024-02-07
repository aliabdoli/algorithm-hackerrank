using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Sorting
{
    public class LilysHomework
    {
        public int FindMinSwap(List<int> arr)
        {
            // need to be sorted to be minimized diff
            var ascSwapCount = FindSwaps(arr.Select(x => x).ToList(), true);
            var descSwapCount = FindSwaps(arr.Select(x => x).ToList(), false);


            var minSwaps = new List<int>() {ascSwapCount, descSwapCount}.Min();
            return minSwaps;
        }

        private static int FindSwaps(List<int> arr, bool ifAsc)
        {
            var dualSortedList = new DualSortedList(arr, ifAsc);
            var swapCount = 0;
            for (int i = 0; i < dualSortedList.Count; i++)
            {
                
                var isMispositioned = dualSortedList.IsMispositionedByIndex(i);
                if (isMispositioned)
                {
                    dualSortedList.MoveToCorrectPlace(i);
                    swapCount++;
                }
            }

            return swapCount;
        }
    }

    public class DualSortedList : IEnumerable<int>
    {
        private readonly List<int> _arr;
        private readonly Dictionary<int, int> _valueIndexesArr;
        private readonly List<int> _sortedArr;


        public DualSortedList(List<int> arr, bool ifAsc)
        {
            _arr = arr;
            _sortedArr = ifAsc ? arr.OrderBy(x => x).ToList() : arr.OrderByDescending(x => x).ToList();
            _valueIndexesArr = arr.Select((val, ind) => new { val = val, ind = ind }).ToDictionary(x => x.val, y => y.ind);
        }


        public int Count => _sortedArr.Count;

  

        public bool IsMispositionedByIndex(int index)
        {
            return _arr[index] != _sortedArr[index];
        }

        public void MoveToCorrectPlace(int index)
        {
            var valToBe = _sortedArr[index];
            var valToBeIndex = _valueIndexesArr[valToBe];
            SwapUpdateArrElement(index, valToBeIndex);
        }

        private void SwapUpdateArrElement(int indexA, int indexB)
        {
            //arr
            var temp = _arr[indexA];
            _arr[indexA] = _arr[indexB];
            _arr[indexB] = temp;

            //value index map
            _valueIndexesArr[_arr[indexA]] = indexA;
            _valueIndexesArr[_arr[indexB]] = indexB;

        }

        public IEnumerator<int> GetEnumerator()
        {
            return _sortedArr.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
