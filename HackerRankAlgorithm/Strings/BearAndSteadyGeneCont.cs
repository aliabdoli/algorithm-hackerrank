using System.Collections.Generic;
using System.Linq;

namespace HackerRankAlgorithm.Strings
{
    public class GeneSlidingWindow
    {
        public List<char> AllowedGenes => new List<char>() { 'A', 'C', 'G', 'T' };
        public int LeftInd { get; private set; }
        public int RightInd { get; private set; }
        
        private readonly string _geneSequence;
        private readonly Dictionary<char, int> _geneFrequencyDic;
        private int GeneSequenceLength => _geneSequence.Length;

        //Todo: bloated constructor, needs to be injected or factory
        public GeneSlidingWindow(string geneSequence, int rightInd)
        {
            var geneFrequencies = new List<BearAndSteadyGene.GeneFrequency>();
            foreach (var gene in AllowedGenes)
            {
                geneFrequencies.Add(new BearAndSteadyGene.GeneFrequency()
                {
                    Gene = gene,
                    Frequency = 0
                });
            }
            

            _geneFrequencyDic = geneFrequencies.ToDictionary(x => x.Gene, y => y.Frequency);

            RightInd = rightInd;
            LeftInd = 0;

            _geneSequence = geneSequence;

            var slidingWindow = geneSequence.Skip(LeftInd).Take(rightInd - LeftInd + 1);

            foreach (var item in slidingWindow)
            {
                _geneFrequencyDic[item]++;
            }
        }


        public bool CheckIfSubset(Dictionary<char, int> superSet)
        {
            var isSubset = true;

            foreach (var setElement in superSet)
            {
                if (_geneFrequencyDic[setElement.Key] < setElement.Value)
                {
                    isSubset = false;
                    break;
                }
            }

            return isSubset;
        }


        public void MoveLeftBoundary()
        {
            _geneFrequencyDic[_geneSequence[LeftInd]]--;
            LeftInd++;
        }

        public void MoveRightBoundary()
        {
            RightInd++;
            _geneFrequencyDic[_geneSequence[RightInd]]++;
        }

        public bool CanMove()
        {
            return LeftInd < RightInd & RightInd < GeneSequenceLength - 1;
        }
    }
}