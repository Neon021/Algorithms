namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            //First we need a way to count frequency of characters in both strings
            //size is 256 assuming s and t contain only extended ASCII characters
            int[] charFrequencyForS = new int[256];
            int[] charFrequencyForT = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                //This means "increase the value at index of the character's ASCII value by 1"
                charFrequencyForS[s[i]]++;
                charFrequencyForT[t[i]]++;
            }

            //Then we can iterate over extended ASCII domain and compare at each step
            for (int i = 0; i < 256; i++)
            {
                //If the frequency of a character is different in both strings, they are not anagrams
                if (charFrequencyForS[i] != charFrequencyForT[i])
                    return false;
            }

            return true;
        }
    }
}