using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Searching
{
    public class PairsAlgorithm
    {
        public int pairs(int k, int[] arr)
        {
            var inputs = arr.ToList();
            inputs.Sort();
            var counter = 0;
            foreach (var input in inputs)
            {
                var itemToFind = k + input;
                var foundIndex = inputs.BinarySearch(itemToFind);
                if (foundIndex >= 0)
                    counter++;
            }

            return counter;
        }
    }
}
