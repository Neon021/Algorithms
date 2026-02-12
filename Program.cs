namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.MergeSort(new int[] { 5, 2, 9, 1, 5, 6 }))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public static int[] MergeSort(int[] nums)
        {
            if (nums.Length == 1)
                return nums;

            int mid = nums.Length / 2;
            int[] left = nums[0..mid];
            int[] right = nums[mid..nums.Length];

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            int firstIdx = 0;
            while (a.Length != 0 && b.Length != 0)
            {
                if (a[0] > b[0])
                {
                    c[firstIdx] = b[0];
                    b = b[1..];
                }
                else
                {
                    c[firstIdx] = a[0];
                    a = a[1..];
                }
                firstIdx++;
            }

            while (a.Length != 0)
            {
                c[firstIdx] = a[0];
                a = a[1..];
                firstIdx++;
            }
            while (b.Length != 0)
            {
                c[firstIdx] = b[0];
                b = b[1..];
                firstIdx++;
            }

            return c;
        }
    }
}