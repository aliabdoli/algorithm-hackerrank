using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Sorting
{
    public class LilysHomework
    {
        public int FindMinSwap(long[] arr)
        {
            var inputs = arr.ToList();
            
            var ascSwap = FindSwapsForAscending(inputs);
            var descSwap = FindSwapForDescending(inputs);

            var swap = Math.Min(ascSwap, descSwap);
            return swap;
        }

        private int FindSwapForDescending(List<long> inputs)
        {
            var desc = inputs.OrderByDescending(x => x).ToList();
            var indexes = CreateValueIndexHash(inputs);
            var swap = CalculateSwap(desc, indexes, inputs.ToList());
            return swap;
        }

        private int FindSwapsForAscending(List<long> inputs)
        {
            var asc = inputs.OrderBy(x => x).ToList();
            var indexes = CreateValueIndexHash(inputs);
            var swap = CalculateSwap(asc, indexes, inputs.ToList());
            return swap;
        }

        private int CalculateSwap(List<long> sorts, Dictionary<long, int> inputMaps, List<long> inputs)
        {
            var swap = 0;
            var i = 0;
            while(i < inputs.Count)
            {
                var input = inputs[i];
                var sort = sorts[i];
                if (input != sort)
                {
                    swap++;

                    inputs[inputMaps[sort]] = input;
                    inputs[i] = sort;

                    inputMaps[input] = inputMaps[sort];
                    inputMaps[sort] = i;
                }

                i++;
            }
            return swap;
        }

        public Dictionary<long, int> CreateValueIndexHash(List<long> inputs)
        {
            var oldIndexes = inputs
                .Select((val, ind) => new { val, ind })
                .ToDictionary(x => x.val, y => y.ind);
            return oldIndexes;
        }
    }
}
