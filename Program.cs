using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
        //MinStack minStack = new(100);
        //Enumerable.Range(1, 100).ToList().ForEach(minStack.Push);
        TestMinStack();
    }
    private static void TestMinStack()
    {
        // Create a new MinStack with a capacity of 5
        var minStack = new MinStack(5);

        // Test the Push, Pop, Top, and GetMin operations
        Console.WriteLine("Pushing 5, 2, 3, 4, 1 to the stack...");
        minStack.Push(5);
        minStack.Push(2);
        minStack.Push(3);
        minStack.Push(4);
        minStack.Push(1);

        Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
        Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

        Console.WriteLine("Popping an element from the stack...");
        minStack.Pop();

        Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
        Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

        // Test the resizing functionality
        Console.WriteLine("Pushing 6, 7, 8 to the stack...");
        minStack.Push(6);
        minStack.Push(7);
        minStack.Push(8);

        Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
        Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

        Console.ReadLine();
    }
    public class MinStack
    {
        private int[] _stack;
        private int _capacity;
        private int _length;

        public MinStack(int capacity)
        {
            _stack = new int[capacity];
            _capacity = capacity;
            _length = 0;
        }

        public void Push(int val)
        {
            if (!(_length + 1 >= _capacity))
            {
                _stack[_length] = val;
                _length += 1;
            }
            else
            {
                Console.WriteLine("STACK CAPACITY IS FULL.\r\nWOULD YOU LIKE TO RESIZE Y/N?");
                string? answer = Console.ReadLine();
                if (answer == "Y")
                {
                    int[] newStack = new int[_capacity * 2];
                    for (int i = 0; i < _length; i++)
                    {
                        newStack[i] = _stack[i];
                    }
                    _stack = newStack;
                    _capacity *= 2;
                    _stack[_length] = val;
                    _length += 1;
                }
            }
        }

        public void Pop()
        {
            if (_length != 0)
            {
                _stack[_length] = 0;
                _length -= 1;
            }
            else
            {
                throw new InvalidOperationException("Cannot pop from an empty stack.");
            }
        }

        public int Top()
        {
            if(_length != 0)
            {
                return _stack[_length];
            }
            else
            {
                throw new InvalidOperationException("Cannot retrieve the top element from an empty stack.");
            }
        }

        public int GetMin()
        {
            if(_length != 0)
            {
                IEnumerable<int> slice = _stack.Take(_length);
                return slice.Min();
            }
            return int.MaxValue;
        }

        //Stack<int> stack;
        //public MinStack()
        //{
        //    stack = new();
        //}

        //public void Push(int val)
        //{
        //    stack.Push(val);
        //}

        //public void Pop()
        //{
        //    stack.Pop();
        //}

        //public int Top()
        //{
        //    return stack.Peek();
        //}

        //public int GetMin()
        //{
        //    return stack.Min();
        //}
    }

}