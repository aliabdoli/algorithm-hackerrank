using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    //NOT Solved
    public class TheCoinChangeProblem
    {

        public long getWays(int n, List<long> c)
        {
            var calculator = new CoinChangeCalculator();
            long ways = calculator.Count(n, c);
            return ways;
        }
    }

    public class CoinChangeCalculator
    {
        public long Count(int totalAmount, List<long> coins)
        {
            var coinAmountMappings = new Dictionary<long, Dictionary<int, long>>();


            var amounts = Enumerable.Range(0, totalAmount+1).Select(x => x).ToList();
            for (int i = 0; i < coins.Count; i++)
            {
                var currentCoin = coins[i];
                coinAmountMappings[currentCoin] = new Dictionary<int, long>();
                foreach (var amount in amounts)
                {
                    if (amount == 0)
                    {
                        //todo: new implementation
                    }

                    var currentWay = 0;
                    if (amount < currentCoin)
                    {
                        if (currentCoin - 1 < 0)
                        {
                            
                        }
                        //coinAmountMappings[currentCoin] = 
                    }
                    coinAmountMappings[currentCoin][amount] = 0;
                }
            }


            



        }
    }
}
