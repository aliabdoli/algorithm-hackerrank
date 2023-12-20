﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using FluentAssertions;
using Xunit;

namespace AlgorithmHackerrank.Tests.Searching
{
   public class GenaPlayingHanoiTests
    {
        //        [InlineData(@"3
        //1 4 1", @"3")]
        //        [InlineData(@"4
        //2 1 3 2", @"7")]
        [Theory]
        [InlineData(@"10
4 1 2 1 4 3 3 4 3 4", "40")]
        public void MainFlow(string inputString, string expectedString)
        {
            
            var input = new StringReader(inputString);
            int N = Convert.ToInt32(input.ReadLine());

            int[] a = Array.ConvertAll(input.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            var result = GenaPlayingHanoi.Do(a);
            Console.WriteLine(result);
            int.Parse(expectedString).Should().Be(result);
        }
        [Theory]
        [InlineData("1", 0b_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000)]
        [InlineData("1,2", 0b_1000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000)]
        [InlineData("1,4,1", 0b_1010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000)]

        public void CreateBarsTest1(string inputString, ulong expected)
        {
            var input = inputString.Split(',').Select(x => int.Parse(x)).ToArray();
            var result = GenaPlayingHanoi.CreateBars(input);
            var ss = Convert.ToString((long)result, 2);
            expected.Should().Be(result);
        }

        [Theory]
        [InlineData(1, 
            5,
            2, 
            0b_1000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
            0b_1000_0100_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            )]
        public void CreateBarsTest(int srcBar, int disk, int destBar, ulong input, ulong expected)
        {
            var result = GenaPlayingHanoi.MoveDisk(srcBar, disk, destBar, input);
            var ss = Convert.ToString((long)result, 2);
            expected.Should().Be(result);
        }
        [Theory]
        [InlineData(3, 0b_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, false)]
        [InlineData(1, 0b_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000ul, false)]
        public void ShouldMove_NoDisks_Tests(int srcBar, ulong input, bool expected)
        {
            var result = GenaPlayingHanoi.ShouldMove(srcBar,-1, input);
            expected.Should().Be(result);
        }

        [Theory]
        [InlineData(1, 0b_1000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 2, true)]
        [InlineData(1, 0b_0000_0000_0001_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 2, false)]
        [InlineData(1, 0b_0000_0000_0001_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 2, false)]
        public void ShouldMove_Tests(int srcBar, ulong input, int destBar, bool expected)
        {
            var result = GenaPlayingHanoi.ShouldMove(srcBar,destBar , input);
            expected.Should().Be(result);
        }

        [InlineData(0b_1110_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 3, true)]
        [InlineData(0b_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 3, false)]
        [InlineData(0b_1111_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000ul, 4, true)]
        public void IfAnswer_Test(ulong input, int diskNumber, bool expected)
        {
            GenaPlayingHanoi._diskNumber = diskNumber;
            var result = GenaPlayingHanoi.IfAnswer(input);
            expected.Should().Be(result);
        }
    }
}
