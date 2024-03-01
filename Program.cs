using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public bool IsValid(string s)
    {
        Stack<char> stack = new();

        Dictionary<char, char> dict = new(){
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };

        for (int i = 0; i < s.Length; i++)
        {
            if (dict.Keys.Contains(s[i]))
                stack.Push(s[i]);
            else if (stack.Count > 0 && s[i] == dict[stack.Peek()])
                stack.Pop();
            else
                return false;
        }
        return stack.Count == 0;
        //Stack<char> stk = new();

        //foreach (char c in s)
        //{
        //    if (c == '(' || c == '[' || c == '{')
        //    {
        //        stk.Push(c);
        //    }
        //    else if (c == ')' && (stk.Count == 0 || stk.Pop() != '('))
        //    {
        //        return false;
        //    }
        //    else if (c == ']' && (stk.Count == 0 || stk.Pop() != '['))
        //    {
        //        return false;
        //    }
        //    else if (c == '}' && (stk.Count == 0 || stk.Pop() != '{'))
        //    {
        //        return false;
        //    }

        //}
        //return stk.Count == 0;
    }
}