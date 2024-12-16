using static Algorithms;

public class Program
{
    public static void Main()
    {
        // Test Case 1: Both Lists Are Empty
        Console.WriteLine("Test Case 1: Both Lists Are Empty");
        var emptyList1 = new LinkedList<int>();
        var emptyList2 = new LinkedList<int>();
        var intersection = emptyList1.GetIntersectionNodeTwoPointer(emptyList2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 2: One List Is Empty
        Console.WriteLine("Test Case 2: One List Is Empty");
        var singleNodeList = new LinkedList<int>();
        singleNodeList.AddLast(new Node<int>(10));
        intersection = singleNodeList.GetIntersectionNodeTwoPointer(emptyList2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 3: Lists Do Not Intersect
        Console.WriteLine("Test Case 3: Lists Do Not Intersect");
        var list1 = new LinkedList<int>();
        list1.AddLast(new Node<int>(1));
        list1.AddLast(new Node<int>(2));
        list1.AddLast(new Node<int>(3));

        var list2 = new LinkedList<int>();
        list2.AddLast(new Node<int>(4));
        list2.AddLast(new Node<int>(5));
        list2.AddLast(new Node<int>(6));

        intersection = list1.GetIntersectionNodeTwoPointer(list2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 4: Lists Intersect at Single Node
        Console.WriteLine("Test Case 4: Lists Intersect at Single Node");
        var commonNode = new Node<int>(100);

        var intersectingList1 = new LinkedList<int>();
        intersectingList1.AddLast(new Node<int>(1));
        intersectingList1.AddLast(new Node<int>(2));
        intersectingList1.AddLast(commonNode);

        var intersectingList2 = new LinkedList<int>();
        intersectingList2.AddLast(new Node<int>(4));
        intersectingList2.AddLast(commonNode);

        intersection = intersectingList1.GetIntersectionNodeTwoPointer(intersectingList2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 5: Lists Intersect at Last Node
        Console.WriteLine("Test Case 5: Lists Intersect at Last Node");
        var lastNode = new Node<int>(999);

        var endIntersectingList1 = new LinkedList<int>();
        endIntersectingList1.AddLast(new Node<int>(10));
        endIntersectingList1.AddLast(new Node<int>(20));
        endIntersectingList1.AddLast(lastNode);

        var endIntersectingList2 = new LinkedList<int>();
        endIntersectingList2.AddLast(new Node<int>(30));
        endIntersectingList2.AddLast(lastNode);

        intersection = endIntersectingList1.GetIntersectionNodeTwoPointer(endIntersectingList2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 6: Lists Are Identical
        Console.WriteLine("Test Case 6: Lists Are Identical");
        var identicalList = new LinkedList<int>();
        identicalList.AddLast(new Node<int>(7));
        identicalList.AddLast(new Node<int>(8));
        identicalList.AddLast(new Node<int>(9));

        intersection = identicalList.GetIntersectionNodeTwoPointer(identicalList.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 7: One List Is Longer but No Intersection
        Console.WriteLine("Test Case 7: One List Is Longer but No Intersection");
        var longerList = new LinkedList<int>();
        longerList.AddLast(new Node<int>(1));
        longerList.AddLast(new Node<int>(2));
        longerList.AddLast(new Node<int>(3));
        longerList.AddLast(new Node<int>(4));
        longerList.AddLast(new Node<int>(5));

        var shorterList = new LinkedList<int>();
        shorterList.AddLast(new Node<int>(6));
        shorterList.AddLast(new Node<int>(7));

        intersection = longerList.GetIntersectionNodeTwoPointer(shorterList.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();

        // Test Case 8: Lists Intersect with Complex Structure
        Console.WriteLine("Test Case 8: Lists Intersect with Complex Structure");
        var complexNode1 = new Node<int>(101);
        var complexNode2 = new Node<int>(102);
        var complexNode3 = new Node<int>(103);

        var complexList1 = new LinkedList<int>();
        complexList1.AddLast(new Node<int>(1));
        complexList1.AddLast(complexNode1);
        complexList1.AddLast(complexNode2);
        complexList1.AddLast(complexNode3);

        var complexList2 = new LinkedList<int>();
        complexList2.AddLast(new Node<int>(4));
        complexList2.AddLast(new Node<int>(5));
        complexList2.AddLast(complexNode2);

        intersection = complexList1.GetIntersectionNodeTwoPointer(complexList2.First);
        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        Console.WriteLine();
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

    public Node<T>? GetIntersectionNodeHashing(Node<T>? otherListHead)
    {
        if (First != null)
        {
            Node<T>? currListHead = First;
            HashSet<Node<T>?> nodes = new();

            while (otherListHead != null)
            {
                nodes.Add(otherListHead);
                otherListHead = otherListHead.Next;
            }

            while (currListHead != null)
            {
                if (nodes.Contains(currListHead))
                    return currListHead;
                currListHead = currListHead.Next;
            }
        }

        return null;
    }

    public Node<T>? GetIntersectionNode(Node<T>? q)
    {
        if (q == null || First == null)
            return null;

        Node<T>? p = First;
        int currListCount = this.Count;
        int otherListCount = 0;

        var countPtr = q;
        while (countPtr != null)
        {
            otherListCount++;
            countPtr = countPtr.Next;
        }

        if (currListCount > otherListCount)
        {
            int skipCount = currListCount - otherListCount;
            while (p != null && skipCount != 0)
            {
                p = p.Next;
                skipCount--;
            }
        }
        else if (otherListCount > currListCount)
        {
            int skipCount = otherListCount - currListCount;
            while (q != null && skipCount != 0)
            {
                q = q.Next;
                skipCount--;
            }
        }

        while (p != null && q != null)
        {
            //If check before pointer assignemnt for identical lists.
            if (p == q)
                return p;
            p = p.Next;
            q = q.Next;
        }

        return null;
    }
    public Node<T>? GetIntersectionNodeTwoPointer(Node<T>? otherListHead)
    {
        if (First == null || otherListHead == null)
            return null;

        var ptr1 = First;
        var ptr2 = otherListHead;

        while (ptr1 != ptr2)
        {
            ptr1 = (ptr1 == null) ? otherListHead : ptr1.Next;
            ptr2 = (ptr2 == null) ? this.First : ptr2.Next;
        }

        return ptr1;
    }
}