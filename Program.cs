using System;

public class Codewars
{
    public static void Main(string[] args)
    {
        TwoSum(new int[] { 0, 0, 3, 4 }, 0);
    }
    //Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
    //Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    //Return the indices of the two numbers, index1 and index2, added by one as an integer array[index1, index2] of length 2.
    public static int[] TwoSum(int[] numbers, int target)
    {
        if (target != 0)
        {
            int[] remaining = numbers.Where(x => x <= target || x == 0).ToArray();
            for (int i = 0, j = remaining.Length - 1; i <= j; i++, j--)
            {
                if (remaining[i] + remaining[j] == target)
                    return new int[2] { i + 1, j + 1 };
            }
        }
        else
        {
            int[] remaining = new int[numbers.Length];

            remaining = numbers;
        }


        return Array.Empty<int>();
    }
}