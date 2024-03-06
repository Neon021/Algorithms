using Microsoft.VisualBasic;
using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {

    }
    public int MySqrt(int x)
    {
        double half = x / 2;
        while (half * half - x > 0.5)
        {
            half = (half + x / half) / 2;
        }
        return (int)half;
        if (x == 0)
            return 0;

        int left = 1;
        int right = x;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int sqrt = x / mid;

            if (sqrt == mid)
                return mid;
            else if (sqrt < mid)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return right;
    }
}