using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Strings;

namespace HackerRankAlgorithm.Searching
{
    public static class ShortPalindrome
    {
//30, 31, 32, 34...40
        //6:03
        public static int shortPalindrome(string input)
        {

            var inputArray = input.ToCharArray();
            var distincts = inputArray.Distinct().ToList();
            var inputArrayLength = inputArray.Length;


            var distCount = distincts.Count();
            var zero = BigInteger.Zero;
            var one = BigInteger.One;
            BigInteger result = zero;

            for (int i = 0; i < distCount; i++)
            {
                for (int j = 0; j < distCount; j++)
                {

                    var toFind = new char[] { distincts[i], distincts[j], distincts[j], distincts[i] };
                    var count = FindAllSubStrings(toFind, inputArray, 4, inputArrayLength, zero, one);
                    result += count;
                }
            }

            var returning = (int) (result % (BigInteger)(Math.Pow(10, 9) + 7));
            return returning;

        }

        private static BigInteger FindAllSubStrings(char[] toFind, char[] inputArray, int toFindLength, int inputArrayLength, BigInteger zero, BigInteger one)
        {
            var subs = new BigInteger[inputArray.Length+1, toFind.Length+1];
            //// little performance
            //var inputArrayLength = inputArray.Length;
            //var toFindLength = 4; toFind.Length;


            var len0 = inputArrayLength +1;
            var len1 = toFindLength + 1;


            for (int i = 0; i < len0; i++)
            {
                subs[i, 0] = one;
            }

            //for (int j = 1; j < len1; j++)
            //{
            //    subs[0, j] = 0;
            //}

            checked
            {
                for (int i = 1; i < len0; i++)
                {
                    for (int j = 1; j < len1; j++)
                    {
                        var elem1 = subs[i - 1, j];
                        BigInteger elem2 = zero;
                        if (inputArray[inputArrayLength - i] == toFind[toFindLength - j])
                        {
                            elem2 = subs[i - 1, j - 1];
                        }

                        subs[i, j] = elem1 + elem2;
                    }
                }
            }

            return subs[inputArrayLength, toFindLength];
        }

        //private static int FindAllSubStrings_recursive_slow(List<char> toFind, List<char> input)
        //{
        //    var result = 0;

        //    if (input.Count == 0 && toFind.Count > 0)
        //    {
        //        return result;
        //    }

        //    if (toFind.Count == 0)
        //    {
        //        return 1;
        //    }

        //    for (int i = 0; i < input.Count; i++)
        //    {
        //        if (input[i] == toFind[0])
        //        {
        //            result += FindAllSubStrings(toFind.Skip(1).ToList(), input.Skip(i+1).ToList());
        //        }
        //    }

        //    return result;
        //}
    }
}
