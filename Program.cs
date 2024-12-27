public class Program
{
    public static void Main()
    {
        //Map<string> map = new(10);

        //map.Insert("furkan");
        //map.Insert("bilal");
        //map.Insert("yigit");
        //map.Insert("ilhan");
        //map.Insert("nermin");
        //map.Insert("tugba");
        //map.Insert("taner");
        //map.Insert("aykat");
        //map.Insert("aykut");
        //map.Insert("aymaz");
        //if (map.GetEntry("aykat") is Node<string> existingNode)
        //    Console.WriteLine(existingNode.Data);
        //if (map.GetEntry("ilhan") is Node<string> existingNode1)
        //    Console.WriteLine(existingNode1.Data);

        //map.Insert("ayaz");

        //if (map.GetEntry("aykat") is Node<string> existingNode2)
        //    Console.WriteLine(existingNode2.Data);
        //if (map.GetEntry("ilhan") is Node<string> existingNode3)
        //    Console.WriteLine(existingNode3.Data);

        LRU<string> lruCache = new(5);
        lruCache.Insert("furkan");
        lruCache.Insert("bilal");
        lruCache.Insert("yigit");
        lruCache.Insert("ilhan");
        lruCache.Insert("nermin");
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
    private readonly ArrayList<T> _arrayList;

    public Map(int capacity)
    {
        _capacity = capacity;
        _arrayList = new ArrayList<T>(_capacity);
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

        bool didResize = _arrayList.PushForMap(newEntry, index);
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

public class LRU<T>
{
    private readonly int _capacity;
    private int _length;
    private readonly ArrayList<T> _buckets;

    public LRU(int capacity)
    {
        _capacity = capacity;
        _length = 0;
        _buckets = new(capacity);
    }

    public void Insert(T data)
    {
        if (data == null)
            return;

        Node<T> newNode = new(data);
        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        bool newBucket = _buckets.PushForLRU(newNode, index);
        if(newBucket)
            _length++;
    }
}

public class ArrayList<T>
{
    public int Length { get; set; } = 0;
    public int Capacity { get; set; }
    //LinkedList of LinkedList?
    //LinkedList<LinkedList<T>>
    private LinkedList<T>[] _buckets { get; set; }

    public ArrayList(int Capacity)
    {
        this.Capacity = Capacity;
        _buckets = new LinkedList<T>[Capacity];
    }

    public Node<T>? Get(int index, T data)
    {
        int checkedIndex = index != -1 && index <= Capacity ? index : Length;

        if (_buckets[checkedIndex] is LinkedList<T> linkedList)
        {
            return linkedList.GetNode(data);
        }
        return null;
    }

    public bool PushForMap(Node<T> newNode, int index = -1)
    {
        int insertIndex = index != -1 && index <= Capacity ? index : Length;
        LinkedList<T> linkedList = this._buckets[insertIndex];

        if (linkedList is not LinkedList<T> _ && Length + 1 <= Capacity)
        {
            linkedList = new();
            linkedList.AddLast(newNode);
            this._buckets[insertIndex] = linkedList;
            //Only increment length when a new linked list is created
            Length++;

            return false;
        }
        else if (linkedList is not LinkedList<T> _ && Length + 1 >= Capacity)
        {
            Capacity *= 2;
            LinkedList<T>[] newArray = new LinkedList<T>[Capacity];

            //COPY EXISTING LINKEDLISTS FROM THE OLD ARRAY
            //Not just copy existing linked lists based on their head values hash,
            //Rather iterate through each node and calculate new index'.
            foreach (var list in _buckets)
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

            this._buckets = newArray;

            return true;
        }
        else
        {
            linkedList.AddLast(newNode);
            return false;
        }
    }

    public bool PushForLRU(Node<T> newNode, int index = -1)
    {
        int bucketIndex = index != -1 && index <= Capacity ? index : Length;
        LinkedList<T> bucket = this._buckets[bucketIndex];

        if (bucket is not LinkedList<T> _ && Length + 1 <= Capacity)
        {
            bucket = new();
            bucket.AddFirst(newNode);
            MoveToFront(bucket);
            //Only increment length when a new bucket is created
            Length++;

            return true;
        }
        else if (bucket is not LinkedList<T> _ && Length + 1 >= Capacity)
        {
            bucket = new();
            bucket.AddFirst(newNode);

            _buckets[Length] = null;
            MoveToFront(bucket);

            return false;
        }
        else
        {
            bucket.AddFirst(newNode);
            return false;
        }
    }

    private void MoveToFront(LinkedList<T> bucket)
    {
        if (bucket is null)
            return;

        LinkedList<T>[] newBuckets = new LinkedList<T>[Capacity];
        int i = 1;
        foreach (var currBucket in _buckets)
        {
            newBuckets[i] = currBucket;
        }

        newBuckets[0] = bucket;
        this._buckets = newBuckets;
    }
}


public class LRU1<T>
{
    private readonly int _capacity;
    private int _length;
    private T[] _entries;

    public LRU1(int capacity)
    {
        _capacity = capacity;
        _length = 0;
        _entries = new T[capacity];
    }


}