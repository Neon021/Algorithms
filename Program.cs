public class Codewars
{
    public static void Main(string[] args)
    {
        int[] ints = { 1, 2, 2, 3, 3, 3 };
        TopKFrequent(ints, 2);
    }
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> map = new();

        foreach (int i in nums)
        {
            if (map.ContainsKey(i))
                map[i]++;
            else
                map[i] = 1;
        }


        var res = map.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();

        return res;
    }
}