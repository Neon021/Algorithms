namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.SortColors(new int[] { 2, 0, 2, 1, 1, 0 }))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public static int[] SortColors(int[] nums)
        {
            //Simple counting sort
            int red = 0, white = 0, blue = 0;

            foreach (int i in nums)
            {
                switch (i)
                {
                    case 0:
                        red++;
                        break;
                    case 1:
                        white++;
                        break;
                    case 2:
                        blue++;
                        break;
                }
            }

            white += red;
            blue += white;

            int redCount = red;
            while (red != 0)
            {
                nums[red - 1] = 0;
                red--;
            }

            int whiteCount = white;
            while (white != redCount)
            {
                nums[white - 1] = 1;
                white--;
            }

            while (blue != whiteCount)
            {
                nums[blue - 1] = 2;
                blue--;
            }

            return nums;
        }
    }
}
