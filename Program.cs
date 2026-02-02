namespace Main
{
    public class Program
    {
        public static void Main()
        {
            //["MinStack","push","push","push","getMin","pop","top","getMin"]
            //[[],[-2],[0],[-3],[],[],[],[]]
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            int param_4 = minStack.GetMin();
            minStack.Pop();
            int param_3 = minStack.Top();
            int param_5 = minStack.GetMin();
        }
        public class MinStack
        {

            private int[] _stack;
            private int _capacity;
            private int _length;

            public MinStack()
            {
                _length = 0;
                _capacity = 10;
                _stack = new int[_capacity];
            }

            public void Push(int val)
            {
                if (_length + 1 < _capacity)
                {
                    _stack[_length] = val;
                    _length++;
                }
                else
                {
                    int[] tmp = _stack;
                    _capacity *= 2;
                    _stack = new int[_capacity];
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        _stack[i] = tmp[i];
                    }
                    _stack[_length] = val;
                    _length++;
                }
            }

            public void Pop()
            {
                if (_length > 0)
                {
                    _stack[_length - 1] = -1;
                    _length--;
                }
            }

            public int Top()
            {
                if (_length > 0)
                {
                    return _stack[_length - 1];
                }

                return -1;
            }

            public int GetMin()
            {
                if (_length > 0)
                {
                    IEnumerable<int> slice = _stack.Take(_length);
                    return slice.Min();
                }

                return int.MaxValue;
            }
        }


    }
}