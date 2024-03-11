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
            var closestBiggestChars = new List<char>();
            var closestBiggestString = NoAnswer;

            var sortedChars = new SortedWithDuplicateList();
            var inputChars = w.ToCharArray().ToList();
            inputChars.Reverse();

            sortedChars.Add(inputChars[0]);

            for (int i = 1; i < inputChars.Count; i++)
            {
                var currentChar = inputChars[i];
                //todo: works for chars?
                if (currentChar >= sortedChars.Max)
                {
                    sortedChars.Add(currentChar);
                    continue;
                }
                else
                {
                    // change active part of string
                    var closestBiggestChar = sortedChars.PopClosestBiggest(currentChar);
                    closestBiggestChars.Add(closestBiggestChar);
                    sortedChars.Add(currentChar);
                    closestBiggestChars.AddRange(sortedChars.GetSorted());

                    //remaining unchanged
                    var remaining = inputChars.Skip(i + 1).ToList();
                    remaining.Reverse();
                    remaining.AddRange(closestBiggestChars);
                    closestBiggestChars = remaining;

                    //convert to string
                    closestBiggestString = string.Join("", closestBiggestChars);
                    return closestBiggestString;
                }
            }
            
            return closestBiggestString;
        }
    }

    public class SortedWithDuplicateList
    {
        public char Max => _sortedChars.Last();
        private List<char> _sortedChars = new List<char>();

        public void Add(char inputChar)
        {
            var ind = FindClosestBiggest(inputChar);

            //todo: O(N)
            _sortedChars.Insert(ind, inputChar);
        }


        public char PopClosestBiggest(char inputChar)
        {
            var ind = _sortedChars.BinarySearch(inputChar);
            if (ind < 0)
            {
                ind = ~ind;
            }
            else
            {
                //handle duplicates
                var existingChar = _sortedChars[ind];
                var current = existingChar;

                while (current == existingChar)
                {
                    ind++;
                    current = _sortedChars[ind];
                }
            }
            var result = _sortedChars[ind];
            _sortedChars.RemoveAt(ind);
            return result;
        }

        public List<char> GetSorted() => _sortedChars;


        private int FindClosestBiggest(char inputChar)
        {
            var ind = _sortedChars.BinarySearch(inputChar);
            if (ind < 0)
            {
                ind = ~ind;
            }

            return ind;
        }
    }


}
