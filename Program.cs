using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
        string s = "z";
        string t = "abcde";
        Console.WriteLine(AppendCharacters(s, t));
    }
    public static bool IsEven(int input)
    {
        return (input & 1) == 0;
    }
    public static int AppendCharacters(string s, string t)
    {
        int i = 0, j = 0;

        while(i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
            }
            else
            {
                i++;
            }
        }

        return t.Length - j;
    }
}