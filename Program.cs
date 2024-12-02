public class Codewars
{
    static void Main(string[] args)
    {
        // Test Case 1: Empty List Reversal
        Console.WriteLine("Test Case 1: Empty List");
        TestReversal(new DoublyLinkedList<int>());

        // Test Case 2: Single Element List
        Console.WriteLine("\nTest Case 2: Single Element List");
        var singleElementList = new DoublyLinkedList<int>();
        singleElementList.AddLast(new Node<int>(42));
        TestReversal(singleElementList);

        // Test Case 3: Two Element List
        Console.WriteLine("\nTest Case 3: Two Element List");
        var twoElementList = new DoublyLinkedList<int>();
        twoElementList.AddLast(new Node<int>(1));
        twoElementList.AddLast(new Node<int>(2));
        TestReversal(twoElementList);

        // Test Case 4: Multiple Element List
        Console.WriteLine("\nTest Case 4: Multiple Element List");
        var multiElementList = new DoublyLinkedList<int>();
        multiElementList.AddLast(new Node<int>(1));
        multiElementList.AddLast(new Node<int>(2));
        multiElementList.AddLast(new Node<int>(3));
        multiElementList.AddLast(new Node<int>(4));
        multiElementList.AddLast(new Node<int>(5));
        TestReversal(multiElementList);
    }

    // Helper method to test list reversal and print results
    static void TestReversal(DoublyLinkedList<int> list)
    {
        // Print original list (forward)
        Console.WriteLine("Original List (Forward):");
        PrintListForward(list.First);
        Console.WriteLine($"Original Count: {list.Count}");

        // Print original list (backward)
        Console.WriteLine("\nOriginal List (Backward):");
        PrintListBackward(GetLastNode(list.First));

        // Reverse the list
        list.Reverse();

        // Print reversed list (forward)
        Console.WriteLine("\nReversed List (Forward):");
        PrintListForward(list.First);

        // Print reversed list (backward)
        Console.WriteLine("\nReversed List (Backward):");
        PrintListBackward(GetLastNode(list.First));

        Console.WriteLine($"Reversed Count: {list.Count}");
    }

    // Helper method to print the list forward
    static void PrintListForward(Node<int>? head)
    {
        if (head == null)
        {
            Console.WriteLine("Empty list");
            return;
        }

        Node<int>? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Helper method to print the list backward
    static void PrintListBackward(Node<int>? tail)
    {
        if (tail == null)
        {
            Console.WriteLine("Empty list");
            return;
        }

        Node<int>? current = tail;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Previous;
        }
        Console.WriteLine("null");
    }

    // Helper method to get the last node
    static Node<int>? GetLastNode(Node<int>? head)
    {
        if (head == null) return null;

        Node<int>? current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        return current;
    }


    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; internal set; }
        public Node<T>? Previous { get; internal set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }
    public class DoublyLinkedList<T>
    {
        public Node<T>? First { get; private set; }
        public int Count { get; set; }

        public DoublyLinkedList()
        {
            this.First = null;
        }
        public void AddLast(Node<T> node)
        {
            if (First == null)
                First = node;
            else if (Count == 1)
            {
                First.Next = node;
                node.Previous = First;
            }
            else
            {
                Node<T>? curr = First;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = node;
                node.Previous = curr;
            }

            Count++;
        }

        public void Reverse()
        {
            if (Count <= 1)
                return;

            Node<T>? currNode = First;
            Node<T>? nextNode = First?.Next;
            Node<T>? prevNode = First?.Previous;

            //we could've used do/while but for that we should've cheked the null status of currNode before
            //since we utilize the nullable types feature of C# we skip that.
            while (currNode != null)
            {
                currNode.Previous = nextNode;
                currNode.Next = prevNode;
                if (currNode.Previous != null)
                {
                    currNode = nextNode;

                    nextNode = currNode?.Next;
                    prevNode = currNode?.Previous;
                }
                else
                {
                    First = currNode;
                    currNode = null;
                }
            }
        }
    }
}