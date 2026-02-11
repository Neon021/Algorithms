namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Solution.BubbleSort(new int[] { 5, 1, 4, 2, 8 }).ToList().ForEach(x => Console.Write(x + " "));
        }
    }
    public static class Solution
    {
        public static int[] BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                }
            }

            return nums;
        }
    }
}