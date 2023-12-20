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
            var input = s;
            var count = 0;
            for (int i = 1; i < input.Length; i++)
            {
                var dict = new Dictionary<string, int>();

                for (int j = 0; j < input.Length - i +1; j++)
                {
                    var item = new string(input.Skip(j).Take(i).OrderBy(x => x).ToArray());


                    var soFar = 0;
                    if (dict.TryGetValue(item, out soFar))
                    {
                        dict[item] = dict[item] + 1;
                        count += dict[item];
                    }
                    else
                    {
                        dict.Add(item, 0);
                    }
                }
            }

            return count;
        }
    }
}
