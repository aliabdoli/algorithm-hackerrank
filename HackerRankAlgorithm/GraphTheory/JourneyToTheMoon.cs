using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.GraphTheory
{
    public static class JourneyToTheMoon
    {
        public static long journeyToMoon(int austroNum, List<List<int>> stupidAustras)
        {
            var moreThanOnes = new List<int>();
            var ones = 0;

            var austras = stupidAustras.Select(x => new []
            {
                new {src = x[0], dest = x[1]},
                new {src = x[1], dest = x[0]}
            })
                .SelectMany(x => x)
                .GroupBy(x => x.src, y => y.dest)
                .ToDictionary(x => x.Key, y => y.Select(z => z).ToList());

            var seens = new HashSet<int>();
            for (int i = 0; i < austroNum; i++)
            {
                var beforeRunCountryCount = seens.Count;

                Dfs(i, austras, seens);
                var justSeenCountryCount = seens.Count - beforeRunCountryCount;
                if (justSeenCountryCount > 1)
                    moreThanOnes.Add(justSeenCountryCount);
                if(justSeenCountryCount == 1)
                    ones++;
            }



            int moreThanOnesResult = 0;
            for (int i = 0; i < moreThanOnes.Count; i++)
            {
                for (int j = i+1; j < moreThanOnes.Count; j++)
                {
                    moreThanOnesResult += moreThanOnes[i] * moreThanOnes[j];
                }
            }

            //try
            //{
            //    checked
            //    {
                    long oneResult = ((long)ones * (long)(ones - 1)) / 2;


                    long mixResult = 0;
                    for (int i = 0; i < moreThanOnes.Count; i++)
                    {
                        mixResult += moreThanOnes[i] * ones;
                    }
                    var result = moreThanOnesResult + oneResult + mixResult;
                    return result;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            //return -1;
        }

        private static void Dfs(int current, Dictionary<int, List<int>> astras, HashSet<int> seens)
        {
            if(!seens.Add(current))
                return;

            List<int> children;
            if(!astras.TryGetValue(current, out children))
                return;

            foreach (var child in children)
            {
                Dfs(child, astras, seens);
            }
        }
    }
}
