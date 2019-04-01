using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Searching
{
    public class MissingNumbers
    {
        public int[] missingNumbers(int[] arr, int[] brr)
        {
            var result = new List<int>();
            var originals = brr.ToList();
            var missings = arr.ToList();

            var originalDict = originals.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
            var missingDict = missings.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            var missingCount = -1;
            foreach (var original in originalDict)
            {
                var originalCount = original.Value;
                var originalValue = original.Key;
                if (missingDict.TryGetValue(originalValue, out missingCount))
                {
                    if (originalCount > missingCount)
                    {
                        result.Add(originalValue);
                    }
                }
                else
                {
                    result.Add(originalValue);
                }
            }

            
            return result.OrderBy(x => x).ToArray();

        }
    }
}
