using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Rokt
{
    public class Question2
    {
        public static int numberOfPayment(List<int> roktCoupons, long k)
        {
            return 0;
        }




        public static int numberOfPayment1(List<int> roktCoupons, long k)
        {
            var counter = 0;
            roktCoupons.Sort();
            var resultPairs =new Dictionary<int, int>();
            for (int i = 0; i < roktCoupons.Count-1; i++)
            {
                var firstCoupon = roktCoupons[i];
                for (int j = i+1; j < roktCoupons.Count; j++)
                {
                    var secondCoupon = roktCoupons[j];
                    if (firstCoupon + secondCoupon == k)
                    {
                        var tempCoupon = -1;
                        if(!resultPairs.TryGetValue(firstCoupon, out tempCoupon))
                        {
                            counter++;
                            resultPairs.Add(firstCoupon, secondCoupon);
                        }
                    }
                }
            }
            return counter;
        }
    }
}
