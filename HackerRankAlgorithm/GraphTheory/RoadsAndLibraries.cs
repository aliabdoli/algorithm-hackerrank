using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.GraphTheory
{
    public static class RoadsAndLibraries
    {

        public static long roadsAndLibraries(int cityCount, int libCost, int roadCost, List<List<int>> stupidCities)
        {
            


                    if (roadCost > libCost)
                    {
                        long result = (long) cityCount * (long) libCost;
                        return result;
                    }

                    var cities = stupidCities.ToList().Select(x =>
                        {
                            return new[]
                            {
                                new { src = x[0], dest = x[1] },
                                new { src = x[1], dest = x[0] }
                            };
                        })
                        .SelectMany(x => x)
                        .GroupBy(x => x.src)
                        .ToDictionary(x => x.Key, y => y.Select(z => z.dest).ToList());

                    long totalRoadCount = 0;
                    long totalLibCount = 0;
                    var seenNodes = new HashSet<int>();
                    var seenLib = new HashSet<int>();


                    for (int i = 1; i <= cityCount; i++)
                    {
                        //check if seen changes!!
                        long roadCount = 0;

                        if (!seenNodes.Contains(i))
                        {
                            totalLibCount++;
                        }

                        DfsCities(i, cities, seenNodes, seenLib, ref roadCount);
                        totalRoadCount += roadCount;

                    }

                    return totalRoadCount * roadCost + totalLibCount * libCost;
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            //return -1;
        }

        private static void DfsCities(int current, 
            Dictionary<int, List<int>> cities, 
            HashSet<int> seenNodes,
            HashSet<int> seenLib,
            ref long roadCount)
        {
            //try
            //{
           
            //checked
            //{


                if (!seenNodes.Add(current))
                {
                    return;
                }

                seenLib.Add(current);
                //no child
                List<int> children;
                if (!cities.TryGetValue(current, out children))
                {
                    return;
                }

                var notSeenChildren = children.Where(x => !seenLib.Contains(x)).ToList();
                roadCount += notSeenChildren.Count;
                seenLib.Add(notSeenChildren);


                for (int i = 0; i < children.Count; i++)
                {
                    DfsCities(children[i], cities, seenNodes, seenLib, ref roadCount);
                }
            //}
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }
    }
}
