public class Codewars
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        int[] elements = { 1, 2, 3, 4, 5 };
        foreach (int value in elements)
        {
            list.AddLast(new Node<int>(value));
        }

        // Test cases
        TestNthFromEnd(list, 1, 5);  // First from end
        TestNthFromEnd(list, 3, 3);  // Middle from end
        TestNthFromEnd(list, 5, 1);  // Last from end
        TestNthFromEnd(list, 6, null);  // Beyond list length

        LinkedList<int> emptyList = new LinkedList<int>();
        TestNthFromEnd(emptyList, 1, null);  // Empty list
    }

    static void TestNthFromEnd(LinkedList<int> list, int n, int? expectedValue)
    {
        Node<int>? result = list.NthNodeFromEnd(n);

        bool isCorrect = (result == null && expectedValue == null) ||
                         (result != null && result.Data == expectedValue);

        Console.WriteLine(isCorrect
            ? $"✓ Correctly found {n}th node from end: {result?.Data}"
            : $"✗ Expected {expectedValue}, got {result?.Data}");
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
    }
}