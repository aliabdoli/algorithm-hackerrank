using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public class MinimumLoss
    {
        public int minimumLoss(List<long> price)
        {
            var pricesList = price
                .Select((val, ind) => new { val, ind })
                .OrderBy(x => x.val)
                .ToList();

            var dists = pricesList.Select((val,sInd) => new {val,sInd}).Skip(1).Select((sVal) =>
            {
                var current = pricesList[sVal.sInd];
                var prev = pricesList[sVal.sInd - 1];
                var result = current.val - prev.val;
                if (current.ind < prev.ind)
                {
                    return result;
                }

                return int.MaxValue;
            });

            var min = dists.Min();
            return (int) min;
        }

    }
}
