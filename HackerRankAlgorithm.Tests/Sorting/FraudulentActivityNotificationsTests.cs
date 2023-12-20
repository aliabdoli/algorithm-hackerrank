using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Sorting;
using FluentAssertions;
using Xunit;


namespace HackerRankAlgorithm.Tests.Sorting
{
    
    public class FraudulentActivityNotificationsTests
    {
        [Theory]
        [InlineData(@"9 5
2 3 4 2 3 6 8 4 5", 2)]
        [InlineData(@"5 4
1 2 3 4 4", 0)]
        [InlineData(@"5 3
10 20 30 40 50", 1)]

        public void WhenThen(string input, int expected)
        {
            var algorithm = new FraudulentActivityNotifications();
            var reader = new StringReader(input);

            string[] nd = reader.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(reader.ReadLine().Split(' '),
                expenditureTemp => Convert.ToInt32(expenditureTemp));
            int result = algorithm.ActivityNotifications(expenditure, d);

            expected.Should().Be(result);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 2)]
        //[InlineData(new[] { 3, 2, 1 }, 2)]
        //[InlineData(new[] { 4, 3, 2, 1 }, 2.5)]
        //[InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 3.5)]
        //[InlineData(new[] { 4, 3, 2, 6, 8 }, 4)]
        //[InlineData(new[] { 1, 1, 2, 6, 6, 9 }, 4)]
        //[InlineData(new[] { 2, 10, 21, 23, 23, 38, 38 }, 23)]
        //[InlineData(new[] { 2, 10, 21, 23, 23, 38, 38, 1027892 }, 23)]
        public void FindMedianTest(int[] input, double expected)
        {
            var algorithm = new FraudulentActivityNotifications();
            var buckets = input.OrderBy(x => x).ToList();
            var result = FraudulentActivityNotifications.FindMedian(buckets, input.Count());
            expected.Should().Be(result);
        }

        [Theory]
        //[InlineData("FraudulentActivityNotificationsInlineData1Expected.txt", 633)]
        //[InlineData("FraudulentActivityNotificationsInlineData3Expected.txt", 1026)]
        //[InlineData("FraudulentActivityNotificationsInlineData4Expected.txt", 492)]
        [InlineData("FraudulentActivityNotificationsInlineData5Expected.txt", 926)]
        public void WhenThenFromFile(string fileName, int expected)
        {
            var s = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\Sorting\"+ fileName;
            //var expectedDir = @"C:\Users\ali.abdoli\source\repos\HackerRankAlgorithm\HackerRankAlgorithm.Tests\"+ fileName;

            var reader = new StreamReader(s);
            //var expectedReader = new StreamReader(expectedDir);

            var algorithm = new FraudulentActivityNotifications();

            string[] nd = reader.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);


            int[] expenditure = Array.ConvertAll(reader.ReadLine().Split(' '),
                expenditureTemp => Convert.ToInt32(expenditureTemp));


            int result = algorithm.ActivityNotifications(expenditure, d);

            expected.Should().Be(result);
        }
    }
}
