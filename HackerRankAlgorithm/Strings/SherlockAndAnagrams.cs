using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Strings
{
    public class SherlockAndAnagrams
    {
        public int sherlockAndAnagrams(string s)
        {
            var substringFrequencies = new Dictionary<string, int>();
            for (int i = 1; i < s.Length; i++)
            {
                var fixedLenSubstrings = FindSubstringWithLen(s, i);

                var sortedSubstrings = SortSubstrings(fixedLenSubstrings);
                substringFrequencies = UpdateFrequencies(sortedSubstrings, substringFrequencies);
            }

            var twoPermutations = CalculateCombinationsForFrequencies(substringFrequencies);

            return twoPermutations;
        }

        private static List<List<char>> SortSubstrings(List<string> fixedLenSubstrings)
        {
            var sortedSubstrings = new List<List<char>>();
            foreach (var fixedLenSubstring in fixedLenSubstrings)
            {
                var sortedSubstring = SortStr(fixedLenSubstring.ToCharArray().ToList());
                sortedSubstrings.Add(sortedSubstring);

            }

            return sortedSubstrings;
        }

        private static int CalculateCombinationsForFrequencies(Dictionary<string, int> substringFrequencies)
        {
            var combinations = 0;
            foreach (var substringFrequency in substringFrequencies)
            {
                var freq = substringFrequency.Value;
                var combination = freq * (freq - 1) / 2;
                combinations += combination;
            }
            return combinations;
        }

        private static Dictionary<string, int> UpdateFrequencies(List<List<char>> substrings, 
            Dictionary<string, int> substringFrequencies)
        {
            foreach (var substring in substrings)
            {
                var actualSubstring = new String(substring.ToArray());
                if (substringFrequencies.TryGetValue(actualSubstring, out var substringFreq))
                {
                    substringFrequencies[actualSubstring]++;
                }
                else
                {
                    substringFrequencies.Add(actualSubstring, 1);
                }
            }

            return substringFrequencies;
        }

        private static List<char> SortStr(List<char> str)
        {
            //todo: performance
            return str.OrderBy(x => x).ToList();
        }

        private static List<string> FindSubstringWithLen(string str, int len)
        {
            var substrings = new List<string>();
            for (int i = 0; i < str.Length-len+1; i++)
            {
                var substring = str.Substring(i, len);
                substrings.Add(substring);
            }
            return substrings;
        }
    }
}
