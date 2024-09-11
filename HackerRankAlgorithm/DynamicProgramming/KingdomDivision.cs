using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/kingdom-division/problem?isFullScreen=true
    /// </summary>
    public class KingdomDivision
    {
        public static int kingdomDivision(int n, List<List<int>> roads)
        {
            var tree = new Tree(n, roads);

            var children = tree.GetLeaves();

            



            return -1;
        }

        private static List<HashSet<int>> CreateSets(List<int> leaves)
        {
            return leaves.Select(x => new HashSet<int>(x)).ToList();
        }
    }

    public class Tree
    {
        public Tree(int nodeCount, List<List<int>> edges)
        {
            
        }

        public List<int> GetLeaves()
        {
            throw new NotImplementedException();
        }

        public List<KeyValuePair<int,int>> GetParents(List<int> leaves)
        {
            throw new NotImplementedException();
        }
    }
}
