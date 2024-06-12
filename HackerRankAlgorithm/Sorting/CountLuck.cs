using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Sorting
{
    public class CountLuck
    {
        private const string Impressed = "Impressed";
        private const string Oops = "Oops!";
        public string countLuck(List<string> matrix, int k)
        {
            var graph = new WonderGraph(matrix);
            var finalNode = graph.PortkeyNode;
            var startNode = graph.StartNode;



            var visitedNodes = new HashSet<WonderGraphNode>();
            var toVisitNodes = new Stack<WonderGraphNode>();
            var parentPathMappings = new Dictionary<WonderGraphNode, WonderGraphNode>();

            
            toVisitNodes.Push(startNode);
            
            while (toVisitNodes.Any())
            {
                var currentNode = toVisitNodes.Pop();
                visitedNodes.Add(currentNode);

                if (currentNode.Equals(finalNode))
                {
                    break;
                }

                var children = graph.GetChildren(currentNode);
                
                foreach (var child in children)
                {
                    if (!visitedNodes.Any(x => x.Equals(child)))
                    {
                        parentPathMappings.Add(child, currentNode);
                        toVisitNodes.Push(child);
                    }
                }
            }

            // create path and if wand
            var wandCheckCounter = CalculateNumberOfWands(finalNode, startNode, parentPathMappings, graph, visitedNodes);


            return wandCheckCounter == k ? Impressed : Oops;

        }

        private static int CalculateNumberOfWands(WonderGraphNode finalNode, WonderGraphNode startNode, Dictionary<WonderGraphNode, WonderGraphNode> parentPath,
            WonderGraph graph, HashSet<WonderGraphNode> visitedNodes)
        {
            var wandCheckCounter = 0;

            var cNode = finalNode;
            while (!cNode.Equals(startNode))
            {
                var parent = parentPath[cNode];
                var parentChildren = graph.GetChildren(parent);
                if (graph.CheckIfNeedsWand(parentChildren, cNode, parent, startNode))
                {
                    wandCheckCounter++;
                }

              

                cNode = parent;
            }

            //var startNodeChildren = graph.GetChildren(startNode);
            //if (startNodeChildren.Count >= 2)
            //{
            //    wandCheckCounter++;
            //}


            return wandCheckCounter;
        }
    }


    public class WonderGraph
    {
        private readonly List<string> _nodesString;
        private const char PortkeyChar = '*';
        private readonly char StartChar = 'M';
        private readonly char TreeChar = 'X';
        private readonly char FreeChar = '.';

        public WonderGraph(List<string> nodesString)
        {
            _nodesString = nodesString;
            PortkeyNode = FindNode(nodesString, PortkeyChar);
            StartNode = FindNode(nodesString, StartChar);
        }

        

        public WonderGraphNode PortkeyNode { get; }

        public WonderGraphNode StartNode { get; }

        public bool CheckIfNeedsWand(List<WonderGraphNode> children, 
            WonderGraphNode child, 
            WonderGraphNode parent, 
            WonderGraphNode startNode)
        {
            if (startNode.Equals(parent))
            {
                if (children.Count > 1)
                {
                    return true;
                }
            }
            var noneParentChilds = children.Where(c => !child.Equals(c)).ToList();
            //todo: too much complexity
            //var noneVisited = children.Where(x => !visited.Contains(x)).ToList();
            return noneParentChilds.Count >= 2;
        }

        public List<WonderGraphNode> GetChildren(WonderGraphNode node)
        {
            var children = new List<WonderGraphNode>();
            //right
            var rightChild = new WonderGraphNode() { X = node.X + 1, Y = node.Y };
            children = ValidateAndAdd(rightChild, children);

            //left
            var leftChild = new WonderGraphNode() { X = node.X - 1, Y = node.Y };
            children = ValidateAndAdd(leftChild, children);

            //up 
            var upChild = new WonderGraphNode() { X = node.X, Y = node.Y + 1 };
            children = ValidateAndAdd(upChild, children);

            //down 
            var downChild = new WonderGraphNode() { X = node.X, Y = node.Y - 1 };
            children = ValidateAndAdd(downChild, children);

            return children;


        }

        private List<WonderGraphNode> ValidateAndAdd(WonderGraphNode rightChild, List<WonderGraphNode> children)
        {
            if (ValidateNode(rightChild))
            {
                children.Add(rightChild);
            }

            return children;
        }

        private bool ValidateNode(WonderGraphNode node)
        {
            if (node.X >= _nodesString.Count | node.Y >= _nodesString[0].Length)
            {
                return false;
            }

            if (node.X < 0 | node.Y < 0)
            {
                return false;
            }

            if (_nodesString[node.X][node.Y] == TreeChar)
            {
                return false;
            }

            return true;
        }

        private static WonderGraphNode FindNode(List<string> nodesString, char toFind)
        {
            WonderGraphNode result = null;

            var yDimensionCount = nodesString[0].Count();
            for (int i = 0; i < nodesString.Count; i++)
            {
                for (int j = 0; j < yDimensionCount; j++)
                {
                    if (nodesString[i][j] == toFind)
                    {
                        result = new WonderGraphNode()
                        {
                            X = i,
                            Y = j,
                        };

                    }
                }
            }

            return result;
        }
    }

    public class WonderGraphNode : IEquatable<WonderGraphNode>
    {
        public int X  { get; set; }
        public int Y { get; set; }
        public bool Equals(WonderGraphNode? other)
        {
            if (other == null) return false;
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object? obj)
        {
            var node = obj as WonderGraphNode;
            if (node == null) return false;
            return node.X == X && node.Y == Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"{X}-{Y}";
        }
    }
}
