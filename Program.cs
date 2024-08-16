using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> map = new(nums);
        int longest = 0;

        foreach (int i in nums)
        {
            //To not start another sequence count for a number that is an element in a already calculated sequence
            if (!map.Contains(i - 1))
            {
                int seqLength = 1;
                while (map.Contains(i + seqLength))
                {
                    seqLength++;
                }
                longest = Math.Max(longest, seqLength);
            }
        }

        return longest;
    }
}