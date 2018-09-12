using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class Encryption
    {
        public string DoEncryption(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var input = s.Replace(" ","");
            var length = input.Length;
            var squareRoot = Math.Sqrt(length);
            //var rowLen = Math.Floor(squareRoot);
            var colLen = Math.Ceiling(squareRoot);

            var encryptedMatrix = input.Select((val, ind) => new {val, ind}).GroupBy(x => x.ind % colLen, x => x.val).Select(x => string.Concat(x));
            var result = string.Join(" ", encryptedMatrix); 
            return result;
        }
    }
}
