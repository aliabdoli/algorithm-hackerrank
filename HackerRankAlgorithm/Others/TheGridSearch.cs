namespace HackerRankAlgorithm.Others
{
    /// <summary>
    /// the complexity is so bad, didnt implement RMQ for pattern matching
    /// </summary>
    public class TheGridSearch
    {

        private const string Yes = "YES";
        private const string No = "NO";

        /// <summary>
        /// https://www.hackerrank.com/challenges/the-grid-search/problem?isFullScreen=true
        /// </summary>

        public string Do(List<string> g, List<string> p)
        {
            var pattern = p;
            
            var patternRowCount = p.Count;
            var patternColumnCount = p.First().Length;

            var grid = g;
            var patternMatcher = new OneDimensionPatternMatcher();
            for (int gRowInd = 0; gRowInd <= g.Count - patternRowCount; gRowInd++)
            {
                var currentPatternRow = pattern[0];
                var currentGridRow = grid[gRowInd];

                var allMatches = patternMatcher.FindAllMatches(currentPatternRow, currentGridRow);
                foreach (var match in allMatches)
                {
                    var startRow = gRowInd;
                    var startColumn = match.StartInd;

                    var ifMatchBlock = CheckMatchBlock(
                        pattern,
                        grid,
                        startRow,
                        startColumn
                    );

                    if (ifMatchBlock)
                    {
                        return Yes;
                    }
                }
            }

            return No;
        }

        private static bool CheckMatchBlock(List<string> pattern, 
            List<string> grid, 
            int startRow, 
            int startColumn 
            )
        {
            var patternRowCount = pattern.Count;
            var patternColumnCount = pattern.First().Length;

            for (int i = startRow; i < startRow + patternRowCount; i++)
            {
                for (int j = startColumn; j < startColumn + patternColumnCount; j++)
                {
                    var gridCurrent = grid[i][j];
                    var patternCurrent = pattern[i - startRow][j-startColumn];
                    if (patternCurrent != gridCurrent)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public class OneDimensionPatternMatcher
    {

        public class IsMatchResult
        {
            //public bool IsMatch { get; set; }
            public int StartInd { get; set; }
            public int EndInd { get; set; }
        }
        /// <summary>
        ///  DIDNT implement RMQ implementation
        /// </summary>
        
        //todo: improve it
        public List<IsMatchResult> FindAllMatches(string pattern, string inputString)
        {
            var matches = new List<IsMatchResult>();

            for (int inputInd = 0; inputInd <= inputString.Length - pattern.Length; inputInd++)
            {
                var resultInputStartInd = inputInd;

                int patternInd = 0;
                while (patternInd < pattern.Length 
                       && pattern[patternInd] == inputString[inputInd + patternInd])
                {
                    patternInd++;
                }

                if (patternInd == pattern.Length)
                {
                    var match = new IsMatchResult()
                    {
                        StartInd = inputInd,
                        EndInd = inputInd + patternInd - 1
                    };
                    matches.Add(match);
                }
                
            }

            return matches;
        }
    }


}
