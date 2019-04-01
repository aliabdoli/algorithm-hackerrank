using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.DynamicProgramming
{
    public class TheMaximumSubarray
    {
        public static int[] maxSubarray(int[] arr)
        {
            var maxSubArr = MaxSubArrayValue(arr);
            var maxSubSeq = MaxSubSequenceValue(arr);
            //return null;
            return new[] { maxSubSeq, maxSubArr };
        }

        private static int MaxSubSequenceValue(int[] arr)
        {
            var result = SubSeqRec(0, arr.Length -1, arr);
            return result;
        }

        private static int SubSeqRec(int leftInd, int rightInd, int[] input)
        {
            if (leftInd == rightInd)
            {
                return input[leftInd];
            }

            var midInd =  (leftInd + rightInd) / 2;
            var left = SubSeqRec(leftInd, midInd, input);
            var right = SubSeqRec(midInd+1, rightInd, input);
            var middle = FindMiddleMax(leftInd, midInd, rightInd, input);
            var resultArray = new List<int>(){middle, left, right};
            return resultArray.Max();
        }

        private static int FindMiddleMax(int leftInd, int midInd, int rightInd, int[] input)
        {
            if (leftInd == rightInd)
            {
                return input[leftInd];
            }
            var bestLeft = FindBestSum(midInd, leftInd, input);
            var bestRight = FindBestSum(midInd + 1, rightInd, input);
            return bestLeft + bestRight;
        }

        private static int FindBestSum(int start, int finish, int[] input)
        {
            if (start == finish)
            {
                return input[start];
            }

            var reverse = start > finish;

            if (reverse)
            {
                var temp = finish;
                finish = start;
                start = temp;
            }

            var inputList = input.Skip(start).Take(finish - start+1).ToList();
            if (reverse)
            {
                inputList.Reverse();
            }

            var max = inputList.First();

            inputList.Aggregate((acc, x) =>
            {
                var nAcc = acc + x;
                if (nAcc > max)
                {
                    max = nAcc;
                }
                return nAcc;
            });

            return max;
        }

        private static int MaxSubArrayValue(int[] arr)
        {
            var input = arr.ToList();
            input.Sort();
            input.Reverse();
            var highests = input.TakeWhile(x => x > 0).ToList();
            var result = highests.Any() ? highests.Sum() : input.First();
            return result;
        }
    }
}
