using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankAlgorithm.Sorting
{
    // start 5:49 6:05
    public class TheFullCountingSort
    {
        public string countSort(List<List<string>> arr)
        {
            var buckets = CreateBuckets(arr);
            var sortedIndex = SortIndex(buckets);
        
            var sortedBuckets = SortBucketsByIndex(buckets, sortedIndex);
            var dashedBuckets = ReplaceHalfWithDash(sortedBuckets, arr);

            var bucketString = ConvertBucketToString(dashedBuckets);
            
            return bucketString;

            
            

        }

        private static Dictionary<int, List<string>> ReplaceHalfWithDash(Dictionary<int, List<string>> buckets, List<List<string>> originalItems)
        {

            //todo: if odd
            var halfLen = originalItems.Count / 2-1;
            var counter = 0;
            var dashedStringFreqs = new Dictionary<string, int>();
            foreach (var originalItem in originalItems)
            {
                if (counter <= halfLen)
                {
                    var toDashStr = $"{originalItem[0]}-{originalItem[1]}";
                    if (dashedStringFreqs.TryGetValue(toDashStr, out var freq))
                    {
                        dashedStringFreqs[toDashStr]++;
                    }
                    else
                    {
                        dashedStringFreqs.Add(toDashStr, 1);
                    }
                    
                    counter++;
                }
                else
                {
                    break;
                }
            }

            var dashedBuckets = new Dictionary<int, List<string>>();
            foreach (var bucket in buckets)
            {
                
                var vals = new List<string>();
                foreach (var str in bucket.Value)
                {
                    var freqIndex = $"{bucket.Key}-{str}";
                    var toAddStr = str;
                    if (dashedStringFreqs.TryGetValue(freqIndex, out var freq))
                    {
                        if (freq > 0)
                        {
                            toAddStr = "-";
                            dashedStringFreqs[freqIndex]--;
                        }
                    }
                    vals.Add(toAddStr);
                }
                dashedBuckets.Add(bucket.Key, vals);

            }

            return dashedBuckets;


            
        }

        private static string ConvertBucketToString(Dictionary<int, List<string>> sortedBuckets)
        {
            var strBuilder = new StringBuilder();
            foreach (var sortedBucket in sortedBuckets)
            {
                foreach (var str in sortedBucket.Value)
                {
                    strBuilder.Append(str);
                    strBuilder.Append(" ");
                }
            }
            return strBuilder.ToString().Trim();
        }

        private static Dictionary<int, List<string>> SortBucketsByIndex(Dictionary<int, List<string>> buckets, List<int> indices)
        {
            var sortedBucket = new Dictionary<int, List<string>>();
            foreach (var index in indices)
            {
                sortedBucket.Add(index, buckets[index]);
            }
            return sortedBucket;
        }

        private static List<int> SortIndex(Dictionary<int, List<string>> buckets)
        {
            var indexes = buckets.Keys.Select(x => x).ToList();
            indexes.Sort();
            return indexes;
        }

        private static Dictionary<int, List<string>> CreateBuckets(List<List<string>> items)
        {
            var result = items.Select(x => new { Ind = int.Parse(x[0]), Val = x[1] }).GroupBy(x => x.Ind, y => y.Val)
                .ToDictionary(x => x.Key, y => y.ToList());
            return result;
        }
    }
}
