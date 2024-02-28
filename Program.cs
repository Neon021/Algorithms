using System.Collections;

public class Codewars
{
    public static void Main(string[] args)
    {
        string s1 = "ab";
        string s2 = "eidboaoo";
        CheckInclusion(s1, s2);
    }
    public static bool CheckInclusion(string s1, string s2)
    {
        int l = 0, r = 0, i = 0;
        Dictionary<char, int> s1CharacterFrequencies = new();
        Dictionary<char, int> s2CharacterFrequencies = new();

        foreach (char c in s1)
        {
            if (s1CharacterFrequencies.ContainsKey(c))
                s1CharacterFrequencies[c]++;
            else s1CharacterFrequencies[c] = 1;
        }

        for (r = 0; r < s2.Length; r++)
        {
            if (!s2CharacterFrequencies.ContainsKey(s2[r]))
            {
                s2CharacterFrequencies.Add(s2[r], 1);
            }
            else
            {
                s2CharacterFrequencies[s2[r]] += 1;
            }
            while (r - l + 1 > s1.Length)
            {
                s2CharacterFrequencies[s2[l]] -= 1;
                l++;
            }

            if (r - l + 1 == s1.Length)
            {
                for (i = 0; i < s1.Length; i++)
                {
                    if (!s2CharacterFrequencies.ContainsKey(s1[i]) || s2CharacterFrequencies[s1[i]] != s1CharacterFrequencies[s1[i]])
                    {
                        break;
                    }
                }
                if (i == s1.Length)
                {
                    return true;
                }
            }
        }
        return false;
        //Dictionary<char, int> s2CharacterFrequencies = new();
        //foreach(char c in s2)
        //{
        //    if (s2CharacterFrequencies.ContainsKey(c))
        //        s2CharacterFrequencies[c]++;
        //    else s2CharacterFrequencies[c] = 1;
        //}
        //Dictionary<char, int> s1CharacterFrequencies = new();
        //foreach (char c in s1)
        //{
        //    if (s1CharacterFrequencies.ContainsKey(c))
        //        s1CharacterFrequencies[c]++;
        //    else s1CharacterFrequencies[c] = 1;
        //}

        //foreach(char c in s1CharacterFrequencies.Keys)
        //{
        //    if (s2CharacterFrequencies.ContainsKey(c) && s2CharacterFrequencies[c] == s1CharacterFrequencies[c])
        //        continue;
        //    else
        //        return false;
        //}
        //return true;
    }
}