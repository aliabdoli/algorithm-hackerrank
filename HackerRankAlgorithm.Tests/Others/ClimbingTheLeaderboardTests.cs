﻿using FluentAssertions;
using HackerRankAlgorithm.Others;

namespace HackerRankAlgorithm.Tests.Others
{
    public class ClimbingTheLeaderboardTests
    {
        [Fact]
        public void WhenThenSimple()
        {
            var algorithm = new ClimbingTheLeaderboard();
            var scores = new List<int>() { 100, 90, 90, 80};
            var alice = new List<int>() { 70, 80, 105 };

            var result = algorithm.FindTheRank(scores, alice);
            result[0].Should().Be(4);
            result[1].Should().Be(3);
            result[2].Should().Be(1);
            
        }

        [Fact]
        public void WhenThen()
        {
            var algorithm = new ClimbingTheLeaderboard();
            var scores = new List<int>() {100, 100, 50, 40, 40, 20, 10};
            var alice = new List<int>() { 5, 10, 25, 50, 120, 100 };
            
            var result = algorithm.FindTheRank(scores, alice);
            result[0].Should().Be(6);
            result[1].Should().Be( 5);
            result[2].Should().Be( 4);
            result[3].Should().Be( 2);
            result[4].Should().Be( 1);
            result[5].Should().Be( 1);
        }

        [Fact]

        public void WhenThen2()
        {
            var algorithm = new ClimbingTheLeaderboard();
            var scores = new List<int>() { 100, 100, 50, 40, 40, 20, 10 };
            var alice = new List<int>() { 5, 25, 50, 120};

            var result = algorithm.FindTheRank(scores, alice);
            result[0].Should().Be(6);
            result[1].Should().Be(4);
            result[2].Should().Be(2);
            result[3].Should().Be(1);
        }
    }
}
