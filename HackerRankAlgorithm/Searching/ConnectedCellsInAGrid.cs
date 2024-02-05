using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Searching
{
    public class ConnectedCellsInAGrid
    {
        public int connectedCell(List<List<int>> matrix)
        {
            var components = new List<List<Node>>();
            var graph = new Graph(matrix);
            var dfs = new DfsSearcher();

            components = dfs.FindComponents(graph);

            var maxComponentSize = components.Select(x => x.Count).Max();
            return maxComponentSize;
        }
    }

    public class DfsSearcher
    {
        public List<List<Node>> FindComponents(Graph graph)
        {
            var nodes = graph.GetAllNodes();
            var seens = new List<Node>();
            var toSee = new Stack<Node>();
            var components = new List<List<Node>>();
            foreach (var node in nodes)
            {
                if (seens.Contains(node))
                {
                    continue;
                }

                var component = new List<Node>();
                toSee.Push(node);
                while (toSee.Any())
                {
                    var currentNode = toSee.Pop();
                    if (seens.Contains(currentNode))
                    {
                        continue;
                    }

                    var children = graph.GetChildren(currentNode);

                    foreach (var child in children)
                    {
                        toSee.Push(child);
                    }

                    component.Add(currentNode);
                    seens.Add(currentNode);
                }

                components.Add(component);
            }

            return components;
        }
    }

    public class Node : IEquatable<Node>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Equals(Node? other)
        {
            if (other == null) return false;
            return other.X == this.X && other.Y == this.Y;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return this.Equals(obj as Node);
        }

        public override int GetHashCode()
        {
            return  HashCode.Combine(X.GetHashCode(),Y.GetHashCode());
        }
    }

    public class Graph
    {
        private readonly List<List<int>> _boardMatrix;
        private readonly int _nodeXCount;
        private readonly List<Node> _nodes;
        private readonly int _nodeYCount;

        public Graph(List<List<int>> boardMatrix)
        {
            _boardMatrix = boardMatrix;
            _nodeXCount = boardMatrix.Count;
            _nodeYCount = boardMatrix.First().Count;
            _nodes = CreateNodes();
        }

        public List<Node> GetAllNodes() => _nodes;
        

        private List<Node> CreateNodes()
        {
            var nodes = new List<Node>();
            for (int i = 0; i < _nodeXCount; i++)
            {
                for (int j = 0; j < _nodeYCount; j++)
                {
                    nodes.Add(new Node()
                    {
                        X = i,
                        Y = j
                    });
                }
            }
            return nodes;
        }

        public List<Node> GetChildren(Node currentNode)
        {

            if (_boardMatrix[currentNode.X][currentNode.Y] == 0)
            {
                return new List<Node>();
            }

            var children = new List<Node>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 & j == 0)
                    {
                        continue;
                    }
                    var newX = currentNode.X + i;
                    var newY = currentNode.Y + j;
                    if (newX >= 0 && newX < _nodeXCount && newY >= 0 && newY < _nodeYCount)
                    {
                        if (_boardMatrix[newX][newY] == 1)
                        {
                            var newNode = new Node() { X = newX, Y = newY };
                            children.Add(newNode);
                        }
                    }
                }
            }
            return children;
        }
    }


}
