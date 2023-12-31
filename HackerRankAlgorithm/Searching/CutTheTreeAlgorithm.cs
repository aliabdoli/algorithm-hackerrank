using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public static class CutTheTreeAlgorithm
    {
        public static int CutTheTree(List<int> data, List<List<int>> edges)
        {
            var tree = new Tree(data, edges);

            var traverser = new LRNTraverser(tree);

            var root = tree.GetRoot();

            traverser.Traverse(root);


            var rootSum = tree.GetRoot().Data;
            var minCutDiff = int.MaxValue;
            foreach (var nodeEdge in tree.Edges)
            {
                foreach (var destNode in nodeEdge.Value)
                {
                    var childSum = destNode.Data;
                    
                    var cutOne = rootSum - childSum;
                    var cutTwo = childSum;
                    var cutDifference = Math.Abs(cutTwo - cutOne);

                    minCutDiff = minCutDiff < cutDifference ? minCutDiff : cutDifference;
                }
            }

            return minCutDiff;
        }
    }


    public class TreeNode
    {
        public int Id { get; set; }
        public int Data { get; set; }

    }

    public class Tree
    {
        public Dictionary<int, TreeNode> NodeData { get; set; }
        public Dictionary<int, List<TreeNode>> Edges { get; set; }

        //todo: bloated ctor, need a mapper
        public Tree(List<int> nodeData,List<List<int>> edges)
        {

            NodeData = nodeData.Select((x, ind) => new TreeNode()
            {
                Id = ind,
                Data = x,
            }).ToDictionary(x => x.Id, y => y);

            var reverseEdges = edges.Select(x => new List<int>()
            {
                x[1], x[0]
            }).ToList();

            edges.AddRange(reverseEdges);


            Edges = edges
                .GroupBy(x => x[0] - 1, y => y[1] - 1)
                .ToDictionary(x => x.Key,
                    y => 
                        y.ToList().Select(
                            z => NodeData[z]).ToList());
        }

        

        public List<TreeNode> GetChildren(int nodeId) => Edges.ContainsKey(nodeId) ? Edges[nodeId] : new List<TreeNode>();

        public TreeNode GetNode(int nodeId) => NodeData[nodeId];

        public TreeNode GetRoot() => NodeData[0];

        public TreeNode SetNodeData(int nodeId, int data)
        {
            NodeData[nodeId].Data = data;
            return NodeData[nodeId];
        }
    }

    public class LRNTraverser
    {
        private readonly Tree _tree;

        private HashSet<int> _visitedNode = new HashSet<int>();

        public LRNTraverser(Tree tree)
        {
            _tree = tree;
        }

        public int Traverse(TreeNode currentNode)
        {
            _visitedNode.Add(currentNode.Id);

            var children = _tree.GetChildren(currentNode.Id);

            if (!children.Any())
            {
                return currentNode.Data;
            }

            var sum = 0;
            foreach (var child in children)
            {
                if (_visitedNode.Contains(child.Id))
                {
                    continue;
                }
                var childSum = Traverse(child); 
                sum += childSum;
            }

            sum += currentNode.Data;

            _tree.SetNodeData(currentNode.Id, sum);

            return sum;

        }
    }

}
