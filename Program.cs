namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
        public static bool IsValid(string s)
        {
            //Do we need to use Stack here?
            //Because with the example 5 we can see that the closing bracket must be subsequent one in the list
            //We just need a char to store the last opened bracket
            //char lastOpened = '\0';

            //for (int i = 0; i < s.Length; i++)
            //{
            //    char c = s[i];
            //    if (c == '(' || c == '[' || c == '{')
            //        lastOpened = c;
            //    else if (c == ')' && lastOpened != '(')
            //        return false;
            //    else if (c == ']' && lastOpened != '[')
            //        return false;
            //    else if (c == '}' && lastOpened != '{')
            //        return false;
            //    else if (i == s.Length - 1)
            //        lastOpened = '\0';
            //    else
            //        return false;
            //}

            //return lastOpened != '(' && lastOpened != '[' && lastOpened != '{';

            Stack<char> stack = new Stack<char>();

            for (int i =0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
                    return false;
                else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
                    return false;
                else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                    return false;
            }

            return stack.Count == 0;
        }
    }
}