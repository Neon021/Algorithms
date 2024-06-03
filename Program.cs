using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
        string s = "z";
        string t = "abcde";
        Console.WriteLine(IsSubsequence(s, t));
    }
    public static bool IsEven(int input)
    {
        return (input & 1) == 0;
    }
    public static bool IsSubsequence(string s, string t)
    {
        int sIdx = 0, tIdx = 0;
        while(sIdx < s.Length && tIdx < t.Length)
        {
            if (s[sIdx] == t[tIdx])
                sIdx++;
            tIdx++;
        }
        return sIdx == s.Length;
    }
}