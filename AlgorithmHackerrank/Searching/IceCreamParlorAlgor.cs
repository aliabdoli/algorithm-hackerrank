using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Searching
{
    public class IceCreamParlorAlgor
    {
        //10:46
        public int[] icecreamParlor(int m, int[] arr)
        {
            var moneyList = arr.ToList();
            var indexDictionary = moneyList
                .Select((x, ind) => new {Index = ind, Value = x})
                .GroupBy(y => y.Value)
                
                .ToDictionary(x => x.Key, y => y.Select(z => z.Index));


            moneyList.Sort();

            var rightMoney = new List<int>();

            var i = 0;
            var j = moneyList.Count -1;

            while (i < j)
            {
                var left = moneyList[i];
                var right = moneyList[j];
                var sum = left + right;

                if (sum == m)
                {
                    rightMoney.Add(left);
                    rightMoney.Add(right);
                    i++;
                    j--;
                }
                else if (sum < m)
                {
                    i++;
                } else if (sum > m)
                {
                    j--;
                }
            }

            var result =  rightMoney.Select(x =>
            {
                var item = indexDictionary[x];
                var oldIndex = item.First();
                indexDictionary[x] = item.Skip(1);
                return ++oldIndex;
            }).ToList();

            result.Sort();
            
            
            return result.ToArray();
        }
    }
}
