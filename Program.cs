public class Codewars
{
    public static void Main(string[] args)
    {
        string[] tokens = { "1", "2", "+", "3", "*", "4", "-" };
        EvalRPN(tokens);
    }
    public static int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();
        foreach (string token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int rightOperand = stack.Pop();
                int leftOperand = stack.Pop();
                int result = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => 0
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }
        return stack.Pop();
    }
}