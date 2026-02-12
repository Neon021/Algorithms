namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.QuickSort(new int[] { 5, 2, 9, 1, 5, 6 }, 0, 6))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public static int[] QuickSort(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(nums, low, high);
                QuickSort(nums, low, pivot);
                QuickSort(nums, pivot + 1, high);
            }

            return nums;
        }

        private static int Partition(int[] nums, int low, int high)
        {
            int pivot = nums[low];
            int leftWall = low;

            for (int i = low + 1; i < high; i++)
            {
                if (nums[i] < pivot)
                {
                    (nums[i], nums[leftWall]) = (nums[leftWall], nums[i]);
                    leftWall++;
                }
            }

            int newPivotIdx = Array.IndexOf(nums, pivot);
            (nums[newPivotIdx], nums[leftWall]) = (nums[leftWall], nums[newPivotIdx]);

            return leftWall;
        }

    }
}