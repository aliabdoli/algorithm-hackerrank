using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Strings
{
    public class CommonChild
    {
        public int commonChild(string s1, string s2)
        {
            /// it s just typical most common subsequence algo!!!!
            var s1Chars = s1.ToCharArray().ToList();
            var s2Chars = s2.ToCharArray().ToList();

            var commonSubsequences = Enumerable.Range(0, s1Chars.Count + 1)
                .Select(x => Enumerable.Range(0, s2Chars.Count + 1).Select(x => 0).ToList()).ToList();


            for (int i = 0; i < s1Chars.Count; i++)
            {
                for (int j = 0; j < s2Chars.Count; j++)
                {
                    var s1Char = s1Chars[i];
                    var s2Char = s2Chars[j];

                    var iCS = i + 1;
                    var jCS = j + 1;

                    var maxCommon = 0;
                    if (s1Char != s2Char)
                    {
                        maxCommon = Math.Max(commonSubsequences[iCS][jCS-1], commonSubsequences[iCS-1][jCS]);
                        
                    }
                    else
                    {
                        maxCommon = 1 + commonSubsequences[iCS - 1][jCS - 1];

                    }
                    commonSubsequences[iCS][jCS] = maxCommon;
                    
                }
            }

            var largestCommonSubsequence = commonSubsequences[s1Chars.Count][s2Chars.Count];
            return largestCommonSubsequence;
        }
    }
}

