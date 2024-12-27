public class Program
{
    public static void Main()
    {
        LRU<string, string> lruCache = new(5);
        lruCache.Update("furkan_Key", "furkan");
        lruCache.Update("bilal_Key", "bilal");
        lruCache.Update("yigit_Key", "yigit");
        lruCache.Update("ilhan_Key", "ilhan");
        lruCache.Update("nermi_nKey", "nermin");

        lruCache.GetNode("furkan");
        lruCache.Update("tanerKey", "taner");
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

    public void Insert(K key, V node)
    {
        if (key == null || node == null)
            return;

        int hash = key.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        Entry<K, V> newEntry = new() { Key = key, Value = node };
        //COLLLLIIIIISSSIOOOOOOOOOOOOOOOOOOOOON
        _entries[index] = newEntry;
    }

    public V? GetNode(K key)
    {
        if (key == null)
            return default;

        int hash = key.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        return _entries[index].Value;
    }

    public void RemoveEntry(K key)
    {
        if (key == null)
            return;

        int hash = key.GetHashCode();
        int index = Math.Abs(hash % _capacity);

        _entries[index] = default;
    }
}

public class LRU<K, V>
{
    private readonly int _capacity;
    private readonly LinkedList<V> _linkedList;
    private readonly HashMap<K, Node<V>> _hashMap;
    //Second lookup table for eviction?

    //Hashmap holds type T as the TKey so that we can do this.
    //Node<string> desiredNode = hashMap.GetNode("data");
    //And the TValue is of course the Node<T> itself.
    public LRU(int capacity)
    {
        _capacity = capacity;
        _linkedList = new();
        _hashMap = new(capacity);
    }

    public void Update(K key, V value)
    {
        if (key is null)
            return;

        if (GetNode(key) is Node<V> _)
            //Prepending Node to the front of the list is done in GetNode.
            return;

        Node<V> newNode = new(value);

        if (_linkedList.Length + 1 >= _capacity)
        {
            _linkedList.RemoveTail();
            _hashMap.RemoveEntry(key);
        }

        _linkedList.AddFirst(newNode);

        _hashMap.Insert(key, newNode);
    }

    public Node<V>? GetNode(K key)
    {
        if (key == null)
            return null;

        Node<V>? retrievedNode = _hashMap.GetNode(key);

        if (retrievedNode is null)
            return null;

        _linkedList.GetNodeToFront(retrievedNode);

        return retrievedNode;
    }
}
