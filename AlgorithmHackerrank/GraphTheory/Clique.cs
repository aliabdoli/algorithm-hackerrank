using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.GraphTheory
{
    public class Clique
    {
        public int FindMinSizeOfMaxClique(int vertices, int edges)
        {
            var maxClique = 0;


            for (int clique = 2; clique <= vertices; clique++)
            {
                var possible = CheckIfCliquePossible(vertices, clique, edges);
                if (possible)
                {
                    maxClique = clique;
                }
            }

            var completeVertices = GetCompleteGraphVerticesByEdges(vertices, edges);

            for (int v = vertices; v <= completeVertices; v++)
            {
                var possible = CheckIfCliquePossible(v, v, edges);
                if (possible)
                {
                    maxClique = v;
                }
            }

            return maxClique;
        }

        public int GetCompleteGraphVerticesByEdges(int vertices, int edges)
        {
            var kEdges = GetCompleteGraphEdges(vertices);
            var kVertices = vertices;

            while (kEdges < edges)
            {
                kVertices++;
                kEdges = GetCompleteGraphEdges(kVertices);
            }

            return kVertices;
        }

        private static int GetCompleteGraphEdges(int vertices)
        {
            return (vertices * (vertices - 1)) / 2;
        }

        public int GetMaxEdgeToNotHaveClique(int vertices, int rClique)
        {
            if (rClique < 2)
            {
                throw new ArgumentException($"clique: {rClique} needs to be >= 2");
            }

            if (rClique > vertices)
            {
                throw new ArgumentException($"rClique: {rClique}, vertices: {vertices}, rClique needs to be smaller or equals than vertices");
            }

            //https://www.maa.org/sites/default/files/Staton-AMM-1999.pdf
            var edges = ((rClique - 2) * vertices * vertices) / (2 * (rClique - 1));

            return edges;
        }

        public bool CheckIfCliquePossible(int vertices, int rClique, int edges)
        {
            var maxEdge = GetMaxEdgeToNotHaveClique(vertices, rClique);
            return edges > maxEdge;
        }
    }


}
