using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
        int[] ints = new int[] { 2,5,5,11 };
        int t = 10;
        var res = TwoSum(ints, t);
        foreach(int i in res)
        {
            Console.WriteLine(i);
        }
    }
    public static int[] TwoSum(int[] nums, int target)
    {
        int j = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length)
            {
                int jIdx = Math.Abs(nums.Length - j);
                if (i != jIdx)
                {
                    if (nums[i] + nums[^j] == target)
                    {
                        return new int[] { Math.Min(i, jIdx), Math.Max(i, jIdx) };
                    }
                }
                j++;
            }
            j = 1;
        }

        return Array.Empty<int>();
    }
}