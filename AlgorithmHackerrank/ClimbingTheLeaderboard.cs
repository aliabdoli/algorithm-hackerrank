using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class ClimbingTheLeaderboard
    {

        //o(nlogn)
        public int[] FindTheRank(int[] scores, int[] alice)
        {
            var scoresUniq = scores.Distinct().OrderBy(x => x).ToList();
            var aliceScores = alice.ToList();

            var results = new List<int>();
            var max = scoresUniq.Count;
            foreach (var item in aliceScores)
            {
                var result = scoresUniq.BinarySearch(item);
                if (result < 0)
                {
                    result = ~result;
                    result = result - 1;
                }
                results.Add(result);
            }

            var normalized = results.Select(x => max-x).ToList();
            return normalized.ToArray();
        }

        //o(n2) - will time out
        public int[] FindTheRank1(int[] scores, int[] alice)
        {
            var scoresList = scores;//.ToList();
            var aliceScores = alice;//.ToList();

            var uniqueScores = scoresList
                .Distinct()
                .Select((val, ind) => new {Index = ind+1, Value = val})
                .ToList()
                ;

            var results = new List<int>();
            var max = uniqueScores.Count() + 1;
            foreach (var item in aliceScores)
            {
                var result = uniqueScores
                    .FirstOrDefault(x => item >= x.Value);
                var toAdd = result?.Index ?? max;

                results.Add(toAdd);
            }

            return results.ToArray();
        }
    }
}
