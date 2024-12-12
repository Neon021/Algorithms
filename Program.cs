public class Program
{
    public static void Main()
    {
        // Test Case 1: Empty List
        Console.WriteLine("Test Case 1: Empty List");
        var emptyList = new LinkedList<int>();
        var slow = emptyList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        emptyList.RemoveCycleFloydAlgoSlow(slow);
        emptyList.PrintList();
        Console.WriteLine();

        // Test Case 2: Single Node, No Cycle
        Console.WriteLine("Test Case 2: Single Node, No Cycle");
        var singleNodeList = new LinkedList<int>();
        singleNodeList.AddLast(new Node<int>(10));
        slow = singleNodeList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        singleNodeList.RemoveCycleFloydAlgoSlow(slow);
        singleNodeList.PrintList();
        Console.WriteLine();

        // Test Case 3: Single Node, Cycle
        Console.WriteLine("Test Case 3: Single Node, Cycle");
        var singleNodeCycle = new LinkedList<int>();
        var node = new Node<int>(20);
        node.Next = node; // Create a cycle
        singleNodeCycle.AddLast(node);
        slow = singleNodeCycle.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        singleNodeCycle.RemoveCycleFloydAlgoSlow(slow);
        singleNodeCycle.PrintList();
        Console.WriteLine();

        // Test Case 4: Two Nodes, No Cycle
        Console.WriteLine("Test Case 4: Two Nodes, No Cycle");
        var twoNodeList = new LinkedList<int>();
        twoNodeList.AddLast(new Node<int>(1));
        twoNodeList.AddLast(new Node<int>(2));
        slow = twoNodeList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        twoNodeList.RemoveCycleFloydAlgoSlow(slow);
        twoNodeList.PrintList();
        Console.WriteLine();

        // Test Case 5: Two Nodes, Cycle
        Console.WriteLine("Test Case 5: Two Nodes, Cycle");
        var twoNodeCycle = new LinkedList<int>();
        var node1 = new Node<int>(1);
        var node2 = new Node<int>(2);
        twoNodeCycle.AddLast(node1);
        twoNodeCycle.AddLast(node2);
        node2.Next = node1; // Create a cycle
        slow = twoNodeCycle.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        twoNodeCycle.RemoveCycleFloydAlgoSlow(slow);
        twoNodeCycle.PrintList();
        Console.WriteLine();

        // Test Case 6: Multiple Nodes, No Cycle
        Console.WriteLine("Test Case 6: Multiple Nodes, No Cycle");
        var noCycleList = new LinkedList<int>();
        noCycleList.AddLast(new Node<int>(1));
        noCycleList.AddLast(new Node<int>(2));
        noCycleList.AddLast(new Node<int>(3));
        noCycleList.AddLast(new Node<int>(4));
        slow = noCycleList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        noCycleList.RemoveCycleFloydAlgoSlow(slow);
        noCycleList.PrintList();
        Console.WriteLine();

        // Test Case 7: Multiple Nodes, Cycle in Middle
        Console.WriteLine("Test Case 7: Multiple Nodes, Cycle in Middle");
        var midCycleList = new LinkedList<int>();
        var midNode1 = new Node<int>(1);
        var midNode2 = new Node<int>(2);
        var midNode3 = new Node<int>(3);
        midCycleList.AddLast(midNode1);
        midCycleList.AddLast(midNode2);
        midCycleList.AddLast(midNode3);
        midNode3.Next = midNode2; // Create a cycle
        slow = midCycleList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        midCycleList.RemoveCycleFloydAlgoSlow(slow);
        midCycleList.PrintList();
        Console.WriteLine();

        // Test Case 8: Multiple Nodes, Cycle at End
        Console.WriteLine("Test Case 8: Multiple Nodes, Cycle at End");
        var endCycleList = new LinkedList<int>();
        var endNode1 = new Node<int>(1);
        var endNode2 = new Node<int>(2);
        var endNode3 = new Node<int>(3);
        endCycleList.AddLast(endNode1);
        endCycleList.AddLast(endNode2);
        endCycleList.AddLast(endNode3);
        endNode3.Next = endNode1; // Create a cycle
        slow = endCycleList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        endCycleList.RemoveCycleFloydAlgoSlow(slow);
        endCycleList.PrintList();
        Console.WriteLine();

        // Test Case 9: Very Large List with Cycle
        Console.WriteLine("Test Case 9: Very Large List with Cycle");
        var largeCycleList = new LinkedList<int>();
        Node<int>? first = null, middle = null;
        for (int i = 1; i <= 1000; i++)
        {
            var newNode = new Node<int>(i);
            if (i == 1) first = newNode;
            if (i == 500) middle = newNode;
            largeCycleList.AddLast(newNode);
        }
        largeCycleList.AddLast(middle!); // Create a cycle at node 500
        slow = largeCycleList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        largeCycleList.RemoveCycleFloydAlgoSlow(slow);
        largeCycleList.PrintList();
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

    public void RemoveCycleHashing()
    {
        Node<T>? prev = null;
        Node<T>? curr = this.First;
        HashSet<Node<T>> prevNodes = new();

        while (curr != null)
        {
            if (prevNodes.Contains(curr))
            {
                if (prev != null)
                {
                    prev.Next = null;
                }
                return;
            }


            prevNodes.Add(curr);
            prev = curr;
            curr = curr.Next;
        }
    }

    public Node<T>? FindLoop()
    {
        if (First == null)
            return null;

        Node<T>? leftIdx = First, rightIdx = First;

        while (leftIdx != null)
        {
            leftIdx = leftIdx.Next?.Next;
            rightIdx = rightIdx.Next;

            if (leftIdx == rightIdx)
                return rightIdx;
        }

        return null;
    }
    public void RemoveCycleFloydAlgoSlow(Node<T>? slow)
    {
        for (Node<T>? curr = this.First; curr != null; curr = curr.Next)
        {
            Node<T>? ptr = slow;
            //To make sure that ptr points to the first node in the cycle
            while (ptr?.Next != curr && ptr?.Next != slow)
                ptr = ptr?.Next;

            if (ptr?.Next == curr)
            {
                ptr.Next = null;
                return;
            }
        }
    }

    public void PrintList()
    {
        Node<T>? curr = First;
        HashSet<Node<T>> visited = new();
        while (curr != null)
        {
            Console.Write($"{curr.Data} -> ");
            if (visited.Contains(curr))
            {
                Console.WriteLine($"(cycle detected at {curr.Data})");
                break;
            }
            visited.Add(curr);
            curr = curr.Next;
        }

        if (curr == null)
            Console.WriteLine("null");
    }
}
