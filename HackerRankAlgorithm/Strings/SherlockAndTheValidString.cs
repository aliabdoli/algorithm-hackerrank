using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Strings
{
    public class SherlockAndTheValidString
    {
        private const string Yes = "YES";
        private const string No = "NO";

        public static string IsValid(string input)
        {
            var frequencyDic = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (frequencyDic.ContainsKey(input[i]))
                {
                    frequencyDic[input[i]]++;
                }
                else
                {
                    frequencyDic.Add(input[i],1);
                }
            }

            var frequencies = frequencyDic.Values.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            if (frequencies.Count == 1)
                return Yes;

            if (frequencies.Count == 2)
            {
                var ordered = frequencies.OrderBy(x => x.Value).ToList();

                if (ordered[0].Value == 1 && ordered[0].Key == 1)
                    return Yes;

                if (ordered[0].Value == 1 && Math.Abs(ordered[1].Key - ordered[0].Key) == 1)
                    return Yes;
            }

            return No;
        }
    }
}
