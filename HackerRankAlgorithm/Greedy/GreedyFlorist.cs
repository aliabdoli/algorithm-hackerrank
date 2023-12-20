using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Greedy
{
    public static class GreedyFlorist
    {
        public static int getMinimumCost(int k, int[] c)
        {
            var people = k;
            var costs = c.OrderByDescending(x => x).ToList();
            var minCost = 0;
            var round = 1;
            for (int j = 0; j < costs.Count; j++)
            {
                if (people > 0)
                {
                    var currentCost = costs[j] * round;
                    minCost += currentCost;
                    people--;
                }

                if (people == 0)
                {
                    round++;
                    people = k;
                }
            }

            return minCost;
        }
    }


}

