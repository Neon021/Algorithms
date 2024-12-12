using static Algorithms;

public class Program
{
    public static void Main()
    {
        // Test Case 1: Empty List
        Console.WriteLine("Test Case 1: Empty List");
        var emptyList = new LinkedList<int>();
        var slow = emptyList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        emptyList.RemoveCycleFloydAlgoFast(slow);
        emptyList.PrintList();
        Console.WriteLine();

        // Test Case 2: Single Node, No Cycle
        Console.WriteLine("Test Case 2: Single Node, No Cycle");
        var singleNodeList = new LinkedList<int>();
        singleNodeList.AddLast(new Node<int>(10));
        slow = singleNodeList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        singleNodeList.RemoveCycleFloydAlgoFast(slow);
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
        singleNodeCycle.RemoveCycleFloydAlgoFast(slow);
        singleNodeCycle.PrintList();
        Console.WriteLine();

        // Test Case 4: Two Nodes, No Cycle
        Console.WriteLine("Test Case 4: Two Nodes, No Cycle");
        var twoNodeList = new LinkedList<int>();
        twoNodeList.AddLast(new Node<int>(1));
        twoNodeList.AddLast(new Node<int>(2));
        slow = twoNodeList.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        twoNodeList.RemoveCycleFloydAlgoFast(slow);
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
        twoNodeCycle.RemoveCycleFloydAlgoFast(slow);
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
        noCycleList.RemoveCycleFloydAlgoFast(slow);
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
        midCycleList.RemoveCycleFloydAlgoFast(slow);
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
        endCycleList.RemoveCycleFloydAlgoFast(slow);
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
        largeCycleList.RemoveCycleFloydAlgoFast(slow);
        largeCycleList.PrintList();
        Console.WriteLine();

        // Test Case 10: Multiple Nodes, Cycle at middle
        Console.WriteLine("Test Case 10: Multiple Nodes, Cycle at middle");
        var cycleMiddle = new LinkedList<int>();
        var cycleMiddleNode1 = new Node<int>(1);
        var cycleMiddleNode2 = new Node<int>(2);
        var cycleMiddleNode3 = new Node<int>(3);
        var cycleMiddleNode4 = new Node<int>(4);
        var cycleMiddleNode5 = new Node<int>(5);
        var cycleMiddleNode6 = new Node<int>(6);
        var cycleMiddleNode7 = new Node<int>(7);
        cycleMiddle.AddLast(cycleMiddleNode1);
        cycleMiddle.AddLast(cycleMiddleNode2);
        cycleMiddle.AddLast(cycleMiddleNode3);
        cycleMiddle.AddLast(cycleMiddleNode4);
        cycleMiddle.AddLast(cycleMiddleNode5);
        cycleMiddle.AddLast(cycleMiddleNode6);
        cycleMiddle.AddLast(cycleMiddleNode7);
        cycleMiddleNode7.Next = cycleMiddleNode3; // Create a cycle
        slow = cycleMiddle.FindLoop();
        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        cycleMiddle.RemoveCycleFloydAlgoFast(slow);
        var fiirst = cycleMiddle.First;
        while(fiirst != null)
        {
            Console.WriteLine(fiirst.Data);
            fiirst = fiirst.Next;
        }
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
            //NO THE ABOVE REASON IS NOT THE CASE FOR THIS WHIILE LOOP

            //Instead, it's here to get the "ptr" to the Node whose "Next" is "curr"; which will be the node that starts the cycle
            //In short, to find the node that points to the "curr" node
            //Also the reason for "&&" is to avoid stucking in the while loop
            //since "slow" doesn't guaranteed to point to the first node in the cycle,
            //it might be pointing to a middle node in the cycle.
            //FOR EXAMPLE
            //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
            //          ↑-------------------←
            //"curr" would be "1"
            //and "ptr" could be "6".
            //In that case, the first condition of the while will *never* be false
            //so we need to check if we circled back to "slow" pointer.
            //Actually, most of the time the second condition will break the loop;
            //in cases of where the first node is incorporated in the cycle,
            //that's when the first condition will be helpful.

            while (ptr?.Next != curr && ptr?.Next != slow)
                ptr = ptr?.Next;


            //When the "curr" will get to "3" this condiiton will be met
            if (ptr?.Next == curr)
            {
                ptr.Next = null;
                return;
            }
        }
    }

    public void RemoveCycleFloydAlgoFast(Node<T>? slow)
    {
        //FOR EXAMPLE
        //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
        //          ↑-------------------←


        //count of nodes in the cycle
        //k = 5
        int k = 1;
        //Condition here is Next not being slow since slow can be any node in the cycle.
        for (Node<T>? ptr = slow; ptr?.Next != slow; ptr = ptr?.Next)
            k++;

        //Get a pointer to the kth node starting from the head
        //curr = 6
        //why do we need the for loop tho? can't we just set curr to slow?
        //Node<T>? curr = slow;
        //Because slow is not guaranteed to be the first node in the cycle.
        Node<T>? curr = First;
        for (int i = 0; i < k; i++)
            curr = curr?.Next;

        Node<T>? head = this.First;
        //Capture the first node of the cycle!
        while (curr != head)
        {
            curr = curr?.Next;
            head = head?.Next;
        }

        //Go to the end node of the cycle.
        //Can we do it "k" times with for loop?
        //while (curr?.Next != head)
        //    curr = curr?.Next;
        for (int i = 1; i <= k; i++)
            curr = curr?.Next;

        if (curr != null)
            curr.Next = null;
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
