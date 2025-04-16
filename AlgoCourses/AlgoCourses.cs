namespace Codewars.AlgoCourses
{

    public class AlgoCourses
    {
        #region Last Algorithms Course
        //Front End Masters The Primeagen(THE MYTH THE LEGEND HIMSELF) Algorithms course
        #region Search
        #region BinarySearch
        public static bool BinarySearch(int[] haystack, int needle)
        {
            int low = 0;
            int high = haystack.Length;
            do
            {
                int index = low + ((high - low) / 2);
                int value = haystack[index];

                if (value == needle)
                    return true;
                else if (value > needle)
                    high = index;
                else
                    low = index + 1;

            } while (low < high);

            return false;
        }
        #endregion
        #region TwoCrystalBalls
        public static int TwoCrystalBalls(bool[] breaks)
        {
            double jmpAmount = Math.Floor(Math.Sqrt(breaks.Length));

            double i = jmpAmount;
            for (; i < breaks.Length; i += jmpAmount)
            {
                if (breaks[(int)i])
                {
                    break;
                }
            }

            i -= jmpAmount;
            for (int j = 0; j <= jmpAmount && i < breaks.Length; ++j, ++i)
            {
                if (breaks[(int)i])
                {
                    return (int)i;
                }
            }
            return -1;
        }
        #endregion
        #endregion

        #region Sort
        #region BubbleSort
        //Sort algorithms
        public static void BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        (numbers[j + 1], numbers[j]) = (numbers[j], numbers[j + 1]);
                    }

                }
            }
        }
        #endregion
        #endregion

        #region Lists
        #region DOUBLY Linked-List
        //Data Structures

        //public static void Main(string[] args)
        //{
        //    LinkedList<string> list = new();

        //    Node<string> a = new("aaa");
        //    Node<string> b = new("bbb");
        //    Node<string> c = new("ccc");
        //    Node<string> d = new("ddd");
        //    Node<string> e = new("eee");

        //    list.AddFirst(a);
        //    list.AddLast(b);
        //    list.AddLast(c);
        //    list.AddLast(d);
        //    list.AddLast(e);
        //    list.AddLast(new("zzzz"));
        //    list.AddAfter(new("ffff"), c);

        //    list.Traverse();
        //}
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; internal set; }
            public Node<T>? Prev { get; internal set; }

            public Node(T data)
            {
                this.Data = data;
            }
        }

        public class LinkedList<T>
        {
            public Node<T> First { get; private set; }
            public Node<T> Last { get; private set; }
            public int Count { get; private set; }

            public LinkedList()
            {
                this.First = null;
                this.Last = null;
            }

            public void AddFirst(Node<T> newNode)
            {
                if (this.First == null)
                {
                    this.First = newNode;
                    this.Last = newNode;
                }
                else
                {
                    newNode.Next = this.First;
                    this.First = newNode;
                }
                this.Count++;
            }

            public void AddLast(Node<T> newNode)
            {
                if (this.First == null)
                {
                    this.First = newNode;
                    this.Last = newNode;
                }
                else
                {
                    this.Last.Next = newNode;
                    Last = newNode;
                }
                this.Count++;
            }

            public void AddAfter(Node<T> newNode, Node<T> existingNode)
            {
                if (this.Last == existingNode)
                {
                    Last = newNode;
                }
                newNode.Next = existingNode.Next;
                existingNode.Next = newNode;
                this.Count++;
            }

            public Node<T> Find(T target)
            {
                Node<T> currentNode = First;

                while (currentNode != null && !currentNode.Data.Equals(target))
                {
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }

            public void RemoveFirst()
            {
                if (First == null || this.Count == 0)
                    return;

                First = First.Next;
                this.Count--;
            }

            public void Remove(Node<T> nodeToRemove)
            {
                if (First == null || this.Count == 0)
                {
                    return;
                }
                if (this.First == nodeToRemove)
                {
                    this.RemoveFirst();
                    return;
                }

                Node<T> previous = First;
                Node<T> current = previous.Next;

                while (current != null && current != nodeToRemove)
                {
                    previous = current;
                    current = previous.Next;
                }

                if (current != null)
                {
                    previous.Next = current.Next;
                    this.Count--;
                }
            }

            public void Traverse()
            {
                Console.WriteLine("First:" + First.Data);
                Console.WriteLine("\nLast:" + Last.Data);

                Node<T> node = this.First;

                while (node.Next is not null)
                {
                    Console.WriteLine(node.Data);
                    node = node.Next;
                }
                Console.WriteLine(node.Data);
            }
        }
        #endregion
        #region Queue
        //Queue
        public class Queue<T>
        {
            public int Length { get; internal set; }
            private Node<T>? Head { get; set; }
            private Node<T>? Tail { get; set; }

            public Queue()
            {
                this.Head = this.Tail = null;
                this.Length = 0;
            }

            public void Enqueue(T data)
            {
                Node<T> node = new(data);
                this.Length++;
                if (this.Tail is null)
                {
                    this.Tail = this.Head = node;
                    return;
                }

                this.Tail.Next = node;
                this.Tail = node;
            }
            public T? Deque()
            {
                if (this.Head == null)
                {
                    return default;
                }

                this.Length--;

                var head = this.Head;
                this.Head = this.Head.Next;

                // free
                head.Next = default;

                if (this.Length == 0)
                {
                    this.Tail = null;
                }

                return head.Data;
            }

            public T? Peek()
            {
                return this.Head is not null ? this.Head.Data : default;
            }
        }


        #endregion
        #region Stack
        public class Stack<T>
        {
            public int Length;
            private Node<T>? Head;

            public Stack()
            {
                this.Head = null;
                this.Length = 0;
            }

            public void Push(T data)
            {
                Node<T> node = new(data);
                this.Length++;

                if (this.Head is null)
                {
                    this.Head = node;
                    return;
                }

                node.Prev = this.Head;
                this.Head = node;
            }

            public T? Pop()
            {
                this.Length = Math.Max(0, this.Length - 1);

                if (this.Length == 0)
                {
                    Node<T>? head0 = this.Head;
                    this.Head = null;
                    return head0!.Data;
                }

                Node<T>? head = this.Head;
                this.Head = head!.Prev;

                return head.Data;
            }

            public T? Peek()
            {
                return this.Head is not null ? this.Head.Data : default;
            }
        }
        #endregion
        #region ArrayList
        //Array List
        //public static void Main(string[] args)
        //{
        //    ArrayList<string> arrayList = new(3);
        //    arrayList.Push("Furkan");
        //    arrayList.Push("Bilal");
        //    arrayList.Push("AKA");
        //    arrayList.Push("Adrian");
        //    arrayList.Push("Is");
        //    arrayList.Push("The Greatest");
        //    arrayList.Enqueue("Mr. ");
        //    arrayList.Dequeue();
        //    Console.WriteLine(arrayList.Get(0));
        //    Console.WriteLine(arrayList.Get(1));
        //    Console.WriteLine(arrayList.Get(2));
        //    Console.WriteLine(arrayList.Get(3));
        //    Console.WriteLine(arrayList.Get(4));
        //    Console.WriteLine(arrayList.Get(5));
        //    Console.WriteLine(arrayList.Get(6));
        //}
        public class ArrayList<T>
        {
            public int Length { get; set; } = 0;
            public int Capacity { get; set; }
            private T[] Array { get; set; }

            public ArrayList(int Capacity)
            {
                this.Capacity = Capacity;
                Array = new T[Capacity];
            }

            //index <= length - 1???
            public T? Get(int index) => (Length > 0) && (index >= 0 && index < Length) ? Array[index] : default(T);

            public void Push(T value)
            {
                if (Length + 1 <= Capacity)
                {
                    this.Array[Length] = value;
                    Length++;
                }
                else
                {
                    T[] newArray = new T[Capacity * 2];
                    for (int i = 0; i < this.Length; i++)
                    {
                        newArray[i] = this.Array[i];
                    }
                    Capacity *= 2;
                    newArray[Length] = value;
                    Length += 1;
                    this.Array = newArray;
                }
            }

            public T? Pop() => Length > 0 ? this.Array[Length - 1] : default(T);

            public void Enqueue(T value)
            {
                if (Length + 1 <= Capacity)
                {
                    for (int i = Length - 1; i >= 0; i--)
                    {
                        this.Array[i + 1] = this.Array[i];
                    }
                    this.Array[0] = value;
                }
                else
                {
                    T[] newArray = new T[Capacity * 2];
                    for (int i = Length - 1; i >= 0; i--)
                    {
                        newArray[i + 1] = this.Array[i];
                    }
                    Capacity *= 2;
                    newArray[0] = value;
                    Length += 1;
                    this.Array = newArray;
                }
            }

            public void Dequeue()
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    this.Array[i] = this.Array[i + 1];
                }
                Length--;
                this.Array[Length] = default(T);
            }
        }

        #endregion
        #region MazeSolver
        //Recursion 
        //public static void Main(string[] args)
        //{
        //    string[] maze = {
        //        "#####",
        //        "#S  #",
        //        "# # #",
        //        "#   #",
        //        "#####"
        //    };

        //    Point start = new() { x = 1, y = 1 };
        //    Point end = new() { x = 3, y = 3 };

        //    List<Point> solution = MazeSolver.Solve(maze, "#", start, end);

        //    Console.WriteLine("Path:");
        //    foreach (Point point in solution)
        //    {
        //        Console.WriteLine($"({point.x}, {point.y})");
        //    }
        //}



        public class Point
        {
            public int x;
            public int y;
        }

        public class MazeSolver
        {
            private static readonly int[][] dir =
            {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

            private static bool Walk(string[] maze, string wall, Point curr, Point end, bool[][] seen, List<Point> path)
            {
                if (curr.x < 0 || curr.x >= maze[0].Length ||
                    curr.y < 0 || curr.y >= maze.Length)
                {
                    return false;
                }

                if (maze[curr.y][curr.x].ToString() == wall)
                {
                    return false;
                }

                if (curr.x == end.x && curr.y == end.y)
                {
                    return true;
                }

                if (seen[curr.y][curr.x])
                {
                    return false;
                }

                seen[curr.y][curr.x] = true;
                path.Add(curr);

                foreach (int[] d in dir)
                {
                    int x = d[0];
                    int y = d[1];
                    if (Walk(maze, wall, new Point { x = curr.x + x, y = curr.y + y }, end, seen, path))
                    {
                        return true;
                    }
                }

                path.RemoveAt(path.Count - 1);

                return false;
            }

            public static List<Point> Solve(string[] maze, string wall, Point start, Point end)
            {
                bool[][] seen = new bool[maze.Length][];
                List<Point> path = new();

                for (int i = 0; i < maze.Length; ++i)
                {
                    seen[i] = new bool[maze[0].Length];
                }

                Walk(maze, wall, start, end, seen, path);

                return path;
            }
        }
        #endregion
        #endregion

        #region Graphs
        #region BFSGraphmatrix
        //public static void Main(string[] args)
        //{
        //    int[][] graph = new int[][]
        //    {
        //        new int[] { 0, 1, 1, 0, 0, 0 },
        //        new int[] { 1, 0, 0, 1, 0, 0 },
        //        new int[] { 1, 0, 0, 1, 1, 0 },
        //        new int[] { 0, 1, 1, 0, 1, 1 },
        //        new int[] { 0, 0, 1, 1, 0, 0 },
        //        new int[] { 0, 0, 0, 1, 0, 0 }
        //    };

        //    int source = 0;
        //    int needle = 5;

        //    int[]? result = BFS(graph, source, needle);

        //    if (result != null)
        //    {
        //        Console.WriteLine($"Shortest path from {source} to {needle}: {string.Join(" -> ", result)}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"No path found from {source} to {needle}");
        //    }
        //}
        public static int[]? BFS(int[][] graph, int source, int needle)
        {
            List<bool> traversedPath = new(Enumerable.Repeat(false, graph.Length));
            List<int> prev = new(Enumerable.Repeat(-1, graph.Length));

            traversedPath[source] = true;
            System.Collections.Queue q = new();
            q.Enqueue(source);

            do
            {
                int curr = (int)q.Dequeue();
                int[] adjs = graph[curr];

                if (curr == needle) break;

                for (int i = 0; i < adjs.Length; i++)
                {
                    if (adjs[i] == 0 || traversedPath[i]) continue;

                    traversedPath[i] = true;
                    prev[i] = curr;
                    q.Enqueue(i);
                }

            } while (q.Count > 0);

            if (prev[needle] == -1) return null;

            int current = needle;
            List<int> path = new();
            while (prev[current] != -1)
            {
                path.Add(current);
                current = prev[current];
            }

            path.Add(source);
            path.Reverse();

            return path.ToArray();
        }
        #endregion

        #endregion

        #region Maps & LRU

        #region Map
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }
        //    public Node<T>? Prev { get; internal set; }
        //    //public Node<T>? Random { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? Head { get; private set; }
        //    public Node<T>? Tail { get; private set; }
        //    public int Length { get; private set; }

        //    public LinkedList()
        //    {
        //        this.Head = null;
        //        this.Tail = null;
        //    }

        //    public void AddFirst(Node<T> newNode)
        //    {
        //        if (Head == null)
        //        {
        //            Head = newNode;
        //            Tail = newNode;
        //        }
        //        else
        //        {
        //            newNode.Next = this.Head;
        //            Head!.Prev = newNode;
        //            this.Head = newNode;
        //        }
        //        Length++;
        //    }
        //    public void AddLast(Node<T> newNode)
        //    {
        //        if (Head == null)
        //        {
        //            Head = newNode;
        //            Tail = newNode;
        //        }
        //        else
        //        {
        //            newNode.Prev = this.Tail;
        //            Tail!.Next = newNode;
        //            this.Tail = newNode;
        //        }

        //        Length++;
        //    }
        //}
        //public class Map<T>
        //{
        //    private int _capacity = 0;
        //    private int _length = 0;
        //    private readonly ArrayList<T> _arrayList;

        //    public Map(int capacity)
        //    {
        //        _capacity = capacity;
        //        _arrayList = new ArrayList<T>(_capacity);
        //    }

        //    public void Insert(T data)
        //    {
        //        if (data == null)
        //            return;

        //        Node<T> newEntry = new(data);
        //        if (_length + 1 >= _capacity)
        //            _capacity *= 2;

        //        int hash = data.GetHashCode();
        //        int index = Math.Abs(hash % _capacity);

        //        bool didResize = _arrayList.Push(newEntry, index);
        //        if (didResize)
        //            _length++;
        //    }

        //    public Node<T>? GetEntry(T data)
        //    {
        //        if (data == null)
        //            return null;

        //        int hash = data.GetHashCode();
        //        int index = Math.Abs(hash % _capacity);

        //        return _arrayList.Get(index, data);
        //    }
        //}
        //public class ArrayList<T>
        //{
        //    public int Length { get; set; } = 0;
        //    public int Capacity { get; set; }
        //    //LinkedList of LinkedList?
        //    //LinkedList<LinkedList<T>>
        //    private LinkedList<T>[] _buckets { get; set; }

        //    public ArrayList(int Capacity)
        //    {
        //        this.Capacity = Capacity;
        //        _buckets = new LinkedList<T>[Capacity];
        //    }

        //    public Node<T>? Get(int index, T data)
        //    {
        //        int checkedIndex = index != -1 && index <= Capacity ? index : Length;

        //        if (_buckets[checkedIndex] is LinkedList<T> linkedList)
        //        {
        //            return linkedList.GetNode(data);
        //        }
        //        return null;
        //    }

        //    public bool Push(Node<T> newNode, int index = -1)
        //    {
        //        int insertIndex = index != -1 && index <= Capacity ? index : Length;
        //        LinkedList<T> linkedList = this._buckets[insertIndex];

        //        if (linkedList is not LinkedList<T> _ && Length + 1 <= Capacity)
        //        {
        //            linkedList = new();
        //            linkedList.AddLast(newNode);
        //            this._buckets[insertIndex] = linkedList;
        //            //Only increment length when a new linked list is created
        //            Length++;

        //            return false;
        //        }
        //        else if (linkedList is not LinkedList<T> _ && Length + 1 >= Capacity)
        //        {
        //            Capacity *= 2;
        //            LinkedList<T>[] newArray = new LinkedList<T>[Capacity];

        //            //COPY EXISTING LINKEDLISTS FROM THE OLD ARRAY
        //            //Not just copy existing linked lists based on their head values hash,
        //            //Rather iterate through each node and calculate new index'.
        //            foreach (var list in _buckets)
        //            {
        //                if (list == null)
        //                    continue;

        //                Node<T>? currNode = list.Head;
        //                while (currNode is Node<T> _)
        //                {
        //                    int newIndex = Math.Abs(currNode.Data!.GetHashCode() % Capacity);

        //                    if (newArray[newIndex] == null)
        //                        newArray[newIndex] = new();

        //                    newArray[newIndex].AddLast(new Node<T>(currNode.Data));
        //                    currNode = currNode.Next;
        //                }
        //            }

        //            int newNodeIndex = Math.Abs(newNode.Data!.GetHashCode() % Capacity);
        //            //INSERT NEW ELEMENT
        //            if (newArray[newNodeIndex] is not LinkedList<T> _)
        //            {
        //                newArray[newNodeIndex] = new LinkedList<T>();
        //                //Only increment length when a new linked list is created
        //                Length++;
        //            }

        //            newArray[newNodeIndex].AddLast(newNode);
        //            //Length++;

        //            this._buckets = newArray;

        //            return true;
        //        }
        //        else
        //        {
        //            linkedList.AddLast(newNode);
        //            return false;
        //        }
        //    }
        //}

        #endregion
        #region LRU

        #endregion

        #endregion

        //////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region MIND EXPANDERS

        #region Kadane's Algorihtm
        //Finding The Maximum Sum Of Subarrays -- Kadane's Algorithm


        static int MaxSubArraySum(int[] a, int size)
        {
            int maxSoFar = a[0];
            int maxEndingHere = 0;

            for (int i = 0; i < size; i++)
            {
                maxEndingHere += a[i];

                if (maxEndingHere < 0)
                    maxEndingHere = 0;

                else if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;
            }

            return maxSoFar;
        }


        static int MaxSubArraySum_butBetter(int[] a, int size)
        {
            int maxSoFar = a[0];
            int currentMax = a[0];

            for (int i = 1; i < size; i++)
            {
                currentMax = Math.Max(a[i], currentMax + a[i]);
                maxSoFar = Math.Max(maxSoFar, currentMax);
            }

            return maxSoFar;
        }
        #endregion

        #region CheapestFlightsWithinKStops
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            PriorityQueue<(int city, int stops, int cost), int> nodes = new();
            Dictionary<int, List<(int city, int price)>> edges = new();

            foreach (var flight in flights)
            {
                if (!edges.ContainsKey(flight[0]))
                {
                    edges[flight[0]] = new();
                }
                edges[flight[0]].Add((flight[1], flight[2]));
            }

            int[][] djikstras = new int[n][];
            for (int i = 0; i < n; i++)
            {
                djikstras[i] = new int[k + 2];
                Array.Fill(djikstras[i], -1);
            }

            nodes.Enqueue((src, 0, 0), 0);

            while (nodes.Count > 0)
            {
                (int city, int stops, int cost) curr = nodes.Dequeue();

                if (curr.city == dst)
                {
                    return curr.cost;
                }

                if (!edges.ContainsKey(curr.city)) continue;

                foreach (var flight in edges[curr.city])
                {
                    int city = flight.city;
                    int total = curr.cost + flight.price;

                    if (city != dst && curr.stops + 1 > k) continue;

                    bool passed = true;
                    for (int i = curr.stops + 1; i > -1; i--)
                    {
                        if (djikstras[city][i] != -1 && djikstras[city][i] <= total)
                        { passed = false; break; }

                    }
                    if (!passed)
                        continue;

                    djikstras[city][curr.stops + 1] = total;
                    nodes.Enqueue((city, curr.stops + 1, total), total);
                }
            }
            return -1;
        }
        #endregion

        #endregion

        #region NEW STUDY PROGRAM

        #region Linked Lists
        #region Two Pointer Techniques

        #region Find Middle Node

        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List
        //    Console.WriteLine("Test Case 1: Empty List");
        //    LinkedList<int> emptyList = new();
        //    TestMiddle(emptyList, 0);

        //    // Test Case 2: Single Element List
        //    Console.WriteLine("\nTest Case 2: Single Element List");
        //    LinkedList<int> singleElementList = new();
        //    singleElementList.AddLast(new Node<int>(10));

        //    TestMiddle(singleElementList, 10);

        //    // Test Case 3: Odd Number of Elements
        //    Console.WriteLine("\nTest Case 3: Odd Number of Elements");
        //    LinkedList<int> oddList = new();
        //    for (int i = 1; i <= 11; i++)
        //    {
        //        oddList.AddLast(new(i));
        //    }
        //    TestMiddle(oddList, 6);

        //    // Test Case 4: Even Number of Elements
        //    Console.WriteLine("\nTest Case 4: Even Number of Elements");
        //    LinkedList<int> evenList = new();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        evenList.AddLast(new(i));
        //    }

        //    TestMiddle(evenList, 5);

        //    // Test Case 5: Large List
        //    Console.WriteLine("\nTest Case 5: Large List");
        //    LinkedList<int> largeList = new();
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        largeList.AddLast(new(i));
        //    }
        //    TestMiddle(largeList, 50);
        //}
        //static void TestMiddle<T>(LinkedList<T> list, T expectedMiddle)
        //{
        //    try
        //    {
        //        Node<T> middleNode = list.LinkedListMiddle();

        //        if (middleNode == null)
        //        {
        //            Console.WriteLine("✓ Correctly returned null for empty list");
        //        }
        //        else
        //        {
        //            Console.WriteLine(middleNode.Data.Equals(expectedMiddle)
        //                ? $"✓ Correct middle node: {middleNode.Data}"
        //                : $"✗ Expected {expectedMiddle}, but got {middleNode.Data}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"✗ Unexpected exception: {ex.Message}");
        //    }
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }
        //}

        #endregion
        #region Find Loop
        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List (No Loop)
        //    Console.WriteLine("Test Case 1: Empty List (No Loop)");
        //    LinkedList<int> emptyList = new LinkedList<int>();
        //    TestFindLoop(emptyList, false);

        //    // Test Case 2: Single Element List (No Loop)
        //    Console.WriteLine("\nTest Case 2: Single Element List (No Loop)");
        //    LinkedList<int> singleElementList = new LinkedList<int>();
        //    singleElementList.AddLast(new Node<int>(10));
        //    TestFindLoop(singleElementList, false);

        //    // Test Case 3: List with No Loop
        //    Console.WriteLine("\nTest Case 3: List with No Loop");
        //    LinkedList<int> noLoopList = new LinkedList<int>();
        //    int[] noLoopArray = new int[] { 1, 2, 3, 4, 5 };
        //    foreach (int value in noLoopArray)
        //    {
        //        noLoopList.AddLast(new Node<int>(value));
        //    }
        //    TestFindLoop(noLoopList, false);

        //    // Test Case 4: List with Loop at End
        //    Console.WriteLine("\nTest Case 4: List with Loop at End");
        //    LinkedList<int> endLoopList = CreateListWithLoop(new int[] { 1, 2, 3, 4, 5 }, 0);
        //    TestFindLoop(endLoopList, true);

        //    // Test Case 5: List with Loop in Middle
        //    Console.WriteLine("\nTest Case 5: List with Loop in Middle");
        //    LinkedList<int> middleLoopList = CreateListWithLoop(new int[] { 1, 2, 3, 4, 5 }, 2);
        //    TestFindLoop(middleLoopList, true);

        //    // Test Case 6: List with Single Element Loop
        //    Console.WriteLine("\nTest Case 6: List with Single Element Loop");
        //    LinkedList<int> singleElementLoopList = CreateListWithLoop(new int[] { 1 }, 0);
        //    TestFindLoop(singleElementLoopList, true);
        //}

        //// Helper method to create a list with a loop
        //static LinkedList<T> CreateListWithLoop<T>(T[] arr, int loopIndex)
        //{
        //    LinkedList<T> list = new LinkedList<T>();

        //    // Create nodes and add them to the list
        //    Node<T>[] nodes = new Node<T>[arr.Length];
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        nodes[i] = new Node<T>(arr[i]);
        //        list.AddLast(nodes[i]);
        //    }

        //    if (loopIndex >= 0 && loopIndex < nodes.Length)
        //    {
        //        // Find the last node
        //        Node<T> curr = list.First;
        //        while (curr.Next != null)
        //        {
        //            curr = curr.Next;
        //        }

        //        // Connect last node to the loop start node
        //        curr.Next = nodes[loopIndex];
        //    }

        //    return list;
        //}

        //// Test method to verify loop detection
        //static void TestFindLoop<T>(LinkedList<T> list, bool expectedLoopResult)
        //{
        //    try
        //    {
        //        bool hasLoop = list.FindLoop();

        //        Console.WriteLine(hasLoop == expectedLoopResult
        //            ? $"✓ Correctly detected loop: {hasLoop}"
        //            : $"✗ Expected loop to be {expectedLoopResult}, but got {hasLoop}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"✗ Unexpected exception: {ex.Message}");
        //    }
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }

        //        Count++;
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }

        //    public bool FindLoop()
        //    {
        //        if (First == null)
        //            return false;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return true;
        //        }

        //        return false;
        //    }
        //}
        #endregion
        #region Reverse Singly Linked List
        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List
        //    Console.WriteLine("Test Case 1: Empty List");
        //    LinkedList<int> emptyList = new LinkedList<int>();
        //    TestReverse(emptyList, new int[] { });

        //    // Test Case 2: Single Element List
        //    Console.WriteLine("\nTest Case 2: Single Element List");
        //    LinkedList<int> singleElementList = CreateList(new int[] { 10 });
        //    TestReverse(singleElementList, new int[] { 10 });

        //    // Test Case 3: Two Element List
        //    Console.WriteLine("\nTest Case 3: Two Element List");
        //    LinkedList<int> twoElementList = CreateList(new int[] { 1, 2 });
        //    TestReverse(twoElementList, new int[] { 2, 1 });

        //    // Test Case 4: Multiple Element List
        //    Console.WriteLine("\nTest Case 4: Multiple Element List");
        //    LinkedList<int> multiElementList = CreateList(new int[] { 1, 2, 3, 4, 5 });
        //    TestReverse(multiElementList, new int[] { 5, 4, 3, 2, 1 });
        //}

        //// Helper method to create a list
        //static LinkedList<T> CreateList<T>(T[] arr)
        //{
        //    LinkedList<T> list = new LinkedList<T>();
        //    foreach (T value in arr)
        //    {
        //        list.AddLast(new Node<T>(value));
        //    }
        //    return list;
        //}

        //// Test method to verify list reversal
        //static void TestReverse<T>(LinkedList<T> list, T[] expectedOrder)
        //{
        //    list.Reverse();

        //    Node<T> current = list.First;
        //    bool isCorrect = true;

        //    for (int i = 0; i < expectedOrder.Length; i++)
        //    {
        //        if (current == null || !current.Data.Equals(expectedOrder[i]))
        //        {
        //            isCorrect = false;
        //            break;
        //        }
        //        current = current.Next;
        //    }

        //    // Check if list length matches
        //    isCorrect = isCorrect && (current == null) && (expectedOrder.Length >= 0);

        //    Console.WriteLine(isCorrect
        //        ? "✓ List correctly reversed"
        //        : "✗ List reversal failed");
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }

        //        Count++;
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }

        //    public bool FindLoop()
        //    {
        //        if (First == null)
        //            return false;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return true;
        //        }

        //        return false;
        //    }

        //    public void Reverse()
        //    {
        //        if (!(First == null || Count == 0))
        //        {
        //            Node<T>? prev = null;
        //            Node<T>? currNode = First;
        //            //If we hadn't nullable types, we would set this to First.
        //            Node<T>? nextNode = currNode.Next;

        //            do
        //            {
        //                currNode.Next = prev;
        //                prev = currNode;
        //                currNode = nextNode;

        //                nextNode = currNode?.Next;
        //            }
        //            while (currNode != null);

        //            First = prev;
        //        }
        //    }
        //}

        #endregion
        #region NthNodeFromEnd
        //static void Main(string[] args)
        //{
        //    LinkedList<int> list = new LinkedList<int>();
        //    int[] elements = { 1, 2, 3, 4, 5 };
        //    foreach (int value in elements)
        //    {
        //        list.AddLast(new Node<int>(value));
        //    }

        //    // Test cases
        //    TestNthFromEnd(list, 1, 5);  // First from end
        //    TestNthFromEnd(list, 3, 3);  // Middle from end
        //    TestNthFromEnd(list, 5, 1);  // Last from end
        //    TestNthFromEnd(list, 6, null);  // Beyond list length

        //    LinkedList<int> emptyList = new LinkedList<int>();
        //    TestNthFromEnd(emptyList, 1, null);  // Empty list
        //}

        //static void TestNthFromEnd(LinkedList<int> list, int n, int? expectedValue)
        //{
        //    Node<int>? result = list.NthNodeFromEnd(n);

        //    bool isCorrect = (result == null && expectedValue == null) ||
        //                     (result != null && result.Data == expectedValue);

        //    Console.WriteLine(isCorrect
        //        ? $"✓ Correctly found {n}th node from end: {result?.Data}"
        //        : $"✗ Expected {expectedValue}, got {result?.Data}");
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }

        //        Count++;
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }

        //    public bool FindLoop()
        //    {
        //        if (First == null)
        //            return false;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return true;
        //        }

        //        return false;
        //    }

        //    public void Reverse()
        //    {
        //        if (!(First == null || Count == 0))
        //        {
        //            Node<T>? prev = null;
        //            Node<T>? currNode = First;
        //            //If we hadn't nullable types, we would set this to First.
        //            Node<T>? nextNode = currNode.Next;

        //            do
        //            {
        //                currNode.Next = prev;
        //                prev = currNode;
        //                currNode = nextNode;

        //                nextNode = currNode?.Next;
        //            }
        //            while (currNode != null);

        //            First = prev;
        //        }
        //    }

        //    public Node<T>? NthNodeFromEnd(int n)
        //    {
        //        if (n <= Count)
        //        {
        //            Node<T>? q = First;
        //            Node<T>? p = First;

        //            for (int i = 0; i < n; i++)
        //            {
        //                q = q?.Next;
        //            }

        //            while (q != null)
        //            {
        //                q = q?.Next;
        //                p = p?.Next;
        //            }

        //            return p;
        //        }

        //        return null;
        //    }
        //}
        #endregion
        #region Intersection Point of Two Linked Lists
        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List Reversal
        //    Console.WriteLine("Test Case 1: Empty List");
        //    TestReversal(new LinkedList<int>());

        //    // Test Case 2: Single Element List
        //    Console.WriteLine("\nTest Case 2: Single Element List");
        //    var singleElementList = new LinkedList<int>();
        //    singleElementList.AddLast(new Node<int>(42));
        //    TestReversal(singleElementList);

        //    // Test Case 3: Two Element List
        //    Console.WriteLine("\nTest Case 3: Two Element List");
        //    var twoElementList = new LinkedList<int>();
        //    twoElementList.AddLast(new Node<int>(1));
        //    twoElementList.AddLast(new Node<int>(2));
        //    TestReversal(twoElementList);

        //    // Test Case 4: Multiple Element List
        //    Console.WriteLine("\nTest Case 4: Multiple Element List");
        //    var multiElementList = new LinkedList<int>();
        //    multiElementList.AddLast(new Node<int>(1));
        //    multiElementList.AddLast(new Node<int>(2));
        //    multiElementList.AddLast(new Node<int>(3));
        //    multiElementList.AddLast(new Node<int>(4));
        //    multiElementList.AddLast(new Node<int>(5));
        //    TestReversal(multiElementList);
        //}

        //// Helper method to test list reversal and print results
        //static void TestReversal(LinkedList<int> list)
        //{
        //    // Print original list
        //    Console.WriteLine("Original List:");
        //    PrintList(list.First);
        //    Console.WriteLine($"Original Count: {list.Count}");

        //    // Reverse the list
        //    list.RecursiveReverse(list.First);

        //    // Print reversed list
        //    Console.WriteLine("Reversed List:");
        //    PrintList(list.First);
        //    Console.WriteLine($"Reversed Count: {list.Count}");
        //}

        //// Helper method to print the list
        //static void PrintList(Node<int>? head)
        //{
        //    if (head == null)
        //    {
        //        Console.WriteLine("Empty list");
        //        return;
        //    }

        //    Node<int>? current = head;
        //    while (current != null)
        //    {
        //        Console.Write(current.Data + " -> ");
        //        current = current.Next;
        //    }
        //    Console.WriteLine("null");
        //}

        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }

        //        Count++;
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }

        //    public bool FindLoop()
        //    {
        //        if (First == null)
        //            return false;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return true;
        //        }

        //        return false;
        //    }

        //    public Node<T>? NthNodeFromEnd(int n)
        //    {
        //        if (n <= Count)
        //        {
        //            Node<T>? q = First;
        //            Node<T>? p = First;

        //            for (int i = 0; i < n; i++)
        //            {
        //                q = q?.Next;
        //            }

        //            while (q != null)
        //            {
        //                q = q?.Next;
        //                p = p?.Next;
        //            }

        //            return p;
        //        }

        //        return null;
        //    }

        //    public Node<T>? IntersectionPointofTwoLinkedLists(LinkedList<T> otherLinkedList)
        //    {
        //        if (otherLinkedList != null && otherLinkedList.First != null && First != null)
        //        {
        //            Node<T>? p = First;
        //            Node<T>? q = otherLinkedList.First;

        //            if (Count < otherLinkedList.Count)
        //            {
        //                int skipCount = otherLinkedList.Count - Count;
        //                while (q != null && skipCount != 0)
        //                {
        //                    q = q?.Next;
        //                }
        //            }
        //            else if (Count > otherLinkedList.Count)
        //            {
        //                int skipCount = Count - otherLinkedList.Count;
        //                while (p != null && skipCount != 0)
        //                {
        //                    p = p?.Next;
        //                    skipCount--;
        //                }
        //            }


        //            while (p?.Next != null && q?.Next != null)
        //            {
        //                p = p.Next;
        //                q = q.Next;
        //                if (p == q)
        //                    return p;
        //            }
        //        }

        //        return null;
        //    }
        //}
        #endregion

        #endregion
        #region Reversing Linked Lists

        #region Recursive Reverse
        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List Reversal
        //    Console.WriteLine("Test Case 1: Empty List");
        //    TestReversal(new LinkedList<int>());

        //    // Test Case 2: Single Element List
        //    Console.WriteLine("\nTest Case 2: Single Element List");
        //    var singleElementList = new LinkedList<int>();
        //    singleElementList.AddLast(new Node<int>(42));
        //    TestReversal(singleElementList);

        //    // Test Case 3: Two Element List
        //    Console.WriteLine("\nTest Case 3: Two Element List");
        //    var twoElementList = new LinkedList<int>();
        //    twoElementList.AddLast(new Node<int>(1));
        //    twoElementList.AddLast(new Node<int>(2));
        //    TestReversal(twoElementList);

        //    // Test Case 4: Multiple Element List
        //    Console.WriteLine("\nTest Case 4: Multiple Element List");
        //    var multiElementList = new LinkedList<int>();
        //    multiElementList.AddLast(new Node<int>(1));
        //    multiElementList.AddLast(new Node<int>(2));
        //    multiElementList.AddLast(new Node<int>(3));
        //    multiElementList.AddLast(new Node<int>(4));
        //    multiElementList.AddLast(new Node<int>(5));
        //    TestReversal(multiElementList);
        //}

        //// Helper method to test list reversal and print results
        //static void TestReversal(LinkedList<int> list)
        //{
        //    // Print original list
        //    Console.WriteLine("Original List:");
        //    PrintList(list.First);
        //    Console.WriteLine($"Original Count: {list.Count}");

        //    // Reverse the list
        //    list.RecursiveReverse(list.First);

        //    // Print reversed list
        //    Console.WriteLine("Reversed List:");
        //    PrintList(list.First);
        //    Console.WriteLine($"Reversed Count: {list.Count}");
        //}

        //// Helper method to print the list
        //static void PrintList(Node<int>? head)
        //{
        //    if (head == null)
        //    {
        //        Console.WriteLine("Empty list");
        //        return;
        //    }

        //    Node<int>? current = head;
        //    while (current != null)
        //    {
        //        Console.Write(current.Data + " -> ");
        //        current = current.Next;
        //    }
        //    Console.WriteLine("null");
        //}

        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }

        //        Count++;
        //    }
        //    public Node<T> LinkedListMiddle()
        //    {
        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            if (leftIdx != null)
        //                rightIdx = rightIdx.Next;
        //        }

        //        return rightIdx;
        //    }

        //    public bool FindLoop()
        //    {
        //        if (First == null)
        //            return false;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return true;
        //        }

        //        return false;
        //    }

        //    public void Reverse()
        //    {
        //        if (!(First == null || Count == 0))
        //        {
        //            Node<T>? prev = null;
        //            Node<T>? currNode = First;
        //            //If we hadn't nullable types, we would set this to First.
        //            Node<T>? nextNode = currNode.Next;

        //            do
        //            {
        //                currNode.Next = prev;
        //                prev = currNode;
        //                currNode = nextNode;

        //                nextNode = currNode?.Next;
        //            }
        //            while (currNode != null);

        //            First = prev;
        //        }
        //    }

        //    public void RecursiveReverse(Node<T>? currentNode, Node<T>? previousNode = null)
        //    {
        //        if (currentNode == null)
        //            First = previousNode;
        //        else
        //        {
        //            Node<T>? prev = previousNode;
        //            Node<T>? currNode = currentNode;
        //            Node<T>? nextNode = currNode.Next;

        //            currentNode.Next = prev;
        //            prev = currentNode;
        //            currNode = nextNode;

        //            RecursiveReverse(currNode, prev);
        //        }
        //    }

        //    public Node<T>? NthNodeFromEnd(int n)
        //    {
        //        if (n <= Count)
        //        {
        //            Node<T>? q = First;
        //            Node<T>? p = First;

        //            for (int i = 0; i < n; i++)
        //            {
        //                q = q?.Next;
        //            }

        //            while (q != null)
        //            {
        //                q = q?.Next;
        //                p = p?.Next;
        //            }

        //            return p;
        //        }

        //        return null;
        //    }

        //    public Node<T>? IntersectionPointofTwoLinkedLists(LinkedList<T> otherLinkedList)
        //    {
        //        if (otherLinkedList != null && otherLinkedList.First != null && First != null)
        //        {
        //            Node<T>? p = First;
        //            Node<T>? q = otherLinkedList.First;

        //            if (Count < otherLinkedList.Count)
        //            {
        //                int skipCount = otherLinkedList.Count - Count;
        //                while (q != null && skipCount != 0)
        //                {
        //                    q = q?.Next;
        //                }
        //            }
        //            else if (Count > otherLinkedList.Count)
        //            {
        //                int skipCount = Count - otherLinkedList.Count;
        //                while (p != null && skipCount != 0)
        //                {
        //                    p = p?.Next;
        //                    skipCount--;
        //                }
        //            }


        //            while (p?.Next != null && q?.Next != null)
        //            {
        //                p = p.Next;
        //                q = q.Next;
        //                if (p == q)
        //                    return p;
        //            }
        //        }

        //        return null;
        //    }
        //}

        #endregion
        #region Recursive&Imperative Reverse with Doubly-Linked List
        //static void Main(string[] args)
        //{
        //    // Test Case 1: Empty List Reversal
        //    Console.WriteLine("Test Case 1: Empty List");
        //    TestReversal(new DoublyLinkedList<int>());

        //    // Test Case 2: Single Element List
        //    Console.WriteLine("\nTest Case 2: Single Element List");
        //    var singleElementList = new DoublyLinkedList<int>();
        //    singleElementList.AddLast(new Node<int>(42));
        //    TestReversal(singleElementList);

        //    // Test Case 3: Two Element List
        //    Console.WriteLine("\nTest Case 3: Two Element List");
        //    var twoElementList = new DoublyLinkedList<int>();
        //    twoElementList.AddLast(new Node<int>(1));
        //    twoElementList.AddLast(new Node<int>(2));
        //    TestReversal(twoElementList);

        //    // Test Case 4: Multiple Element List
        //    Console.WriteLine("\nTest Case 4: Multiple Element List");
        //    var multiElementList = new DoublyLinkedList<int>();
        //    multiElementList.AddLast(new Node<int>(1));
        //    multiElementList.AddLast(new Node<int>(2));
        //    multiElementList.AddLast(new Node<int>(3));
        //    multiElementList.AddLast(new Node<int>(4));
        //    multiElementList.AddLast(new Node<int>(5));
        //    TestReversal(multiElementList);
        //}

        //// Helper method to test list reversal and print results
        //static void TestReversal(DoublyLinkedList<int> list)
        //{
        //    // Print original list (forward)
        //    Console.WriteLine("Original List (Forward):");
        //    PrintListForward(list.First);
        //    Console.WriteLine($"Original Count: {list.Count}");

        //    // Print original list (backward)
        //    Console.WriteLine("\nOriginal List (Backward):");
        //    PrintListBackward(GetLastNode(list.First));

        //    // Reverse the list
        //    list.RecursiveReverse(list.First);

        //    // Print reversed list (forward)
        //    Console.WriteLine("\nReversed List (Forward):");
        //    PrintListForward(list.First);

        //    // Print reversed list (backward)
        //    Console.WriteLine("\nReversed List (Backward):");
        //    PrintListBackward(GetLastNode(list.First));

        //    Console.WriteLine($"Reversed Count: {list.Count}");
        //}

        //// Helper method to print the list forward
        //static void PrintListForward(Node<int>? head)
        //{
        //    if (head == null)
        //    {
        //        Console.WriteLine("Empty list");
        //        return;
        //    }

        //    Node<int>? current = head;
        //    while (current != null)
        //    {
        //        Console.Write(current.Data + " -> ");
        //        current = current.Next;
        //    }
        //    Console.WriteLine("null");
        //}

        //// Helper method to print the list backward
        //static void PrintListBackward(Node<int>? tail)
        //{
        //    if (tail == null)
        //    {
        //        Console.WriteLine("Empty list");
        //        return;
        //    }

        //    Node<int>? current = tail;
        //    while (current != null)
        //    {
        //        Console.Write(current.Data + " -> ");
        //        current = current.Previous;
        //    }
        //    Console.WriteLine("null");
        //}

        //// Helper method to get the last node
        //static Node<int>? GetLastNode(Node<int>? head)
        //{
        //    if (head == null) return null;

        //    Node<int>? current = head;
        //    while (current.Next != null)
        //    {
        //        current = current.Next;
        //    }
        //    return current;
        //}


        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }
        //    public Node<T>? Previous { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}
        //public class DoublyLinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; set; }

        //    public DoublyLinkedList()
        //    {
        //        this.First = null;
        //    }
        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else if (Count == 1)
        //        {
        //            First.Next = node;
        //            node.Previous = First;
        //        }
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //            node.Previous = curr;
        //        }

        //        Count++;
        //    }

        //    public void ImperativeReverse()
        //    {
        //        if (Count <= 1)
        //            return;

        //        Node<T>? currNode = First;
        //        Node<T>? nextNode = First?.Next;
        //        Node<T>? prevNode = First?.Previous;

        //        //we could've used do/while but for that we should've cheked the null status of currNode before
        //        //since we utilize the nullable types feature of C# we skip that.
        //        while (currNode != null)
        //        {
        //            currNode.Previous = nextNode;
        //            currNode.Next = prevNode;
        //            if (currNode.Previous != null)
        //            {
        //                currNode = nextNode;

        //                nextNode = currNode?.Next;
        //                prevNode = currNode?.Previous;
        //            }
        //            else
        //            {
        //                First = currNode;
        //                currNode = null;
        //            }
        //        }
        //    }

        //    public void RecursiveReverse(Node<T>? currentNode)
        //    {
        //        if (Count <= 1 || currentNode == null)
        //            return;

        //        Node<T>? currNode = currentNode;
        //        Node<T>? prevNode = currentNode?.Previous;
        //        Node<T>? nextNode = currentNode?.Next;


        //        currNode.Previous = nextNode;
        //        currNode.Next = prevNode;
        //        currNode = nextNode;

        //        //How to avoid settings First at every iteration?
        //        First = currentNode;
        //        RecursiveReverse(currNode);
        //    }
        //}

        #endregion

        #endregion
        #region Remove Cycle

        #region Hashing
        //    public static void Main()
        //    {
        //        Console.WriteLine("Test Case 1: Empty List");
        //        var emptyList = new LinkedList<int>();
        //        Console.WriteLine("Before:");
        //        emptyList.PrintList();
        //        emptyList.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        emptyList.PrintList();
        //        Console.WriteLine();

        //        Console.WriteLine("Test Case 2: Single Node, No Cycle");
        //        var singleNodeList = new LinkedList<int>();
        //        singleNodeList.AddLast(new Node<int>(10));
        //        Console.WriteLine("Before:");
        //        singleNodeList.PrintList();
        //        singleNodeList.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        singleNodeList.PrintList();
        //        Console.WriteLine();

        //        Console.WriteLine("Test Case 3: Single Node, Cycle");
        //        var singleNodeCycle = new LinkedList<int>();
        //        var node = new Node<int>(20);
        //        node.Next = node; // Create a cycle
        //        singleNodeCycle.AddLast(node);
        //        Console.WriteLine("Before:");
        //        singleNodeCycle.PrintList();
        //        singleNodeCycle.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        singleNodeCycle.PrintList();
        //        Console.WriteLine();

        //        Console.WriteLine("Test Case 4: Multiple Nodes, No Cycle");
        //        var noCycleList = new LinkedList<int>();
        //        noCycleList.AddLast(new Node<int>(1));
        //        noCycleList.AddLast(new Node<int>(2));
        //        noCycleList.AddLast(new Node<int>(3));
        //        Console.WriteLine("Before:");
        //        noCycleList.PrintList();
        //        noCycleList.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        noCycleList.PrintList();
        //        Console.WriteLine();

        //        Console.WriteLine("Test Case 5: Multiple Nodes, Cycle in Middle");
        //        var midCycleList = new LinkedList<int>();
        //        var node1 = new Node<int>(1);
        //        var node2 = new Node<int>(2);
        //        var node3 = new Node<int>(3);
        //        midCycleList.AddLast(node1);
        //        midCycleList.AddLast(node2);
        //        midCycleList.AddLast(node3);
        //        node3.Next = node2; // Create a cycle
        //        Console.WriteLine("Before:");
        //        midCycleList.PrintList();
        //        midCycleList.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        midCycleList.PrintList();
        //        Console.WriteLine();

        //        Console.WriteLine("Test Case 6: Multiple Nodes, Cycle at End");
        //        var fullCycleList = new LinkedList<int>();
        //        var nodeA = new Node<int>(1);
        //        var nodeB = new Node<int>(2);
        //        var nodeC = new Node<int>(3);
        //        fullCycleList.AddLast(nodeA);
        //        fullCycleList.AddLast(nodeB);
        //        fullCycleList.AddLast(nodeC);
        //        nodeC.Next = nodeA; // Create a full cycle
        //        Console.WriteLine("Before:");
        //        fullCycleList.PrintList();
        //        fullCycleList.RemoveCycleHashing();
        //        Console.WriteLine("After:");
        //        fullCycleList.PrintList();
        //        Console.WriteLine();
        //    }
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; private set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }

        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }
        //        Count++;
        //    }

        //    public void RemoveCycleHashing()
        //    {
        //        Node<T>? prev = null;
        //        Node<T>? curr = this.First;
        //        HashSet<Node<T>> prevNodes = new();

        //        while (curr != null)
        //        {
        //            if (prevNodes.Contains(curr))
        //            {
        //                if (prev != null)
        //                {
        //                    prev.Next = null;
        //                }
        //                return;
        //            }


        //            prevNodes.Add(curr);
        //            prev = curr;
        //            curr = curr.Next;
        //        }
        //    }

        //    public void PrintList()
        //    {
        //        Node<T>? curr = First;
        //        HashSet<Node<T>> visited = new();
        //        while (curr != null)
        //        {
        //            Console.Write($"{curr.Data} -> ");
        //            if (visited.Contains(curr))
        //            {
        //                Console.WriteLine($"(cycle detected at {curr.Data})");
        //                break;
        //            }
        //            visited.Add(curr);
        //            curr = curr.Next;
        //        }

        //        if (curr == null)
        //            Console.WriteLine("null");
        //    }
        //}

        #endregion
        #region Floyd's Algo
        //    public static void Main()
        //    {
        //        // Test Case 1: Empty List
        //        Console.WriteLine("Test Case 1: Empty List");
        //        var emptyList = new LinkedList<int>();
        //        var slow = emptyList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        //        emptyList.RemoveCycleFloydAlgoFast(slow);
        //        emptyList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 2: Single Node, No Cycle
        //        Console.WriteLine("Test Case 2: Single Node, No Cycle");
        //        var singleNodeList = new LinkedList<int>();
        //        singleNodeList.AddLast(new Node<int>(10));
        //        slow = singleNodeList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        //        singleNodeList.RemoveCycleFloydAlgoFast(slow);
        //        singleNodeList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 3: Single Node, Cycle
        //        Console.WriteLine("Test Case 3: Single Node, Cycle");
        //        var singleNodeCycle = new LinkedList<int>();
        //        var node = new Node<int>(20);
        //        node.Next = node; // Create a cycle
        //        singleNodeCycle.AddLast(node);
        //        slow = singleNodeCycle.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        singleNodeCycle.RemoveCycleFloydAlgoFast(slow);
        //        singleNodeCycle.PrintList();
        //        Console.WriteLine();

        //        // Test Case 4: Two Nodes, No Cycle
        //        Console.WriteLine("Test Case 4: Two Nodes, No Cycle");
        //        var twoNodeList = new LinkedList<int>();
        //        twoNodeList.AddLast(new Node<int>(1));
        //        twoNodeList.AddLast(new Node<int>(2));
        //        slow = twoNodeList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        //        twoNodeList.RemoveCycleFloydAlgoFast(slow);
        //        twoNodeList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 5: Two Nodes, Cycle
        //        Console.WriteLine("Test Case 5: Two Nodes, Cycle");
        //        var twoNodeCycle = new LinkedList<int>();
        //        var node1 = new Node<int>(1);
        //        var node2 = new Node<int>(2);
        //        twoNodeCycle.AddLast(node1);
        //        twoNodeCycle.AddLast(node2);
        //        node2.Next = node1; // Create a cycle
        //        slow = twoNodeCycle.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        twoNodeCycle.RemoveCycleFloydAlgoFast(slow);
        //        twoNodeCycle.PrintList();
        //        Console.WriteLine();

        //        // Test Case 6: Multiple Nodes, No Cycle
        //        Console.WriteLine("Test Case 6: Multiple Nodes, No Cycle");
        //        var noCycleList = new LinkedList<int>();
        //        noCycleList.AddLast(new Node<int>(1));
        //        noCycleList.AddLast(new Node<int>(2));
        //        noCycleList.AddLast(new Node<int>(3));
        //        noCycleList.AddLast(new Node<int>(4));
        //        slow = noCycleList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : "Loop detected");
        //        noCycleList.RemoveCycleFloydAlgoFast(slow);
        //        noCycleList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 7: Multiple Nodes, Cycle in Middle
        //        Console.WriteLine("Test Case 7: Multiple Nodes, Cycle in Middle");
        //        var midCycleList = new LinkedList<int>();
        //        var midNode1 = new Node<int>(1);
        //        var midNode2 = new Node<int>(2);
        //        var midNode3 = new Node<int>(3);
        //        midCycleList.AddLast(midNode1);
        //        midCycleList.AddLast(midNode2);
        //        midCycleList.AddLast(midNode3);
        //        midNode3.Next = midNode2; // Create a cycle
        //        slow = midCycleList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        midCycleList.RemoveCycleFloydAlgoFast(slow);
        //        midCycleList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 8: Multiple Nodes, Cycle at End
        //        Console.WriteLine("Test Case 8: Multiple Nodes, Cycle at End");
        //        var endCycleList = new LinkedList<int>();
        //        var endNode1 = new Node<int>(1);
        //        var endNode2 = new Node<int>(2);
        //        var endNode3 = new Node<int>(3);
        //        endCycleList.AddLast(endNode1);
        //        endCycleList.AddLast(endNode2);
        //        endCycleList.AddLast(endNode3);
        //        endNode3.Next = endNode1; // Create a cycle
        //        slow = endCycleList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        endCycleList.RemoveCycleFloydAlgoFast(slow);
        //        endCycleList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 9: Very Large List with Cycle
        //        Console.WriteLine("Test Case 9: Very Large List with Cycle");
        //        var largeCycleList = new LinkedList<int>();
        //        Node<int>? first = null, middle = null;
        //        for (int i = 1; i <= 1000; i++)
        //        {
        //            var newNode = new Node<int>(i);
        //            if (i == 1) first = newNode;
        //            if (i == 500) middle = newNode;
        //            largeCycleList.AddLast(newNode);
        //        }
        //        largeCycleList.AddLast(middle!); // Create a cycle at node 500
        //        slow = largeCycleList.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        largeCycleList.RemoveCycleFloydAlgoFast(slow);
        //        largeCycleList.PrintList();
        //        Console.WriteLine();

        //        // Test Case 10: Multiple Nodes, Cycle at middle
        //        Console.WriteLine("Test Case 10: Multiple Nodes, Cycle at middle");
        //        var cycleMiddle = new LinkedList<int>();
        //        var cycleMiddleNode1 = new Node<int>(1);
        //        var cycleMiddleNode2 = new Node<int>(2);
        //        var cycleMiddleNode3 = new Node<int>(3);
        //        var cycleMiddleNode4 = new Node<int>(4);
        //        var cycleMiddleNode5 = new Node<int>(5);
        //        var cycleMiddleNode6 = new Node<int>(6);
        //        var cycleMiddleNode7 = new Node<int>(7);
        //        cycleMiddle.AddLast(cycleMiddleNode1);
        //        cycleMiddle.AddLast(cycleMiddleNode2);
        //        cycleMiddle.AddLast(cycleMiddleNode3);
        //        cycleMiddle.AddLast(cycleMiddleNode4);
        //        cycleMiddle.AddLast(cycleMiddleNode5);
        //        cycleMiddle.AddLast(cycleMiddleNode6);
        //        cycleMiddle.AddLast(cycleMiddleNode7);
        //        cycleMiddleNode7.Next = cycleMiddleNode3; // Create a cycle
        //        slow = cycleMiddle.FindLoop();
        //        Console.WriteLine(slow == null ? "No loop detected" : $"Loop detected at node {slow.Data}");
        //        cycleMiddle.RemoveCycleFloydAlgoFast(slow);
        //        var fiirst = cycleMiddle.First;
        //        while(fiirst != null)
        //        {
        //            Console.WriteLine(fiirst.Data);
        //            fiirst = fiirst.Next;
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; private set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }

        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }
        //        Count++;
        //    }

        //    public void RemoveCycleHashing()
        //    {
        //        Node<T>? prev = null;
        //        Node<T>? curr = this.First;
        //        HashSet<Node<T>> prevNodes = new();

        //        while (curr != null)
        //        {
        //            if (prevNodes.Contains(curr))
        //            {
        //                if (prev != null)
        //                {
        //                    prev.Next = null;
        //                }
        //                return;
        //            }


        //            prevNodes.Add(curr);
        //            prev = curr;
        //            curr = curr.Next;
        //        }
        //    }

        //    public Node<T>? FindLoop()
        //    {
        //        if (First == null)
        //            return null;

        //        Node<T>? leftIdx = First, rightIdx = First;

        //        while (leftIdx != null)
        //        {
        //            leftIdx = leftIdx.Next?.Next;
        //            rightIdx = rightIdx.Next;

        //            if (leftIdx == rightIdx)
        //                return rightIdx;
        //        }

        //        return null;
        //    }

        //    public void RemoveCycleFloydAlgoSlow(Node<T>? slow)
        //    {
        //        for (Node<T>? curr = this.First; curr != null; curr = curr.Next)
        //        {
        //            Node<T>? ptr = slow;

        //            //To make sure that ptr points to the first node in the cycle
        //            //NO THE ABOVE REASON IS NOT THE CASE FOR THIS WHIILE LOOP

        //            //Instead, it's here to get the "ptr" to the Node whose "Next" is "curr"; which will be the node that starts the cycle
        //            //In short, to find the node that points to the "curr" node
        //            //Also the reason for "&&" is to avoid stucking in the while loop
        //            //since "slow" doesn't guaranteed to point to the first node in the cycle,
        //            //it might be pointing to a middle node in the cycle.
        //            //FOR EXAMPLE
        //            //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
        //            //          ↑-------------------←
        //            //"curr" would be "1"
        //            //and "ptr" could be "6".
        //            //In that case, the first condition of the while will *never* be false
        //            //so we need to check if we circled back to "slow" pointer.
        //            //Actually, most of the time the second condition will break the loop;
        //            //in cases of where the first node is incorporated in the cycle,
        //            //that's when the first condition will be helpful.

        //            while (ptr?.Next != curr && ptr?.Next != slow)
        //                ptr = ptr?.Next;


        //            //When the "curr" will get to "3" this condiiton will be met
        //            if (ptr?.Next == curr)
        //            {
        //                ptr.Next = null;
        //                return;
        //            }
        //        }
        //    }

        //    public void RemoveCycleFloydAlgoFast(Node<T>? slow)
        //    {
        //        //FOR EXAMPLE
        //        //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
        //        //          ↑-------------------←


        //        //count of nodes in the cycle
        //        //k = 5
        //        int k = 1;
        //        //Condition here is Next not being slow since slow can be any node in the cycle.
        //        for (Node<T>? ptr = slow; ptr?.Next != slow; ptr = ptr?.Next)
        //            k++;

        //        //Get a pointer to the kth node starting from the head
        //        //curr = 6
        //        //why do we need the for loop tho? can't we just set curr to slow?
        //        //Node<T>? curr = slow;
        //        //Because slow is not guaranteed to be the first node in the cycle.
        //        Node<T>? curr = First;
        //        for (int i = 0; i < k; i++)
        //            curr = curr?.Next;

        //        Node<T>? head = this.First;
        //        //Capture the first node of the cycle!
        //        while (curr != head)
        //        {
        //            curr = curr?.Next;
        //            head = head?.Next;
        //        }

        //        //Go to the end node of the cycle.
        //        //Can we do it "k" times with for loop?
        //        //while (curr?.Next != head)
        //        //    curr = curr?.Next;
        //        for (int i = 1; i <= k; i++)
        //            curr = curr?.Next;

        //        if (curr != null)
        //            curr.Next = null;
        //    }
        //    public void PrintList()
        //    {
        //        Node<T>? curr = First;
        //        HashSet<Node<T>> visited = new();
        //        while (curr != null)
        //        {
        //            Console.Write($"{curr.Data} -> ");
        //            if (visited.Contains(curr))
        //            {
        //                Console.WriteLine($"(cycle detected at {curr.Data})");
        //                break;
        //            }
        //            visited.Add(curr);
        //            curr = curr.Next;
        //        }

        //        if (curr == null)
        //            Console.WriteLine("null");
        //    }
        //}
        #endregion

        #endregion
        #region Intersection Point of Linked Lists
        //    public static void Main()
        //    {
        //        // Test Case 1: Both Lists Are Empty
        //        Console.WriteLine("Test Case 1: Both Lists Are Empty");
        //        var emptyList1 = new LinkedList<int>();
        //        var emptyList2 = new LinkedList<int>();
        //        var intersection = emptyList1.GetIntersectionNodeTwoPointer(emptyList2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 2: One List Is Empty
        //        Console.WriteLine("Test Case 2: One List Is Empty");
        //        var singleNodeList = new LinkedList<int>();
        //        singleNodeList.AddLast(new Node<int>(10));
        //        intersection = singleNodeList.GetIntersectionNodeTwoPointer(emptyList2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 3: Lists Do Not Intersect
        //        Console.WriteLine("Test Case 3: Lists Do Not Intersect");
        //        var list1 = new LinkedList<int>();
        //        list1.AddLast(new Node<int>(1));
        //        list1.AddLast(new Node<int>(2));
        //        list1.AddLast(new Node<int>(3));

        //        var list2 = new LinkedList<int>();
        //        list2.AddLast(new Node<int>(4));
        //        list2.AddLast(new Node<int>(5));
        //        list2.AddLast(new Node<int>(6));

        //        intersection = list1.GetIntersectionNodeTwoPointer(list2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 4: Lists Intersect at Single Node
        //        Console.WriteLine("Test Case 4: Lists Intersect at Single Node");
        //        var commonNode = new Node<int>(100);

        //        var intersectingList1 = new LinkedList<int>();
        //        intersectingList1.AddLast(new Node<int>(1));
        //        intersectingList1.AddLast(new Node<int>(2));
        //        intersectingList1.AddLast(commonNode);

        //        var intersectingList2 = new LinkedList<int>();
        //        intersectingList2.AddLast(new Node<int>(4));
        //        intersectingList2.AddLast(commonNode);

        //        intersection = intersectingList1.GetIntersectionNodeTwoPointer(intersectingList2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 5: Lists Intersect at Last Node
        //        Console.WriteLine("Test Case 5: Lists Intersect at Last Node");
        //        var lastNode = new Node<int>(999);

        //        var endIntersectingList1 = new LinkedList<int>();
        //        endIntersectingList1.AddLast(new Node<int>(10));
        //        endIntersectingList1.AddLast(new Node<int>(20));
        //        endIntersectingList1.AddLast(lastNode);

        //        var endIntersectingList2 = new LinkedList<int>();
        //        endIntersectingList2.AddLast(new Node<int>(30));
        //        endIntersectingList2.AddLast(lastNode);

        //        intersection = endIntersectingList1.GetIntersectionNodeTwoPointer(endIntersectingList2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 6: Lists Are Identical
        //        Console.WriteLine("Test Case 6: Lists Are Identical");
        //        var identicalList = new LinkedList<int>();
        //        identicalList.AddLast(new Node<int>(7));
        //        identicalList.AddLast(new Node<int>(8));
        //        identicalList.AddLast(new Node<int>(9));

        //        intersection = identicalList.GetIntersectionNodeTwoPointer(identicalList.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 7: One List Is Longer but No Intersection
        //        Console.WriteLine("Test Case 7: One List Is Longer but No Intersection");
        //        var longerList = new LinkedList<int>();
        //        longerList.AddLast(new Node<int>(1));
        //        longerList.AddLast(new Node<int>(2));
        //        longerList.AddLast(new Node<int>(3));
        //        longerList.AddLast(new Node<int>(4));
        //        longerList.AddLast(new Node<int>(5));

        //        var shorterList = new LinkedList<int>();
        //        shorterList.AddLast(new Node<int>(6));
        //        shorterList.AddLast(new Node<int>(7));

        //        intersection = longerList.GetIntersectionNodeTwoPointer(shorterList.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();

        //        // Test Case 8: Lists Intersect with Complex Structure
        //        Console.WriteLine("Test Case 8: Lists Intersect with Complex Structure");
        //        var complexNode1 = new Node<int>(101);
        //        var complexNode2 = new Node<int>(102);
        //        var complexNode3 = new Node<int>(103);

        //        var complexList1 = new LinkedList<int>();
        //        complexList1.AddLast(new Node<int>(1));
        //        complexList1.AddLast(complexNode1);
        //        complexList1.AddLast(complexNode2);
        //        complexList1.AddLast(complexNode3);

        //        var complexList2 = new LinkedList<int>();
        //        complexList2.AddLast(new Node<int>(4));
        //        complexList2.AddLast(new Node<int>(5));
        //        complexList2.AddLast(complexNode2);

        //        intersection = complexList1.GetIntersectionNodeTwoPointer(complexList2.First);
        //        Console.WriteLine(intersection == null ? "No intersection" : $"Intersection at node {intersection.Data}");
        //        Console.WriteLine();
        //    }

        //}
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        //public class LinkedList<T>
        //{
        //    public Node<T>? First { get; private set; }
        //    public int Count { get; private set; }

        //    public LinkedList()
        //    {
        //        this.First = null;
        //    }

        //    public void AddLast(Node<T> node)
        //    {
        //        if (First == null)
        //            First = node;
        //        else
        //        {
        //            Node<T>? curr = First;
        //            while (curr.Next != null)
        //            {
        //                curr = curr.Next;
        //            }
        //            curr.Next = node;
        //        }
        //        Count++;
        //    }

        //    public Node<T>? GetIntersectionNodeHashing(Node<T>? otherListHead)
        //    {
        //        if (First != null)
        //        {
        //            Node<T>? currListHead = First;
        //            HashSet<Node<T>?> nodes = new();

        //            while (otherListHead != null)
        //            {
        //                nodes.Add(otherListHead);
        //                otherListHead = otherListHead.Next;
        //            }

        //            while (currListHead != null)
        //            {
        //                if (nodes.Contains(currListHead))
        //                    return currListHead;
        //                currListHead = currListHead.Next;
        //            }
        //        }

        //        return null;
        //    }

        //    public Node<T>? GetIntersectionNode(Node<T>? q)
        //    {
        //        if (q == null || First == null)
        //            return null;

        //        Node<T>? p = First;
        //        int currListCount = this.Count;
        //        int otherListCount = 0;

        //        var countPtr = q;
        //        while (countPtr != null)
        //        {
        //            otherListCount++;
        //            countPtr = countPtr.Next;
        //        }

        //        if (currListCount > otherListCount)
        //        {
        //            int skipCount = currListCount - otherListCount;
        //            while (p != null && skipCount != 0)
        //            {
        //                p = p.Next;
        //                skipCount--;
        //            }
        //        }
        //        else if (otherListCount > currListCount)
        //        {
        //            int skipCount = otherListCount - currListCount;
        //            while (q != null && skipCount != 0)
        //            {
        //                q = q.Next;
        //                skipCount--;
        //            }
        //        }

        //        while (p != null && q != null)
        //        {
        //            //If check before pointer assignemnt for identical lists.
        //            if (p == q)
        //                return p;
        //            p = p.Next;
        //            q = q.Next;
        //        }

        //        return null;
        //    }
        //    public Node<T>? GetIntersectionNodeTwoPointer(Node<T>? otherListHead)
        //    {
        //        if (First == null || otherListHead == null)
        //            return null;

        //        var ptr1 = First;
        //        var ptr2 = otherListHead;

        //        while (ptr1 != ptr2)
        //        {
        //            ptr1 = (ptr1 == null) ? otherListHead : ptr1.Next;
        //            ptr2 = (ptr2 == null) ? this.First : ptr2.Next;
        //        }

        //        return ptr1;
        //    }
        //}
        #endregion
        #region Merging of Linked Lists(Recursive, Imperative, In-Place)
        //public static void Main()
        //{
        //    Node<int>? mergedList = null;

        //    // Test Case 3: One Node in Each List
        //    Console.WriteLine("Test Case 3: One Node in Each List");
        //    var singleNodeA = new Node<int>(5);
        //    var singleNodeB = new Node<int>(10);
        //    mergedList = MergeLinkedLists(singleNodeA, singleNodeB);
        //    Console.WriteLine("Merged List:");
        //    PrintList(mergedList);
        //    Console.WriteLine();

        //    // Test Case 4: Multiple Nodes in Each List, No Overlap
        //    Console.WriteLine("Test Case 4: Multiple Nodes in Each List, No Overlap");
        //    var listA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        //    var listB = new Node<int>(6) { Next = new Node<int>(8) { Next = new Node<int>(10) } };
        //    mergedList = MergeLinkedLists(listA, listB);
        //    Console.WriteLine("Merged List:");
        //    PrintList(mergedList);
        //    Console.WriteLine();

        //    // Test Case 5: Multiple Nodes in Each List, Overlapping Values
        //    Console.WriteLine("Test Case 5: Multiple Nodes in Each List, Overlapping Values");
        //    var overlappingListA = new Node<int>(1) { Next = new Node<int>(3) { Next = new Node<int>(5) } };
        //    var overlappingListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(6) } };
        //    mergedList = MergeLinkedLists(overlappingListA, overlappingListB);
        //    Console.WriteLine("Merged List:");
        //    PrintList(mergedList);
        //    Console.WriteLine();

        //    // Test Case 6: One List Is Subset of the Other
        //    Console.WriteLine("Test Case 6: One List Is Subset of the Other");
        //    var subsetListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        //    var subsetListB = new Node<int>(2) { Next = new Node<int>(3) { Next = new Node<int>(4) } };
        //    mergedList = MergeLinkedLists(subsetListA, subsetListB);
        //    Console.WriteLine("Merged List:");
        //    PrintList(mergedList);
        //    Console.WriteLine();

        //    // Test Case 7: Lists with Identical Elements
        //    Console.WriteLine("Test Case 7: Lists with Identical Elements");
        //    var identicalListA = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        //    var identicalListB = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) } };
        //    mergedList = MergeLinkedLists(identicalListA, identicalListB);
        //    Console.WriteLine("Merged List:");
        //    PrintList(mergedList);
        //    Console.WriteLine();
        //}
        //// Helper Function to Print a Linked List
        //public static void PrintList(Node<int>? head)
        //{
        //    while (head != null)
        //    {
        //        Console.Write(head.Data + " -> ");
        //        head = head.Next;
        //    }
        //    Console.WriteLine("null");
        //}

        //public static Node<int>? MergeLinkedListsRecursive(Node<int>? headA, Node<int>? headB)
        //{
        //    //Base case is, we arrived at the end of one of the lists.
        //    if (headA == null)
        //        return headB;
        //    else if (headB == null)
        //        return headA;

        //    Node<int>? res;
        //    if (headA.Data < headB.Data)
        //    {
        //        res = headA;
        //        res.Next = MergeLinkedListsRecursive(headA.Next, headB);
        //    }
        //    else
        //    {
        //        res = headB;
        //        res.Next = MergeLinkedListsRecursive(headA, headB.Next);
        //    }

        //    return res;
        //}
        //public static Node<int> MergeLinkedListsImperative(Node<int> headA, Node<int> headB)
        //{
        //    //REMEMBER! THESE ARE POINTERS TO OBJECTS ON THE HEAP NOT SEPARATE ENTITIES!!!
        //    Node<int> dummyNode = new(default);
        //    Node<int> currNode = dummyNode;

        //    while (headA != null && headB != null)
        //    {
        //        if (headA.Data < headB.Data)
        //        {
        //            currNode.Next = headA;
        //            //This would create another object on the heap
        //            //currNode.Next = new(headA.Data);
        //            headA = headA.Next;
        //        }
        //        else
        //        {
        //            currNode.Next = headB;
        //            headB = headB.Next;
        //        }

        //        currNode = currNode.Next;
        //    }

        //    currNode.Next = headA ?? headB;

        //    return dummyNode.Next;
        //}

        //public static Node<int> MergeLinkedLists(Node<int> headA, Node<int> headB)
        //{
        //    if (headA == null)
        //        return headB;
        //    if (headB == null)
        //        return headA;

        //    if (headA.Data < headB.Data)
        //        return MergeLinkedListsInPlace(headA, headB);
        //    else
        //        return MergeLinkedListsInPlace(headB, headA);
        //}
        //public static Node<int> MergeLinkedListsInPlace(Node<int> headA, Node<int> headB)
        //{
        //    //Example
        //    // headA -> 1 -> 3 -> 5
        //    // headB -> 2 -> 4 -> 6
        //    if (headA.Next == null)
        //    {
        //        headA.Next = headB;
        //        return headA;
        //    }

        //    //        1              3
        //    Node<int> curr1 = headA, next1 = headA.Next;
        //    //         2              4
        //    Node<int>? curr2 = headB, next2 = headB.Next;

        //    while (next1 != null && curr2 != null)
        //    {
        //        //if the head of the second list is between head of the first list and its next in terms of value
        //        if (curr2.Data >= curr1.Data && curr2.Data <= next1.Data)
        //        {
        //            //This here is to save us from infinite while loop
        //            //Now that we have concluded that the head of the second list is between head of the first list and its next
        //            //we are going to put it between the first and its next element in the first list.
        //            //As a result, the next value of the head of the second list will be altered.
        //            //Before that happens we need to establish a pointer to it so that or conneciton to rest of the second list persists.
        //            next2 = curr2.Next;

        //            //Put the head of the second list between the head and its next object of the first list
        //            curr1.Next = curr2;
        //            curr2.Next = next1;

        //            //So, after pointing to the head of the second list from curr1Next we should also update curr1 and curr2's pointee right?
        //            curr1 = curr2; //Remember we dont set curr1 as the head of the second list, we point to the object on the heap!
        //            curr2 = next2;
        //        }
        //        else
        //        {
        //            //If there are more than 2 nodes in the first list and the first two nodes are smaller than the first node in the second list.
        //            if (next1.Next != null)
        //            {
        //                next1 = next1.Next;
        //                curr1 = curr1.Next;
        //            }
        //            else
        //            {
        //                //if only 2 nodes exist in the first list and they are both smaller than the first node in the second list.
        //                //Just point the rest of the first list to the head of the second list
        //                next1.Next = curr2;
        //                return headA;
        //            }
        //        }
        //    }

        //    return headA;
        //}
        #endregion
        #region Deep Copy of Linked Lists With Random Pointers
        //public class Node<T>
        //{
        //    public T Data { get; set; }
        //    public Node<T>? Next { get; internal set; }
        //    public Node<T>? Random { get; internal set; }

        //    public Node(T data)
        //    {
        //        this.Data = data;
        //    }
        //}

        ////DRAW MEMORY
        //public static Node<int>? CloneLinkedListRecursiveFast(Node<int>? head)
        //{
        //    // Dictionary provides O(1) lookup with minimal memory overhead
        //    Dictionary<Node<int>, Node<int>> mapping = new();
        //    return CloneListHelper(head, mapping);

        //    static Node<int>? CloneListHelper(Node<int>? currNode, Dictionary<Node<int>, Node<int>> map)
        //    {
        //        if (currNode == null)
        //            return null;

        //        //TryGetValue to avoid double lookup
        //        if (map.TryGetValue(currNode, out Node<int>? value))
        //        {
        //            Console.WriteLine($"This node has already been cloned! {value.Data}");
        //            return value;
        //        }

        //        Console.WriteLine($"This node hasn't been cloned! {currNode.Data}");
        //        // Create new node only once per original node
        //        Node<int> newNode = new(currNode.Data);
        //        map[currNode] = newNode;  // Store mapping immediately to prevent cycles

        //        newNode.Next = CloneListHelper(currNode.Next, map);
        //        //Recursive call for random pointers reuse existing nodes through dictionary lookup
        //        newNode.Random = CloneListHelper(currNode.Random, map);

        //        return newNode;
        //    }
        //}

        //public static Node<int>? CloneLinkedListRecursiveSlow(Node<int>? head)
        //{
        //    List<Node<int>> mapping = new();
        //    return CloneListHelper(head, mapping);

        //    static Node<int>? CloneListHelper(Node<int>? currNode, List<Node<int>> map)
        //    {
        //        if (currNode == null)
        //            return null;

        //        //If the currNode has already been cloned.
        //        if (map.Where(n => n.Data == currNode.Data).FirstOrDefault() is Node<int> existingNode)
        //            return existingNode;

        //        Node<int> newNode = new(currNode.Data);
        //        map.Add(newNode);

        //        newNode.Next = CloneListHelper(currNode.Next, map);
        //        newNode.Random = CloneListHelper(currNode.Random, map);

        //        return newNode;
        //    }
        //}

        ////Violates "None of the pointers in the new list should point to nodes in the original list" rule
        ////DRAW MEMORY FOR THIS AS WELL. TO SEE REFERENCES TO OLD LIST NODES
        //public static Node<int>? CloneLinkedListStupidWay(Node<int> head)
        //{
        //    if (head == null)
        //        return null;

        //    Node<int>? currOriginal = head;
        //    Node<int>? clonedHead = null;
        //    Node<int>? currClonedHead = null;
        //    //This is stupid, there should be a way to do it with references.
        //    int i = 0;

        //    while (currOriginal != null)
        //    {
        //        if (clonedHead == null)
        //        {
        //            clonedHead = new(currOriginal.Data)
        //            {
        //                Next = null,
        //                Random = currOriginal.Random
        //            };
        //            currOriginal = currOriginal.Next;
        //            i++;
        //        }
        //        else
        //        {
        //            currClonedHead = new(currOriginal.Data)
        //            {
        //                Next = currOriginal.Next,
        //                Random = currOriginal.Random
        //            };
        //            i++;
        //            if (i == 2)
        //                clonedHead.Next = currClonedHead;

        //            currClonedHead = currClonedHead.Next;
        //            currOriginal = currOriginal.Next;
        //        }
        //    }

        //    return clonedHead;
        //}

        ////Violates "None of the pointers in the new list should point to nodes in the original list" rule
        ////DRAW MEMORY FOR THIS AS WELL. TO SEE REFERENCES TO OLD LIST NODES
        //public static Node<int>? CloneLinkedListSmarterWay(Node<int> head)
        //{
        //    if (head == null)
        //        return null;

        //    Node<int>? currOriginal = head;
        //    Node<int>? clonedHead = null;
        //    Node<int>? previousCloned = null;  // Keep track of the last Node<int> we created

        //    while (currOriginal != null)
        //    {
        //        Node<int> newNode = new(currOriginal.Data)
        //        {
        //            Random = currOriginal.Random
        //        };

        //        if (clonedHead == null)
        //            clonedHead = newNode;
        //        else
        //            previousCloned!.Next = newNode;


        //        // Update previous Node<int> for next iteration
        //        previousCloned = newNode;
        //        currOriginal = currOriginal.Next;
        //    }

        //    return clonedHead;
        //}

        //public static Node<int>? CloneLinkedListWhyDaFuckWay(Node<int> head)
        //{
        //    if (head == null)
        //        return null;

        //    Node<int>? curr = head;
        //    while (curr != null)
        //    {
        //        Node<int> newNode = new(curr.Data)
        //        {
        //            Next = curr.Next
        //        };
        //        curr.Next = newNode;
        //        curr = newNode.Next;
        //    }

        //    curr = head;
        //    while (curr != null)
        //    {
        //        if (curr.Random != null)
        //            curr.Next!.Random = curr.Random.Next;
        //        curr = curr.Next?.Next;
        //    }

        //    // Separate the new nodes from the original nodes
        //    curr = head;
        //    Node<int>? clonedHead = head.Next;
        //    Node<int>? clone = clonedHead;
        //    while (clone?.Next != null)
        //    {

        //        // Update the next nodes of original node 
        //        // and cloned node
        //        curr!.Next = curr?.Next?.Next;
        //        clone.Next = clone.Next.Next;

        //        // Move pointers of original as well as  
        //        // cloned linked list to their next nodes
        //        curr = curr?.Next;
        //        clone = clone.Next;
        //    }
        //    curr!.Next = null;
        //    clone!.Next = null;

        //    return clonedHead;
        //}

        ////DRAW MEMORY
        //public static Node<int>? CloneLinkedListGeniusWay(Node<int> head)
        //{
        //    if (head == null)
        //        return null;

        //    Dictionary<Node<int>, Node<int>> mapping = new();

        //    Node<int>? curr = head;
        //    while (curr != null)
        //    {
        //        Node<int> newNode = new(curr.Data);
        //        mapping[curr] = newNode;
        //        curr = curr.Next;
        //    }

        //    foreach (var kvp in mapping)
        //    {
        //        Node<int> currNode = kvp.Value;
        //        currNode.Next = kvp.Key.Next != null ? mapping[kvp.Key.Next] : null;
        //        currNode.Random = kvp.Key.Random != null ? mapping[kvp.Key.Random] : null;
        //    }

        //    return mapping[head];
        //}
        #endregion
        #endregion
        #region Trees
        #region Stanford -- Binary Tree
        #region MaxDepth
        //public int max_depth_recursive(Node root)
        //{
        //    if (root == null)
        //        return 0;

        //    return Math.Max(max_depth_recursive(root.Left), max_depth_recursive(root.Right)) + 1;
        //}

        //public int max_depth_imperative_pre_order(Node root)
        //{
        //    if (root == null)
        //        return -1;

        //    int answer = 1;
        //    Stack<(Node, int)> stack = new();
        //    stack.Push((root, 1));

        //    while (stack.Count > 0)
        //    {
        //        (Node currNode, int depth) tuple = stack.Pop();

        //        if (tuple.currNode != null)
        //        {
        //            answer = Math.Max(answer, tuple.depth);
        //            stack.Push((tuple.currNode.Left, tuple.depth + 1));
        //            stack.Push((tuple.currNode.Right, tuple.depth + 1));
        //        }
        //    }

        //    return answer;
        //}
        #endregion
        #region MinValue
        //public int min_value_recursive(Node root)
        //{
        //    if (root.Left == null)
        //        return root.Data;

        //    return min_value_recursive(root.Left);
        //}

        //public int min_value_imperative(Node root)
        //{
        //    if (root == null) return 0;

        //    int answer = -1;
        //    while (root != null)
        //    {
        //        if (root.Left == null)
        //            answer = root.Data;
        //        else
        //            root = root.Left;
        //    }

        //    return answer;
        //}
        #endregion
        #region PrintTree
        //public void print_tree_recursive(Node root)
        //{
        //    if (root == null) return;

        //    print_tree_recursive(root.Left);
        //    Console.WriteLine(root.Data);
        //    print_tree_recursive(root.Right);
        //}
        //public void print_tree(Node root)
        //{
        //    if (root == null) return;

        //    Stack<Node> stack = new();
        //    stack.Push(root);
        //    root = root.Left;

        //    while (stack.Count > 0)
        //    {
        //        //try to conjure a simple binary tree with 3 nodes
        //        //      2
        //        //     / \
        //        //    1   3
        //        //   / \ / \
        //        //  ---NULL---
        //        //In order to print in this order => 1,2,3, you need to first travel all to way to the left-most leaf
        //        //and stack nodes and their left child along the way.
        //        //then you should pop each sub-trees left node and root node subsequently and right after printin the root node
        //        //you should pay a quick visit to the right child and print it as well.
        //        //Then you can rise to the next subtree and repeat the process.

        //        if (root != null)
        //        {
        //            stack.Push(root);
        //            root = root.Left;
        //        }
        //        else
        //        {
        //            root = stack.Pop();
        //            Console.WriteLine(root.Data);
        //            root = root.Right;
        //        }
        //    }
        //}
        #endregion
        #region PrintPostOrder
        //public void print_post_order_recursive(Node root)
        //{
        //    if (root == null) return;

        //    print_post_order_recursive(root.Left);
        //    print_post_order_recursive(root.Right);
        //    Console.WriteLine(root.Data);
        //}
        //public void print_post_order(Node root)
        //{
        //    if (root == null) return;

        //    Stack<Node> stack = new();
        //    stack.Push(root);
        //    root = root.Left;
        //    Node? lastVisitedNode = null;

        //    while (stack.Count > 0)
        //    {
        //        if (root != null)
        //        {
        //            stack.Push(root);
        //            root = root.Left;
        //        }
        //        else
        //        {
        //            Node peekedNode = stack.Peek();

        //            //try to conjure a simple binary tree with 3 nodes
        //            //      2
        //            //     / \
        //            //    1   3
        //            //   / \ / \
        //            //  ---NULL---
        //            //In order to print in this order => 1,3,2, you need to first travel all to way to the left-most leaf
        //            //and stack root nodes with their left child along the way.
        //            //Then you should firs peek the node on top of the stack to check if its a root node by checking its right child,
        //            //if it has a right child set the root to that node and push it on to the stack in the next iteration.
        //            //After pushing it set the root to its left node to see if its also a root node by itself.
        //            //The need for lasVisitedNode variable is to avoid getting stuck on the right child of a root node, if you wouldn't have that
        //            //you'd keep checking the peekedNode's right child(which is available since its a root node) push it on to stack, print and pop it,
        //            //only to push it again in the next iteration because you didn't print the root node just yet; for that we need to check if the lastvisitedNode
        //            //is the right child of the root node.
        //            if (peekedNode.Right != null && lastVisitedNode != peekedNode.Right)
        //                root = peekedNode.Right;
        //            else
        //            {
        //                Console.WriteLine(peekedNode.Data);
        //                lastVisitedNode = stack.Pop();
        //            }

        //        }
        //    }
        //}
        #endregion
        #region HasPathSum
        //public int has_path_sum_recursive(Node root, int currSum, int desiredSum)
        //{
        //    if (root == null)
        //        return 0;

        //    if (root.Left == null && root.Right == null)
        //        return currSum + root.Data;
        //    else
        //    {
        //        currSum += root.Data;
        //        int leftBranchSum = has_path_sum_recursive(root.Left, currSum, desiredSum);
        //        int rightBranchSum = has_path_sum_recursive(root.Right, currSum, desiredSum);
        //        if (rightBranchSum == desiredSum || leftBranchSum == desiredSum)
        //            return desiredSum;
        //    }

        //    return 0;
        //}


        //public bool has_path_sum_imperative(Node root, int sum)
        //{
        //    Stack<(Node, int)> stack = new();

        //    stack.Push((root, root.Data));
        //    Node? lastVisitedNode = root;
        //    root = root.Left;

        //    while (stack.Count > 0)
        //    {
        //        if (root != null)
        //        {
        //            int currPathSum = stack.Peek().Item2 + root.Data;
        //            stack.Push((root, currPathSum));
        //            root = root.Left;
        //        }
        //        else
        //        {
        //            (Node peekedNode, int currPathSum) tuple = stack.Peek();

        //            //First condition is to not miss the right child of a node, the second is to avoid getting stuck on the right child
        //            if (tuple.peekedNode.Right != null && lastVisitedNode != tuple.peekedNode.Right)
        //                root = tuple.peekedNode.Right;
        //            else
        //            {
        //                Console.WriteLine(tuple.peekedNode.Data);
        //                //Ensure the peekedNode is a leaf
        //                if ((tuple.peekedNode.Left == null && tuple.peekedNode.Right == null) && tuple.currPathSum == sum)
        //                    return true;
        //                lastVisitedNode = stack.Pop().Item1;
        //            }
        //        }
        //    }

        //    return false;
        //}
        #endregion
        #region Binary tree traversals (pre, in, post, level order -- BFS)
        //public class Node
        //{
        //    public int Data;
        //    public Node? Left;
        //    public Node? Right;
        //}

        //public class BinaryTree
        //{
        //    //LNR([root]Node-Left-Right)
        //    public void pre_order(Node root)
        //    {
        //        if (root == null) return;

        //        Stack<Node> stack = new();
        //        stack.Push(root);

        //        while (stack.Count > 0)
        //        {
        //            root = stack.Pop();
        //            Console.WriteLine(root.Data);

        //            //Because stack is a LIFO structure you need to push right node first to print it last
        //            if (root.Right != null)
        //                stack.Push(root.Right);
        //            if (root.Left != null)
        //                stack.Push(root.Left);
        //        }
        //    }

        //    //LNR(Left-[root]Node-Right)
        //    public void in_order(Node root)
        //    {
        //        if (root == null) return;

        //        Stack<Node> stack = new();
        //        stack.Push(root);
        //        root = root.Left;

        //        //The second condition is active when the all of the nodes in the left sub-tree of the root node is printed and the stack is empty
        //        while (stack.Count > 0 || root != null)
        //        {
        //            if (root != null)
        //            {
        //                stack.Push(root);
        //                root = root.Left;
        //            }
        //            else
        //            {
        //                Node curr_node = stack.Pop();
        //                Console.WriteLine(curr_node.Data);
        //                root = curr_node.Right;
        //            }
        //        }
        //    }

        //    //LRN((Left-Right-[root]Node)
        //    public void post_order(Node root)
        //    {
        //        if (root == null) return;

        //        Stack<Node> stack = new();
        //        stack.Push(root);
        //        root = root.Left;
        //        Node? lastVisitedNode = null;

        //        //When the root node is not printed in the first position, you need the second condition!
        //        while (stack.Count > 0 || root != null)
        //        {
        //            if (root != null)
        //            {
        //                stack.Push(root);
        //                root = root.Left;
        //            }
        //            else
        //            {
        //                Node peekedNode = stack.Peek();

        //                if (peekedNode.Right != null && peekedNode.Right != lastVisitedNode)
        //                    root = peekedNode.Right;
        //                else
        //                {
        //                    Console.WriteLine(peekedNode.Data);
        //                    lastVisitedNode = stack.Pop();
        //                }
        //            }
        //        }
        //    }
        //}

        //public void BFS(Node root)
        //{
        //    if (root == null)
        //        return;

        //    //FIFO
        //    Queue<Node> queue = new();
        //    queue.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        Node currNode = queue.Dequeue();
        //        Console.WriteLine(currNode.Data);

        //        if (currNode.Left != null)
        //            queue.Enqueue(currNode.Left);
        //        if (currNode.Right != null)
        //            queue.Enqueue(currNode.Right);
        //    }
        //}
        #endregion
        #endregion
        #endregion

        #endregion
    }
}