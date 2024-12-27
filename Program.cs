public class Program
{
    public static void Main()
    {
        LRU<string> lruCache = new(5);
        lruCache.Insert("furkan");
        lruCache.Insert("bilal");
        lruCache.Insert("yigit");
        lruCache.Insert("ilhan");
        lruCache.Insert("nermin");

        lruCache.GetNode("furkan");
        lruCache.Insert("taner");
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
    public int Length { get; private set; }

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
        Length++;
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

        Length++;
    }

    public Node<T>? GetNode(T data)
    {
        if (Head == null)
            return null;
        else if (Length == 1)
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

    public void GetNodeToFront(Node<T> node)
    {
        if (Head == node)
            return;
        else if (Tail == node)
        {
            Tail.Next = Head;
            Head!.Prev = Tail;
            Head = Tail;
            Head.Prev = null;
        }
        else
        {
            Node<T> prevNode = node.Prev!;
            Node<T> nextNode = node.Next!;

            prevNode.Next = nextNode;
            nextNode.Prev = prevNode;

            node.Next = Head;
            Head!.Prev = node;
            Head = node;
        }
    }

    public void RemoveTail()
    {
        if (Tail == null)
            return;

        Node<T>? newTail = Tail.Prev;
        newTail!.Next = null;
        Tail = newTail;
        Length--;
    }
}

public struct Entry<K, V>
{
    public K Key;

    public V Value;
}
public class HashMap<K, V>
{
    private readonly int _capacity;
    private readonly Entry<K, V>[] _entries;

    public HashMap(int capacity)
    {
        _capacity = capacity;
        _entries = new Entry<K, V>[capacity];
    }

    public void Insert(K data, V node)
    {
        if (data == null || node == null)
            return;

        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        Entry<K, V> newEntry = new() { Key = data, Value = node };
        //COLLLLIIIIISSSIOOOOOOOOOOOOOOOOOOOOON
        _entries[index] = newEntry;
    }

    public V? GetNode(K data)
    {
        if (data == null)
            return default;

        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        return _entries[index].Value;
    }

    public void RemoveEntry(K data)
    {
        if (data == null)
            return;

        int hash = data.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        _entries[index] = default;
    }
}

public class LRU<T>
{
    private readonly int _capacity;
    private readonly LinkedList<T> _linkedList;
    private readonly HashMap<T, Node<T>> _hashMap;
    //Hashmap holds type T as the TKey so that we can do this.
    //Node<string> desiredNode = hashMap.GetNode("data");
    //And the TValue is of course the Node<T> itself.
    public LRU(int capacity)
    {
        _capacity = capacity;
        _linkedList = new();
        _hashMap = new(capacity);
    }

    public void Insert(T data)
    {
        if (data == null)
            return;

        Node<T> newNode = new(data);
        if (_linkedList.Length + 1 >= _capacity)
        {
            _linkedList.RemoveTail();
            _hashMap.RemoveEntry(data);
        }

        _linkedList.AddFirst(newNode);

        _hashMap.Insert(data, newNode);
    }

    public Node<T>? GetNode(T data)
    {
        if (data == null)
            return null;

        Node<T>? retrievedNode = _hashMap.GetNode(data);

        if (retrievedNode is null)
            return null;

        _linkedList.GetNodeToFront(retrievedNode);

        return retrievedNode;
    }
}
