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

    public static Node<int>? MergeLinkedListsRecursive(Node<int>? headA, Node<int>? headB)
    {
        //Base case is, we arrived at the end of one of the lists.
        if (headA == null)
            return headB;
        else if (headB == null)
            return headA;

        Node<int>? res;
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
            if (headA.Data < headB.Data)
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

    public static Node<int> MergeLinkedLists(Node<int> headA, Node<int> headB)
    {
        if (headA == null)
            return headB;
        if (headB == null)
            return headA;

        if (headA.Data < headB.Data)
            return MergeLinkedListsInPlace(headA, headB);
        else
            return MergeLinkedListsInPlace(headB, headA);
    }
    public static Node<int> MergeLinkedListsInPlace(Node<int> headA, Node<int> headB)
    {
        //Example
        // headA -> 1 -> 3 -> 5
        // headB -> 2 -> 4 -> 6
        if (headA.Next == null)
        {
            headA.Next = headB;
            return headA;
        }

        //        1              3
        Node<int> curr1 = headA, next1 = headA.Next;
        //         2              4
        Node<int>? curr2 = headB, next2 = headB.Next;

        while (next1 != null && curr2 != null)
        {
            //if the head of the second list is between head of the first list and its next in terms of value
            if (curr2.Data >= curr1.Data && curr2.Data <= next1.Data)
            {
                //This here is to save us from infinite while loop
                //Now that we have concluded that the head of the second list is between head of the first list and its next
                //we are going to put it between the first and its next element in the first list.
                //As a result, the next value of the head of the second list will be altered.
                //Before that happens we need to establish a pointer to it so that or conneciton to rest of the second list persists.
                next2 = curr2.Next;

                //Put the head of the second list between the head and its next object of the first list
                curr1.Next = curr2;
                curr2.Next = next1;

                //So, after pointing to the head of the second list from curr1Next we should also update curr1 and curr2's pointee right?
                curr1 = curr2; //Remember we dont set curr1 as the head of the second list, we point to the object on the heap!
                curr2 = next2;
            }
            else
            {
                //If there are more than 2 nodes in the first list and the first two nodes are smaller than the first node in the second list.
                if (next1.Next != null)
                {
                    next1 = next1.Next;
                    curr1 = curr1.Next;
                }
                else
                {
                    //if only 2 nodes exist in the first list and they are both smaller than the first node in the second list.
                    //Just point the rest of the first list to the head of the second list
                    next1.Next = curr2;
                    return headA;
                }
            }
        }

        return headA;
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