using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Sorting
{
    public class CountLuck
    {
        public string countLuck(string[] matrix, int k)
        {
            var data = matrix.Select(x => x.Select(y => y).ToArray()).ToArray();
            var points = data.Select((x, r) => x.Select((y, c) => new {r, c, val = y})).SelectMany(z => z);

            var startPoint = points.Single(x => x.val == 'M');



            var result = DFS(data, startPoint.r, startPoint.c, new Help(), new List<string>());

            return result.helpCount == k ? "Impressed" : "Oops!";
        }


        public static Help DFS(char[][] data, int rind, int cind, Help help, List<string> pathToRoot)
        {
            var block = 'X';
            var path = '.';
            var target = '*';
            var start = 'M';
            var pathKey = $"{rind}-{cind}";
            //var visited = 'V';


            if (rind < 0 || rind >= data.Length || cind < 0 || cind >= data[rind].Length
                 || pathToRoot.Any(x => x == pathKey)
                 || data[rind][cind] == block
                )
            {
                return new Help()
                {
                    helpCount = help.helpCount,
                    HasTarget = false
                };
            }

            
            if (data[rind][cind] == target)
            {
                return new Help()
                {
                    helpCount = help.helpCount,
                    HasTarget = true
                };
            }

            if (data[rind][cind] == path || data[rind][cind] == start)
            {
                pathToRoot.Add(pathKey);
            }

            var down = DFS(data, rind - 1, cind, help, pathToRoot);
            var up = DFS(data, rind + 1, cind, help, pathToRoot);
            var left = DFS(data, rind, cind - 1, help, pathToRoot);
            var right = DFS(data, rind, cind + 1, help, pathToRoot);

            var childs = new List<char>();
            var indicators = new List<char>(){path,target};
            if (rind - 1 >= 0 && indicators.Any(x =>x == data[rind - 1][cind]) && !pathToRoot.Contains($"{rind - 1}-{cind}") )
            {
                childs.Add(data[rind - 1][cind]);
            }

            if (cind - 1 >= 0 && indicators.Any(x => x == data[rind][cind - 1]) && !pathToRoot.Contains($"{rind}-{cind -1}"))
            {
                childs.Add(data[rind][cind - 1]);
            }

            if (rind + 1 < data.Length && indicators.Any(x => x == data[rind + 1][cind]) && !pathToRoot.Contains($"{rind + 1}-{cind}"))
            {
                childs.Add(data[rind + 1][cind]);
            }

            if (cind + 1 < data[rind].Length && indicators.Any(x => x == data[rind][cind + 1]) && !pathToRoot.Contains($"{rind}-{cind + 1}"))
            {
                childs.Add(data[rind][cind + 1]);
            }

            var currentHelpCount = 0;
            //if (data[rind][cind] == start)
                currentHelpCount = childs.Count() >= 2 ? 1 : 0;
            //else
                //currentHelpCount = childs.Count() >= 3 ? 1 : 0;

            var helps = new List<Help>()
            {
                down, up, left, right
            };
            var targetChild = helps.SingleOrDefault(x => x.HasTarget);

            var resultHelp = new Help()
            {
                HasTarget = targetChild?.HasTarget ?? false,
                helpCount = (targetChild?.helpCount ?? 0) + currentHelpCount
            };
            pathToRoot.Remove(pathKey);

            //help = down + up + left + right + currentHelp;
            return resultHelp;
        }

        public class Help
        {
            public bool HasTarget { get; set; }
            public int helpCount { get; set; }

            public static Help operator +(Help a, Help b)
            {

                return new Help()
                {
                    helpCount = a.helpCount + b.helpCount,
                    HasTarget = a.HasTarget || b.HasTarget
                };
            } 
        }
    }
}
