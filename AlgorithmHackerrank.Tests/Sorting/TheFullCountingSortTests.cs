using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Sorting;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests.Sorting
{
    [TestFixture]
    public class TheFullCountingSortTests
    {
        [Test]
        public void BasicShouldPass()
        {
            
            var input = @"20
0 ab
6 cd
0 ef
6 gh
4 ij
0 ab
6 cd
0 ef
6 gh
0 ij
4 that
3 be
0 to
1 be
5 question
1 or
2 not
4 is
2 to
4 the";
            var inputString = new StringReader(input);
            int n = Convert.ToInt32(inputString.ReadLine().Trim());

            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(inputString.ReadLine().TrimEnd().Split(' ').ToList());
            }


            var algor = new TheFullCountingSort();
            var result = algor.countSort(arr);
            Assert.AreEqual("- - - - - to be or not to be - that is the question - - - -", result);
        }
    }
}
