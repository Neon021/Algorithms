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
            // Main Stack storage
            private int[] _stack;
            private int _capacity;
            private int _length;

            // Min value storage
            private int[] _minStack;
            private int _minStackCapacity;
            private int _minStackLength;

            public MinStack()
            {
                _length = 0;
                _capacity = 10;
                _stack = new int[_capacity];

                _minStackLength = 0;
                _minStackCapacity = 10;
                _minStack = new int[_minStackCapacity];
            }

            public void Push(int val)
            {
                if (_length == _capacity)
                {
                    _capacity *= 2;
                    int[] newStack = new int[_capacity];
                    for (int i = 0; i < _stack.Length; i++)
                    {
                        newStack[i] = _stack[i];
                    }
                    _stack = newStack;
                }
                _stack[_length] = val;
                _length++;


                //Only push to minStack if new value is <= current min
                if (!(_minStackLength == 0 || val <= _minStack[_minStackLength - 1])) return;

                if (_minStackLength == _minStackCapacity)
                {
                    _minStackCapacity *= 2;
                    int[] newMinStack = new int[_minStackCapacity];
                    for (int i = 0; i < _minStack.Length; i++)
                    {
                        newMinStack[i] = _minStack[i];
                    }
                    _minStack = newMinStack;
                }
                _minStack[_minStackLength] = val;
                _minStackLength++;
            }

            public void Pop()
            {
                if (_length <= 0) return;

                int valBeingPopped = _stack[_length - 1];

                // Only pop from minStack if the values match
                if (_minStackLength > 0 && valBeingPopped == _minStack[_minStackLength - 1])
                    _minStackLength--;

                //Always pop from mainStack
                _length--;

                //By only decreasing the _length we actually don't replace actual values in the array.
                //However, they are now considered "out of bounds" and will be overwritten on the next Push.
            }

            public int Top()
            {
                if (_length > 0)
                    return _stack[_length - 1];

                return -1;
            }

            public int GetMin()
            {
                if (_minStackLength > 0)
                    return _minStack[_minStackLength - 1];

                return -1;
            }
        }


    }
}