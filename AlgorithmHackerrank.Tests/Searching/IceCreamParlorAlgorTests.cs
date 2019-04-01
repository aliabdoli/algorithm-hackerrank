using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.Searching
{
    [TestFixture]
    public class IceCreamParlorAlgorTests
    {
        [Test]
//        [TestCase(@"2
//4
//5
//1 4 5 3 2
//4
//4
//2 2 4 3")]
        [TestCase(@"3
9
6
1 3 4 6 7 9
8
6
1 3 4 4 6 8
3
2
1 2")]
        public void MainFlow(string input)
        {
            var algor = new IceCreamParlorAlgor();
            var inputReader = new StringReader(input);
            int t = Convert.ToInt32(inputReader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int m = Convert.ToInt32(inputReader.ReadLine());

                int n = Convert.ToInt32(inputReader.ReadLine());

                int[] arr = Array.ConvertAll(inputReader.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                    ;
                int[] result = algor.icecreamParlor(m, arr);
                var output = string.Join(" ", result);

            }

        }
    }
}
