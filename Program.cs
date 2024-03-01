using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {
        EvalRPN(new string[] { "2", "1", "+", "3", "*" });
    }
    public static int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int secondOperand = stack.Pop();
                int firstOperand = stack.Pop();
                int result = token switch
                {
                    "+" => firstOperand + secondOperand,
                    "-" => firstOperand - secondOperand,
                    "*" => firstOperand * secondOperand,
                    "/" => firstOperand / secondOperand,
                    _ => throw new ArgumentOutOfRangeException(nameof(token))
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
        //int result = 0;
        //Stack<string> stack = new();
        //for (int i = 0; i < tokens.Length - 1;)
        //{
        //    while (tokens[i] != "*" && tokens[i] != "+" && tokens[i] != "-" && tokens[i] != "/")
        //    {
        //        stack.Push(tokens[i]);
        //        i++;
        //    }
        //    string @operator = stack.Pop();
        //    string firstOperand = stack.Pop();
        //    string secondOperand = stack.Pop();
        //    switch (@operator)
        //    {
        //        case "*":
        //            result += int.Parse(firstOperand) * int.Parse(secondOperand);
        //            break;
        //        case "+":
        //            result += int.Parse(firstOperand) + int.Parse(secondOperand);
        //            break;
        //        case "-":
        //            result += int.Parse(firstOperand) - int.Parse(secondOperand);
        //            break;
        //        case "/":
        //            result += int.Parse(firstOperand) / int.Parse(secondOperand);
        //            break;
        //    }
        //}
        //return result;
    }
}