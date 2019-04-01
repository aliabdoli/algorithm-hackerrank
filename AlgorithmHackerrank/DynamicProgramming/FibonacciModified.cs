using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.DynamicProgramming
{
    public class FibonacciModified
    {
        public string fibonacciModified(int t1, int t2, int n)
        {
            var ti1 = new BigInteger(t2);
            var ti = new BigInteger(t1);
            var ti2 = new BigInteger(0);            

            for (int i = 3; i <= n; i++)
            {
                ti2 = ti + ti1 * ti1;
                ti = ti1;
                ti1 = ti2;
            }

            return ti2.ToString();
        }
    }
}
