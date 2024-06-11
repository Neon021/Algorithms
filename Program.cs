using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
        int[] test = { 9, 4, 2, 10, 7, 8, 8, 1, 9 };
        Console.WriteLine(MaxTurbulenceSize(test));
    }
    public static int MaxTurbulenceSize(int[] arr)
    {
        int res = 1;
        int start = 0;
        int length = arr.Length;
        for (int i = 1; i < length; i++)
        {
            //_value > value = 1
            //_value < value = -1
            int leftComp = arr[i].CompareTo(arr[i - 1]);
            if(leftComp == 0)
                start = i;
            else if(i == length - 1 || leftComp != arr[i].CompareTo(arr[i + 1]))
            {
                res = Math.Max(res, i - start + 1);
                start = i;
            }
        }
        return res;
    }

}