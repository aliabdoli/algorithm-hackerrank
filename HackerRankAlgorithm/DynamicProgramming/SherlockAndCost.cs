using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    public class SherlockAndCost
    {
        public int cost(int[] B)
        {
            var input = B.ToList();
            var costWith = 0;
            var costOne = 0;

            for (int i = 1; i < input.Count; i++)
            {
                var withR = Math.Max(costWith + Math.Abs(input[i] - input[i - 1]), costOne + Math.Abs(input[i] - 1));
                var OneR = Math.Max(costWith + Math.Abs(input[i - 1] - 1), costOne);
                costWith = withR;
                costOne = OneR;
            }

            var result = Math.Max(costWith, costOne);
            return result;
        }


    }
}
