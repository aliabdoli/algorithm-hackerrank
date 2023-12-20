using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Rokt
{
    public class Question1
    {
        private static readonly Dictionary<char, char> _closingDictionary = new Dictionary<char, char>()
        {
            {'{','}'}, 
            {'[',']'}, 
            {'(',')'},
        };

        private static readonly Dictionary<char, char> _openningDictionary = new Dictionary<char, char>()
        {
            {'}','{'},
            {']','['},
            {')','('},
        };

        private const string Fail = "NO";
        private const string Pass = "YES";

        public static List<string> correctness(List<string> roktx)
        {
          
            var results = new List<string>();

            foreach (var input in roktx)
            {
                var result = CorrectnessIndividual(input);
                results.Add(result);
            }
            return results;
        }

        public static string CorrectnessIndividual(string input)
        {
            var inputStack =new Stack<char>();
            char tempChar;
            foreach (var item in input)
            {
                if (_closingDictionary.TryGetValue(item, out tempChar))
                {
                    inputStack.Push(item);
                    continue;
                }

                if (inputStack.Count == 0)
                    return Fail;

                var top = inputStack.Pop();
                
                _openningDictionary.TryGetValue(item, out tempChar);
                if (top != tempChar)
                {
                    return Fail;
                }
            }

            return Pass;
        }
    }
}
