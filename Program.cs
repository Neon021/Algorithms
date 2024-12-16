public class Program
{
    public static void Main()
    {
        Node<int>? mergedList = null;

        // Test Case 3: One Node in Each List
        Console.WriteLine("Test Case 3: One Node in Each List");
        var singleNodeA = new Node<int>(5);
        var singleNodeB = new Node<int>(10);
        mergedList = MergeLinkedLists(singleNodeA, singleNodeB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 4: Multiple Nodes in Each List, No Overlap
        Console.WriteLine("Test Case 4: Multiple Nodes in Each List, No Overlap");
        var listA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        var listB = new Node<int>(6) { Next = new Node<int>(8) { Next = new Node<int>(10) } };
        mergedList = MergeLinkedLists(listA, listB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 5: Multiple Nodes in Each List, Overlapping Values
        Console.WriteLine("Test Case 5: Multiple Nodes in Each List, Overlapping Values");
        var overlappingListA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        var overlappingListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(6) } };
        mergedList = MergeLinkedLists(overlappingListA, overlappingListB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 6: One List Is Subset of the Other
        Console.WriteLine("Test Case 6: One List Is Subset of the Other");
        var subsetListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        var subsetListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(4) } };
        mergedList = MergeLinkedLists(subsetListA, subsetListB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 7: Lists with Identical Elements
        Console.WriteLine("Test Case 7: Lists with Identical Elements");
        var identicalListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        var identicalListB = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        mergedList = MergeLinkedLists(identicalListA, identicalListB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();
    }

    // Helper Function to Print a Linked List
    public static void PrintList(Node<int>? head)
    {
        while (head != null)
        {
            Console.Write(head.Data + " -> ");
            head = head.Next;
        }
        Console.WriteLine("null");
    }

    public static Node<int>? MergeLinkedLists(Node<int>? headA, Node<int>? headB)
    {
        //Base case is, we arrived at the end of one of the lists.
        if (headA == null)
            return headB;
        else if (headB == null)
            return headA;

        Node<int>? res = null;

        if (headA.Data < headB.Data)
        {
            res = headA;
            res.Next = MergeLinkedLists(headA.Next, headB);
        }
        else
        {
            res = headB;
            res.Next = MergeLinkedLists(headA, headB.Next);
        }

        return res;
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
    public int Count { get; private set; }

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
}