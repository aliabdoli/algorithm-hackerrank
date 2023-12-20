using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public class FindMissingNumbersAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subsetNumbers">numbers to check</param>
        /// <param name="originalNumbers">big list that contains all numbers</param>
        /// <returns></returns>
        public List<int> FindMissingElements(List<int> subsetNumbers, List<int> originalNumbers)
        {
            var minOriginalNumbers = originalNumbers.Min();
            var maxOriginalNumbers = originalNumbers.Max();
            if (maxOriginalNumbers - minOriginalNumbers > 100)
            {
                throw new ArgumentException("min and max cant be higher than 100 in original list");
            }

            var missingNumbers = new List<int>();

            var originalFrequencies = CalculateFrequencies(originalNumbers);
            var subsetFrequencies = CalculateFrequencies(subsetNumbers);

            foreach (var item in originalFrequencies)
            {
                var frequency = 0;
                if (subsetFrequencies.TryGetValue(item.Key, out frequency))
                {
                    if (item.Value != frequency)
                    {
                        missingNumbers.Add(item.Key);
                    }
                }
                else
                {
                    missingNumbers.Add(item.Key);
                }
            }

            var result = missingNumbers.OrderBy(x => x).ToList();
            return result;

        }

        private static Dictionary<int, int> CalculateFrequencies(List<int> originalNumbers)
        {
            var frequencies = new Dictionary<int, int>();

            for (int i = 0; i < originalNumbers.Count; i++)
            {
                var val = originalNumbers[i];
                var _ = 0;
                if (frequencies.TryGetValue(val, out _))
                {
                    frequencies[val]++;
                }
                else
                {
                    frequencies[val] = 1;
                }
            }

            return frequencies;
        }
    }
}
