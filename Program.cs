public class Codewars
{
    static void Main(string[] args)
    {
        // Test Case 1: Empty List Reversal
        Console.WriteLine("Test Case 1: Empty List");
        TestReversal(new LinkedList<int>());

        // Test Case 2: Single Element List
        Console.WriteLine("\nTest Case 2: Single Element List");
        var singleElementList = new LinkedList<int>();
        singleElementList.AddLast(new Node<int>(42));
        TestReversal(singleElementList);

        // Test Case 3: Two Element List
        Console.WriteLine("\nTest Case 3: Two Element List");
        var twoElementList = new LinkedList<int>();
        twoElementList.AddLast(new Node<int>(1));
        twoElementList.AddLast(new Node<int>(2));
        TestReversal(twoElementList);

        // Test Case 4: Multiple Element List
        Console.WriteLine("\nTest Case 4: Multiple Element List");
        var multiElementList = new LinkedList<int>();
        multiElementList.AddLast(new Node<int>(1));
        multiElementList.AddLast(new Node<int>(2));
        multiElementList.AddLast(new Node<int>(3));
        multiElementList.AddLast(new Node<int>(4));
        multiElementList.AddLast(new Node<int>(5));
        TestReversal(multiElementList);
    }

    // Helper method to test list reversal and print results
    static void TestReversal(LinkedList<int> list)
    {
        // Print original list
        Console.WriteLine("Original List:");
        PrintList(list.First);
        Console.WriteLine($"Original Count: {list.Count}");

        // Reverse the list
        list.RecursiveReverse(list.First);

        // Print reversed list
        Console.WriteLine("Reversed List:");
        PrintList(list.First);
        Console.WriteLine($"Reversed Count: {list.Count}");
    }

    // Helper method to print the list
    static void PrintList(Node<int>? head)
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

        public void RecursiveReverse(Node<T>? currentNode, Node<T>? previousNode = null)
        {
            if (currentNode == null)
                First = previousNode;
            else
            {
                Node<T>? prev = previousNode;
                Node<T>? currNode = currentNode;
                Node<T>? nextNode = currNode.Next;

                currentNode.Next = prev;
                prev = currentNode;
                currNode = nextNode;

                RecursiveReverse(currNode, prev);
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