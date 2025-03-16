using System.Numerics;
using System.Text;

namespace HackerRankAlgorithm.Others
{
    /// <summary>
    /// 
    /// https://www.hackerrank.com/challenges/extra-long-factorials/problem?isFullScreen=true
    /// </summary>
    public static class ExtraLongFactorials
    {
        public static string Run(int n)
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
            {
                factorial = BigInteger.Multiply(factorial, new BigInteger(i));
            }


            return factorial.ToString();
        }
    }
}
