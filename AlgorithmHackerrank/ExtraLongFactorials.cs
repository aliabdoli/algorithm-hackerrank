using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public static class ExtraLongFactorials
    {
        public static List<int> Run(int n)
        {
            var result = CalculateExtraLongFactorials(n);
            return result;
        }

        static List<int> CalculateExtraLongFactorials(int n)
        {
            var resultList = new List<int>();
            var result = 1;

            checked
            {
                try
                {
                    for (int i = 1; i <= n; i++)
                    {
                        result = result * i;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            resultList.Add(result);
            resultList.Reverse();
            return resultList;
        }

        public static string MultiplyByAdd(int a, int b)
        {
            //var result = new StringBuilder();
            var aBinary = Convert.ToString(a, 2);
            var result = string.Join("", Enumerable.Range(0, aBinary.Length).Select(x => "0"));

            for (int i = 0; i < b; i++)
            {
                result = Add(aBinary, result);
            }

            return result;
        }

        public static string Add(string a, string b)
        {
            var sum = new StringBuilder();
            var carrier = '0';
            for (int i = a.Length - 1; i >=0 ; i--)
            {
                var lst = new List<char>(){a[i], b[i], carrier};
                var numberOfOnes = lst.Count(x => x == '1');
                switch (numberOfOnes)
                {
                    case 0:
                        sum.Append('0');
                        carrier = '0';
                        break;
                    case 1:
                        sum.Append('1');
                        carrier = '0';
                        break;
                    case 2:
                        sum.Append('0');
                        carrier = '1';
                        break;
                    case 3:
                        sum.Append('1');
                        carrier = '1';
                        break;
                }
            }

            sum.Append(carrier);

            return sum.ToString().Reverse().ToString();

        }


    }
    public class BinarySumResult
    {
        public int Result { get; set; }
        public int Carry { get; set; }

    }
}
