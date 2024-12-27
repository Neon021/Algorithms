public class Program
{
    public static void Main()
    {
        Map<string> map = new(10);

        map.Insert("furkan");
        map.Insert("bilal");
        map.Insert("yigit");
        map.Insert("ilhan");
        map.Insert("nermin");
        map.Insert("tugba");
        map.Insert("taner");
        map.Insert("aykat");
        map.Insert("aykut");
        map.Insert("aymaz");
        if (map.GetEntry("aykat") is Node<string> existingNode)
            Console.WriteLine(existingNode.Data);
        if (map.GetEntry("ilhan") is Node<string> existingNode1)
            Console.WriteLine(existingNode1.Data);

        map.Insert("ayaz");

        if (map.GetEntry("aykat") is Node<string> existingNode2)
            Console.WriteLine(existingNode2.Data);
        if (map.GetEntry("ilhan") is Node<string> existingNode3)
            Console.WriteLine(existingNode3.Data);
    }
}
public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; internal set; }
    public Node<T>? Prev { get; internal set; }
    //public Node<T>? Random { get; internal set; }

    public Node(T data)
    {
        this.Data = data;
    }
}

public class LinkedList<T>
{
    public Node<T>? Head { get; private set; }
    public Node<T>? Tail { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        this.Head = null;
        this.Tail = null;
    }

    public void AddFirst(Node<T> newNode)
    {
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = this.Head;
            Head!.Prev = newNode;
            this.Head = newNode;
        }
        Count++;
    }
    public void AddLast(Node<T> newNode)
    {
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Prev = this.Tail;
            Tail!.Next = newNode;
            this.Tail = newNode;
        }

        Count++;
    }

    public Node<T>? GetNode(T data)
    {
        if (Head == null)
            return null;
        else if (Count == 1)
            return Head;

        Node<T>? headNode = this.Head;
        Node<T>? tailNode = this.Tail;

        //In order to avoid making Map Get O(N) worst case we can mitigate it by dividing.
        while (headNode!.Next != null && !headNode.Data!.Equals(data) && tailNode!.Prev != null && !tailNode.Data!.Equals(data))
        {
            headNode = headNode.Next;
            tailNode = tailNode.Next;
        }

        if (headNode!.Data!.Equals(data))
            return headNode;
        else
            return tailNode;
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

        Node<T>? curr = Head;
        while (curr.Next != null && randIndex != 0)
        {
            curr = curr.Next;
            randIndex--;
        }
        //node.Random = curr;
    }
}

public class Map<T>
{
    private int _capacity = 0;
    private int _length = 0;
    private readonly ArrayListForMap<T> _arrayList;

    public Map(int capacity)
    {
        _capacity = capacity;
        _arrayList = new ArrayListForMap<T>(_capacity);
    }

    public void Insert(T data)
    {
        if (data == null)
            return;

        Node<T> newEntry = new(data);
        if (_length + 1 >= _capacity)
            _capacity *= 2;

        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        bool didResize = _arrayList.Push(newEntry, index);
        if (didResize)
            _length++;
    }

    public Node<T>? GetEntry(T data)
    {
        if (data == null)
            return null;

        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        return _arrayList.Get(index, data);
    }
}

public class ArrayListForMap<T>
{
    public int Length { get; set; } = 0;
    public int Capacity { get; set; }
    private LinkedList<T>[] Array { get; set; }

    public ArrayListForMap(int Capacity)
    {
        this.Capacity = Capacity;
        Array = new LinkedList<T>[Capacity];
    }

    public Node<T>? Get(int index, T data)
    {
        int checkedIndex = index != -1 && index <= Capacity ? index : Length;

        if (Array[checkedIndex] is LinkedList<T> linkedList)
        {
            return linkedList.GetNode(data);
        }
        return null;
    }

    public bool Push(Node<T> newNode, int index = -1)
    {
        if (Length + 1 <= Capacity)
        {
            int insertIndex = index != -1 && index <= Capacity ? index : Length;

            //CHECK COLLISION
            //rather than checking here, we utilize double linked list to store values with the same hash value.
            LinkedList<T> linkedList = this.Array[insertIndex];
            if (linkedList is not LinkedList<T> _)
            {
                linkedList = new();
                //Only increment length when a new linked list is created
                Length++;
            }

            linkedList.AddLast(newNode);
            this.Array[insertIndex] = linkedList;
            //Length++;

            return false;
        }
        else
        {
            Capacity *= 2;
            LinkedList<T>[] newArray = new LinkedList<T>[Capacity];

            //COPY EXISTING LINKEDLISTS FROM THE OLD ARRAY
            //Not just copy existing linked lists based on their head values hash,
            //Rather iterate through each node and calculate new index'.
            foreach (var list in Array)
            {
                if (list == null)
                    continue;

                Node<T>? currNode = list.Head;
                while (currNode is Node<T> _)
                {
                    int newIndex = Math.Abs(currNode.Data!.GetHashCode() % Capacity);

                    if (newArray[newIndex] == null)
                        newArray[newIndex] = new();

                    newArray[newIndex].AddLast(new Node<T>(currNode.Data));
                    currNode = currNode.Next;
                }
            }

            int newNodeIndex = Math.Abs(newNode.Data!.GetHashCode() % Capacity);
            //INSERT NEW ELEMENT
            if (newArray[newNodeIndex] is not LinkedList<T> _)
            {
                newArray[newNodeIndex] = new LinkedList<T>();
                //Only increment length when a new linked list is created
                Length++;
            }

            newArray[newNodeIndex].AddLast(newNode);
            //Length++;

            this.Array = newArray;

            return true;
        }
    }
}