using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.GraphTheory
{
    public static class RoadsAndLibraries1
    {
        /// <summary>
        /// for each clique
        /// 1- find all shortest paths
        /// 2- foreach node, check which has the lowest cost
        /// 3- update total cost and cost of each node given selected N
        /// 4- pop the highest cost node, see it worth a library
        /// </summary>
        /// <param name="cityCount"></param>
        /// <param name="libCost"></param>
        /// <param name="roadCost"></param>
        /// <param name="stupidCities"></param>
        /// <returns></returns>

        public static long roadsAndLibraries1(int cityCount, int libCost, int roadCost, List<List<int>> cities)
        {
            var graph = new Graph(cities, cityCount, roadCost);
            var componentFinder = new GraphComponentFinder();
            var components = componentFinder.GetComponents(graph);

            var shortestPathFinder = new ShortestPathFinder();
            var bestCityPlans = new List<CityPlanModel>();
            foreach (var componentNodes in components)
            {
                //todo: if only one city, better drop out



                var shortestPaths = shortestPathFinder.CalculateAllShortestPaths(graph, componentNodes);
                var bestCityPlan = new CityPlanModel();
                foreach (var componentNode in componentNodes)
                {
                    
                    var suggestedCityPlan = CalculateCityPlan(new List<int>(){componentNode}, 
                        shortestPaths, 
                        libCost, 
                        roadCost);

                    if (suggestedCityPlan.TotalCost < bestCityPlan.TotalCost)
                    {
                        bestCityPlan = suggestedCityPlan;
                    }
                }

                var mostExpensiveCities = bestCityPlan.
                    NodeCosts.
                    OrderBy(x => x.Value).
                    ToList();

                var shouldBuildAnotherLibrary = true;
                
                while (shouldBuildAnotherLibrary)
                {
                    var i = 0;
                    var city = mostExpensiveCities[i];
                    var libraries = bestCityPlan.LibraryNodes;
                    libraries.Add(city.Key);
                    var suggestionPlan = CalculateCityPlan(libraries, shortestPaths, libCost, roadCost);
                    if (suggestionPlan.TotalCost < bestCityPlan.TotalCost)
                    {
                        bestCityPlan = suggestionPlan;
                    }
                    else
                    {
                        shouldBuildAnotherLibrary = false;
                    }

                }

                bestCityPlans.Add(bestCityPlan);

            }

            var bestCost = bestCityPlans.Select(x => x.TotalCost).Sum();


            return bestCost;
        }

        private static CityPlanModel CalculateCityPlan(List<int> libraryNodes, Dictionary<EdgeModel, int> shortestPaths, int libCost, int roadCost)
        {
            throw new NotImplementedException();
        }
    }

    public class CityPlanModel
    {
        public List<int> LibraryNodes { get; set; } = new List<int>();
        public long TotalCost { get; } = long.MaxValue;

        public Dictionary<int, long> NodeCosts { get; set; } = new Dictionary<int, long>();
    }

    public class EdgeModel : IEquatable<EdgeModel>
    {
        public int SourceNode { get; }
        public int DestNode { get; }

        public EdgeModel(int sourceNode, int destNode)
        {
            SourceNode = sourceNode;
            DestNode = destNode;
        }

        public bool Equals(EdgeModel? other)
        {
            if (other == null) return false;
            return other.SourceNode == SourceNode && other.DestNode == DestNode;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as EdgeModel;
            if (other == null) return false;
            return other.SourceNode == SourceNode && other.DestNode == DestNode;
        }

        public override int GetHashCode()
        {
            return SourceNode.GetHashCode() + DestNode.GetHashCode();
        }
    }

    public class ShortestPathFinder
    {
        public Dictionary<EdgeModel, int> CalculateAllShortestPaths(Graph graph, List<int> componentItems)
        {
            var subgraph = graph.CreateSubGraph(componentItems);
            var allShortPaths = new Dictionary<EdgeModel, int>();
            foreach (var componentItem in componentItems)
            {
                var shortPaths = CalculateShortestPath(componentItem, subgraph);
                foreach (var shortPath in shortPaths)
                {
                    allShortPaths.Add(shortPath.Key, shortPath.Value);
                }
            }
            return allShortPaths;
        }

        private Dictionary<EdgeModel, int> CalculateShortestPath(int sourceNode, Graph graph)
        {
            var distanceNodeMatrix = new SortedDictionary<int, int>();
            foreach (var node in graph.Nodes)
            {
                if (node == sourceNode)
                {
                    distanceNodeMatrix.Add(0, node);
                }
                else
                {
                    distanceNodeMatrix.Add(int.MaxValue, node);
                }
            }

            var seens = new HashSet<int>();

            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                //var node = distanceNodeMatrix.First() 
                //todo: bad performance
                var node = distanceNodeMatrix.FirstOrDefault(x => !seens.Contains(x.Value));

            }

            while (seens.Count < graph.Nodes.Count)
            {
                
                while (node != null)
                {
                    
                }
            }



        }
    }

    public class GraphComponentFinder
    {

        public List<List<int>> GetComponents(Graph graph)
        {

            var components = new List<List<int>>();

            var seens = new HashSet<int>();


            var allNodes = graph.Nodes.ToHashSet();
            
            //todo: problem with performance
            var toSee = new Stack<int>();


            foreach (var currentNode in allNodes)
            {

                if (seens.Contains(currentNode))
                {
                    continue;
                }

                var component = new List<int>();
                
                toSee.Push(currentNode);

                while (toSee.Any())
                {
                    var node = toSee.Pop();
                    if (seens.Contains(node))
                    {
                        continue;
                    }

                    var children = graph.GetChildren(node);
                    foreach (var child in children)
                    {
                        toSee.Push(child);
                    }
                    component.Add(currentNode);
                }

                components.Add(component);
            }

            return components;
        }
    }

    public class Graph
    {
        private readonly int _nodeCount;
        private readonly int _edgeWeight;
        private readonly Dictionary<int, List<int>> _nodeEdgeMatrix;
        private readonly List<int> _nodes;

        public Graph(List<List<int>> nodeEdges, int nodeCount, int edgeWeight)
        {
            _nodeCount = nodeCount;
            _edgeWeight = edgeWeight;
            var edges = nodeEdges.Select(x => new List<int>() { x[1], x[0] }).ToList();
            edges.AddRange(nodeEdges);

            _nodeEdgeMatrix = edges.GroupBy(x => x[0], y => y[1])
                .ToDictionary(x => x.Key, x => x.ToList());


            _nodes = Enumerable.Range(0, nodeCount).ToList();
        }

        public List<int> Nodes => _nodes;

        public List<int> GetChildren(int node)
        {
            return _nodeEdgeMatrix[node];
        }

        public Graph CreateSubGraph(List<int> componentItems)
        {
            throw new NotImplementedException();
        }
    }
}
            