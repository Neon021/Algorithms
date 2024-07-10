using System.Globalization;
using System.Text;
using static Algorithms;

public class Codewars
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 1, 1, 3 };
        Console.WriteLine(NumIdenticalPairs(nums));
    }

    public static int NumIdenticalPairs(int[] nums)
    {
        //Span<int> counts = stackalloc int[101];
        //var count = 0;
        //foreach (var n in nums)
        //    count += counts[n]++;
        //return count;

        int res = 0;

        for (int i = 0, j = i + 1; i < nums.Length; i++)
        {
            j = i + 1;
            while (j < nums.Length)
            {
                if (nums[i] == nums[j])
                    res++;
                j++;
            }
        }
        return res;

        //int res = 0;
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    for(int j = i+1; j < nums.Length; j++)
        //    {
        //        if (nums[i] == nums[j])
        //            res++;
        //    }
        //}
        //return res;
    }
}