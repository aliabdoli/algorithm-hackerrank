using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.ConstructiveAlgorithm
{
    public class InverseRMQ
    {

        public void Main(string[] args)
        {
            var input = new string[2];
            for (int i = 0; i < 2; i++)
            {
                input[i] = Console.ReadLine();
            }
            var result = Create(input);
        }
        public static string[] Create(string[] args)
        {

            var len = int.Parse(args[0]);
            var input = Array.ConvertAll(args[1].Trim().Split(' '), long.Parse );

            var unique = new HashSet<long>(input);
            if (unique.Count < len)
            {
                Console.WriteLine("NO");
                return new [] {"NO"};
            }

            for (int i = input.Length-1; i > 0; i--)
            {
                var parentInd =Math.Max((int)Math.Ceiling((decimal) i / 2) - 1, 0);

                var otherChildInd = (i % 2 == 0) ? i - 1 : i + 1;

                CheckBoundry(input.Length, parentInd, "ParentId");
                var parent = input[parentInd];
                var currentChild = input[i];
                var otherChild = input[otherChildInd];

                if (parent >= currentChild || parent >= otherChild)
                {
                    var dict = new List<long>()
                    {
                        parent,
                        currentChild,
                        otherChild
                    };


                    var ordered = new Stack<long>(dict.OrderByDescending(x => x));
                    var item = ordered.Pop();
                    input[parentInd] = item;

                    var item1 = ordered.Pop();
                    var item2 = ordered.Pop();
                    if (i < otherChildInd)
                    {

                        input[i] = item1;
                        input[otherChildInd] = item2;
                    }
                    else
                    {

                        input[i] = item2;
                        input[otherChildInd] = item1;
                    }
                }
            }

            var result = string.Join(" ", input);
            var finalResult = new[] {"YES", result};

            Console.WriteLine("YES" + Environment.NewLine + result) ;
            return finalResult;

        }

        private static void Swap(long[] input, int sourceInd, int targetInd)
        {
            var temp = input[sourceInd];
            input[sourceInd] = input[targetInd];
            input[targetInd] = temp;
        }

        private static void CheckBoundry(int len, int input, string message)
        {
            if (input < 0 || input >= len)
                throw new Exception(message +":" + input);
        }
    }
}
