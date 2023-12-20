using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    public class SubstringDiff
    {
        public static int substringDiff(int k, string s1, string s2)
        {
            var result1 = SubstringRec(s1, s2, s1.Length, k);
            var result2 = SubstringRec(s2, s1, s2.Length, k);
            var result = Math.Max(result1, result2);
            return result;
        }


        //private static int SubstringRec(int remainDiff, string s1, int ind1, string s2, int ind2, ref string commonString)
        //{
        //    var length = s1.Length;
        //    var diff = new int[length, length];
        //    for (int k = 0; k < length; k++)
        //    {
        //        for (int i = 0; i < length - k; i++)
        //        {
        //            for (int j = 0; j < length - k; j++)
        //            {

        //                diff[i, j] = (s1[i] == s2[j]) ? diff[i, j] + 1 : diff[i, j];
        //            }
        //        }
        //    }

        //}


        private static int SubstringRec(string s1,  string s2, int s1Len, int maxDiff)
        {
            if(s1.Length != s2.Length)
                throw new Exception("Length should be the same");
            var len = s1.Length;
            var que = new Queue<int>();
            var best = 0;
            for (int off = 0; off < len; ++off)
            {
                for (int i = 0; i + off < len; i++)
                {
                    var char1 = s1[i];
                    var char2 = s2[off + i];
                    if (char1 == char2)
                    {
                        que.Enqueue(i);
                        while (i-que.Peek() - que.Count >= maxDiff)
                        {
                            que.Dequeue();
                        }

                        var score = que.Count + Math.Min(maxDiff, len - off - que.Count);
                        best = Math.Max(best, score);
                    }
                }
                que.Clear();

            }

            return best;
        }

        private static int SubstringRec1(int remainDiff, string s1, int ind1, string s2, int ind2, ref string commonString)
        {
            if (remainDiff < 0)
                return 0;

            if (ind1 < 0 || ind2 < 0)
                return 0;

            var result = 0;
            Console.WriteLine($"{ind1}-{ind2}");
            if (s1[ind1] == s2[ind2])
            {
                commonString = s1[ind1] + commonString;
                result =  1 + SubstringRec1(remainDiff, s1, ind1 - 1, s2, ind2 - 1, ref commonString);
            }
            else
            {
                var commonString1 = "";
                var commonString2 = "";
                var withoutS1 = SubstringRec1(remainDiff, s1, ind1 - 1, s2, ind2, ref commonString1);
                var withoutS2 = SubstringRec1(remainDiff, s1, ind1, s2, ind2 - 1, ref commonString2);

                result = Math.Max(withoutS2, withoutS1);
                if (withoutS1 > withoutS2)
                {
                    commonString = commonString1;
                }
                else
                {
                    commonString = commonString2;
                }
                
            }

            return result;
        }
    }
}
