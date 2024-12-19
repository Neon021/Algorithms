public class Program
{
    public static void Main()
    {
        LinkedList<int> linkedList = new LinkedList<int>();

        // Adding nodes to the linked list
        Node<int> node1 = new Node<int>(1);
        linkedList.AddLast(node1);

        Node<int> node2 = new Node<int>(2);
        linkedList.AddLast(node2);

        Node<int> node3 = new Node<int>(3);
        linkedList.AddLast(node3);

        Node<int> node4 = new Node<int>(4);
        linkedList.AddLast(node4);

        Node<int> node5 = new Node<int>(5);
        linkedList.AddLast(node5);

        linkedList.AssignRandomPointer(ref node1);

        // Print the linked list along with random pointers
        Console.WriteLine("Linked List with Random Pointers:");
        Node<int>? current = linkedList.First;
        while (current != null)
        {
            string randomPointerData = current.Random != null ? current.Random.Data.ToString() : "null";
            Console.WriteLine($"Node Data: {current.Data}, Next Data: {current.Next?.Data}, Random Pointer Data: {randomPointerData}");
            current = current.Next;
        }

        Console.WriteLine();

        var newListHead = CloneLinkedList(node1);
        while (newListHead != null)
        {
            string randomPointerData = newListHead.Random != null ? newListHead.Random.Data.ToString() : "null";
            string nextPointerData = newListHead.Next != null ? newListHead.Next.Data.ToString() : "null";
            Console.WriteLine($"Node Data: {newListHead.Data}, Next Data: {nextPointerData}, Random Pointer Data: {randomPointerData}");
            newListHead = newListHead.Next;
        }
    }

    public static Node<int>? CloneLinkedList(Node<int>? head)
    {
        Dictionary<Node<int>, Node<int>> mapping = new();
        return CloneListHelper(head, mapping);

        static Node<int>? CloneListHelper(Node<int>? currNode, Dictionary<Node<int>, Node<int>> map)
        {
            if (currNode == null)
                return null;

            //If the currNode has already been cloned.
            if (map.ContainsKey(currNode))
                return map[currNode];

            Node<int> newNode = new(currNode.Data);
            map[currNode] = newNode;

            newNode.Next = CloneListHelper(currNode.Next, map);
            newNode.Random = CloneListHelper(currNode.Random, map);

            return newNode;
        }
    }
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; internal set; }
    public Node<T>? Random { get; internal set; }

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
        AssignRandomPointer(ref node);
    }

    public void AssignRandomPointer(ref Node<T> node)
    {
        //First != null would supress warning with the curr but we are sure that First is not null from AddLast here!
        if (Count == 1)
            return;

        Random random = new();
        int randIndex = random.Next(0, Count + 1);
        if (randIndex == 0)
            randIndex++;

        Node<T>? curr = First;
        while (curr.Next != null && randIndex != 0)
        {
            curr = curr.Next;
            randIndex--;
        }
        node.Random = curr;
    }
}