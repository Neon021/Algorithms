using System.Reflection;

public class Codewars
{
    public static void Main(string[] args)
    {
        string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
        GroupAnagrams(strs);
    }
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        List<IList<string>> anagramGroup = new();

        for (int i = 0; i < strs.Length; i++)
        {
            int internalIndex = 0;
            List<string> anagrams = new();
            while (internalIndex < strs.Length)
            {
                if (IsAnagram(strs[i], strs[internalIndex]) && i != internalIndex)
                {
                    anagrams.Add(strs[internalIndex]);
                    strs[internalIndex] = string.Empty;
                }
                internalIndex++;
            }
            anagrams.Add(strs[i]);
            anagramGroup.Add(anagrams);
        }
        return anagramGroup;
    }
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        char[] charArray1 = s.ToCharArray();
        char[] charArray2 = t.ToCharArray();

        Array.Sort(charArray1);
        Array.Sort(charArray2);

        return Enumerable.SequenceEqual(charArray1, charArray2);
    }
}