using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.DynamicProgramming
{
    //NOT Solved
    public class TheCoinChangeProblem
    {

        public long getWays(long n, long[] c)
        {
            //var nc = c.ToList();
            //nc.Add(0);
            //var coins = nc.OrderBy(x => x).ToArray();
           

            //var ways = getWayRec(n, coins, 0);


            //var oWays = ways.Select(x => x.Split('-').Select(y => long.Parse(y)).OrderBy(y => y).ToList());

            //var waysN = new List<List<long>>();
            //foreach (var way in oWays)
            //{
            //    if (!waysN.Any(x => x.SequenceEqual(way)))
            //        waysN.Add(way);
            //}

            //var result = waysN.Count;
            //return result;
            return -1;
        }

        public List<string> getWayRec(long n, long[] coins, int cCoinInd)
        {
            var ways = new List<string>();
            if (n < 0)
                return ways;

            if (n == 0)
            {
                ways.Add($"{coins[cCoinInd]}");
                return ways;
            }

            for (int i = 1; i < coins.Length; i++)
            {
                
                var nWays = getWayRec(n - coins[i], coins, i);
                if (nWays.Count > 0)
                {
                    var toAdd = nWays.Select(x => $"{coins[cCoinInd]}-{x}");
                    ways.AddRange(toAdd);
                }
            }

            return ways;
        }

        public class Way
        {
            public List<string> Changes { get; set; }
        }

        public long getWays2(long n, long[] c)
        {
            var coins = c.OrderBy(x => x).ToArray();//.Select(x => new {value = x, way = 0}).ToArray();
            var ways = Enumerable.Range(0, n+1).Select(x =>
            {
                var item = new
                {
                    Ways = new List<string>()
                };
                if (c.Contains(x))
                {
                    item.Ways.Add($"{x}");
                }
                return item;
            }).ToArray();

            var minCoin = coins.Min();
            var maxCoin = coins.Max();
            for (long i = 0; i < ways.Length;  i += minCoin )
            {
                if (i - maxCoin > 0)
                {
                    ways[i - maxCoin].Ways.Clear();
                }

                for (int j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0)
                    {
                        if (ways[i - coins[j]].Ways.Count > 0)
                        {
                            var newChange = coins[j];

                            var otherChanges = ways[i - coins[j]].Ways.Select(x => $"{x}-{newChange}").ToList();
                            
                            ways[i].Ways.AddRange(otherChanges);

                        }
                    }
                }
            }

            //var oWays = ways[n].Ways.Select(x => x.GroupBy(y => y).OrderBy(y => y.Key).ToDictionary(z => z.Key, z => z.Count())).ToList();
            //var oWays = ways[n].Ways.Select(y => y.OrderBy(z => z.Key).ToDictionary(x => x.Key, x => x.Value));
            var oWays = ways[n].Ways.Select(x => x.Split('-').Select(y => long.Parse(y)).OrderBy(y => y).ToList());

            var waysN = new List<List<long>>();
            foreach (var way in oWays)
            {
                if (!waysN.Any(x => x.SequenceEqual(way)))
                    waysN.Add(way);
            }

            var result = waysN.Count;

            return result;
        }




        public long getWays1(long n, long[] c)
        {
            var coins = c.OrderBy(x => x).ToArray();//.Select(x => new {value = x, way = 0}).ToArray();
            var ways = Enumerable.Range(0, n + 1).Select(x =>
            {
                var item = new
                {
                    Changes = new HashSet<HashSet<long>>()
                };
                if (c.Contains(x))
                {
                    item.Changes.Add(new HashSet<long>(new List<long> { x }));
                }
                return item;
            }).ToArray();

            for (int i = 1; i < ways.Length; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i - coins[j] >= 0)
                    {
                        if (ways[i - coins[j]].Changes.Count > 0)
                        {
                            var newChange = coins[j];

                            var otherChanges = ways[i - coins[j]].Changes.Select(x =>
                            {
                                var list = new HashSet<long>(x.Select(y => y));
                                list.Add(newChange);
                                return list;
                            });

                            foreach (var otherChange in otherChanges)
                            {
                                if (!ways[i].Changes.Any(x => x.SetEquals(otherChange)))
                                    ways[i].Changes.Add(otherChange);
                            }

                        }
                    }
                }
            }

            var result = ways[n].Changes.Count;
            return result;
        }


        public static class Enumerable
        {
            public static IEnumerable<long> Range(long start, long count)
            {
                var end = start + count;
                for (var current = start; current < end; ++current)
                {
                    yield return current;
                }
            }
        }
    }
}
