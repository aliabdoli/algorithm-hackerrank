namespace HackerRankAlgorithm.Others
{
    public class NonDivisibleSubset
    {
        public int Run(int k, List<int> s)
        {
            var divisor = k;
            var mods = s.Select(x => x % divisor).ToList();
            mods.Sort();
            var modCounts = mods.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            var maxSubsetCount = 0;
            if (modCounts.ContainsKey(0))
            {
                maxSubsetCount++;
            }

            var midInd = (divisor - 1) / 2;
            for (int i = 1; i <= midInd ; i++)
            {

                var hasLeft = modCounts.TryGetValue(i, out var leftCount);
                var hasRight = modCounts.TryGetValue(divisor - i, out var rightCount);

                if (hasLeft & hasRight)
                {
                    maxSubsetCount += Math.Max(leftCount, rightCount);
                }
                else if (hasLeft)
                {
                    maxSubsetCount += leftCount;
                } else if (hasRight)
                {
                    maxSubsetCount += rightCount;
                }
            }

            //handle middle for odds divisors
            if (divisor % 2 == 0)
            {
                if (modCounts.ContainsKey(midInd))
                {
                    maxSubsetCount++;
                }
            }

            return maxSubsetCount;

        }
    }
}
