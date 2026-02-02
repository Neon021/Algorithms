namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
        public List<int> prevSmaller(List<int> A)
        {
            List<int> result = new();

            Stack<int> stack = new();
            foreach (int a in A)
            {
                while (stack.Count > 0 && stack.Peek() >= a)
                    stack.Pop();

                if (stack.Peek() < a)
                    result.Add(stack.Peek());
                else
                    result.Add(-1);

                stack.Push(a);
            }
            return result;
        }
    }
}