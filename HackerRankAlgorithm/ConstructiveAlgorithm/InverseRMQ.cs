using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.ConstructiveAlgorithm
{

    
    public class InverseRMQRunner
    {
        /// <summary>
        /// for hackerrank to run as it needs stdout and args in
        /// </summary>
        /// <param name="args"></param>
        public void MainRunner(string[] args)
        {
            var input = new string[2];
            for (int i = 0; i < 2; i++)
            {
                input[i] = Console.ReadLine();
            }

            var algo = new InverseRMQ();
            var len = int.Parse(input[0]);
            var inputs = Array.ConvertAll(input[1].Trim().Split(' '), long.Parse);

            var result = algo.Create(len, inputs);
            
            Console.WriteLine(result.IsDoable);
            Console.WriteLine(string.Join(' ', result.TreeSnapshot.Select(x => x.ToString())));
        }
    }

    public class InverseRMQResult
    {
        public string IsDoable { get; set; }
        public List<long> TreeSnapshot { get; set; } = new List<long>();
    }
    public class InverseRMQ
    {
        private readonly Mapper _mapper;
        public const string Doable = "YES";
        public const string NotDoable = "NO";

        public InverseRMQ()
        {
            _mapper = new Mapper();
        }

        public InverseRMQResult Create(int len, long[] inputs)
        {
            Validate(len, inputs);
            var tree = new Tree(len);

            var mappings = _mapper.ToIndexValueDictionary(inputs);
            var mappedInputs = _mapper.MapValueToIndex(mappings, inputs);

            var frequencies = CalculateFrequencies(mappedInputs);

            while (frequencies.Any())
            {
                var currentNode = frequencies.Pop();

                var addable = tree.Add(currentNode);
                if (!addable)
                {
                    return new InverseRMQResult()
                    {
                        IsDoable = NotDoable
                    };
                }
            }

            var treeNodes = tree.GetTreeShortForm();
            var mappedList = _mapper.MapBack(treeNodes, mappings);
            return new InverseRMQResult()
            {
                IsDoable = Doable,
                TreeSnapshot = mappedList
            };

        }

        private void Validate(int len, long[] inputs)
        {
            //throw new NotImplementedException();
        }

        private Stack<FrequencyModel> CalculateFrequencies(List<long> inputs)
        {
            var freqDict = new Dictionary<long, long>();

            foreach (var input in inputs)
            {
                if (!freqDict.ContainsKey(input))
                {
                    freqDict.Add(input, 0);
                }
                freqDict[input]++;
            }

            var freqModels = freqDict.Select(x => new FrequencyModel()
            {
                Id = x.Key,
                Frequency = x.Value,
            });

            //freqModels = freqModels.OrderBy(x => x.Frequency);//.ThenByDescending(x => x.Id);

            //freqModels = freqModels.OrderBy(x => x).ToList();
            var freqModelsList = freqModels.ToList();
            freqModelsList.Sort(new FrequencyModelComparer());


            //order by first frequencies in inputs then by value
            //var freqs = inputs.GroupBy(x => x).Select(y => new FrequencyModel()
            //{
            //    Id = y.Key,
            //    Frequency = y.Count()
            //});

            //freqs = freqs.OrderBy(x => x).ToList();

            var freqStack = new Stack<FrequencyModel>(freqModelsList);

            return freqStack;

        }
    }


    public class Mapper
    {
        public Dictionary<long, long> ToIndexValueDictionary(long[] inputs)
        {
            return inputs.Distinct().
                OrderBy(x => x)
                .Select((x, ind) =>
                    new KeyValuePair<long, long>(ind+1, x)
            ).ToDictionary(x => x.Key, y => y.Value);
        }

        public List<long> MapBack(List<long> inputs, Dictionary<long, long> mappings)
        {
            return inputs.Select(x => mappings[x]).ToList();
        }

        public List<long> MapValueToIndex(Dictionary<long, long> indexValueMappings, long[] inputs)
        {
            //todo: not everytime!!!
            var mappingsBack = indexValueMappings
                .Select(x => new KeyValuePair<long,long>(x.Value, x.Key))
                .ToDictionary(x => x.Key, y => y.Value);

            return inputs.Select(x => mappingsBack[x]).ToList();

        }
    }

    class FrequencyModelComparer : IComparer<FrequencyModel> 
    {
        public int Compare(FrequencyModel x, FrequencyModel y)
        {
            //if (x == null && y == null) return 0;

            if (ReferenceEquals(x, y)) return 0;

            if (x.Id == y.Id && x.Frequency == y.Frequency) return 0;

            if (x.Frequency > y.Frequency) return 1;

            if (x.Frequency == y.Frequency)
            {
                if (x.Id < y.Id)
                    return 1;

                if (x.Id > y.Id)
                    return -1;

                if (x.Id == y.Id)
                    return 0;
            }

            return -1;
        }

    }
    
    class FrequencyModel : IComparable<FrequencyModel>, IEquatable<FrequencyModel>
    {
        public long Id { get; set; }
        public long Frequency { get; set; }

        //todo: need unite test and logic check
        public int CompareTo(FrequencyModel? other)
        {
            if (other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;

            if (Id == other.Id & Frequency == other.Frequency) return 0;

            if (Frequency > other.Frequency) return 1;

            if (Frequency == other.Frequency)
            {
                if (Id < other.Id) 
                    return 1;
                if (Id > other.Id)
                    return -1;
                if (Id == other.Id)
                    return 0;
            }

            return -1;

        }

        public bool Equals(FrequencyModel? other)
        {
            if(ReferenceEquals(this, other))
                return true;
            return (Id == other.Id & Frequency == other.Frequency);
        }

      
    }

    class Tree
    {
        private readonly int _leafCount;
        private readonly List<long> _nodeConnectivities;
        private const long _emptyNode = long.MinValue;
        private readonly int _startIndxOfLeaves;
        
        //todo: wrong
        private int _lastPowerTwo = 1;
        private int _lastUsedIndex;

        public Tree(int leafCount)
        {
            _leafCount = leafCount;
            _nodeConnectivities = Enumerable.Range(0, 2 * leafCount - 1).Select(x => _emptyNode).ToList();
            _startIndxOfLeaves = leafCount - 1;
            _lastUsedIndex = _startIndxOfLeaves;

        }

        public bool Add(FrequencyModel currentNode)
        {
            if (currentNode.Frequency == 1)
            {
                return AddToFirstNoneEmptyLeave(currentNode);
            }
            // find biggest available chunk when devide by two from the most left on tree
            // based on frequency populate all parents as much as nodes are empty
            // if frequency is bigger or smaller then return false

            //todo: clean up
            var lastpowerTwo = this._lastPowerTwo;
            var nodeIndex = this._lastUsedIndex;
            (nodeIndex, _lastPowerTwo) = FindCurrentBiggestUnusedBinaryChunkIndexOnLeaves(lastpowerTwo, this._lastUsedIndex);
            this._lastUsedIndex = nodeIndex;



            var currentFreq = currentNode.Frequency;
            var currentNodeIndex = nodeIndex;
            var currentNodeValue = currentNode.Id;

            //while (currentFreq > 0)
            //{
            //_nodeConnectivities[currentNodeIndex] = currentNodeValue;
            var pathNodes = GetNoneEmptyPathIndexToRoot(currentNodeIndex);

            if (pathNodes.Count() != currentFreq)
            {
                return false;
            }

            foreach (var pathNode in pathNodes)
            {
                _nodeConnectivities[pathNode] = currentNodeValue;
            }
            //}

            return true;
        }

        private bool AddToFirstNoneEmptyLeave(FrequencyModel currentNode)
        {
            if (_nodeConnectivities.Count == 1)
            {
                _nodeConnectivities[0] = currentNode.Id;
                return true;
            }
            for (int i = 0; i < _leafCount; i++)
            {
                if (_nodeConnectivities[_leafCount + i] == _emptyNode)
                {
                    _nodeConnectivities[_leafCount + i] = currentNode.Id;
                    return true;
                }
            }

            return false;
        }

        private List<int> GetNoneEmptyPathIndexToRoot(int currentNodeIndex)
        {
            var path = new List<int>() {currentNodeIndex};
            var nodeIndex = currentNodeIndex;
            while (nodeIndex != 0)
            {
                var kir = (double)(nodeIndex / 2);
                nodeIndex = (int)Math.Floor(kir);

                if (_nodeConnectivities[nodeIndex] == _emptyNode)
                {
                    path.Add(nodeIndex);
                }
            } 

            return path;
        }


        //todo: bad Complexity
        private (int,int) FindCurrentBiggestUnusedBinaryChunkIndexOnLeaves(int lastPowerTwo, int lastUsedIndex)
        {
            var leaves = _nodeConnectivities.TakeLast(_leafCount).ToList();
            var leavesCount = _leafCount;
            var lastUsedIndexLeave = lastUsedIndex - _startIndxOfLeaves;

            var foundIndex = FindIndexOfFirstNoneEmpty(lastPowerTwo, lastUsedIndexLeave, leavesCount, leaves);

            if (foundIndex == null)
            {
                lastPowerTwo++;
                foundIndex = FindIndexOfFirstNoneEmpty(lastPowerTwo, lastUsedIndexLeave, leavesCount, leaves);
            }

            if (foundIndex == null)
            {
                throw new Exception("Count Found Index");
            }
            return (foundIndex.Value, lastPowerTwo);

        }

        private int? FindIndexOfFirstNoneEmpty(int lastPowerTwo, int lastNoneEmptyIndex, int leavesCount, List<long> leaves)
        {
            int? foundInd = null;
            var size = Math.Pow(2, lastPowerTwo);
            var step = (int)Math.Floor(leavesCount / size);

            for (int j = lastNoneEmptyIndex; j < leavesCount; j = j + step)
            {
                if (leaves[j] == _emptyNode)
                {
                    foundInd = j + _startIndxOfLeaves;
                    return foundInd;
                }
            }

            return foundInd;
        }

        public List<long> GetTreeShortForm()
        {
            // just print the string of all array of the whole tree
            return _nodeConnectivities;
        }
    }
}
