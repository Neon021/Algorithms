using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
        string[] strs = new string[] { "act", "pots", "tops", "cat", "stop", "hat" };
        GroupAnagrams(strs);
    }
    public static List<List<string>> GroupAnagrams(string[] strs)
    {
        if (strs.Length == 1)
        {
            return new() { new() { strs[0] } };
        }

        bool b = false;
        Dictionary<string, List<string>> kv = new() { { strs[0], new() { strs[0] } } };

        for (int i = 1; i < strs.Length; i++)
        {
            foreach (string str in kv.Keys)
            {
                if (IsAnagram(strs[i], str))
                {
                    kv[str].Add(strs[i]);
                    b = true; 
                    break;
                }
                b = false;
            }
            if (!b)
                kv.Add(strs[i], new() { strs[i] });
        }

        List<List<string>> res = new();
        foreach (List<string> list in kv.Values)
        {
            res.Add(list);
        }

        return res;

        bool IsAnagram(string s, string t)
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
        }
    }
}