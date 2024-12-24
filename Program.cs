using static Algorithms;

public class Program
{
    public static void Main()
    {
        Random rand = new();

        Map<string, int> map = new(10);
        Entry<string, int> entry = new("furkan", rand.Next(-100, 101));
        Entry<string, int> entry1 = new("bilal", rand.Next(-100, 101));
        Entry<string, int> entry3 = new("yigit", rand.Next(-100, 101));
        Entry<string, int> entry4 = new("ilhan", rand.Next(-100, 101));
        Entry<string, int> entry5 = new("nermin", rand.Next(-100, 101));
        Entry<string, int> entry6 = new("tugba", rand.Next(-100, 101));
        Entry<string, int> entry7 = new("taner", rand.Next(-100, 101));
        Entry<string, int> entry8 = new("aykat", rand.Next(-100, 101));
        Entry<string, int> entry9 = new("aykut", rand.Next(-100, 101));
        Entry<string, int> entry0 = new("aymaz", rand.Next(-100, 101));
        Entry<string, int> entry10 = new("ayaz", rand.Next(-100, 101));
        map.Insert(entry);
        map.Insert(entry1);
        map.Insert(entry3);
        map.Insert(entry4);
        map.Insert(entry5);
        map.Insert(entry6);
        map.Insert(entry7);
        map.Insert(entry8);
        map.Insert(entry9);
        map.Insert(entry0);
        map.Insert(entry10);
        Console.WriteLine(map.GetEntry("aykat")!.Value);
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

public class Map<K, V>
{
    private int _capacity = 0;
    private int _length = 0;
    private ArrayListForMap<K, V> _arrayList;

    public Map(int capacity)
    {
        _capacity = capacity;
        _arrayList = new ArrayListForMap<K, V>(_capacity);
    }

    public void Insert(Entry<K, V> newEntry)
    {
        if (_length + 1 <= _capacity)
        {
            int hash = newEntry.Key!.GetHashCode();
            int index = Math.Abs(hash % _capacity);

            _arrayList.Push(newEntry, index);
            _length++;
        }
        else
        {
            _capacity *= 2;
            int hash = newEntry.Key!.GetHashCode();
            int index = Math.Abs(hash % _capacity);

            _arrayList.Push(newEntry, index);
            _length++;
        }
    }

    public Entry<K, V>? GetEntry(K key)
    {
        if (key == null)
            return null;

        int hash = key.GetHashCode();
        return _arrayList.Get(hash);
    }
}

public class Entry<K, V>
{
    private readonly K _key;

    private readonly V _value;
    public K Key
    {
        get { return _key; }
    }
    public V Value
    {
        get { return _value; }
    }

    public Entry(K key, V value)
    {
        _key = key;
        _value = value;
    }
}

public class ArrayListForMap<K, V>
{
    public int Length { get; set; } = 0;
    public int Capacity { get; set; }
    private Entry<K, V>[] Array { get; set; }

    public ArrayListForMap(int Capacity)
    {
        this.Capacity = Capacity;
        Array = new Entry<K, V>[Capacity];
    }

    public Entry<K, V>? Get(int hash)
    {
        int index = Math.Abs(hash % Capacity);

        if (Array[index] != null && Array[index].Key!.GetHashCode() == hash)
        {
            return Array[index];
        }
        return null;
    }

    public void Push(Entry<K, V> value, int index = -1)
    {
        int insertIndex = index != -1 && index <= Capacity ? index : Length;

        if (Length + 1 <= Capacity)
        {
            //CHECK COLLISION
            this.Array[insertIndex] = value;
            Length++;
        }
        else
        {
            Entry<K, V>[] newArray = new Entry<K, V>[Capacity * 2];

            foreach (var entry in Array)
            {
                if (entry == null)
                    continue;
                int newIndex = Math.Abs(entry.Key!.GetHashCode() % (this.Capacity * 2));

                //CHECK COLLISION
                newArray[newIndex] = entry;
            }
            Capacity *= 2;
            newArray[insertIndex] = value;
            Length += 1;
            this.Array = newArray;
        }
    }
}