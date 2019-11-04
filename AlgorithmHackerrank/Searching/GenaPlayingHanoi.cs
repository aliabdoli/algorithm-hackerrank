using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace AlgorithmHackerrank.Searching
{
    public class GenaPlayingHanoi
    {
        public static int _diskNumber;
        private static ulong _answerBar;
        private const int BarNumber = 4;
        private const int BarWindowLength = 16; //max number of N also
        public static int Do(int[] input)
        {
            var bars = CreateBars(input);
            
            _diskNumber = input.Length;

            var answerInput = Enumerable.Range(0, _diskNumber).Select(x => 1).ToArray();
             _answerBar = CreateBars(answerInput);

            var path = FindSortedRodCountBfs(_diskNumber, bars);

            return path;
        }

        public class Node
        {
            public ulong Value { get; set; }
            public int Depth { get; set; }
        }

        public static int FindSortedRodCountBfs(int diskSize, ulong root)
        {
            var seen = new HashSet<ulong>();
            var toSeeQueue = new Queue<Node>();
            var resultDepth = -1;

            toSeeQueue.Enqueue(new Node()
            {
                Value = root,
                Depth = 0
            });

            while (toSeeQueue.Any())
            {
                var barsNode = toSeeQueue.Dequeue();
                var bars = barsNode.Value;

                //already seen
                var ifAlreadySeen = !seen.Add(bars);
                if (ifAlreadySeen)
                {
                    continue;
                }

                //ifAnswer
                if (IfAnswer(bars))
                {
                    resultDepth = barsNode.Depth;
                    break;
                }


                //adding children
                for (var i = 1; i <= BarNumber; i++)
                {
                    for (var j = 1; j <= BarNumber; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        if (ShouldMove(i, j, bars))
                        {
                            var newBars = Move(i, j, bars);

                            toSeeQueue.Enqueue(new Node(){Value = newBars , Depth = barsNode.Depth + 1}); 
                        }
                    }
                }
            }

            return resultDepth;
        }

        public static ulong Move(int srcBar, int destBar, ulong bars)
        {
            var srcBarValue = GetValueOfBar(srcBar, bars);
            var minSrc =BarWindowLength - (int)Math.Log(srcBarValue, 2);

            var newBars = MoveDisk(srcBar, minSrc, destBar, bars);
            return newBars;
        }

        public static ulong CreateBars(int[] input)
        {
            var bars = 0ul;
            // 1 2 3 4 4 4 3 3
            for (int i = 0; i < input.Length; i++)
            {
                var shift = GetShift(input[i], i+1);
                var newPosition = 1ul << shift;

                bars = bars | newPosition;
            }

            return bars;
        }


        public static bool IfAnswer(ulong bars)
        {
            //var dd = FormatBar(bars);
              
            return bars == _answerBar;
        }

        public static bool ShouldMove(int srcBar, int destBar, ulong bars)
        {
            //bars[i].Any()
            //    &&
            //    (bars[i].Min < bars[j].Min
            //     ||
            //     !bars[j].Any()


            //check source have disk
            var srcBarValue = GetValueOfBar(srcBar, bars);
            if (srcBarValue > 0)
            {
                //check dest have disk
                var destBarValue = GetValueOfBar(destBar, bars);
                if (destBarValue == 0)
                    return true;

                //check if min of src < min of dest
                if (srcBarValue > destBarValue)
                    return true;
                return false;
            }

            return false;

        }

        private static ulong GetValueOfBar(int srcBar, ulong bars)
        {
            ulong srcBarValue;
            var init = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111ul;
            var srcShift = BarWindowLength * (BarNumber - srcBar);
            var srcBarMask = init << srcShift;
            srcBarValue = bars & srcBarMask;
            srcBarValue = srcBarValue >> srcShift;
            return srcBarValue;
        }

        public static ulong MoveDisk(int srcBar, int disk, int destBar, ulong bars)
        {
            //adding to dest
            var shift = GetShift(destBar, disk);
            var newPosition = 1ul << shift;
            bars = bars | newPosition;

            //removing from src
            var shift1 = GetShift(srcBar, disk);
            var newPosition1 = 1ul << shift1;
            bars = bars & ~newPosition1;
            return bars;
        }

        public static int GetShift(int bar, int disk)
        {
            return (BarNumber - bar + 1 - 1) * BarWindowLength + (BarWindowLength - disk);
        }
    }


    //public static string FormatBar(ulong input)
    //{
    //return String.Format("{0,64}", Convert.ToString((long)input, 2)).Replace(' ', '0');

    //}

    //public static string FormatToDict(ulong input)
    //{
    //var formatted = FormatBar(input).ToList();

    ////var dbdd = formatted.Take(BarWindowLength).ToList().Select((val, ind) => new { val, ind }).Where(x => x.val == '1').ToList()
    ////    ;
    //var result = "";
    //var bar1 = String.Join(",", formatted.Take(BarWindowLength).Select((val, ind) => new { val, ind = ind + 1 }).Where(x => x.val == '1').Select(x => x.ind).ToList());
    //var bar2 = String.Join(",", formatted.Skip(1 * BarWindowLength).Select((val, ind) => new { val, ind = ind + 1 }).Take(BarWindowLength).Where(x => x.val == '1').Select(x => x.ind).ToList());
    //var bar3 = String.Join(",", formatted.Skip(2 * BarWindowLength).Select((val, ind) => new { val, ind = ind + 1 }).Take(BarWindowLength).Where(x => x.val == '1').Select(x => x.ind).ToList());
    //var bar4 = String.Join(",", formatted.Skip(3 * BarWindowLength).Select((val, ind) => new { val, ind = ind + 1 }).Take(BarWindowLength).Where(x => x.val == '1').Select(x => x.ind).ToList());

    //result += "$1$" + bar1 + "/";
    //result += "$2$" + bar2 + "/";
    //result += "$3$" + bar3 + "/";
    //result += "$4$" + bar4 + "/";

    //return result;
    //}
}