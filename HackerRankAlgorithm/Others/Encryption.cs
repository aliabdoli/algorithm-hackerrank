using System.Text;
using System.Text.RegularExpressions;

namespace HackerRankAlgorithm.Others
{
    public class Encryption
    {
        //todo: see previous commit on this file (the solution is just one liner)!!!!
        public string DoEncryption(string s)
        {
            var noSpaceString = s.Replace(" ", "");
            var noSpaceStringCount = noSpaceString.Count();


            var sqrtLen = Math.Sqrt(noSpaceString.Length);
            var gridRowCount = (int)sqrtLen;
            var gridColCount = (int)Math.Ceiling(sqrtLen);

            if (gridRowCount * gridColCount < noSpaceStringCount)
            {
                gridRowCount++;
            }
            

            var gridChars = new List<List<char>>();
            
            for (int i = 0; i < gridRowCount - 1; i++)
            {

                var gridRow = noSpaceString.Skip(i * gridColCount).Take(gridColCount).ToList();
                gridChars.Add(gridRow);
            }

            var lastGridRow = noSpaceString.Skip((gridRowCount - 1) * gridColCount).ToList();
            if (lastGridRow.Count < gridColCount)
            {
                var toAddSpace = gridColCount - lastGridRow.Count;
                for (int i = 0; i < toAddSpace; i++)
                {
                    lastGridRow.Add(' ');
                }
            }
            gridChars.Add(lastGridRow);

            var strBuilder = new StringBuilder();

            for (int colInd = 0; colInd < gridColCount; colInd++)
            {
                for (int rowInd = 0; rowInd < gridRowCount; rowInd++)
                {
                    if (gridChars[rowInd][colInd] != ' ')
                    {
                        strBuilder.Append(gridChars[rowInd][colInd]);
                    }
                }
                strBuilder.Append(" ");
            }

            var result = strBuilder.ToString().Trim();
            return result;
        }
    }
}
