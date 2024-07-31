using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
        IsAnagram("racecar", "carrace");
    }
    public static bool IsAnagram(string s, string t)
    {
        int[] count1 = new int[256];
        int[] count2 = new int[256];
        int i;

        for (i = 0; i < s.Length && i < t.Length; i++)
        {
            count1[s[i]]++;
            count2[t[i]]++;
        }

        if (s.Length != t.Length)
        {
            return false;
        }

        for (i = 0; i < 256; i++)
        {
            if (count1[i] != count2[i])
                return false;

        }
        return true;
        //if (s.Length != t.Length)
        //    return false;

        //Dictionary<char, int> kv = new();

        //foreach(char c in s)
        //{
        //    if (!kv.ContainsKey(c))
        //        kv.Add(c, 1);
        //    else
        //        kv[c]++;
        //}
        //foreach(char c in t)
        //{
        //    if (!kv.ContainsKey(c))
        //        return false;
        //    else if (kv[c])
        //}
        //if (s.Length != t.Length)
        //    return false;

        //char[] chars1 = s.ToCharArray();
        //foreach(char ch in t)
        //{
        //    if(!chars1.Contains(ch))
        //        return false;
        //}
        //return true;
    }
}