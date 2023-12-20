using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.DynamicProgramming;
using Xunit;

namespace HackerRankAlgorithm.Tests.DynamicProgramming
{
    public class HackerRankCityTests
    {
        [Theory]
        [InlineData(@"")]
        public void MainFlow(string inputString)
        {
            var input = new StringReader(inputString);

            int ACount = Convert.ToInt32(input.ReadLine());

            int[] A = Array.ConvertAll(input.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
            int result = HackerRankCity.hackerrankCity(A);


        }
    }
}
