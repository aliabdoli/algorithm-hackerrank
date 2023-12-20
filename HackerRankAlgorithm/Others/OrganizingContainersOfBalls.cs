namespace HackerRankAlgorithm.Others
{
    //types cast int to long if not enough
    // look at how transport the matrix ([][] array)
    public class OrganizingContainersOfBalls
    {
        public const string Impossible = "Impossible";
        public const string Possible = "Possible";
        public string OrganizingContainers(int[][] container)
        {
            var rowSum = container.Select(r => r.Sum(c => (long)c));

            var rowColumnIndex = container.Select((rval, rind) => 
                new { rind, rval = rval
                    .Select((cval, cind) => new { cind, cval }) });
            var flattened = rowColumnIndex.SelectMany(x => x.rval.Select(y => new { x.rind, y.cind, y.cval }));
            var colSum = flattened.GroupBy(x => x.cind).Select(y => y.Sum(z => (long) z.cval)).ToList();

            var rowHash = new HashSet<long>(rowSum);
            var colHash = new HashSet<long>(colSum);

            return rowHash.SetEquals(colHash)? Possible : Impossible;

        }
    }
}
