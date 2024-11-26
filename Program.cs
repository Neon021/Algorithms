public class Codewars
{
    static void Main(string[] args)
    {
        // Test Case 1: Empty List
        Console.WriteLine("Test Case 1: Empty List");
        LinkedList<int> emptyList = new();
        TestMiddle(emptyList, 0);

        // Test Case 2: Single Element List
        Console.WriteLine("\nTest Case 2: Single Element List");
        LinkedList<int> singleElementList = new();
        singleElementList.AddLast(new Node<int>(10));

        TestMiddle(singleElementList, 10);

        // Test Case 3: Odd Number of Elements
        Console.WriteLine("\nTest Case 3: Odd Number of Elements");
        LinkedList<int> oddList = new();
        for (int i = 1; i <= 11; i++)
        {
            oddList.AddLast(new(i));
        }
        TestMiddle(oddList, 6);

        // Test Case 4: Even Number of Elements
        Console.WriteLine("\nTest Case 4: Even Number of Elements");
        LinkedList<int> evenList = new();
        for (int i = 1; i <= 10; i++)
        {
            evenList.AddLast(new(i));
        }

        TestMiddle(evenList, 5);

        // Test Case 5: Large List
        Console.WriteLine("\nTest Case 5: Large List");
        LinkedList<int> largeList = new ();
        for (int i = 1; i <= 100; i++)
        {
            largeList.AddLast(new(i));
        }
        TestMiddle(largeList, 50);
    }
    static void TestMiddle<T>(LinkedList<T> list, T expectedMiddle)
    {
        try
        {
            Node<T> middleNode = list.LinkedListMiddle();

            if (middleNode == null)
            {
                Console.WriteLine("✓ Correctly returned null for empty list");
            }
            else
            {
                Console.WriteLine(middleNode.Data.Equals(expectedMiddle)
                    ? $"✓ Correct middle node: {middleNode.Data}"
                    : $"✗ Expected {expectedMiddle}, but got {middleNode.Data}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Unexpected exception: {ex.Message}");
        }
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
        }
        public Node<T> LinkedListMiddle()
        {
            Node<T>? leftIdx = First, rightIdx = First;

            while (leftIdx != null)
            {
                leftIdx = leftIdx.Next?.Next;
                if(leftIdx != null)
                    rightIdx = rightIdx.Next;
            }

            return rightIdx;
        }
    }
}