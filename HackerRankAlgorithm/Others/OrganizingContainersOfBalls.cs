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
            var containerCount = containerInput.Count;
            
            var longContainers = containerInput.Select(x => 
                x.Select(y => (long)y).ToList()).
                ToList();


            var rowSums = longContainers.Select(x => x.Sum()).ToList();

            var columnSums = new List<long>();
            for (int colInd = 0; colInd < containerCount; colInd++)
            {
                var columnSum = Enumerable.Range(0, containerCount).Select((x, ind) => longContainers[x][colInd]).Sum();
                columnSums.Add(columnSum);
            }
        

            rowSums.Sort();
            columnSums.Sort();

            for (int i = 0; i < containerCount; i++)
            {
                if (rowSums[i] != columnSums[i])
                {
                    return Impossible;
                }
            }
            return Possible;

        }
    }
}
