using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HackerRankAlgorithm.Recursion
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/k-factorization/problem?isFullScreen=true
    /// - original worked, this one times out
    /// </summary>
    public static class kFactorization
    {
        public static List<int> Do(int n, List<int> A)
        {

            var multipliers = new SortedSet<int>(A);

            var target = n;


            var fromTargetToOnePathInit = new MultiplierInfo()
            {
                Target = target,
                Multipliers = new List<int>()
                {
                    target
                }
            };


            var descendingMultipliers = multipliers.Reverse().ToList();
            var shortestMultiplierLenInfo = FindSmallestByLength(descendingMultipliers,
                1,
                fromTargetToOnePathInit
                );


            if (shortestMultiplierLenInfo.Target == -1)
            {
                return PrepareResult(shortestMultiplierLenInfo);
            }


            //shortestMultiplierLenInfo = shortestMultiplierLenInfo.

            var maxMultiplierLen = shortestMultiplierLenInfo.MultipliersCount - 1;
            var fromOneToTargetPathInit = new MultiplierInfo()
            {
                Target = 1,
                Multipliers = new List<int>()
                {
                    1
                }
            };
            var shortestMultiplierInfo = FindSmallestByLexicographical(multipliers.ToList(), 
                target, 
                fromOneToTargetPathInit,
                maxMultiplierLen);

            
            var result = PrepareResult(shortestMultiplierInfo);

            return result;
        }

        private static MultiplierInfo FindSmallestByLength(List<int> multipliers, 
            int target, 
            MultiplierInfo startingMultiplier)
        {
            // check results
            if (startingMultiplier.Target == target)
            {
                return startingMultiplier;
            }



            if (startingMultiplier.Target < target)
            {
                return MultiplierInfo.CreateNoAnswer();
            }

            // process nodes
            foreach (var multiplier in multipliers)
            {
                //tochange
                if (startingMultiplier.Target % multiplier != 0)
                {
                    continue;
                }

                

                //todo: not sure needed
                if (startingMultiplier.Multipliers.Any() && startingMultiplier.Multipliers.Min() < multiplier)
                {
                    continue;
                }

                var toAddMultiplier = new List<int>(startingMultiplier.Multipliers);
                toAddMultiplier.Add(multiplier);

                
                //tochange
                var nextMultipliers = new MultiplierInfo()
                {
                    Target = startingMultiplier.Target / multiplier,
                    Multipliers = toAddMultiplier
                };

                if (nextMultipliers.Target == target)
                {
                    return nextMultipliers;
                }

                var addedMultplier = FindSmallestByLength(multipliers, target, nextMultipliers);

                if (addedMultplier.Target == target)
                {
                    return addedMultplier;
                }
                
            }

            return MultiplierInfo.CreateNoAnswer();

        }

        private static List<int> PrepareResult(MultiplierInfo multiplierInfo)
        {
            var result = new List<int>();
            foreach (var shortestMultiplier in multiplierInfo.Multipliers)
            {
                var last = result.LastOrDefault() == 0 ? 1 : result.Last();  
                result.Add(last * shortestMultiplier);
            }

            return result;
        }

        private static MultiplierInfo FindSmallestByLexicographical(
            List<int> multipliers,
            int target,
            MultiplierInfo previousMultiplierInfo,
            int maxLen
        )
        {

            var current = previousMultiplierInfo;

            //process


            if (current.Multipliers.Count > maxLen)
            {
                return MultiplierInfo.CreateNoAnswer();
            }

            if (current.Target == target)
            {
                return current;
            }

            if (current.Target > target)
            {
                return MultiplierInfo.CreateNoAnswer();
            }


            //queue children
            foreach (var multiplier in multipliers)
            {
                //bad performance copying things
                var childMultiplier = current.Multipliers.Select(x => x).ToList();


                childMultiplier.Add(multiplier);
                var child = new MultiplierInfo()
                {
                    Target = current.Target * multiplier,
                    Multipliers = childMultiplier
                };

                if (child.Target == target)
                {
                    return child;
                }

                var addedMultplier = FindSmallestByLexicographical(multipliers, target, child, maxLen);

                if (addedMultplier.Target == target)
                {
                    return addedMultplier;
                }
            }


            return MultiplierInfo.CreateNoAnswer();
        }


        class MultiplierInfo
        {
            public int Target { get; set; }
            public List<int> Multipliers { get; set; }

            public int MultipliersCount => Multipliers.Count;

            public static MultiplierInfo CreateNoAnswer()
            {
                return new MultiplierInfo()
                {
                    Target = -1,
                    Multipliers = new List<int>() {-1}
                };
            }
        }
    }
}
