public class Codewars
{
    static void Main(string[] args)
    {
        IDunno(8);
    }

    public static void IDunno(int lineCount)
    {
        int[] fibonacciSeries = new int[lineCount];
        Fibonacci(lineCount);

        for (int lineNumber = 1; lineNumber < lineCount; lineNumber++)
        {
            int firstIntOftheLine = fibonacciSeries[lineNumber];
            Console.Write(firstIntOftheLine);
            for (int j = 1; j < lineNumber; j++)
            {
                int nextNumber = (firstIntOftheLine + (lineNumber * j));
                Console.Write(" " + nextNumber);
            }
            Console.WriteLine("");
        }

        #region Fibonacci Functions
        void Fibonacci(int n)
        {
            for (int i = 0; i < n; i++)
            {
                fibonacciSeries[i] = GetFibonacci(i); // Store the Fibonacci result at the current index
            }
        }

        int GetFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
        #endregion
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; internal set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }

    public class LinkedList<T>
    {
        public Node<T>? First { get; private set; }
        public int Count { get; set; }

        public LinkedList()
        {
            this.First = null;
        }
        public void AddLast(Node<T> node)
        {
            if (First == null)
                First = node;
            else
            {
                Node<T>? curr = First;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = node;
            }

            Count++;
        }
        public Node<T> LinkedListMiddle()
        {
            Node<T>? leftIdx = First, rightIdx = First;

            while (leftIdx != null)
            {
                leftIdx = leftIdx.Next?.Next;
                if (leftIdx != null)
                    rightIdx = rightIdx.Next;
            }

            return rightIdx;
        }

        public bool FindLoop()
        {
            if (First == null)
                return false;

            Node<T>? leftIdx = First, rightIdx = First;

            while (leftIdx != null)
            {
                leftIdx = leftIdx.Next?.Next;
                rightIdx = rightIdx.Next;

                if (leftIdx == rightIdx)
                    return true;
            }

            return false;
        }

        public void Reverse()
        {
            if (!(First == null || Count == 0))
            {
                Node<T>? prev = null;
                Node<T>? currNode = First;
                //If we hadn't nullable types, we would set this to First.
                Node<T>? nextNode = currNode.Next;

                do
                {
                    currNode.Next = prev;
                    prev = currNode;
                    currNode = nextNode;

                    nextNode = currNode?.Next;
                }
                while (currNode != null);

                First = prev;
            }
        }

        public Node<T>? NthNodeFromEnd(int n)
        {
            if (n <= Count)
            {
                Node<T>? q = First;
                Node<T>? p = First;

                for (int i = 0; i < n; i++)
                {
                    q = q?.Next;
                }

                while (q != null)
                {
                    q = q?.Next;
                    p = p?.Next;
                }

                return p;
            }

            return null;
        }

        public Node<T>? IntersectionPointofTwoLinkedLists(LinkedList<T> otherLinkedList)
        {
            if (otherLinkedList != null && otherLinkedList.First != null && First != null)
            {
                Node<T>? p = First;
                Node<T>? q = otherLinkedList.First;

                if (Count < otherLinkedList.Count)
                {
                    int skipCount = otherLinkedList.Count - Count;
                    while (q != null && skipCount != 0)
                    {
                        q = q?.Next;
                    }
                }
                else if (Count > otherLinkedList.Count)
                {
                    int skipCount = Count - otherLinkedList.Count;
                    while (p != null && skipCount != 0)
                    {
                        p = p?.Next;
                        skipCount--;
                    }
                }


                while (p?.Next != null && q?.Next != null)
                {
                    p = p.Next;
                    q = q.Next;
                    if (p == q)
                        return p;
                }
            }

            return null;
        }
    }
}