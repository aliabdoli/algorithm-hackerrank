using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class TheGridSearch
    {
        /// <summary>
        /// Not solved
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public string Do(string[] g, string[] p)
        {
            //var grid = g;
            //var pattern = p;

            //var tGrid = Trans(grid);
            //var tPattern = Trans(pattern);

            //var match = false;

            //for (int gr = 0; gr < grid.Length; gr++)
            //{
            //    match = false;
            //    int gc = 0;
            //    while ((gc = grid[gr].IndexOf(pattern[0], gc, StringComparison.Ordinal)) != -1
            //           &&
            //           gc + pattern[0].Length < grid[gr].Length
            //           )
            //    {
            //        match = true;
            //        for (int k = 0; k < pattern[0].Length ; k++)
            //        {
            //            if (gc + k <  
            //            tGrid[gc + k].IndexOf(tPattern[k], gr, StringComparison.Ordinal) == -1
            //                )
            //            {
            //                match = false;
            //                break;
            //            }
            //        }

            //        if (match)
            //        {
            //            break;
            //        }
            //        gc++;
            //    }

                //if (match )
                //{
                //    break;
                //}


            //}
            return null;

        }

        private const string Yes = "YES";
        private const string No = "NO";

        private static string[] Trans(string[] grid)
        {
            var gridCrv = grid.Select((rv, r) => new {crv = rv.ToCharArray().Select((v, c) => new {r, c, v})})
                .SelectMany(x => x.crv);
            var tGrid = gridCrv.GroupBy(x => x.c).Select(y => string.Concat(y.Select(z => z.v))).ToArray();
            return tGrid;
        }
    }
}
