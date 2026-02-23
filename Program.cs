namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.FindPeakElement(new int[] { 1, 2 }));
        }
    }

    public class Solution
    {
        public static int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = (right + left) / 2;
                int peak = nums[mid];

                if ((mid - 1 < 0 || nums[mid - 1] < peak) && (mid + 1 > nums.Length || nums[mid + 1] < peak))
                    return mid;
                //increase left to whichever side is bigger
                else if (nums[mid + 1] > peak)
                    left = mid + 1;
                else
                    left = mid - 1;
            }

            return left;
        }
    }
}
