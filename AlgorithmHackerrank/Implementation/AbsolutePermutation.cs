using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AlgorithmHackerrank.Utilities;


namespace AlgorithmHackerrank.Implementation
{
    public static class AbsolutePermutation
    {
        public static List<int> FindAbsolutePermutation(int len, int dist)
        {
            var root = new TreeNode(len, dist+1, dist, 1);
            //path.Add(root);
            var rootWithMemory = new TreeNodeWithPathMemory(root);

            var traverser = new TreeTraverser();

            var exist = traverser.NLR(rootWithMemory);

            if (traverser.Answer != null)
            {
                return traverser.Path.OrderBy(x => x.Depth).Select(x => x.Data).ToList();
            }
            else
            {
                return new List<int>() { -1 };
            }
        }
    }

    public class TreeNode : IComparable<TreeNode>, IEquatable<TreeNode>
    {
        public readonly int Len;
        public readonly int Dist;

        public TreeNode(int len, int data, int dist, int depth)
        {
            Len = len;
            Dist = dist;
            Data = data;
            Depth = depth;
        }

        public int Depth { get; set; }
        public int Data { get; }
        public TreeNode LeftChild => Depth + 1 - Dist > 0 ? new TreeNode(len:Len, Depth + 1 - Dist , Dist, Depth+1) : null;
        public TreeNode RightChild => Depth + 1 +  Dist <= Len ? new TreeNode(Len, Depth + 1 + Dist, Dist, Depth + 1) : null;

        public int CompareTo(TreeNode other)
        {
            return this.Data.CompareTo(other.Data);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TreeNode);
        }

        public bool Equals(TreeNode other)
        {
            return other != null && Data == other.Data;
        }

        public override int GetHashCode()
        {
            return Data;
        }
    }

    public class TreeNodeWithPathMemory
    {
        public TreeNodeWithPathMemory(TreeNode node)
        {
            TreeNode = node;
        }

        public TreeNode TreeNode { get; }
        
    }

    public class TreeTraverser
    {
        public UniqueStack<TreeNode> Path { get; } = new UniqueStack<TreeNode>();

        //public string PathData => String.Join("-", Path.OrderBy(x => x.Depth).Select(x => x.Data.ToString()));

        public TreeNodeWithPathMemory Answer { get; set; } 

        public bool IsLeaf(TreeNodeWithPathMemory node)
        {
            return node.TreeNode.Depth == node.TreeNode.Len;
        }
        public bool NLR(TreeNodeWithPathMemory node)
        {
            if (node.TreeNode == null) return false;

            if (!Path.Push(node.TreeNode))
            {
                return false;
            }
            

            if (IsLeaf(node))
            {
                //o(1)
                if (Path.Count == node.TreeNode.Len)
                    Answer = node;
                return true;
            }
            
            var isAnswer = NLR(new TreeNodeWithPathMemory(node.TreeNode.LeftChild));
            
            if (isAnswer)
            {
                return true;
            }

            //todo: disgraceful
            if (!Path.Peek().Equals(node.TreeNode))
            {
                var _ = Path.Pop();
            }
            isAnswer = NLR(new TreeNodeWithPathMemory(node.TreeNode.RightChild));
            if (isAnswer)
            {
                return true;
            }

            if (!Path.Peek().Equals(node.TreeNode))
            {
                var _ = Path.Pop();
            }
            return false;
        }
        
    }
}
