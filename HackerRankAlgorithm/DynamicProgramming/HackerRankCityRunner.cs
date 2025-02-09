using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.DynamicProgramming
{
    public class HackerRankCityRunner
    {
        public static int hackerrankCity(List<int> A)
        {
            throw new NotImplementedException();
        }
    }
    
    public class HackerRankCityAlgorithm
    {
        public int ModuloResult => 1000000007;
        public int CalculateSumOfAllDistance(List<int> stepEdgeWeights)
        {
            //todo: expanding list for more capacity bad complexity
            var cornerDistances = new List<int>();
            var distanceWithinChunkAtLastStep = 0;

            var distanceSum = 0;
            for (int currentStep = 0; currentStep < stepEdgeWeights.Count; currentStep++)
            {
                var currentStepDistanceSum = 0;
                var stepEdgeWeight = stepEdgeWeights[currentStep];
                var verticesCount = GetVerticeCount(currentStep);

                var distanceToOneOfNewVertex = CalculateDistanceToOneOfNewVertex(cornerDistances, stepEdgeWeight);
                var distanceToCornerSum = CalculateDistanceToCornerSum(cornerDistances, stepEdgeWeight);
                
                var distancesWithinChunks = 4 * distanceWithinChunkAtLastStep;
                var distanceToNoneCornerSum = CalculateDistanceToNoneCornerSum(stepEdgeWeight, currentStepDistanceSum);


                //todo: not so sure counting everything
                currentStepDistanceSum =   distancesWithinChunks 
                                         + distanceToNoneCornerSum 
                                         + distanceToCornerSum
                                         + 2 * distanceToOneOfNewVertex;

                //todo: udpate corner distance and others for the next step
                // ????

                distanceSum += currentStepDistanceSum;

            }

            var result = distanceSum % ModuloResult;
            return result;
        }

        private int CalculateDistanceToNoneCornerSum(int stepEdgeWeight, int currentStepDistanceSum)
        {
            throw new NotImplementedException();
        }

        private int CalculateDistanceToOneOfNewVertex(List<int> cornerDistances, int stepEdgeWeight)
        {
            throw new NotImplementedException();
        }

        private int CalculateDistanceToCornerSum(List<int> cornerDistances, int stepEdgeWeight)
        {
            throw new NotImplementedException();
        }

        private int GetVerticeCount(int currentStep)
        {
            throw new NotImplementedException();
        }
    }
}
