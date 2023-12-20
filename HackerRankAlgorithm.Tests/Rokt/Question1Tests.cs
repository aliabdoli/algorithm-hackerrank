using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerRankAlgorithm.Rokt;
using Xunit;

namespace HackerRankAlgorithm.Tests.Rokt
{
    public class Question1Tests
    {
        [Fact]
        public void MainTest()
        {
            var inputString = @"6
]}{]](]}{))}
{}()[()]
()
([]({}{})){}()
[){}(]}]}]))](())(
({{)";
            //            //var algor = new /*Question1*/();
            //            var input = new StreamReader(inputString);
            //            int roktxCount = Convert.ToInt32(input.ReadLine().Trim());
            int roktxCount = 2;

            //List<string> roktx = new List<string>() { "[]{}()", "[{]}" };
            List<string> roktx = new List<string>()
            {
                "({{)"};

            //for (int i = 0; i < roktxCount; i++)
            //{
            //    string roktxItem = input.ReadLine();
            //    roktx.Add(roktxItem);
            //}

            List<string> res = Question1.correctness(roktx);
            

        }
    }
}
