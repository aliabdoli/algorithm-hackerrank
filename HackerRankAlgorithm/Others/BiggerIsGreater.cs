using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm
{
    public class BiggerIsGreater
    {
        public const string NoAnswer = "no answer";

        public string Do(string w)
        {
            var characters = w.Split("").SelectMany(x => x).ToList();
            var sortedCharManagement = new SortedCharManagement();

            var reverseCharacter = characters
                .Select(x => x)
                .Reverse()
                .ToList();

            sortedCharManagement.Add(reverseCharacter[0]);
            //wrong, what if continue
            for (int i = 1; i < reverseCharacter.Count; i++)
            {
                var currentChar = reverseCharacter[i];

                //todo: char comparison safer
                if (currentChar >= sortedCharManagement.MaxChar)
                {
                    sortedCharManagement.Add(currentChar);
                }
                else
                {
                    sortedCharManagement.AddAndMark(currentChar);
                    var markedSubstringChars = CalculateSubstringUpToMarked(sortedCharManagement);
                    var intactSubstringChars = reverseCharacter.Skip(i + 1).Reverse().ToList();
                    var resultList = new List<char>();
                    resultList.AddRange(intactSubstringChars);
                    resultList.AddRange(markedSubstringChars);
                    return string.Join("", resultList);
                }
            }

            return NoAnswer;
        }

        private static List<char> CalculateSubstringUpToMarked(SortedCharManagement sortedCharManagement)
        {
            var nextSmaller = sortedCharManagement.GetNextSmallerAndRemove(
                sortedCharManagement.MarkedChar.Value);

            var sortedList = sortedCharManagement.GetSortedList();
            //sortedList.Reverse();
            //maybe string builder
            var resultList = new List<char>(){nextSmaller};
            resultList.AddRange(sortedList);
            return resultList;
        }
    }

    public class SortedCharManagement
    {
        public char MaxChar => _sortedChars.Keys.Last();
        public char? MarkedChar { get; private set; }

        private SortedList<char, int> _sortedChars = new SortedList<char, int>();

        public void Add(char character)
        {
            if (!_sortedChars.TryAdd(character, 1))
            {
                _sortedChars[character]++;
            }
        }

        public char GetNextSmallerAndRemove(char currentChar)
        {
            var ind = _sortedChars.IndexOfKey(currentChar);
            var nextSmaller = _sortedChars.Keys[++ind];
                _sortedChars[nextSmaller]--;

            return nextSmaller;

        }

        public List<char> GetSortedList()
        {
            var result = new List<char>();

            foreach (var item in _sortedChars)
            {
                var chars = Enumerable.Range(0, item.Value).Select(x => item.Key).ToList();
                //not great perf
                result.AddRange(chars);
            }

            return result;
        }

        public void AddAndMark(char currentChar)
        {
            this.Add(currentChar);
            MarkedChar = currentChar;
        }
    }


}
