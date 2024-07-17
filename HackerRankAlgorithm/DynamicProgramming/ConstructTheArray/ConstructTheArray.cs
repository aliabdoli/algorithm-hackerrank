using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static HackerRankAlgorithm.DynamicProgramming.ConstructTheArray.ConstructTheArray;

namespace HackerRankAlgorithm.DynamicProgramming.ConstructTheArray
{
    public class ConstructTheArray
    {
        public long CountArray(int n, int k, int x)
        {
            var arrayLength = n;
            var maxValidValue = k;
            var lastItemValue = x;
            var startItemValue = 1;

            var request = new NoneDuplicateArrayRequest()
            {
                StartItem = startItemValue,
                EndItem = lastItemValue,
                Length = arrayLength
            };

            var factory = new NoneDuplicateArrayCollectionFactory();
            var calculator = new NoneDuplicateArrayCalculator<NoneDuplicateArrayCollection, List<NoneDuplicateArray>>(factory);
            var result = calculator.CalculateCountOfNoneDuplicateArray(request, maxValidValue);


            var arrays = result.Aggregate.Select(x => x.ToString()).ToList();

            if (arrays.Distinct().Count() != arrays.Count)
            {
                var ss = 0;
            }


            return result.Aggregate.Count;
        }


        ///////interfaces//////////////////////////////////////////
        public interface INoneDuplicateArrayAggregate<T>
        {
            public T Aggregate { get; set; }

            public void AddAggregate(NoneDuplicateArrayRequest request);

            public void AddNewStart(int startItem, INoneDuplicateArrayAggregate<T> aggregate);

        }

        public interface INoneDuplciateArrayAggregateFactory<V, T> where V : INoneDuplicateArrayAggregate<T>
        {
            V CreateNoneDuplicateArrayAggregate();
        }

        /// //////////////////////

        public class NoneDuplicateArrayRequest : IEquatable<NoneDuplicateArrayRequest>
        {
            public int StartItem { get; set; }
            public int Length { get; set; }
            public int EndItem { get; set; }
            public override string ToString()
            {
                return $"{Length}:{StartItem}-{EndItem}";
            }

            public bool Equals(NoneDuplicateArrayRequest? other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return StartItem == other.StartItem && Length == other.Length && EndItem == other.EndItem;
            }

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((NoneDuplicateArrayRequest)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(StartItem, Length, EndItem);
            }
        }


        public class NoneDuplicateArrayCalculator<V, T> where V : INoneDuplicateArrayAggregate<T>

        {
            private readonly INoneDuplciateArrayAggregateFactory<V, T> _aggregateFactory;

            public NoneDuplicateArrayCalculator(INoneDuplciateArrayAggregateFactory<V, T> aggregateFactory)
            {
                _aggregateFactory = aggregateFactory;
            }

            public Dictionary<NoneDuplicateArrayRequest, INoneDuplicateArrayAggregate<T>> CalculatedRequestResults
            {
                get;
                private set;
            } =
                new Dictionary<NoneDuplicateArrayRequest, INoneDuplicateArrayAggregate<T>>();

            public INoneDuplicateArrayAggregate<T> CalculateCountOfNoneDuplicateArray(NoneDuplicateArrayRequest request, int maxValidItem)
            {
                var result = _aggregateFactory.CreateNoneDuplicateArrayAggregate();

                if (request.Length == 2)
                {
                    if (request.StartItem != request.EndItem)
                    {
                        result.AddAggregate(request);
                    }

                    return result;
                }


                for (int newItem = 1; newItem <= maxValidItem; newItem++)
                {
                    if (newItem != request.StartItem)
                    {
                        var newRequest = new NoneDuplicateArrayRequest()
                        {
                            Length = request.Length - 1,
                            StartItem = newItem,
                            EndItem = request.EndItem
                        };

                        INoneDuplicateArrayAggregate<T> childArrayCounter;
                        if (CalculatedRequestResults.ContainsKey(newRequest))
                        {
                            childArrayCounter = CalculatedRequestResults[newRequest];
                        }
                        else
                        {
                            childArrayCounter = CalculateCountOfNoneDuplicateArray(newRequest, maxValidItem);
                            CalculatedRequestResults.Add(newRequest, childArrayCounter);
                        }

                        result.AddNewStart(request.StartItem, childArrayCounter);
                    }
                }

                return result;
            }
        }
    }
}
