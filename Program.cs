namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
        public class MyQueue
        {
            //FIFO elements
            private Stack<int> stack1;
            private Stack<int> stack2;
            public MyQueue()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            //Enqueue
            public void Push(int x)
            {
                //Imagine this, we have two stacks that operate with FIFO principle
                //In order to simulate a queue with stacks that use FILO principle, we need to reverse the order of the elements
                //So by turning stack1 upside down into stack2 we are able to put the new element at the bottom of the stack in the next push
                while (stack2.Count > 0)
                    stack1.Push(stack2.Pop());

                stack1.Push(x);

                while (stack1.Count > 0)
                    stack2.Push(stack1.Pop());
            }

            //Dequeue
            public int Pop()
            {
                return stack2.Pop();
            }

            public int Peek()
            {
                return stack2.Peek();
            }

            public bool Empty()
            {
                return stack2.Count == 0;
            }
        }
    }
}