using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Implementation
{
    public static class AbsolutePermutation
    {
        private static int _dist;
        private static int _len;
        private static HashSet<int> _noResult = new HashSet<int>(new []{-1});
        public static int[] absolutePermutation(int len, int dist)
        {
            var donotExist = new[] { -1 };
            var result = new int[len];

            _len = len;
            _dist = dist;
            bool ifAnswer = false;
            var res = FindDfs(1, 1 + dist, new HashSet<int>(), ref ifAnswer);

            return res.ToArray();
        }

        private static HashSet<int> FindDfs(int position, int value, HashSet<int> path, ref bool ifAnswer)
        {
            if (value < 1 || value > _len)
            {
                ifAnswer = false;
                return _noResult;
            }

            if (!path.Add(value))
            {
                ifAnswer = false;
                return _noResult;
            }

            if (position == _len)
            {
                ifAnswer = true;
                return path;
            }

            var newPosition = position + 1;
            
            var child1 = newPosition - _dist;
            var child2 = _dist + newPosition;
            var result = FindDfs(newPosition, child1, path, ref ifAnswer);
            
            if (ifAnswer)
            {
                return result;
            }

            result = FindDfs(newPosition, child2, path, ref ifAnswer);

            return result;

        }
        
    }
}
