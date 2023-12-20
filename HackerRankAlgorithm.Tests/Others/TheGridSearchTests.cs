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
        [Fact]
        public void WhenThen()
        {
            var input = "";
            var reader = new StreamReader(input, true);
            var algorithm = new TheGridSearch();


            int t = Convert.ToInt32(reader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] RC = reader.ReadLine().Split(' ');

                int R = Convert.ToInt32(RC[0]);

                int C = Convert.ToInt32(RC[1]);

                string[] G = new string[R];

                for (int i = 0; i < R; i++)
                {
                    string GItem = reader.ReadLine();
                    G[i] = GItem;
                }

                string[] rc = reader.ReadLine().Split(' ');

                int r = Convert.ToInt32(rc[0]);

                int c = Convert.ToInt32(rc[1]);

                string[] P = new string[r];

                for (int i = 0; i < r; i++)
                {
                    string PItem = reader.ReadLine();
                    P[i] = PItem;
                }

                string result = algorithm.Do(G, P);

                "".Should().Be(result);
            }

        }
    }
}
