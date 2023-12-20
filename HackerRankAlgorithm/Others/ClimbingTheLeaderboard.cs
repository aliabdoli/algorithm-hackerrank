namespace HackerRankAlgorithm.Others
{
    public class ClimbingTheLeaderboard
    {

        //o(nlogn)
        public int[] FindTheRank11(int[] scores, int[] alice)
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



        public int[] FindTheRank(int[] scores, int[] alice)
        {
            var scoresList = scores.OrderBy(x => x).ToList();

            var rankings = new List<int>();
            foreach (var aliceScore in alice)
            {
                var score = scoresList.BinarySearch(aliceScore);
                if (score > 0)
                {
                    rankings.Add(score);
                }
                else
                {
                    var closestScore = ~score;
                    if (closestScore == scoresList.Count)
                    {
                        rankings.Add(score);
                    }
                    else
                    {
                        rankings.Add(score);
                    }
                }

            }

            var scoresCount = scoresList.Count;

            var result = rankings.Select(x => scoresCount - x + 1).ToArray();
            return result;
        }

    }
}
