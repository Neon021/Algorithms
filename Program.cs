using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
    }

    public bool IsValid(string s)
    {
        Stack<char> stack = new();

        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
            {
                return false;
            }
            else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
            {
                return false;
            }
            else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
            {
                return false;
            }

        }
        return stack.Count == 0;
    }
}