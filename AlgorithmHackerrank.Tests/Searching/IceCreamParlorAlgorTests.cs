using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmHackerrank.Searching;
using FluentAssertions;
using Xunit;


namespace AlgorithmHackerrank.Tests.Searching
{
    
    public class IceCreamParlorAlgorTests
    {
        [Theory]
        [InlineData("1 4 5 3 2", new int[] { 1, 4 }, 4)]
        [InlineData("2 2 4 3", new int[] { 1, 2 }, 4)]
        [InlineData("1 3 4 6 7 9", new int[] { 2, 4 }, 9)]
        [InlineData("1 3 4 4 6 8", new int[] { 3, 4 }, 8)]
        [InlineData("1 2", new int[] { 1, 2 }, 3)]

        [InlineData("5 75 25" , new int[] { 2, 3 }, 100)]
        [InlineData("150 24 79 50 88 345 3", new int[] { 1, 4 }, 200)]
        [InlineData("2 1 9 4 4 56 90 3", new int[] { 4, 5 }, 8)]
        [InlineData("230 863 916 585 981 404 316 785 88 12 70 435 384 778 887 755 740 337 86 92 325 422 815 650 920 125 277 336 221 847 168 23 677 61 400 136 874 363 394 199 863 997 794 587 124 321 212 957 764 173 314 422 927 783 930 282 306 506 44 926 691 568 68 730 933 737 531 180 414 751 28 546 60 371 493 370 527 387 43 541 13 457 328 227 652 365 430 803 59 858 538 427 583 368 375 173 809 896 370 789", new int[] { 29, 46 }, 542)]
        [InlineData("591 955 829 805 312 83 764 841 12 744 104 773 627 306 731 539 349 811 662 341 465 300 491 423 569 405 508 802 500 747 689 506 129 325 918 606 918 370 623 905 321 670 879 607 140 543 997 530 356 446 444 184 787 199 614 685 778 929 819 612 737 344 471 645 726", new int[] { 11, 56 }, 789)]
        [InlineData("722 600 905 54 47", new int[] { 4, 5 }, 101)]
        public void WhenMoneyAndCost_ThenFindIndex(string arrString, int[] expected, int m)
        {
            //arrange
            var arr = Array.ConvertAll(arrString.Split(' '), int.Parse);
            var algo = new IceCreamParlorAlgorithm();

            //act
            var result = algo.Solve(m, arr.ToList());

            //assert
            result.Should().BeEquivalentTo(expected.ToList());
        }
        
    }
}
