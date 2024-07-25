public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        foreach (int num in nums)
        {
            Dictionary<char, int> map = new();
            string s = num.ToString();

            foreach (char digit in s)
            {
                if (!map.ContainsKey(digit))
                {
                    int corresponding = mapping[digit];
                    map.Add(digit, corresponding);
                    s.Where(x => x == digit).Select(x => x == corresponding);
                }
            }
        }

        return new int[] { };
    }
}