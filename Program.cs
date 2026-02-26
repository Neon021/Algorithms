namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class LRUCache
    {
        private readonly int _capacity;
        private int _length;

        private Dictionary<int, Node> _lookupTable;
        private LinkedList _linkedList;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _lookupTable = new();
            _linkedList = new(capacity);
        }

        public int Get(int key)
        {
            if (_lookupTable.TryGetValue(key, out Node node))
            {
                _linkedList.GetToFront(node);
                return node.value;
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            if (_lookupTable.TryGetValue(key, out Node node))
            {
                _linkedList.GetToFront(node);
                node.value = value;
            }
            else
            {
                if (_length + 1 > _capacity)
                {
                    int tailKey = _linkedList.GetTailKey();
                    _lookupTable.Remove(tailKey);
                }

                Node newNode = new(key, value);
                _linkedList.InsertFront(newNode);
                _lookupTable[key] = newNode;
                _length++;
            }
        }

        public class Node
        {
            public int key;
            public int value;
            public Node next;
            public Node prev;

            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public class LinkedList
        {
            public Node _head;
            public Node _tail;
            private int _length;
            private int _capacity;
            public LinkedList(int capacity)
            {
                _capacity = capacity;
            }

            public void InsertFront(Node node)
            {
                if (_head == null)
                {
                    _head = node;
                    _tail = node;
                }
                else
                {
                    _head.next = node;
                    node.prev = _head;
                    _head = node;
                }

                if (_length + 1 > _capacity)
                    RemoveTail();
                _length++;
            }

            public void GetToFront(Node node)
            {
                if (_head == node) return;
                else if (_tail == node)//If its the tail, move the tail forward
                {
                    _tail.next.prev = null;
                    _tail = _tail.next;
                }
                else //If its a node in the middle, rewire its neighbours
                {
                    node.next.prev = node.prev;
                    node.prev.next = node.next;
                }

                //Move the node to the head
                node.prev = _head;
                _head.next = node;
                node.next = null;
                _head = node;
            }

            public void RemoveTail()
            {
                _tail.next.prev = null;
                _tail = _tail.next;
                _length--;
            }
            public int GetTailKey() => _tail.key;
        }
    }
}
