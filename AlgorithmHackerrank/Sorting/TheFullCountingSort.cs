using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Sorting
{
    // start 5:49 6:05
    public class TheFullCountingSort
    {
        public string countSort(List<List<string>> arr)
        {
           // arr.Sort(x => x.);
            for (int i = 0; i < arr.Count/2; i++)
            {
                arr[i][1] = "-";
            }
            var dicPairValueList = arr.Select(x => new {Key=int.Parse(x[0]), Value= x[1]})
                .GroupBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.ToList());

            var ordered = dicPairValueList.OrderBy(x => x.Key).SelectMany(x => x.Value);
            var semiFlat = ordered.Select(x => string.Join(" ", x.Value));
            var flat = string.Join(" ", semiFlat);

            return flat;

            //var ordered = dicPairValueList.OrderBy(x => x.Key);
            //var result = ordered.Select(x => x.Value.Select(y => y.Value)).ToList();

            //arr = result;
        }
    }
}
