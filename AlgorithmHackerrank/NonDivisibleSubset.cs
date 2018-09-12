using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class NonDivisibleSubset
    {
        public int Run(int k, int[] S)
        {
            var set = S.ToList();
            var factor = k;
            var result = 0;

            var factorArray = Enumerable.Range(0, factor).ToDictionary(key => key, val => 0);

            foreach (var item in set)
            {
                var remain = item % factor;
                factorArray[remain]++;
            }

            var halfCounter = Math.Ceiling((decimal) (factor / 2.0));
            for (int i = 1; i < halfCounter; i++)
            {
                if (factorArray[i] > factorArray[factor - i])
                    result += factorArray[i];
                else
                    result += factorArray[factor - i];
            }

            if (factorArray[0] > 0)
                result++;

            if (factor % 2 == 0 && factorArray[factor / 2] > 0)
            {
                result += 1;
            }

            return result;
        }

    }
}
