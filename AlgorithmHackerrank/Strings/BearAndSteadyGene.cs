using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Strings
{
    public class BearAndSteadyGene
    {
        public int steadyGene(string gene)
        {
            
            var input = gene.ToCharArray();
            var lenForEach = input.Length / 4;
            var frequencies = input.GroupBy(x => x).ToDictionary(x => x.Key, y => lenForEach - y.Count());
            var allowed = new List<char>()
            {
                'A','C','T', 'G'
            };

            foreach (var item in allowed)
            {
                if (!frequencies.ContainsKey(item))
                {
                    frequencies.Add(item, lenForEach);
                }    
            }

            var left = 0;
            var right = -1;
       
            var mores = frequencies.Where(x => x.Value < 0).ToDictionary(x => x.Key, y => y.Value);

            while (right < input.Length - 1 && mores.Any(x => x.Value < 0))
            {
                right++;

                if (mores.ContainsKey(input[right]))
                {
                    mores[input[right]]++;
                }
            }

            var bestRight = right;
            var bestLeft = left;

            while (right < input.Length - 1)
            {
                right++;
                if (!mores.ContainsKey(input[right]))
                {
                    continue;
                }

                mores[input[right]]++;

                while (true)
                {
                    if(mores.ContainsKey(input[left]))
                    {
                        mores[input[left]]--;
                        var valid = mores.All(x => x.Value >= 0);
                        if (valid)
                        {
                            left++;
                        }
                        else
                        {
                            mores[input[left]]++;
                            break;
                        }
                    }
                    else
                    {
                        left++;
                    }
                }

                var isAnswer = mores.All(x => x.Value >= 0);
                if (isAnswer && bestRight - bestLeft > right - left)
                {
                    bestLeft = left;
                    bestRight = right;
                }
            }
            
            var result = bestRight - bestLeft +1;
            

            return result;
           
        }
    }
}


