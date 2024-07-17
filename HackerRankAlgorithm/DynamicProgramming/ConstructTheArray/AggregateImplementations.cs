using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackerRankAlgorithm.DynamicProgramming.ConstructTheArray.ConstructTheArray;

namespace HackerRankAlgorithm.DynamicProgramming.ConstructTheArray
{
    ///////counters//////////////////////////////////////////

    class 
    public class NoneDuplicateArrayCounter : INoneDuplicateArrayAggregate<long>
    {
        public long Aggregate { get; set; }
        public void AddAggregate(NoneDuplicateArrayRequest request)
        {
            throw new NotImplementedException();
        }

        public void AddNewStart(int startItem, INoneDuplicateArrayAggregate<long> aggregate)
        {
            throw new NotImplementedException();
        }
    }

    public class NoneDuplicateArrayCounterFactory : INoneDuplciateArrayAggregateFactory<NoneDuplicateArrayCounter, long>
    {
        public NoneDuplicateArrayCounter CreateNoneDuplicateArrayAggregate()
        {
            throw new NotImplementedException();
        }
    }
    ///////path//////////////////////////////////////////

    public class NoneDuplicateArray
    {
        public List<int> Items { get; set; }
        public override string ToString()
        {
            return string.Join("-", Items);
        }
    }
    public class NoneDuplicateArrayCollection : INoneDuplicateArrayAggregate<List<NoneDuplicateArray>>
    {
        public List<NoneDuplicateArray> Aggregate { get; set; } = new List<NoneDuplicateArray>();
        public void AddAggregate(NoneDuplicateArrayRequest request)
        {
            Aggregate.Add(new NoneDuplicateArray()
            {
                Items = new List<int>() { request.EndItem, request.StartItem }
            });
        }

        public void AddNewStart(int startItem, INoneDuplicateArrayAggregate<List<NoneDuplicateArray>> aggregate)
        {
            var newCopy = aggregate.Aggregate.Select(x =>
                new NoneDuplicateArray()
                {
                    Items = x.Items.Select(i => i).ToList()
                }).ToList();

            foreach (var noneDuplicateArray in newCopy)
            {
                noneDuplicateArray.Items.Add(startItem);
            }

            Aggregate.AddRange(newCopy);
        }
    }

    public class NoneDuplicateArrayCollectionFactory : INoneDuplciateArrayAggregateFactory<NoneDuplicateArrayCollection, List<NoneDuplicateArray>>
    {
        public NoneDuplicateArrayCollection CreateNoneDuplicateArrayAggregate()
        {
            return new NoneDuplicateArrayCollection();
        }
    }
}
