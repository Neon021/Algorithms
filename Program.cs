using static Algorithms;

public class Program
{
    public static void Main()
    {
        Node<int>? mergedList = null;

        // Test Case 3: One Node in Each List
        Console.WriteLine("Test Case 3: One Node in Each List");
        var singleNodeA = new Node<int>(5);
        var singleNodeB = new Node<int>(10);
        mergedList = MergeLinkedListsImperative(singleNodeA, singleNodeB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 4: Multiple Nodes in Each List, No Overlap
        Console.WriteLine("Test Case 4: Multiple Nodes in Each List, No Overlap");
        var listA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        var listB = new Node<int>(6) { Next = new Node<int>(8) { Next = new Node<int>(10) } };
        mergedList = MergeLinkedListsImperative(listA, listB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 5: Multiple Nodes in Each List, Overlapping Values
        Console.WriteLine("Test Case 5: Multiple Nodes in Each List, Overlapping Values");
        var overlappingListA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        var overlappingListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(6) } };
        mergedList = MergeLinkedListsImperative(overlappingListA, overlappingListB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 6: One List Is Subset of the Other
        Console.WriteLine("Test Case 6: One List Is Subset of the Other");
        var subsetListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        var subsetListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(4) } };
        mergedList = MergeLinkedListsImperative(subsetListA, subsetListB);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);
        Console.WriteLine();

        // Test Case 7: Lists with Identical Elements
        Console.WriteLine("Test Case 7: Lists with Identical Elements");
        var identicalListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        var identicalListB = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        mergedList = MergeLinkedListsImperative(identicalListA, identicalListB);
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

    public static Node<int>? MergeLinkedListsRecursive(Node<int>? headA, Node<int>? headB)
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
            res.Next = MergeLinkedListsRecursive(headA.Next, headB);
        }
        else
        {
            res = headB;
            res.Next = MergeLinkedListsRecursive(headA, headB.Next);
        }

        return res;
    }
    public static Node<int> MergeLinkedListsImperative(Node<int> headA, Node<int> headB)
    {
        //REMEMBER! THESE ARE POINTERS TO OBJECTS ON THE HEAP NOT SEPARATE ENTITIES!!!
        Node<int> dummyNode = new(default);
        Node<int> currNode = dummyNode;

        while (headA != null && headB != null)
        {
            if(headA.Data < headB.Data)
            {
                currNode.Next = headA;
                //This would create another object on the heap
                //currNode.Next = new(headA.Data);
                headA = headA.Next;
            }
            else
            {
                currNode.Next = headB;
                headB = headB.Next;
            }

            currNode = currNode.Next;
        }

        currNode.Next = headA ?? headB;

        return dummyNode.Next;
    }
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new();
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        current.next = list1 ?? list2;

        return dummy.next;
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