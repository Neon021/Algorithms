public class Codewars
{
    public static void Main(string[] args)
    {
        foreach (var item in TwoSum(new int[] { 5, 82, 2, 4, 3, 1, 6, 5, 3, 36, 34 }, 5))
        {
            Console.WriteLine(item);
        }
    }
    public static int[] TwoSum(int[] numbers, int target)
    {
        int l = 0, r = 0;

        while (l < numbers.Length - 1)
        {
            int leftVal = numbers[l];
            r = l + 1;
            while (r < numbers.Length)
            {
                int rightVal = numbers[r];
                if (leftVal + rightVal == target)
                    return new int[] { l + 1, r + 1 };
                r++;
            }
            l++;
        }

        return Array.Empty<int>();
    }
}