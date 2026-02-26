namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //["LFUCache","put","put","get","put","get","get","put","get","get","get"]
            //[[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]
            LFUCache lfuCache = new(2);
            lfuCache.Put(1, 1);
            lfuCache.Put(2, 2);
            Console.WriteLine(lfuCache.Get(1)); // returns 1
            lfuCache.Put(3, 3); // evicts key 2
            Console.WriteLine(lfuCache.Get(2)); // returns -1 (not found)
            Console.WriteLine(lfuCache.Get(3)); // returns 3.
            lfuCache.Put(4, 4); // evicts key 1.
            Console.WriteLine(lfuCache.Get(1)); // returns -1 (not found)
            Console.WriteLine(lfuCache.Get(3)); // returns 3 (found)
            Console.WriteLine(lfuCache.Get(4)); // returns 4 (found)
        }

        public class LFUCache
        {
            private readonly int _capacity;
            private int _length;

            Dictionary<int, Bucket> _bucketList;
            public Bucket _dummyTail;
            public Bucket _dummyHead;
            public LFUCache(int capacity)
            {
                _capacity = capacity;
                _bucketList = new();
                _dummyTail = new Bucket(int.MaxValue, 0);
                _dummyHead = new Bucket(0, 0);
                _dummyTail.prev = _dummyHead;
                _dummyHead.next = _dummyTail;
            }

            public int Get(int key)
            {
                if (_bucketList.TryGetValue(key, out Bucket existingBucket))
                {
                    //Move the key to the next bucket
                    int value = existingBucket.lruCache.Get(key);
                    existingBucket.lruCache.RemoveKey(key);

                    int newFrequency = existingBucket.frequency + 1;
                    Bucket nextBucket = existingBucket.next;
                    if (nextBucket.frequency != newFrequency)
                        nextBucket = InsertBucketAfter(existingBucket, newFrequency);

                    nextBucket.lruCache.Put(key, value);
                    _bucketList[key] = nextBucket;

                    RemoveBucketIfEmpty(existingBucket);

                    return value;
                }
                return -1;
            }
            public void Put(int key, int value)
            {
                if (_capacity == 0) return;

                if (_bucketList.TryGetValue(key, out Bucket existingBucket))
                {
                    // 1. Update existing key and move to next bucket
                    existingBucket.lruCache.RemoveKey(key);

                    int newFrequency = existingBucket.frequency + 1;
                    Bucket nextBucket = existingBucket.next;
                    if (nextBucket.frequency != newFrequency)
                        nextBucket = InsertBucketAfter(existingBucket, newFrequency);

                    nextBucket.lruCache.Put(key, value);
                    _bucketList[key] = nextBucket;

                    RemoveBucketIfEmpty(existingBucket);
                }
                else
                {
                    if (_length + 1 > _capacity)
                    {
                        //If the cache is full, remove the least frequently used key
                        Bucket leastFreqBucket = _dummyHead.next;
                        int keyToRemove = leastFreqBucket.lruCache.GetTailKey();

                        leastFreqBucket.lruCache.RemoveKey(keyToRemove);
                        _bucketList.Remove(keyToRemove);
                        _length--;

                        RemoveBucketIfEmpty(leastFreqBucket);
                    }

                    // 3. Now safely insert the new key
                    Bucket firstBucket = _dummyHead.next;
                    if (firstBucket.frequency != 1)
                        firstBucket = InsertBucketAfter(_dummyHead, 1);

                    firstBucket.lruCache.Put(key, value);
                    _bucketList[key] = firstBucket;
                    _length++;
                }
            }
            public Bucket InsertBucketAfter(Bucket existingBucket, int frequency)
            {
                Bucket newBucket = new(frequency, _capacity);
                newBucket.next = existingBucket.next;
                newBucket.prev = existingBucket;

                existingBucket.next.prev = newBucket;
                existingBucket.next = newBucket;

                return newBucket;
            }

            private void RemoveBucketIfEmpty(Bucket bucket)
            {
                if (bucket.lruCache.Length == 0) //If the bucket is empty
                {
                    //If the bucket is empty, remove it from the list
                    bucket.prev.next = bucket.next;
                    bucket.next.prev = bucket.prev;
                }
            }
            public class Bucket
            {
                public int frequency;
                public LRUCache lruCache;
                public Bucket next;
                public Bucket prev;
                public Bucket(int freq, int capacity)
                {
                    frequency = freq;
                    lruCache = new LRUCache();
                }
            }
            public class LRUCache
            {
                private int _length;
                public int Length { get => _length; }
                private Dictionary<int, Node> _lookupTable;
                private LinkedList _linkedList;

                public LRUCache()
                {
                    _lookupTable = new();
                    _linkedList = new();
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
                        Node newNode = new(key, value);
                        _linkedList.InsertFront(newNode);
                        _lookupTable[key] = newNode;
                        _length++;
                    }
                }

                public void RemoveKey(int key)
                {
                    if (_lookupTable.TryGetValue(key, out Node node))
                    {
                        _linkedList.RemoveNode(node);
                        _lookupTable.Remove(key);
                        _length--;
                    }
                }

                public int GetTailKey() => _linkedList.GetTailKey();
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
                    public LinkedList()
                    {
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

                    public void RemoveNode(Node node)
                    {
                        if (node == _head && node == _tail)
                        {
                            _head = null;
                            _tail = null;
                        }
                        else if (node == _head)
                        {
                            node.prev.next = null;
                            _head = node.prev;
                        }
                        else if (node == _tail)
                        {
                            node.next.prev = null;
                            _tail = node.next;
                        }
                        else
                        {
                            node.prev.next = node.next;
                            node.next.prev = node.prev;
                        }
                    }
                    public void RemoveTail()
                    {
                        if (_head == _tail)
                        {
                            _head = null;
                            _tail = null;
                            return;
                        }
                        _tail.next.prev = null;
                        _tail = _tail.next;
                    }
                    public int GetTailKey() => _tail.key;
                }
            }
        }
    }
}
