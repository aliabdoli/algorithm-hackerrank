using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Others;
using Xunit;


namespace HackerRankAlgorithm.Tests
{

    public class TheGridSearchTests
    {
        [Theory]
        [InlineData(@"1234567890  
                        0987654321  
                        1111111111  
                        1111111111  
                        2222222222",
            @"876543  
111111  
111111",
            "YES")]
        [InlineData(@"7283455864
                        6731158619
                        8988242643
                        3830589324
                        2229505813
                        5633845374
                        6473530293
                        7053106601
                        0834282956
                        4607924137",
                    @"9505
                        3845
                        3530",
            "YES")]
        [InlineData(@"400453592126560
                        114213133098692
                        474386082879648
                        522356951189169
                        887109450487496
                        252802633388782
                        502771484966748
                        075975207693780
                        511799789562806
                        404007454272504
                        549043809916080
                        962410809534811
                        445893523733475
                        768705303214174
                        650629270887160",
            @"99
                99",
            "NO")]

        [InlineData(@"123412
                        561212
                        123634
                        781288",
                    @"12
                        34",
            "YES")]

        [InlineData(@"999999
                        121211",
                @"99
                    11",
            "YES")]

        [InlineData(@"123456
                    567890
                    234567
                    194729",
                @"2345
                    6789
                    3456
                    9472",
            "YES")]


        public void WhenThen(string g, string p, string expected)
        {
            //arrange
            var input = "";
            var algorithm = new TheGridSearch();
            var grid = g.Split("\n").Select(x => x.Trim()).ToList();
            var pattern = p.Split("\n").Select(x => x.Trim()).ToList();

            //act
            var result = algorithm.Do(grid, pattern);

            //assert
            result.Should().Be(expected);

        }
    }
}

