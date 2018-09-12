using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class BiggerIsGreater
    {
        public const string NoAnswer = "no answer";
        public string Do(string w)
        {
            var input = w;
            var result = w.ToCharArray();
            var doable = false;
            for (int i = input.Length -1; i > 0; i--)
            {
                var fi = input[i];
                var fi1 = input[i - 1];
                if (fi1 < fi)
                {
                    //find fi position
                    for (int j = input.Length -1 ; j >= i; j--)
                    {
                        if (input[j] > fi1)
                        {
                            result[i-1] = input[j];
                            result[j] = fi1;
                            result.Skip(i).OrderBy(o => o).ToArray().CopyTo(result,i);
                            break;
                        }
                    }
                    doable = true;
                    break;
                }
            }

            return doable ? string.Concat(result) : NoAnswer;
        }
    }
}
