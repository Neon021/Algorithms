namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
    }

    public static class Solution
    {
        public class StockSpanner
        {
            private Stack<(int price, int count)> _stack;

            public StockSpanner()
            {
                _stack = new();
            }

            public int Next(int price)
            {
                int count = 1;

                while (_stack.Count > 0 && _stack.Peek().price <= price)
                {
                    (int price, int count) prevDay = _stack.Pop();
                    count += prevDay.count;
                }

                _stack.Push((price, count));

                return count;
            }
        }

    }
}