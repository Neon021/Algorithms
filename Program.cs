public class Codewars
{
    public static void Main(string[] args)
    {
        GenerateParenthesis(3);
    }
    public static List<string> GenerateParenthesis(int n)
    {
        //1 <= n <= 7
        //At most, n number of same parantheses can be stacked
        //if n is 3 "(((.." and the rest is the close parantheses
        //According to that
        List<string> result = new();
        Construct(n, 0, 0, "", result);
        return result;

        static void Construct(int n, int openParen, int closeParen, string currPattern, List<string> result)
        {
            //Base condition for recursion
            //as there should be n number of coherent parantheses 
            if (openParen == n && openParen == closeParen)
            {
                result.Add(currPattern);
                return;
            }

            //If we have less then required amount of parantheses
            if (openParen < n)
                Construct(n, openParen + 1, closeParen, currPattern + '(', result);


            if (closeParen < openParen)
                Construct(n, openParen, closeParen + 1, currPattern + ')', result);
        }
    }
}