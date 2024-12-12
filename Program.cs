public class Program
{
    public static void Main()
    {
        Console.WriteLine("Test Case 1: Empty List");
        var emptyList = new LinkedList<int>();
        Console.WriteLine("Before:");
        emptyList.PrintList();
        emptyList.RemoveCycleHashing();
        Console.WriteLine("After:");
        emptyList.PrintList();
        Console.WriteLine();

        Console.WriteLine("Test Case 2: Single Node, No Cycle");
        var singleNodeList = new LinkedList<int>();
        singleNodeList.AddLast(new Node<int>(10));
        Console.WriteLine("Before:");
        singleNodeList.PrintList();
        singleNodeList.RemoveCycleHashing();
        Console.WriteLine("After:");
        singleNodeList.PrintList();
        Console.WriteLine();

        Console.WriteLine("Test Case 3: Single Node, Cycle");
        var singleNodeCycle = new LinkedList<int>();
        var node = new Node<int>(20);
        node.Next = node; // Create a cycle
        singleNodeCycle.AddLast(node);
        Console.WriteLine("Before:");
        singleNodeCycle.PrintList();
        singleNodeCycle.RemoveCycleHashing();
        Console.WriteLine("After:");
        singleNodeCycle.PrintList();
        Console.WriteLine();

        Console.WriteLine("Test Case 4: Multiple Nodes, No Cycle");
        var noCycleList = new LinkedList<int>();
        noCycleList.AddLast(new Node<int>(1));
        noCycleList.AddLast(new Node<int>(2));
        noCycleList.AddLast(new Node<int>(3));
        Console.WriteLine("Before:");
        noCycleList.PrintList();
        noCycleList.RemoveCycleHashing();
        Console.WriteLine("After:");
        noCycleList.PrintList();
        Console.WriteLine();

        Console.WriteLine("Test Case 5: Multiple Nodes, Cycle in Middle");
        var midCycleList = new LinkedList<int>();
        var node1 = new Node<int>(1);
        var node2 = new Node<int>(2);
        var node3 = new Node<int>(3);
        midCycleList.AddLast(node1);
        midCycleList.AddLast(node2);
        midCycleList.AddLast(node3);
        node3.Next = node2; // Create a cycle
        Console.WriteLine("Before:");
        midCycleList.PrintList();
        midCycleList.RemoveCycleHashing();
        Console.WriteLine("After:");
        midCycleList.PrintList();
        Console.WriteLine();

        Console.WriteLine("Test Case 6: Multiple Nodes, Cycle at End");
        var fullCycleList = new LinkedList<int>();
        var nodeA = new Node<int>(1);
        var nodeB = new Node<int>(2);
        var nodeC = new Node<int>(3);
        fullCycleList.AddLast(nodeA);
        fullCycleList.AddLast(nodeB);
        fullCycleList.AddLast(nodeC);
        nodeC.Next = nodeA; // Create a full cycle
        Console.WriteLine("Before:");
        fullCycleList.PrintList();
        fullCycleList.RemoveCycleHashing();
        Console.WriteLine("After:");
        fullCycleList.PrintList();
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
