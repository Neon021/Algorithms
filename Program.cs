namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
        public class CustomStack
        {
            private int _length;
            private readonly int[] _stack;
            private readonly int _capacity;

            public CustomStack(int maxSize)
            {
                _length = 0;
                _capacity = maxSize;
                _stack = new int[_capacity];

            }

            public void Push(int x)
            {
                if (_length == _capacity) return;

                _stack[_length] = x;
                _length++;
            }

            public int Pop()
            {
                if (_length == 0) return -1;

                int poppedVal = _stack[_length - 1];
                _length--;
                return poppedVal;
            }

            public void Increment(int k, int val)
            {
                int incVal = k;
                if (_length < k) incVal = _length;

                for (int i = 0; i < incVal; i++)
                {
                    _stack[i] += val;
                }
            }
        }
    }
}