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
            var inputChars = input.ToCharArray().ToList();

            var letterFrequencies = inputChars.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            var groupedFrequencies = letterFrequencies.Values.GroupBy(x => x).
                ToDictionary(x => x.Key, y => y.Count());

            if (groupedFrequencies.Count > 2)
                return No;

            if (groupedFrequencies.Count == 1)
                return Yes;


            var minGroupedFreq = groupedFrequencies.OrderBy(x => x.Key).FirstOrDefault();
            var maxGroupedFreq = groupedFrequencies.OrderByDescending(x => x.Key).FirstOrDefault();

            if (minGroupedFreq.Value == 1)
            {
                if (minGroupedFreq.Key == 1)
                {
                    return Yes;
                }
            }

            if (maxGroupedFreq.Value == 1)
            {
                if (maxGroupedFreq.Key - minGroupedFreq.Key == 1)
                    return Yes;
            }

            return No;

        }
    }
}
