using static Algorithms;

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

    //DRAW MEMORY
    public static Node<int>? CloneLinkedListRecursiveFast(Node<int>? head)
    {
        // Dictionary provides O(1) lookup with minimal memory overhead
        Dictionary<Node<int>, Node<int>> mapping = new();
        return CloneListHelper(head, mapping);

        static Node<int>? CloneListHelper(Node<int>? currNode, Dictionary<Node<int>, Node<int>> map)
        {
            if (currNode == null)
                return null;

            //TryGetValue to avoid double lookup
            if (map.TryGetValue(currNode, out Node<int>? value))
            {
                Console.WriteLine($"This node has already been cloned! {value.Data}");
                return value;
            }

            Console.WriteLine($"This node hasn't been cloned! {currNode.Data}");
            // Create new node only once per original node
            Node<int> newNode = new(currNode.Data);
            map[currNode] = newNode;  // Store mapping immediately to prevent cycles

            newNode.Next = CloneListHelper(currNode.Next, map);
            //Recursive call for random pointers reuse existing nodes through dictionary lookup
            newNode.Random = CloneListHelper(currNode.Random, map);

            return newNode;
        }
    }

    public static Node<int>? CloneLinkedListRecursiveSlow(Node<int>? head)
    {
        List<Node<int>> mapping = new();
        return CloneListHelper(head, mapping);

        static Node<int>? CloneListHelper(Node<int>? currNode, List<Node<int>> map)
        {
            if (currNode == null)
                return null;

            //If the currNode has already been cloned.
            if (map.Where(n => n.Data == currNode.Data).FirstOrDefault() is Node<int> existingNode)
                return existingNode;

            Node<int> newNode = new(currNode.Data);
            map.Add(newNode);

            newNode.Next = CloneListHelper(currNode.Next, map);
            newNode.Random = CloneListHelper(currNode.Random, map);

            return newNode;
        }
    }

    //Violates "None of the pointers in the new list should point to nodes in the original list" rule
    //DRAW MEMORY FOR THIS AS WELL. TO SEE REFERENCES TO OLD LIST NODES
    public static Node<int>? CloneLinkedListStupidWay(Node<int> head)
    {
        if (head == null)
            return null;

        Node<int>? currOriginal = head;
        Node<int>? clonedHead = null;
        Node<int>? currClonedHead = null;
        //This is stupid, there should be a way to do it with references.
        int i = 0;

        while (currOriginal != null)
        {
            if (clonedHead == null)
            {
                clonedHead = new(currOriginal.Data)
                {
                    Next = null,
                    Random = currOriginal.Random
                };
                currOriginal = currOriginal.Next;
                i++;
            }
            else
            {
                currClonedHead = new(currOriginal.Data)
                {
                    Next = currOriginal.Next,
                    Random = currOriginal.Random
                };
                i++;
                if (i == 2)
                    clonedHead.Next = currClonedHead;

                currClonedHead = currClonedHead.Next;
                currOriginal = currOriginal.Next;
            }
        }

        return clonedHead;
    }

    //Violates "None of the pointers in the new list should point to nodes in the original list" rule
    //DRAW MEMORY FOR THIS AS WELL. TO SEE REFERENCES TO OLD LIST NODES
    public static Node<int>? CloneLinkedListSmarterWay(Node<int> head)
    {
        if (head == null)
            return null;

        Node<int>? currOriginal = head;
        Node<int>? clonedHead = null;
        Node<int>? previousCloned = null;  // Keep track of the last Node<int> we created

        while (currOriginal != null)
        {
            Node<int> newNode = new(currOriginal.Data)
            {
                Random = currOriginal.Random
            };

            if (clonedHead == null)
                clonedHead = newNode;
            else
                previousCloned!.Next = newNode;


            // Update previous Node<int> for next iteration
            previousCloned = newNode;
            currOriginal = currOriginal.Next;
        }

        return clonedHead;
    }

    public static Node<int>? CloneLinkedListWhyDaFuckWay(Node<int> head)
    {
        if (head == null)
            return null;

        Node<int>? curr = head;
        while (curr != null)
        {
            Node<int> newNode = new(curr.Data)
            {
                Next = curr.Next
            };
            curr.Next = newNode;
            curr = newNode.Next;
        }

        curr = head;
        while (curr != null)
        {
            if (curr.Random != null)
                curr.Next!.Random = curr.Random.Next;
            curr = curr.Next?.Next;
        }

        // Separate the new nodes from the original nodes
        curr = head;
        Node<int>? clonedHead = head.Next;
        Node<int>? clone = clonedHead;
        while (clone?.Next != null)
        {

            // Update the next nodes of original node 
            // and cloned node
            curr!.Next = curr?.Next?.Next;
            clone.Next = clone.Next.Next;

            // Move pointers of original as well as  
            // cloned linked list to their next nodes
            curr = curr?.Next;
            clone = clone.Next;
        }
        curr!.Next = null;
        clone!.Next = null;

        return clonedHead;
    }

    //DRAW MEMORY
    public static Node<int>? CloneLinkedListGeniusWay(Node<int> head)
    {
        if (head == null)
            return null;

        Dictionary<Node<int>, Node<int>> mapping = new();

        Node<int>? curr = head;
        while (curr != null)
        {
            Node<int> newNode = new(curr.Data);
            mapping[curr] = newNode;
            curr = curr.Next;
        }

        foreach (var kvp in mapping)
        {
            Node<int> currNode = kvp.Value;
            currNode.Next = kvp.Key.Next != null ? mapping[kvp.Key.Next] : null;
            currNode.Random = kvp.Key.Random != null ? mapping[kvp.Key.Random] : null;
        }

        return mapping[head];
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