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
            var source = s1;
            var dest = s2;
            var commons = new int[source.Length + 1, source.Length + 1];
            var adding = 0;
            var prev = 0;
            var val = 0;
            for (int i = 1; i < commons.GetLength(0); i++)
            {
                for (int j = 1; j < commons.GetLength(1); j++)
                {
                    if (source[i - 1] == dest[j - 1])
                    {
                        commons[i, j] = 1 + commons[i - 1, j - 1];
                    }
                    else
                    {
                        commons[i, j] = Math.Max(commons[i - 1, j], commons[i, j - 1]);
                    }
                }
            }

            var result =  commons[source.Length, dest.Length];
            return result;
        }
        
    }
}
