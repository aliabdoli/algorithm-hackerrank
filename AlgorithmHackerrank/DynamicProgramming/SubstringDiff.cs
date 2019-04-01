using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.DynamicProgramming
{
    public class SubstringDiff
    {
        public static int substringDiff(int i, string s1, string s2)
        {
            var commonString = "";
            var result = SubstringRec(i, s1, s1.Length -1, s2, s2.Length -1, ref commonString);
            return result;
        }

        private static int SubstringRec(int maxDiff, string s1, int ind1, string s2, int ind2, ref string commonString)
        {
            if (maxDiff < 0)
                return 0;

            if (ind1 < 0 || ind2 < 0)
                return 0;

            var result = 0;
            Console.WriteLine($"{ind1}-{ind2}");
            if (s1[ind1] == s2[ind2])
            {
                commonString = s1[ind1] + commonString;
                result =  1 + SubstringRec(maxDiff, s1, ind1 - 1, s2, ind2 - 1, ref commonString);
            }
            else
            {
                var commonString1 = "";
                var commonString2 = "";
                var withoutS1 = SubstringRec(maxDiff, s1, ind1 - 1, s2, ind2, ref commonString1);
                var withoutS2 = SubstringRec(maxDiff, s1, ind1, s2, ind2 - 1, ref commonString2);

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
