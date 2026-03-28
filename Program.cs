namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.MaxConsecutive(new int[] { 1, 0, 1, 0}));
        }
    }

    public static class Solution
    {
        public static int MaxConsecutive(int[] nums)
        {
            int result = 0;
            int left = 0;
            int zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                    zeroCount++;

                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                        zeroCount--;
                    left++;
                }

                result = Math.Max(result, right - left + zeroCount);
            }

            return result;
        }
    }
}
