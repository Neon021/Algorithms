using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> map = new (nums);
        int longest = 0;

        foreach(int i in nums)
        {
            if (!map.Contains(i - 1))
            {
                int seqLength = 1; 
                while(map.Contains(i + seqLength))
                {
                    seqLength++;
                }
                longest = Math.Max(longest, seqLength);
            }
        }

        return longest;
    }
}