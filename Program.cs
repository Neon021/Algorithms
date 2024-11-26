public class Codewars
{
    static void Main(string[] args)
    {
        // Test Case 1: Empty List (No Loop)
        Console.WriteLine("Test Case 1: Empty List (No Loop)");
        LinkedList<int> emptyList = new LinkedList<int>();
        TestFindLoop(emptyList, false);

        // Test Case 2: Single Element List (No Loop)
        Console.WriteLine("\nTest Case 2: Single Element List (No Loop)");
        LinkedList<int> singleElementList = new LinkedList<int>();
        singleElementList.AddLast(new Node<int>(10));
        TestFindLoop(singleElementList, false);

        // Test Case 3: List with No Loop
        Console.WriteLine("\nTest Case 3: List with No Loop");
        LinkedList<int> noLoopList = new LinkedList<int>();
        int[] noLoopArray = new int[] { 1, 2, 3, 4, 5 };
        foreach (int value in noLoopArray)
        {
            noLoopList.AddLast(new Node<int>(value));
        }
        TestFindLoop(noLoopList, false);

        // Test Case 4: List with Loop at End
        Console.WriteLine("\nTest Case 4: List with Loop at End");
        LinkedList<int> endLoopList = CreateListWithLoop(new int[] { 1, 2, 3, 4, 5 }, 0);
        TestFindLoop(endLoopList, true);

        // Test Case 5: List with Loop in Middle
        Console.WriteLine("\nTest Case 5: List with Loop in Middle");
        LinkedList<int> middleLoopList = CreateListWithLoop(new int[] { 1, 2, 3, 4, 5 }, 2);
        TestFindLoop(middleLoopList, true);

        // Test Case 6: List with Single Element Loop
        Console.WriteLine("\nTest Case 6: List with Single Element Loop");
        LinkedList<int> singleElementLoopList = CreateListWithLoop(new int[] { 1 }, 0);
        TestFindLoop(singleElementLoopList, true);
    }

    // Helper method to create a list with a loop
    static LinkedList<T> CreateListWithLoop<T>(T[] arr, int loopIndex)
    {
        LinkedList<T> list = new LinkedList<T>();

        // Create nodes and add them to the list
        Node<T>[] nodes = new Node<T>[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            nodes[i] = new Node<T>(arr[i]);
            list.AddLast(nodes[i]);
        }

        if (loopIndex >= 0 && loopIndex < nodes.Length)
        {
            // Find the last node
            Node<T> curr = list.First;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            // Connect last node to the loop start node
            curr.Next = nodes[loopIndex];
        }

        return list;
    }

    // Test method to verify loop detection
    static void TestFindLoop<T>(LinkedList<T> list, bool expectedLoopResult)
    {
        try
        {
            bool hasLoop = list.FindLoop();

            Console.WriteLine(hasLoop == expectedLoopResult
                ? $"✓ Correctly detected loop: {hasLoop}"
                : $"✗ Expected loop to be {expectedLoopResult}, but got {hasLoop}");
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
    }
}