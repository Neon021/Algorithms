namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.QuickSort(new int[] { 5, 2, 9, 1, 5, 6 }, 0, 5))
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
                QuickSort(nums, low, pivot - 1); //Exclude pivot as its already in the correct position
                QuickSort(nums, pivot + 1, high);
            }

            return nums;
        }

        private static int Partition(int[] nums, int low, int high)
        {
            int pivot = nums[low];
            int i = low, j = high;

            while (i < j)
            {
                while (nums[j] > pivot && j > low)
                    j--;

                while (nums[i] <= pivot && i < high)
                    i++;


                if (i < j)
                    (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            //swap pivot with the element at j which will put pivot in the center of the nums
            (nums[low], nums[j]) = (nums[j], nums[low]);

            //return the partition position
            return j;
        }
        //private static int Partition(int[] nums, int low, int high)
        //{
        //    int pivot = nums[low];
        //    int leftWall = low;

        //    for (int i = low + 1; i < high; i++)
        //    {
        //        if (nums[i] < pivot)
        //        {
        //            (nums[i], nums[leftWall]) = (nums[leftWall], nums[i]);
        //            leftWall++;
        //        }
        //    }

        //    int newPivotIdx = Array.IndexOf(nums, pivot);
        //    (nums[newPivotIdx], nums[leftWall]) = (nums[leftWall], nums[newPivotIdx]);

        //    return leftWall;
        //}
    }
}
