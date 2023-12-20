using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.GraphTheory;
using Xunit;

namespace HackerRankAlgorithm.Tests.GraphTheory
{

    public class BreadthFirstSearchShortestReachTests
    {
        [Theory]
        [InlineData(@"2
        4 2
        1 2
        1 3
        1
        3 1
        2 3
        2", @"6 6 -1
        -1 6")]
        //        [InlineData(@"1
        //5 3
        //1 2
        //1 3
        //3 4
        //1", "6 6 12 -1")]
        public void MainFlow(string inputString, string expectedString)
        {
            var input = new StringReader(inputString);
            var expected = new StringReader(expectedString);
            var arr = new ArrayList();

            arr.Add("bb");
            arr.Add(new String[] {"ad", "bb"});





        }

        public int CountItems(ArrayList arr, string item)
        {
            var total = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                var current = arr[i];
                if (current is string && string.Equals(current, item))
                {
                    total++;
                }

                if (current is ArrayList)
                {
                    var arrayCurrent = (ArrayList) current;
                    var currentCount = CountItems(arrayCurrent, item);
                    total += currentCount;
                }
            }

            return total;
        }
    }
}
