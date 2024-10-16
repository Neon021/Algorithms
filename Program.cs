public class Codewars
{
    public static void Main(string[] args)
    {
        Console.WriteLine(IsPalindrome("Was it a car or a cat I saw?"));
    }
    public static bool IsPalindrome(string s)
    {
        //string normalStr = new(s.Where(char.IsLetterOrDigit).ToArray());
        //string revStr = new(s.Where(char.IsLetterOrDigit).Reverse().ToArray());

        //return string.Equals(normalStr, revStr, StringComparison.OrdinalIgnoreCase);

        int i = 0, j = s.Length - 1;
        while (i < j)
        {
            while (!AlphaNum(s[i]) && i < j)
            {
                i++;
            }
            while (!AlphaNum(s[j]) && j > i)
            {
                j--;
            }

            if (char.ToLower(s[i]) != char.ToLower(s[j]))
                return false;
            i++;
            j--;
        }
        return true;

        static bool AlphaNum(char c)
        {
            return (c >= 'A' && c <= 'Z' ||
                    c >= 'a' && c <= 'z' ||
                    c >= '0' && c <= '9');
        }
    }
}