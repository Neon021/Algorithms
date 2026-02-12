namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.SelectionSort(new int[] { 2, 8, 5, 3, 9, 4, 1 }))
            {
                Console.WriteLine(item);
            }
            ;
        }
    }

    public static class Solution
    {
        public static int[] SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIdx])
                        minIdx = j;
                }

                if (minIdx != i)
                {
                    int tmp = nums[i];
                    nums[i] = nums[minIdx];
                    nums[minIdx] = tmp;
                }
            }

            return nums;
        }
    }


}