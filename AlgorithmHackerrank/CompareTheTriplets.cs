using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/compare-the-triplets/problem
    /// </summary>
    public class CompareTheTriplets
    {
        public static void Run()
        {
            
        }

        public int[] Solve(int[] a, int[] b)
        {
            var ifValid = Validate(a, b);
            if (!ifValid)
                throw new ArgumentException("not valid");

            var len = a.Length;
            var result = new int[2];
            for (int i = 0; i < len; i++)
            {
                if (a[i] > b[i])
                {
                    result[0]++;
                }
                else if (a[i] < b[i])

                {
                    result[1]++;
                }
            }

            return result;
        }

        private bool Validate(int[] ints, int[] ints1)
        {
            return true;
        }
    }
}
