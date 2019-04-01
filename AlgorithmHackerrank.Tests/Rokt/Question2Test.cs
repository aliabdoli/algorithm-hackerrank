using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Rokt;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlgorithmHackerrank.Tests.Rokt
{
    [TestFixture]
    public class Question2Test
    {
        [Test]
        public void MainTest()
        {
//            var input = @"6
//1
//3
//46
//1
//3
//9
//47";

            var input = @"7
6
12
3
9
3
5
1
12";
            var inputString = new StringReader(input);
            int roktCouponsCount = Convert.ToInt32(inputString.ReadLine().Trim());

            List<int> roktCoupons = new List<int>();

            for (int i = 0; i < roktCouponsCount; i++)
            {
                int roktCouponsItem = Convert.ToInt32(inputString.ReadLine().Trim());
                roktCoupons.Add(roktCouponsItem);
            }

            long k = Convert.ToInt64(inputString.ReadLine().Trim());

            Question2.numberOfPayment(roktCoupons, k);



        }
    }
}
