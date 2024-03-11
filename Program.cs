﻿public class Codewars
{
    public static void Main(string[] args)
    {
        int[][] ints = { new int[] { 1 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };
        SearchMatrix(ints, 13);
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int index = 0;

        if (matrix.Length == 1 && matrix[0].Length == 1)
        {
            return matrix[0][0] == target;
        }

        while (index < matrix.Length)
        {
            if (!(matrix[index][0] <= target && target <= matrix[index][^1]))
            {
                index++;
                continue;
            }
            else
            {
                int left = 0, right = matrix[index].Length - 1;
                while (left <= right)
                {
                    int i = (left + right) / 2;
                    if (target > matrix[index][i])
                        left = i + 1;
                    else if (target < matrix[index][i])
                        right = i - 1;
                    else
                        return true;
                }
                return false;
            }
        }
        return false;
    }
}