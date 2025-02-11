using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.GraphTheory
{
    public class Clique
    {
        public int FindMinSizeOfLargestClique(int vertices, int edges)
        {

            Validate(vertices, edges);

            var rightClique = vertices;
            var leftClique = 1;

            //todo: not sure till when
            while (leftClique >= 1 || rightClique <= vertices)
            {

                var leftEdgeForClique = CalculateTurinUpperBound(vertices, leftClique);
                var rightEdgeForClique = CalculateTurinUpperBound(vertices, rightClique);

                //todo: bad
                if (leftClique + 1 == rightClique)
                {
                    if (rightEdgeForClique >= edges)
                    {
                        return leftClique;
                    }
                    else
                    {
                        return rightClique;
                    }
                }


                if (leftEdgeForClique >= edges)
                {
                    return leftClique;
                }

                if (rightEdgeForClique < edges)
                {
                    return rightClique;
                }

                var middleClique = (leftClique + rightClique) / 2;
                var middleEdgeForClique = CalculateTurinUpperBound(vertices, middleClique);

                //todo: edge cases
                if (edges > middleEdgeForClique)
                {
                    leftClique = middleClique;
                }
                else
                {
                    rightClique = middleClique;
                }
            }

            throw new Exception("could not find");
        }

        private void Validate(int vertices, int edges)
        {
            if (edges > (vertices * (vertices - 1)) / 2)
            {
                throw new ArgumentException("too many edges");
            }
        }


        // https://mathworld.wolfram.com/TuransTheorem.html 
        public int CalculateTurinUpperBound(int vertices, int cliqueSize)
        {
            var turinCliqueSize = cliqueSize - 1;
            if (turinCliqueSize <= 0)
            {
                return 1;
            }
            var resultUp = Math.Pow(vertices, 2) * (turinCliqueSize - 1);

            var resultDown = 2 * turinCliqueSize;

            return (int)Math.Floor(resultUp / resultDown);
        }
    }
}
