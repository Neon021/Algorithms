public class Codewars
{
    static void Main(string[] args)
    {
        // Test Case 1: Empty List
        Console.WriteLine("Test Case 1: Empty List");
        LinkedList<int> emptyList = new LinkedList<int>();
        TestReverse(emptyList, new int[] { });

        // Test Case 2: Single Element List
        Console.WriteLine("\nTest Case 2: Single Element List");
        LinkedList<int> singleElementList = CreateList(new int[] { 10 });
        TestReverse(singleElementList, new int[] { 10 });

        // Test Case 3: Two Element List
        Console.WriteLine("\nTest Case 3: Two Element List");
        LinkedList<int> twoElementList = CreateList(new int[] { 1, 2 });
        TestReverse(twoElementList, new int[] { 2, 1 });

        // Test Case 4: Multiple Element List
        Console.WriteLine("\nTest Case 4: Multiple Element List");
        LinkedList<int> multiElementList = CreateList(new int[] { 1, 2, 3, 4, 5 });
        TestReverse(multiElementList, new int[] { 5, 4, 3, 2, 1 });
    }

    // Helper method to create a list
    static LinkedList<T> CreateList<T>(T[] arr)
    {
        LinkedList<T> list = new LinkedList<T>();
        foreach (T value in arr)
        {
            list.AddLast(new Node<T>(value));
        }
        return list;
    }

    // Test method to verify list reversal
    static void TestReverse<T>(LinkedList<T> list, T[] expectedOrder)
    {
        list.Reverse();

        Node<T> current = list.First;
        bool isCorrect = true;

        for (int i = 0; i < expectedOrder.Length; i++)
        {
            if (current == null || !current.Data.Equals(expectedOrder[i]))
            {
                isCorrect = false;
                break;
            }
            current = current.Next;
        }

        // Check if list length matches
        isCorrect = isCorrect && (current == null) && (expectedOrder.Length >= 0);

        Console.WriteLine(isCorrect
            ? "✓ List correctly reversed"
            : "✗ List reversal failed");
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
    }
}