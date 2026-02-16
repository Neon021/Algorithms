namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
        }
    }

    public static class Solution
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            int[] sorted = QuickSort(nums, 0, nums.Length - 1);
            return sorted[^k];
        }

        public static int[] QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(nums, left, right);
                QuickSort(nums, left, pivot - 1);
                QuickSort(nums, pivot + 1, right);
            }

            return nums;
        }

        public static int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int low = left, high = right;

            while (low < high)
            {
                while (high > left && nums[high] > pivot)
                    high--;
                while (low < right && nums[low] <= pivot)
                    low++;

                if (low < high)
                    (nums[low], nums[high]) = (nums[high], nums[low]);
            }

            (nums[left], nums[high]) = (nums[high], nums[left]);

            return high;
        }
    }
}
