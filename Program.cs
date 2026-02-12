namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.InsertionSort(new int[] { 2, 8, 5, 3, 9, 4, 1 }))
            {
                Console.WriteLine(item);
            }
            ;
        }
    }

    public static class Solution
    {
        public static int[] InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int j = i;
                while (j > 0 && nums[j] < nums[j - 1])
                {
                    int tmp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = tmp;

                    j -= 1;
                }
            }
            return nums;
        }
    }


}