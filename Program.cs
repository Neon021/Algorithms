using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
    }
    public int HeightChecker(int[] heights)
    {
        int[] expected = new int[heights.Length];
        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);
        int res = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != expected[i])
                res++;
        }
        return res;
    }

}