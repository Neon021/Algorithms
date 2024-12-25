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
        map.Insert("ayaz");

        if (map.GetEntry("aykat") is Node<string> existingNode)
            Console.WriteLine(existingNode.Data);
        if (map.GetEntry("ilhan") is Node<string> existingNode1)
            Console.WriteLine(existingNode1.Data);
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
        while (headNode!.Next != null && headNode.Data!.Equals(data) && tailNode!.Prev != null && tailNode.Data!.Equals(data))
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
        if (_length + 1 <= _capacity)
        {
            int hash = newEntry.Data!.GetHashCode();
            int index = Math.Abs(hash % _capacity);

            _arrayList.Push(newEntry, index);
            _length++;
        }
        else
        {
            _capacity *= 2;
            int hash = newEntry.Data!.GetHashCode();
            int index = Math.Abs(hash % _capacity);

            _arrayList.Push(newEntry, index);
            _length++;
        }
    }

    public Node<T>? GetEntry(T data)
    {
        if (data == null)
            return null;

        int hash = data.GetHashCode();
        return _arrayList.Get(hash, data);
    }
}

public class Entry<K, V>
{
    private readonly K _key;

    private V _value;
    public K Key
    {
        get { return _key; }
    }
    public V Value
    {
        get { return _value; }
        set
        {
            if (value is V val)
                this._value = val;
        }
    }

    public Entry(K key, V value)
    {
        _key = key;
        _value = value;
    }
}

public class ArrayListForMap<T>
{
    public int Length { get; set; } = 0;
    public int Capacity { get; set; }
    private Entry<int, LinkedList<T>>[] Array { get; set; }

    public ArrayListForMap(int Capacity)
    {
        this.Capacity = Capacity;
        Array = new Entry<int, LinkedList<T>>[Capacity];
    }

    public Node<T>? Get(int hash, T data)
    {
        int index = Math.Abs(hash % Capacity);

        if ((Array[index] is Entry<int, LinkedList<T>> entry) && (entry.Value is LinkedList<T> linkedList && Array[index].Key!.GetHashCode() == hash))
        {
            return linkedList.GetNode(data);
        }
        return null;
    }

    public void Push(Node<T> value, int index = -1)
    {
        int insertIndex = index != -1 && index <= Capacity ? index : Length;

        if (Length + 1 <= Capacity)
        {
            //CHECK COLLISION
            //rather than checking here, we utilize double linked list to store values with the same hash value.
            Entry<int, LinkedList<T>> kv = this.Array[insertIndex];
            if ((kv is Entry<int, LinkedList<T>> _) && kv.Value is LinkedList<T> _)
                kv.Value.AddLast(value);
            else
            {
                kv = new Entry<int, LinkedList<T>>(value.Data!.GetHashCode(), new());
                kv.Value.AddLast(value);
                this.Array[insertIndex] = kv;
            }
            Length++;
        }
        else
        {
            Entry<int, LinkedList<T>>[] newArray = new Entry<int, LinkedList<T>>[Capacity * 2];

            //COPY EXISTING ELEMENTS FROM THE OLD ARRAY
            foreach (var entry in Array)
            {
                if (entry == null)
                    continue;
                int newIndex = Math.Abs(entry.Key!.GetHashCode() % (this.Capacity * 2));

                //CHECK COLLISION
                //Exponential back-off
                while (newArray[newIndex] is not null && newIndex <= Capacity - 1)
                    newIndex++;

                newArray[newIndex] = entry;
            }

            //INSERT NEW ELEMENT
            if ((newArray[insertIndex] is Entry<int, LinkedList<T>> existingEntry) && existingEntry.Value is LinkedList<T> _)
                newArray[insertIndex].Value.AddLast(value);
            else
            {
                newArray[insertIndex] = new Entry<int, LinkedList<T>>(value.Data!.GetHashCode(), new());
                newArray[insertIndex].Value.AddLast(value);
            }

            Capacity *= 2;
            Length += 1;
            this.Array = newArray;
        }
    }
}