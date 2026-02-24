namespace Main
{
    public class Program
    {
        public static void Main()
        {
            //["AllOne","inc","inc","inc","inc","getMaxKey","inc","inc","inc","dec","inc","inc","inc","getMaxKey"]
            //[[],["hello"],["goodbye"],["hello"],["hello"],[],["leet"],["code"],["leet"],["hello"],["leet"],["code"],["code"],[]]
            AllOne allOne = new();
            allOne.Inc("hello");
            allOne.Inc("goodbye");
            allOne.Inc("hello");
            allOne.Inc("hello");
            Console.WriteLine(allOne.GetMaxKey());
            allOne.Inc("leet");
            allOne.Inc("code");
            allOne.Inc("leet");
            allOne.Dec("hello");
            allOne.Inc("leet");
            allOne.Inc("code");
            allOne.Inc("code");
            Console.WriteLine(allOne.GetMaxKey());
        }
    }
    public class AllOne
    {
        private Dictionary<string, Bucket> _lookupTable;
        private Bucket _head; //dummy head
        private Bucket _tail; //dummy tail
        public AllOne()
        {
            _lookupTable = new();
            _head = new Bucket(0);
            _tail = new Bucket(int.MaxValue);
            _head.next = _tail;
            _tail.previous = _head;

        }

        public void Inc(string key)
        {
            if (!_lookupTable.TryGetValue(key, out Bucket existingBucket))
            {
                //Key does not exists, so we need to insert it into frequency 1 bucket
                Bucket firstBucket = _head.next;
                if (firstBucket.frequency != 1)
                    firstBucket = InsertBucketAfter(_head, 1);

                firstBucket.keys.Add(key);
                _lookupTable[key] = firstBucket;
            }
            else
            {
                //Key exists in a bucket, we need to move it to next bucket with +1 frequency
                int newFrequency = existingBucket.frequency + 1;
                Bucket nextBucket = existingBucket.next;
                if (nextBucket.frequency != newFrequency)
                    nextBucket = InsertBucketAfter(existingBucket, newFrequency);

                nextBucket.keys.Add(key);
                _lookupTable[key] = nextBucket;
                RemoveKeyFromBucket(existingBucket, key);
            }
        }

        public void Dec(string key)
        {
            if (!_lookupTable.TryGetValue(key, out Bucket existingBucket)) return; //Key does not exists, so we can ignore the operation

            int newFrequency = existingBucket.frequency - 1;

            if (newFrequency > 0)
            {
                //New frequency is bigger than zero, we will move the current key to the previous bucket
                Bucket previousBucket = existingBucket.previous;
                if (previousBucket.frequency != newFrequency)
                    previousBucket = InsertBucketBefore(existingBucket, newFrequency);

                previousBucket.keys.Add(key);
                _lookupTable[key] = previousBucket;
            }
            else //New frequency is less than or equal to zero, we will remove this key from the lookupDict
                _lookupTable.Remove(key);

            RemoveKeyFromBucket(existingBucket, key);
        }

        public string GetMaxKey() => _tail.previous == _head ? "" : _tail.previous.keys.First();

        public string GetMinKey() => _head.next == _tail ? "" : _head.next.keys.First();

        private Bucket InsertBucketAfter(Bucket existingBucket, int frequency)
        {
            Bucket newBucket = new(frequency);
            newBucket.next = existingBucket.next;
            newBucket.previous = existingBucket;
            existingBucket.next.previous = newBucket;
            existingBucket.next = newBucket;
            return newBucket;
        }

        private Bucket InsertBucketBefore(Bucket existingBucket, int frequency)
        {
            Bucket newBucket = new(frequency);
            newBucket.previous = existingBucket.previous;
            newBucket.next = existingBucket;
            existingBucket.previous.next = newBucket;
            existingBucket.previous = newBucket;
            return newBucket;
        }
        private void RemoveKeyFromBucket(Bucket bucket, string key)
        {
            bucket.keys.Remove(key);
            if (bucket.keys.Count == 0)
            {
                bucket.next.previous = bucket.previous;
                bucket.previous.next = bucket.next;
            }
        }
        public class Bucket
        {
            public int frequency;
            public HashSet<string> keys;

            public Bucket next;
            public Bucket previous;
            public Bucket(int freq) { frequency = freq; keys = new(); }
        }
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
//public class AllOne
//{
//    //Thi hould ork like LFU cache actually.
//    //in order to achieve O(1) for getma and getmin e can ue a dequeue to tore them on front and back. Dequeue node ill have the key value a ell hich ill enable u to acce to hamap in O(1) time. When we inc or dec we can move the node to the front or back of the dequeue depending on the count.
//    //Then in dec and inc operation e can move thee node to the front or back of the dequeue depending on the count. If the count is increased we can move it to the front and if it is decreased we can move it to the back. This way we can ensure that the getmax and getmin operations will always return the correct key in O(1) time.
//    //Also, we should maintain a hashmap to store the key and the related node in the linked list. This way we can access the node in O(1) time when we need to inc or dec the count of a key.


//    LinkedList _dequeue;
//    HashSet<HashMapNode> _hashSet;

//    public AllOne()
//    {
//        _dequeue = new();
//        _hashSet = new();
//    }

//    public void Inc(string key)
//    {
//        HashMapNode? node = _hashSet.FirstOrDefault(x => x.Key == key);
//        if (node == null)
//        {
//            DequeueNode newNode = new()
//            {
//                Key = key,
//                Count = 1
//            };

//            _dequeue.AddLast(newNode);
//            _hashSet.Add(new HashMapNode()
//            {
//                Key = key,
//                Count = 1,
//                DequeueNode = newNode
//            });
//        }
//        else
//        {
//            node.Count++;
//            node.DequeueNode.Count++;
//            //How to rearrange the nodes? we need to compare the current value ith te next value until we find the correct position for the node.
//            //This violate O(1) though, we need to find a way to move the node to the correct position in O(1) time.
//            while (node.DequeueNode.next != null && node.DequeueNode.Count > node.DequeueNode.next.Count)
//            {
//                var nextNode = node.DequeueNode.next;
//                node.DequeueNode.next = nextNode.next;
//                node.DequeueNode.previousious = nextNode;
//                //nextNode.previousious = node.DequeueNode.previousious;
//                nextNode.next = node.DequeueNode;
//            }
//        }
//    }

//    public void Dec(string key)
//    {
//        //It is guaranteed that key exists in the data structure before the decrement.
//        HashMapNode node = _hashSet.FirstOrDefault(x => x.Key == key);
//        node.Count--;
//        node.DequeueNode.Count--;
//        //How to rearrange the nodes? we need to compare the current value with the previousious value until we find the correct position for the node.
//        while (node.DequeueNode.previousious != null && node.DequeueNode.Count < node.DequeueNode.previousious.Count)
//        {
//            var previousiousNode = node.DequeueNode.previousious;
//            node.DequeueNode.previousious = previousiousNode.previousious;
//            node.DequeueNode.next = previousiousNode;
//            previousiousNode.next = node.DequeueNode.next;
//            previousiousNode.previousious = node.DequeueNode;
//        }

//        if (node.Count == 0)
//        {
//            _hashSet.Remove(node);
//            _dequeue.RemoveTail();
//        }
//    }

//    public string GetMaxKey()
//    {
//        return _dequeue.Length > 0 ? _dequeue.Head.Key : "";
//    }

//    public string GetMinKey()
//    {
//        return _dequeue.Length > 0 ? _dequeue.Tail.Key : "";
//    }

//    public class HashMapNode
//    {
//        public string Key { get; set; }
//        public int Count { get; set; }
//        public DequeueNode DequeueNode { get; set; }
//    }
//    public class DequeueNode
//    {
//        public string Key { get; set; }
//        public int Count { get; set; }
//        public DequeueNode next { get; set; }
//        public DequeueNode previousious { get; set; }
//    }

//    public class LinkedList
//    {
//        public DequeueNode? Head { get; private set; }
//        public DequeueNode? Tail { get; private set; }
//        public int Length { get; private set; }

//        public LinkedList()
//        {
//            this.Head = null;
//            this.Tail = null;
//        }
//        public void AddFirst(DequeueNode newNode)
//        {
//            if (Head == null)
//            {
//                Head = newNode;
//                Tail = newNode;
//            }
//            else
//            {
//                this.Head.next = newNode;
//                this.Head = newNode;
//            }
//            Length++;
//        }
//        public void AddLast(DequeueNode newNode)
//        {
//            if (Head == null)
//            {
//                Head = newNode;
//                Tail = newNode;
//            }
//            else
//            {
//                this.Tail.previousious = newNode;
//                newNode.next = this.Tail;
//                this.Tail = newNode;
//            }

//            Length++;
//        }

//        public void RemoveTail()
//        {
//            if (Tail == null)
//                return;

//            DequeueNode? newTail = Tail.previousious;
//            newTail!.next = null;
//            Tail = newTail;
//            Length--;
//        }
//    }
//}
