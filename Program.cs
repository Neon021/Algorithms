using System.Reflection;

public class Codewars
{
    public static void Main(string[] args)
    {
        int[] nums = { 0, 1 };
        MissingNumber(nums);
    }
    //Given an array nums containing n distinct numbers in the range[0, n],
    //return the only number in the range that is missing from the array.
    public static int MissingNumber(int[] nums)
    {
        //Array.Sort(nums);
        //int res = 0;
        //if (nums[^1] != nums.Length)
        //{
        //    res = nums.Length;
        //    return res;
        //}
        //for (int i = 1; i < nums.Length; i++)
        //{
        //    if (nums[i] != nums[i - 1] + 1) { res = i; }
        //}
        //return res;

        return
     Enumerable
     .Range(0, nums.Length + 1)
     .Except(nums)
     .FirstOrDefault();
    }
}