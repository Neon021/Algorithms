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
        //true '>'
        //false '<'
        //if (arr.Length == 1)
        //    return 1;
        //int res = 1;
        //bool currComp = arr[0] > arr[1];

        //for (int i = 1; i < arr.Length - 1; i++)
        //{
        //    int temp = 0;
        //    while (i < arr.Length - 1 && arr[i + 1] > arr[i] is bool comp && comp != currComp && arr[i + 1] != arr[i])
        //    {
        //        i++;
        //        currComp = comp;
        //        temp++;
        //    }
        //    res = temp > res ? temp + 1 : res;
        //    temp = 0;
        //    currComp = i < arr.Length - 1 ? arr[i + 1] > arr[i] : currComp;
        //}
        //return res;
        if (arr.Length == 1)
            return 1;

        int maxLen = 1;
        int inc = 1, dec = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                inc = dec + 1;
                dec = 1;
            }
            else if (arr[i] < arr[i - 1])
            {
                dec = inc + 1;
                inc = 1;
            }
            else
            {
                inc = 1;
                dec = 1;
            }
            maxLen = Math.Max(maxLen, Math.Max(inc, dec));
        }

        return maxLen;
    }

}