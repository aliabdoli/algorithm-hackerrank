namespace HackerRankAlgorithm.Others
{
    //types cast int to long if not enough
    // look at how transport the matrix ([][] array)
    public class OrganizingContainersOfBalls
    {
        public const string Impossible = "Impossible";
        public const string Possible = "Possible";
        public string OrganizingContainers(List<List<int>> containerInput)
        {
            var containerInputLongs = ConvertToLong(containerInput);
            var rowSums = CalculateRowSums(containerInputLongs);
            var colSums = CalculateColSums(containerInputLongs);

            rowSums.Sort();
            colSums.Sort();

            for (int i = 0; i < rowSums.Count; i++)
            {
                if (rowSums[i] != colSums[i])
                {
                    return Impossible;
                }
            }

            return Possible;

        }

        private static List<List<long>> ConvertToLong(List<List<int>> containerInput1)
        {
            return containerInput1.Select(r => r.Select(c => (long)c).ToList()).ToList();
        }

        private static List<long> CalculateColSums(List<List<long>> matrix)
        {
            var transposedMatrix = new List<List<long>>();
            var colCount = matrix[0].Count;
            
            transposedMatrix = matrix.Select(x => Enumerable.Range(0, colCount).Select(y => (long)-1).ToList()).ToList();
            
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    transposedMatrix[col][row] = matrix[row][col];
                }
            }

            var rowSums = CalculateRowSums(transposedMatrix);
            return rowSums;
        }

        private static List<long> CalculateRowSums(List<List<long>> matrix)
        {
            return matrix.Select(x => (long) x.Sum()).ToList();
        }
    }
}
