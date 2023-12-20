using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Sorting
{
    public class FraudulentActivityNotifications
    {
        public int ActivityNotifications(int[] expenditure, int d)
        {
            var notif = 0;
            var buckets = expenditure
                .Take(d)
                .OrderBy(x => x)
                .ToList();

            for (int i = d; i < expenditure.Length; i++)
            {
                var median = FindMedian(buckets, d);

                if (expenditure[i] >= 2 * median)
                {
                    notif++;
                }


                var itemToAdd = expenditure[i];
                var itemToRemove = expenditure[i - d];

                UpdateBuckets(itemToAdd, itemToRemove, buckets);

            }

            return notif;
        }

        private static void UpdateBuckets(int itemToAdd, int itemToRemove, List<int> buckets)
        {
            //todo: buckets.removeAt() does not use binary search and slows down!!!!!!
            //todo: So, if buckets.remove(item) will time out!!! and it is not because of copy inside remove but for findIndex(item)
            var rIndex = buckets.BinarySearch(itemToRemove);
            buckets.RemoveAt(rIndex);

            //todo: never do linear search, binary search
            var index = buckets.BinarySearch(itemToAdd);
            if (index < 0)
            {
                index = ~index;
            }
            buckets.Insert(index, itemToAdd);

        }




        public static double FindMedian(List<int> bucketsList, int inputCount)
        {
            var ifOdd = inputCount % 2 != 0;

            var result = 0.0; 
            if (ifOdd)
            {
                var ind = (inputCount + 1) / 2 -1;
                result = bucketsList[ind];
            }
            else
            {
                var ind = inputCount / 2 - 1;
                result = (double)(bucketsList[ind + 1] + bucketsList[ind])/2;
            }

            return result;
        }


        //by buckets
        //public static double FindMedian(SortedDictionary<int, int> buckets, int inputCount)
        //{
        //    var soFar = 0;
        //    var ifOdd = inputCount % 2 != 0;
        //    var medIndex = ifOdd ? inputCount / 2 + 1 : inputCount / 2;

        //    var bucketsList = buckets.ToList();

        //    for (int i = 0; i < bucketsList.Count; i++)
        //    {
        //        var item = bucketsList[i];
        //        soFar += item.Value;

        //        if (soFar >= medIndex)
        //        {
        //            if (ifOdd)
        //                return item.Key;

        //            if (soFar > medIndex)
        //            {
        //                return item.Key;
        //            }

        //            if (soFar == medIndex)
        //            {
        //                if (item.Value > 1)
        //                    return item.Key;

        //                var next = bucketsList[++i];
        //                return ((double)(item.Key + next.Key)) / 2;
        //            }
        //        }
        //    }
        //    throw new Exception("Not Found");
        //}
    }
}
