using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
    }
    public void SortColors(int[] nums)
    {
        int lo = 0;
        int mid = 0;
        int hi = nums.Length - 1;
        int tmp = 0;
        while (mid <= hi)
        {
            if (nums[mid] == 0)
            {
                tmp = nums[lo];
                nums[lo] = nums[mid];
                nums[mid] = tmp;

                mid++;
                lo++;
            }
            else if (nums[mid] == 2)
            {
                tmp = nums[hi];
                nums[hi] = nums[mid];
                nums[mid] = tmp;

                hi--;
            }
            else
            {
                mid++;
            }
        }
    }
}