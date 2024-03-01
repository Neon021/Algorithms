using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {
        GenerateParenthesis(4);
    }
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = new List<string>();
        GenerateValidParentheses(n, n, "", result);
        return result;
    }

    private static void GenerateValidParentheses(int openCount, int closeCount, string current, IList<string> result)
    {
        if (openCount == 0 && closeCount == 0)
        {
            result.Add(current);
            return;
        }

        if (openCount > 0)
        {
            GenerateValidParentheses(openCount - 1, closeCount, current + '(', result);
        }

        if (closeCount > openCount)
        {
            GenerateValidParentheses(openCount, closeCount - 1, current + ')', result);
        }
    }
}