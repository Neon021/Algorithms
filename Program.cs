using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public bool IsValidSudoku(char[][] board)
    {
        for(int rowIdx = 0; rowIdx < 9; rowIdx++)
        {
            HashSet<char> rowSet = new();
            for(int colIdx = 0;  colIdx < 9; colIdx++)
            {
                char val = board[rowIdx][colIdx];
                if(val != '.')
                {
                    if (!rowSet.Add(val))
                        return false;
                }
            }
        }
        for (int colIdx = 0; colIdx < 9; colIdx++)
        {
            HashSet<char> colSet = new();
            for (int rowIdx = 0; rowIdx < 9; rowIdx++)
            {
                char val = board[rowIdx][colIdx];
                if (val != '.')
                {
                    if (!colSet.Add(val))
                        return false;
                }
            }
        }
        for (int boxRow = 0; boxRow < 3; boxRow++)
        {
            for (int boxCol = 0; boxCol < 3; boxCol++)
            {
                HashSet<char> squareSet = new();

                for (int i = boxRow * 3; i < boxRow * 3 + 3; i++)
                {
                    for (int j = boxCol * 3; j < boxCol * 3 + 3; j++)
                    {
                        char current = board[i][j];
                        if (current != '.')
                        {
                            if (!squareSet.Add(current))
                                return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}