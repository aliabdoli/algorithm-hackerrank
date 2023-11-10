using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/compare-the-triplets/problem
    /// </summary>
    public class CompareTheTriplets
    {

        class PointSummary
        {
            public int FirstCompetitorScore { get; set; } = 0;
            public int SecondCompetitorScore { get; set; } = 0;
        }

        
        public List<int> Solve(List<int> a, List<int> b)
        {
            Validate(a, b);

            var pointSummary = new PointSummary();

            var firstPoints = a;
            var secondPoints = b;
            var matchCount = a.Count;

            for (int i = 0; i < matchCount; i++)
            {
                if (firstPoints[i] > secondPoints[i])
                {
                    pointSummary.FirstCompetitorScore += 1;
                }
                else if (firstPoints[i] < secondPoints[i])
                {
                    pointSummary.SecondCompetitorScore += 1;
                }
            }

            var result = MapToResult(pointSummary);
            return result;
        }

        private static List<int> MapToResult(PointSummary pointSummary)
        {
            var result = new List<int>()
            {
                pointSummary.FirstCompetitorScore, pointSummary.SecondCompetitorScore
            };
            return result;
        }

        private static void Validate(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
            {
                throw new ArgumentException("length must be the same");
            }

            if (a.Any(x => x > 100 | x < 1))
            {
                throw new ArgumentException("A inputs must be betweeen 1 and 100");
            }

            if (b.Any(x => x > 100 | x < 1))
            {
                throw new ArgumentException("B inputs must be betweeen 1 and 100");
            }
        }
    }
}
