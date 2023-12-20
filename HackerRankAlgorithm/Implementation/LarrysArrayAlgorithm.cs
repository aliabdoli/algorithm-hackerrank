using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Implementation
{
    public class LarrysArrayAlgorithm
    {
        private const string Yes = "YES";
        private const string No = "NO";

        public static string larrysArray(int[] a)
        {
            var input = a.ToList();
            for (int ind = 0; ind < input.Count; ind++)
            {
                var currentInd = input.IndexOf(ind + 1);
                var shouldInd = ind;
                if (currentInd == shouldInd)
                {
                    continue;
                }
                while (currentInd >= shouldInd + 2)
                {
                    var right = input[currentInd];
                    var middle = input[currentInd - 1];
                    var left = input[currentInd - 2];

                    input[currentInd - 2] = right;
                    input[currentInd - 1] = left;
                    input[currentInd] = middle;
                    currentInd -= 2;
                }

                if (currentInd + 1 == input.Count)
                {
                    return No;
                }

                if (currentInd == shouldInd + 1)
                {
                    var right = input[currentInd +1];
                    var middle = input[currentInd];
                    var left = input[currentInd - 1];

                    input[currentInd - 1] = middle;
                    input[currentInd] = right;
                    input[currentInd + 1] = left;
                    currentInd--;
                }

                if (currentInd < shouldInd)
                {
                    return No;
                }
            }
            return Yes;
        }
    }
}
