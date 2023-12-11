using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace AlgorithmHackerrank.Searching
{
    /// <summary>
    /// Naive is combination of 2 from N => O(n^2)
    /// solution: O(n * log(n)) + O(n), just for sorting, and you traverse only once (from
    /// </summary>

    public class IceCreamParlorAlgorithm
    {
        //10:46
        public List<int> Solve(int money, List<int> costs)
        {
            // needs validations (e.x. money positive, costs none negative, ...

            var flavorCost = SearchFlavorCosts(money, costs);

            return CalculateOneBasedIndex(money, costs, flavorCost);
        }

        private static FlavorCost SearchFlavorCosts(int money, List<int> costs)
        {
            var sortedCosts = new List<int>();
            sortedCosts.AddRange(costs);
            sortedCosts.Sort();

            var largerCostInd = sortedCosts.Count() - 1;
            var lesserCostInd = 0;
            var flavorCost = new FlavorCost();

            while (lesserCostInd < largerCostInd)
            {
                flavorCost = new FlavorCost()
                {
                    LesserFlavorCost = sortedCosts[lesserCostInd],
                    LargerFlavorCost = sortedCosts[largerCostInd],
                };

                if (flavorCost.TotalCost == money)
                {
                    break;
                }

                if (flavorCost.TotalCost > money)
                {
                    largerCostInd--;
                }
                else if (flavorCost.TotalCost < money)
                {
                    lesserCostInd++;
                }
            }

            return flavorCost;
        }

        private static List<int> CalculateOneBasedIndex(int money, List<int> costs, FlavorCost flavorCost)
        {
            if (flavorCost.TotalCost == money)
            {
                var lesserFlavorCostInd = costs.FindIndex(x => x == flavorCost.LesserFlavorCost) + 1;
                var largerFlavorCostInd = -1;
                if (flavorCost.LesserFlavorCost == flavorCost.LargerFlavorCost)
                {
                    largerFlavorCostInd =
                        costs.Skip(lesserFlavorCostInd).ToList().FindIndex(x => x == flavorCost.LargerFlavorCost) +
                        lesserFlavorCostInd + 1;
                }
                else
                {
                    largerFlavorCostInd = costs.FindIndex(x => x == flavorCost.LargerFlavorCost) + 1;
                }


                var result = new List<int>() { lesserFlavorCostInd, largerFlavorCostInd }.OrderBy(x => x).ToList();
                return result;
            }
            else
            {
                return new List<int>();
            }
        }


        public class FlavorCost
        {
            public int LesserFlavorCost { get; set; } = 0;
            public int LargerFlavorCost { get; set; } = 0;

            public int TotalCost => LesserFlavorCost + LargerFlavorCost;
        }
    }
}