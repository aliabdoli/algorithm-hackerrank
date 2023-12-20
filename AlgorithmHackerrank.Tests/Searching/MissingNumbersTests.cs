using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using FluentAssertions;
using Xunit;


namespace AlgorithmHackerrank.Tests.Searching
{
    
    public class MissingNumbersTests
    {
        [Theory]
        [InlineData(@"10
203 204 205 206 207 208 203 204 205 206
13
203 204 204 205 206 207 205 208 203 206 205 206 204", "204 205 206")]
        public void MainFlow(string inputString, string expected)
        {
            var inputStream = new StringReader(inputString);
            var algor = new FindMissingNumbersAlgorithm();

            int n = Convert.ToInt32(inputStream.ReadLine());

            int[] arr = Array.ConvertAll(inputStream.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
            int m = Convert.ToInt32(inputStream.ReadLine());

            int[] brr = Array.ConvertAll(inputStream.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
                ;
            List<int> result = algor.FindMissingElements(arr.ToList(), brr.ToList());


            result.Should().BeEquivalentTo(Array.ConvertAll(expected.Split(' '), int.Parse));
            //textWriter.WriteLine(string.Join(" ", result));
        }
    }
}
