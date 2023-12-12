using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Strings
{
    public class BearAndSteadyGene
    {
        public int FindSmallestSubsequenceToReplace(string geneSequence)
        {

            //find frequency
            var geneSequenceLength = geneSequence.Length;

            var genesFrequencies = ConvertToGeneFrequency(geneSequence);

            //find the extra appearance
            var excessiveGeneFrequencies = genesFrequencies.OrderByDescending(x => x.Frequency).
                Where(x => x.Frequency> 0);
            
             
            // find sequence that has all extra appearances
            var excessiveGeneFreqTotal = excessiveGeneFrequencies.Select(x => x.Frequency).Sum();
            var excessiveGenesFrequenciesDic = excessiveGeneFrequencies.ToDictionary(x => x.Gene, y => y.Frequency);

            //var leftInd = 0;
            var rightInd = excessiveGeneFreqTotal;

            var slidingWindow = new GeneSlidingWindow(geneSequence, rightInd);
            

            var shortestSubgeneLen = int.MaxValue;

            while (slidingWindow.CanMove())
            {
                
                // check if equal
                var isSubset = slidingWindow.CheckIfSubset(excessiveGenesFrequenciesDic);

                if (isSubset)
                {
                    while (isSubset)
                    {
                        var newShortestSubgeneLen = slidingWindow.RightInd - slidingWindow.LeftInd + 1;
                        shortestSubgeneLen = newShortestSubgeneLen < shortestSubgeneLen ? newShortestSubgeneLen : shortestSubgeneLen;


                        slidingWindow.MoveLeftBoundary();
                        

                        isSubset = slidingWindow.CheckIfSubset(excessiveGenesFrequenciesDic);
                    }
                    
                    slidingWindow.MoveRightBoundary();
                  
                }
                else
                {
                    
                    if (!excessiveGenesFrequenciesDic.TryGetValue(geneSequence[slidingWindow.LeftInd], out int _))
                    {
                       slidingWindow.MoveLeftBoundary();
                    }
                    
                    slidingWindow.MoveRightBoundary();
                }
            }


                

            var result = shortestSubgeneLen == int.MaxValue ? 0 : shortestSubgeneLen;
            return result;
        }

        private static IEnumerable<GeneFrequency> ConvertToGeneFrequency(string geneSequence)
        {
            var geneSequenceLength = geneSequence.Length;
            var genesFrequencies = geneSequence.ToCharArray().ToList().GroupBy(x => x, y => y, (keys, nums) =>
                new GeneFrequency()
                {
                    Gene = nums.FirstOrDefault(),
                    Frequency = nums.Count() - (geneSequenceLength / 4)
                });
            return genesFrequencies;
        }

        

        public class GeneFrequency
        {
            public Char Gene { get; set; }
            public int Frequency { get; set; } = 0;
        }


       
        
    }
}


