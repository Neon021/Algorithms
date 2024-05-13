public class Codewars
{
    static void Main(string[] args)
    {
    }
    public int MatrixScore(int[][] grid)
    {
        int rowNumber = grid.Length;
        int columnNumber = grid[0].Length;
        int result = rowNumber;

        for (var j = 1; j < columnNumber; j++)
        {
            var sum = 0;
            for (var i = 0; i < rowNumber; i++)
                sum += grid[i][j] ^ grid[i][0];

            result = (result << 1) + Math.Max(sum, rowNumber - sum);
        }
        return result;
    }
}