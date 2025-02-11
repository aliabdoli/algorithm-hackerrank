using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.GraphTheory;
using FluentAssertions;
using Xunit;

namespace HackerRankAlgorithm.Tests.GraphTheory
{
    public class CliqueTests
    {
        [Theory]
        [InlineData(3, 2, 2)]
        [InlineData(4, 6, 4)]
        [InlineData(5, 7, 3)]
        [InlineData(15, 144, 16)]
        public void WhenThen(int vertices, int edges, int expectedClique)
        {
            //arrange
            var algo = new Clique();

            //act
            var min = algo.FindMinSizeOfLargestClique(vertices, edges);

            //assert
            min.Should().Be(expectedClique);
        }

        [Theory]
        [InlineData(3, 3, 2)]
        [InlineData(3, 2, 0)]
        [InlineData(4, 3, 4)]
        [InlineData(4, 4, 5)]
        [InlineData(4, 3, 4)]
        public void Test_max_allowed_edges_to_not_have_clique(int vertices, int clique, int expected)
        {
            //arrange
            var algo = new Clique();

            //act
            var max = algo.CalculateTurinUpperBound(vertices, clique);

            //assert
            max.Should().Be(expected);
        }

        //[Theory]
        //[InlineData(3, 3, 3, true)]
        //[InlineData(4, 4, 3, false)]
        //[InlineData(19, 166, 14, true)]

        //public void Test_if_clique_possible(int vertices, int edges, int clique, bool expected)
        //{
        //    //arrange
        //    var algo = new Clique();

        //    //act
        //    var possible = algo.CheckIfCliquePossible(vertices, clique, edges);

        //    //assert
        //    possible.Should().Be(expected);
        //}

        //[Theory]
        //[InlineData(2,3,3)]
        //[InlineData(15,144,18)]
        //public void Test_complete_graph_by_edges(int vertices, int edges, int expected)
        //{
        //    //arrange
        //    var algo = new Clique();

        //    //act
        //    var possible = algo.GetCompleteGraphVerticesByEdges(vertices, edges);

        //    //assert
        //    possible.Should().Be(expected);
        //}
    }
}
