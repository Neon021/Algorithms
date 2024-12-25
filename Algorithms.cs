public class Algorithms
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

    //////////////////////////////////////////////////////////////////////////////////
    #endregion

    #region NOVICE 
    public static bool IsPangram(string input)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        return alphabet.All(input.ToLower().Contains);
    }


    //I love Enumerable <3
    public static List<string> FizzBuzz(int n)
    {
        return Enumerable
            .Range(1, n)
            .Aggregate(new List<string>(),
            (accumulator, element) =>
            {
                if ((element % 3) == 0 && (element % 5) == 0)
                {
                    accumulator.Add("FizzBuzz");
                }
                else if (element % 3 == 0)
                {
                    accumulator.Add("Fizz");
                }
                else if (element % 5 == 0)
                {
                    accumulator.Add("Buzz");
                }
                else
                {
                    accumulator.Add(element.ToString());
                }

                return accumulator;
            });
    }

    public static void IDunno(int lineCount)
    {
        int[] fibonacciSeries = new int[lineCount];
        Fibonacci(lineCount);

        for (int lineNumber = 1; lineNumber < lineCount; lineNumber++)
        {
            int firstIntOftheLine = fibonacciSeries[lineNumber];
            Console.Write(firstIntOftheLine);
            for (int j = 1; j < lineNumber; j++)
            {
                int nextNumber = (firstIntOftheLine + (lineNumber * j));
                Console.Write(" " + nextNumber);
            }
            Console.WriteLine("");
        }

        #region Fibonacci Functions
        void Fibonacci(int n)
        {
            for (int i = 0; i < n; i++)
            {
                fibonacciSeries[i] = GetFibonacci(i); // Store the Fibonacci result at the current index
            }
        }

        int GetFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
        #endregion
    }

    //ACKERMANN'S FUNCTION:

    static int ack(int m, int n)
    {
        if (m == 0)
        {
            return n + 1;
        }
        else if ((m > 0) && (n == 0))
        {
            return ack(m - 1, 1);
        }
        else if ((m > 0) && (n > 0))
        {
            return ack((m - 1), ack(m, n - 1));
        }
        else
        {
            return n + 1;
        }
    }


    //CHALLANGE 2: Checking wheter a string has all unique characters or  not.
    public static bool IsUnique(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            for (int j = i + 1; j < str.Length; j++)
            {
                if (str[i] == str[j])
                {
                    return false;
                }
            }
        }
        return true;
    }


    public static bool AreAnagram(char[] str1, char[] str2)
    {

        int[] count1 = new int[256];
        int[] count2 = new int[256];
        int i;

        for (i = 0; i < str1.Length && i < str2.Length; i++)
        {
            count1[str1[i]]++;
            count2[str2[i]]++;
        }

        if (str1.Length != str2.Length)
        {
            return false;
        }

        for (i = 0; i < 256; i++)
        {
            if (count1[i] != count2[i])
                return false;

        }
        return true;
    }

    public static void nthTermofAP()
    {
        Console.WriteLine("Enter the first term of the plub");
        int A1 = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second term of the plub");
        int A2 = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Which term's value would you like to know?");
        int Nth = Int32.Parse(Console.ReadLine());


        int d = (A2 - A1);
        int N = A2 + d * (Nth - 2);
        Console.WriteLine(N);
    }


    //REVERSING STRINGS

    public static string Reverse(string text)
    {
        char[] cArray = text.ToCharArray();
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i >= 0; i--)
        {
            reverse += cArray[i];
        }
        return reverse;
    }

    //REVERSING WORDS IN A STRING

    //Easiest to implement
    public static string ReverseWords(string str)
    {
        string[] words = str.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    //My way
    public static string ReverseWords1(string text)
    {
        string[] s1 = text.Split(' ');
        string answer = "";

        for (int i = s1.Length - 1; i > 0; i--)
        {
            answer += s1[i] + " ";
        }

        answer += s1[0];
        return answer;
    }

    //Clever way
    public static string ReverseWords_Clever(string str)
    {
        return string.Join(" ", str.Split(' ').Reverse());
    }






    public static void isParityEven()
    {
        Console.WriteLine("Enter a number to see whether its binary representations parity is even or odd.");

        int value = int.Parse(Console.ReadLine());
        byte[] byteArray = BitConverter.GetBytes(value);
        //We can convert an int into a string type of byte too 
        //string cnvrtd = Convert.ToString(value, 2);

        List<byte> byteArray1 = new();

        foreach (byte i in byteArray)
        {
            if (i == 1)
            {
                byteArray1.Add(i);
            }
        }

        if (byteArray1.Count % 2 == 0)
        {
            Console.WriteLine("It's parity is even");
        }
        else
            Console.WriteLine("It's parity is odd");

    }



    //I came back to this after 1-1.5 years (I'm not sure ho much time has passed) and here is the new refactored version


    public static bool IsParityEven(int value)
    {
        var byteList = Convert.ToString(value, 2).Where(x => x == '1');

        return byteList.Count() % 2 == 0 ? true : false;
    }






    public static void SomeMath()
    {
        Console.WriteLine("Enter three integers.(with spaces between).");
        string[] inputs = Console.ReadLine().Split(' ');



        for (int i = 0; i < inputs.Length; i++)
        {
            int[] cnvrtd = Array.ConvertAll(inputs, i => int.Parse(i));

            int result = (cnvrtd[0] + cnvrtd[1]) * cnvrtd[2];
            int result1 = (cnvrtd[0] * cnvrtd[1]) + (cnvrtd[1] * cnvrtd[2]);

            Console.WriteLine($"First mathematical operations result is {result}.");
            Console.WriteLine($"Second mathematical operations result is {result1}.");

        }


    }




    public static void ArithemticAvarage()
    {
        Console.WriteLine("Enter four integers.");
        string[] inputs = Console.ReadLine().Split(' ');



        foreach (string i in inputs)
        {
            int[] cnvrtd = Array.ConvertAll(inputs, i => int.Parse(i));

            double result = (cnvrtd[0] + cnvrtd[1] + cnvrtd[2] + cnvrtd[3]) / 4;
            Console.WriteLine(result);
        }
    }


    //I came back to this after 1-1.5 years (I'm not sure ho much time has passed) and here is the new refactored version


    public static int ArithemticAvarage(int[] values)
    {
        List<int> list = values.OfType<int>().ToList();

        return list.Sum() / 4;
    }









    public static void fourtimes()
    {
        Console.WriteLine("Enter a number");
        string input = Console.ReadLine();

        for (int i = 0; i <= 4; i++)
        {
            for (int n = 0; i <= 2; n++)
            {
                Console.WriteLine($"{input}  {input}  {input}  {input}");

                for (int h = 0; i <= 2; h++)
                {
                    Console.WriteLine($"{input}{input}{input}{input}");
                    break;
                }
                break;
            }
        }
    }



    public static class SimpleCalculatorWithSwitch
    {
        public static string Calculate(int operand1, int operand2, string operation)
        {
            return operation switch
            {
                "+" => $"{operand1} {operation} {operand2} = {operand1 + operand2}",
                "*" => $"{operand1} {operation} {operand2} = {operand1 * operand2}",
                "/" when operand2 == 0 => "Division by zero is not allowed.",
                "/" => $"{operand1} {operation} {operand2} = {operand1 / operand2}",
                null => throw new ArgumentNullException(),
                "" => throw new ArgumentException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }



    public class Operators
    {

        public void Addition(int x, int y)
        {
            int z = x + y;
            Console.WriteLine(z);
        }

        public void Multiplication(int x, int y)
        {
            int z = x * y;
            Console.WriteLine(z);
        }

        public void Division(int x, int y)
        {
            decimal z = x / y;
            Console.WriteLine(z);
        }
    }

    public class SimpleCalculator
    {
        public void Calculate(int x, int y, string @operator)
        {
            Operators operators = new();

            if (@operator == "Addition")
            {
                operators.Addition(x, y);
            }
            else if (@operator == "Multiplication")
            {
                operators.Multiplication(x, y);
            }
            else if (@operator == "Division")
            {
                if (x == 0)
                {
                    try { }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("You can't divide by zero");
                    }
                }
                else
                    operators.Division(x, y);
            }
            else if (@operator == null || @operator == "" || @operator == "Subtraction")
            {
                Console.WriteLine("Check the operator");
            }
        }
    }

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

    #endregion



    #region CODEWARS
    //public static string Likes(string[] names)
    //{
    //    int count = names.Length;
    //    switch (count)
    //    {
    //        case 0:
    //            return "no one likes this";
    //            break;

    //        case 1:
    //            return $"{names[0]} likes this";
    //            break;

    //        case 2:
    //            return $"{names[0]} and {names[1]} like this";
    //            break;

    //        case 3:
    //            return $"{names[0]}, {names[1]} and {names[2]} like this";

    //        default:
    //            return $"{names[0]}, {names[1]} and {count - 2} others like this";
    //            break;
    //    }
    //}


    //public static int CountBits(int n)
    //{
    //    char[] c = Convert.ToString(n, 2).ToCharArray();

    //    int answer = 0;
    //    foreach (char bin in c)
    //    {
    //        if (bin.Equals('1'))
    //        {
    //            answer += 1; //? bin.Equals('1) : return;
    //        }
    //    }
    //    return answer;
    //}


    //public static int CountBits_OneLiner(int n)
    //{
    //    return Convert.ToString(n, 2).Count(x => x == '1');
    //}


    ////MySolution
    //public static string DuplicateEncode(string word)
    //{
    //    word = word.ToLower();
    //    string result = "";
    //    for (int i = 0; i < word.Length; i++)
    //    {
    //        char ch = word[i];
    //        result += word.LastIndexOf(ch) == word.IndexOf(ch) ? '(' : ')';
    //    }
    //    return result;
    //}

    ////Refactored after a year or so
    //public static string DuplicateEncode_Refactored(string word)
    //{
    //    word = word.ToLower();
    //    string result = "";
    //    foreach (char ch in word)
    //    {
    //        result += word.LastIndexOf(ch) == word.IndexOf(ch) ? '(' : ')';
    //    }
    //    return result;
    //}


    ////BestPractice (yersen)
    //public static string DuplicateEncode_BestPractice(string word)
    //{
    //    var disct = word.ToUpper().Distinct();
    //    Dictionary<char, int> counts = new();

    //    foreach (var c in word.ToUpper())
    //    {
    //        if (counts.ContainsKey(c))
    //            counts[c]++;
    //        else
    //            counts.Add(c, 1);
    //    }

    //    StringBuilder builder = new();
    //    foreach (var c in word.ToUpper())
    //    {
    //        if (counts[c] == 1)
    //            builder.Append('(');
    //        else
    //            builder.Append(')');
    //    }

    //    return builder.ToString();
    //}





    //public static int[] ArrayDiff_Obvious(int[] a, int[] b)
    //{
    //    return a.Except(b).ToArray();
    //}

    //public static int[] ArrayDiff(int[] a, int[] b)
    //{
    //    return a.Where(m => b.Contains(m)).ToArray();
    //}




    //public static int[,] MultiplicationTable(int size)
    //{
    //    int[,] table = new int[size, size];
    //    //for loop will break if the size variable is 0. Apperantly for loop 
    //    //incorporates some sort of while logic as well.
    //    for (int i = 0; i < size; i++)
    //    {
    //        for (int j = 0; j < size; j++)
    //        {
    //            table[i, j] = (i + 1) * (j + 1);
    //        }
    //    }
    //    return table;
    //}



    ////Bu da C++
    ////#include <vector>
    ////#include <iostream>
    ////using namespace std;
    ////vector<vector<int>> multiplication_table(int n)
    ////{
    ////    vector<vector<int>> res;
    ////    for (int i = 1; i <= n; i++)
    ////    {
    ////        vector<int> tmp;
    ////        for (int j = 1; j <= n; j++)
    ////        {
    ////            tmp.push_back(i * j);
    ////        }
    ////        res.push_back(tmp);
    ////    }
    ////    return res;
    ////}




    ////Tatsız olan (ama tek attım)
    //public static int Multipleof3or5(int value)
    //{
    //    while (value! <= 0 /*value * -1 != +value && value != 0*/)
    //    {
    //        int sum = 0;

    //        for (int i = 0; i < value; i++)
    //        {
    //            if (i % 3 == 0 && i % 5 == 0)
    //            {
    //                sum += i;
    //            }
    //            else if (i % 3 == 0)
    //            {
    //                sum += i;
    //            }
    //            else if (i % 5 == 0)
    //            {
    //                sum += i;
    //            }
    //            else
    //                continue;
    //        }
    //        return sum;
    //    }

    //    return 0;
    //}


    ////Refactored one
    //public static int Multipleof3or5_Refactored(int value)
    //{
    //    while (value! <= 0 /*value * -1 != +value && value != 0*/)
    //    {
    //        int sum = 0;

    //        for (int i = 0; i < value; i++)
    //        {
    //            if (i % 3 == 0 || i % 5 == 0)
    //                sum += i;
    //            else
    //                continue;
    //        }
    //        return sum;
    //    }
    //    return 0;
    //}



    ////Yine tek attım (https://www.youtube.com/watch?v=OjZcboiOjX4&ab_channel=Aleskut)
    //public static int FindMissing(List<int> list)
    //{
    //    int difference = list[1] - list[0];
    //    // int answer = 0;
    //    // for(int i = 1; i < list.Count(); i++){
    //    //     if(list[i] - list[i - 1] != difference){
    //    //        return answer = list[i] - difference;
    //    //     }
    //    //     else
    //    //         continue;
    //    // } 
    //    // return answer;
    //    return list.First(x => !list.Contains(x - (x - difference)));
    //}


    //public static bool IsPrime(int n)
    //{
    //    if (n >= 0)
    //    {
    //        if (n == 1 || n == 0)
    //            return false;

    //        for (int i = 2; i <= Math.Sqrt(n); i++)
    //        {
    //            if (n % i == 0)
    //                return false;
    //        }
    //    }
    //    else
    //    {
    //        if (n == -1 || n == 0 || n == -2)
    //            return false;

    //        n = n * -1;
    //        for (int i = 2; i <= Math.Sqrt(n); i++)
    //        {
    //            if (n % i == 0)
    //                return false;
    //        }
    //    }

    //    return true;
    //}


    ////Better solution
    //public static bool IsPrime_OneLiner(int n)
    //{
    //    return n > 1 && Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
    //}



    //public static bool Narcissistic(int input)
    //{
    //    //Digits
    //    List<int> list = input.ToString().Select(x => (int)char.GetNumericValue(x)).ToList();

    //    //Sum of digits
    //    double sum = 0;
    //    list.ForEach(x =>
    //    {
    //        sum += Math.Pow(x, list.Count);
    //    });

    //    return sum == input;
    //}



    //public static string PascalCaseToSnakeCase(string input)
    //{
    //    List<char> list = input.ToList();

    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        char c = list[i];
    //        if (char.IsUpper(c) && i != 0)
    //        {
    //            list.Insert(i, '_');
    //            list[i + 1] = char.ToLower(c);
    //        }
    //        else
    //        {
    //            list[i] = char.ToLower(c);
    //        }
    //    }

    //    return string.Join("", list);
    //}



    ////çalışmıyor (divide by zero and overflow errors) :(
    //public static double Going(int n)
    //{
    //    int factorial = Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);
    //    decimal fraction = decimal.Divide(1, factorial);

    //    List<int> ints = new();

    //    for (int i = 1; i <= n; i++)
    //    {
    //        int result = Enumerable.Range(1, i).Aggregate(1, (p, item) => p * item);
    //        ints.Add(result);
    //    }

    //    return (double)fraction * ints.Sum();
    //}


    ////this...this is art f@!?ing beautiful
    //public static double Going_ButArt(int n)
    //{
    //    double result = 0;
    //    double denominator = 1;
    //    for (int i = n; i > 0; i--)
    //    {
    //        result += 1 / denominator;
    //        denominator *= i;
    //    }
    //    return Math.Round(result, 6);
    //}



    ////gene olmadı :(  (4kyu'lar zorlardı biraz)
    ////IndexOutOfRangeException
    //public static int DblLinear(int n)
    //{
    //    List<int> ints = new();

    //    int index = -1;
    //    for (int multiplier = 1; multiplier <= n; multiplier = ints[index])
    //    {
    //        ints.Add(2 * multiplier + 1);
    //        ints.Add(3 * multiplier + 1);
    //        ints.Sort((x, y) => x.CompareTo(y));
    //        index++;
    //    }

    //    return ints.ElementAt(n - 1);
    //}



    //public static int DblLinear_Better(int n)
    //{
    //    SortedSet<int> answer = new() { 1 };

    //    while (n > 0)
    //    {
    //        answer.Add(2 * answer.Min + 1);
    //        answer.Add(3 * answer.Min + 1);

    //        answer.Remove(answer.Min);
    //        n--;
    //    }

    //    return answer.Min;
    //}


    //int IsHappynumber(int n)
    //{
    //    if (n == 1 || n == 7)
    //        return 1;
    //    int sum = n, x = n;

    //    while (sum > 9)
    //    {
    //        sum = 0;
    //        while (x > 0)
    //        {
    //            int d = x % 10;
    //            sum += d * d;
    //            x /= 10;
    //        }
    //        if (sum == 1)
    //            return 1;

    //        x = sum;
    //    }
    //    if (sum == 7)
    //        return 1;

    //    return 0;
    //}
    #endregion

    #region LEETCODE

    #region Easy
    #region FindJudge
    public int FindJudge(int n, int[][] trust)
    {
        int[] right = new int[n + 1];
        int[] left = new int[n + 1];

        foreach (int[] array in trust)
        {
            right[array[1]]++;
            left[array[0]]++;
        }

        for (int i = 1; i <= n; i++)
        {
            if (right[i] == n - 1 && left[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
    #endregion
    #region MissingNumber
    public static int MissingNumber(int[] nums)
    {
        //Array.Sort(nums);
        //int res = 0;
        //if (nums[^1] != nums.Length)
        //{
        //    res = nums.Length;
        //    return res;
        //}
        //for (int i = 1; i < nums.Length; i++)
        //{
        //    if (nums[i] != nums[i - 1] + 1) { res = i; }
        //}
        //return res;

        //int length = nums.Length;
        //int expectedSum = length * (length + 1) / 2;
        //int actualSum = nums.Sum();

        //return expectedSum - actualSum;

        return
     Enumerable
     .Range(0, nums.Length + 1)
     .Except(nums)
     .FirstOrDefault();
    }
    #endregion
    #region MaxProfit
    public static int MaxProfit(int[] prices)
    {
        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
        }

        return maxProfit;
        //int result = 0;
        //int i = 0;
        //int j = 1;

        //while (j < prices.Length)
        //{
        //    if (prices[i] >= prices[j])
        //    {
        //        i = j;
        //        j++;
        //    }
        //    else if (prices[i] < prices[j])
        //    {
        //        if (prices[j] - prices[i] > result) result = prices[j] - prices[i];
        //        j++;
        //    }
        //}
        //return result;
    }
    #endregion
    #region IsSameTree
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            // Base case: if both nodes are null, they are equal
            if (p == null && q == null)
            {
                return true;
            }

            // If one of the nodes is null and the other is not, they are not equal
            if (p == null || q == null)
            {
                return false;
            }

            // Check the current node values and recursively check left and right subtrees
            return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
    #endregion
    #region MaximumOddBinaryNumber
    public static string MaximumOddBinaryNumber(string s)
    {
        //int numberOfOne = s.Count(x => x == '1');
        //StringBuilder sb = new();
        //for (int i = 0; i < numberOfOne - 1; i++)
        //{
        //    sb.Append('1');
        //}
        //for (int i = 0; i < s.Length - numberOfOne; i++)
        //{
        //    sb.Append('0');
        //}
        //sb.Append('1');
        //return sb.ToString();
        int count = s.Count(x => x == '1');
        String? rs = new string('1', count - 1) + new string('0', s.Length - count) + new string('1', 1);
        return rs;
    }
    #endregion
    #region HeightDifference
    public int HeightChecker(int[] heights)
    {
        int[] expected = new int[heights.Length];
        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);
        int res = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            if (heights[i] != expected[i])
                res++;
        }
        return res;
    }
    #endregion
    #region SlidingWindow

    #region Valid Parentheses
    public bool IsValid(string s)
    {
        return true;
        //Stack<char> stack = new();

        //Dictionary<char, char> dict = new(){
        //    {'(', ')'},
        //    {'{', '}'},
        //    {'[', ']'}
        //};

        //for (int i = 0; i < s.Length; i++)
        //{
        //    if (dict.Keys.Contains(s[i]))
        //        stack.Push(s[i]);
        //    else if (stack.Count > 0 && s[i] == dict[stack.Peek()])
        //        stack.Pop();
        //    else
        //        return false;
        //}
        //return stack.Count == 0;
        //Stack<char> stk = new();

        //foreach (char c in s)
        //{
        //    if (c == '(' || c == '[' || c == '{')
        //    {
        //        stk.Push(c);
        //    }
        //    else if (c == ')' && (stk.Count == 0 || stk.Pop() != '('))
        //    {
        //        return false;
        //    }
        //    else if (c == ']' && (stk.Count == 0 || stk.Pop() != '['))
        //    {
        //        return false;
        //    }
        //    else if (c == '}' && (stk.Count == 0 || stk.Pop() != '{'))
        //    {
        //        return false;
        //    }

        //}
        //return stk.Count == 0;
    }
    #endregion

    #endregion
    #region Binary Search and Linked Lists
    #region Binary Search
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int index = (left + right) / 2;
            if (target > nums[index])
                left = index + 1;
            else if (target < nums[index])
                right = index - 1;
            else
                return index;
        }
        return -1;
    }
    #endregion
    #region ReverseLinkedList
    //public static void Main(string[] args)
    //{
    //    ListNode head = new ListNode(1);
    //    head.next = new ListNode(2);
    //    head.next.next = new ListNode(3);
    //    head.next.next.next = new ListNode(4);
    //    head.next.next.next.next = new ListNode(5);

    //    Console.WriteLine("Original List:");
    //    PrintList(head);

    //    // Reversing the linked list
    //    ListNode reversedHead = ReverseList(head);

    //    Console.WriteLine("\nReversed List:");
    //    PrintList(reversedHead);
    //}
    //public class ListNode
    //{
    //    public int val;
    //    public ListNode? next;
    //    public ListNode(int val = 0, ListNode? next = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //    }
    //}

    //public static ListNode ReverseList(ListNode head)
    //{
    //    ListNode previousNode = null;
    //    while (head != null)
    //    {
    //        ListNode currNext = head.next;
    //        head.next = previousNode;
    //        previousNode = head;
    //        head = currNext;
    //    }
    //    return previousNode;
    //    //ListNode previous = null;
    //    //ListNode curr = head;
    //    //while(curr != null)
    //    //{
    //    //    ListNode next = curr.next;
    //    //    curr.next = previous;
    //    //    previous = curr;
    //    //    curr = next;
    //    //}
    //    //return previous;
    //}

    //public static void PrintList(ListNode head)
    //{
    //    while (head != null)
    //    {
    //        Console.Write(head.val + " -> ");
    //        head = head.next;
    //    }
    //    Console.WriteLine("null");
    //}
    #endregion
    #endregion
    #region MinOperations
    public static int MinOperations(string[] logs)
    {
        //int depth = 0;
        //foreach(string s in logs)
        //{
        //    if (s[..^1] == "..")
        //    {
        //        if (depth == 0)
        //            depth += 0;
        //        else
        //            depth--;
        //    }
        //    else if (s[..^1] == ".")
        //        depth +=0;
        //    else
        //        depth++;
        //}

        //return depth;
        int depth = 0;
        foreach (string s in logs)
        {
            if (s[1] == '.' && depth != 0)
                depth--;
            else if (s[0] != '.')
                depth++;
        }
        return depth;
    }
    #endregion
    #region TwoSum
    //public int[] TwoSum(int[] nums, int target)
    //{
    //    Dictionary<int, int> pairs = new();
    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        if (pairs.ContainsKey(target - nums[i]))
    //            return new int[] { pairs[target - nums[i]], i };
    //        else
    //            pairs.TryAdd(nums[i], i);
    //    }
    //    return default;
    //}
    #region HasCycle
    //public bool HasCycle(ListNode? head)
    //{
    //    HashSet<ListNode?> visited = new();
    //    while (head != null)
    //    {
    //        if (visited.Contains(head))
    //        {
    //            return true;
    //        }
    //        visited.Add(head);
    //        head = head.next;
    //    }
    //    return false;
    //    //if (head == null) return false;

    //    //ListNode fast = head;
    //    //ListNode slow = head;

    //    //while (fast.next != null && fast.next.next != null)
    //    //{
    //    //    fast = fast.next.next;
    //    //    slow = slow.next;

    //    //    if(fast == slow) return true;
    //    //}
    //    //return false;
    //}
    #endregion
    #region SubsetXORSum
    public static int SubsetXORSum(int[] nums)
    {
        //int answer = 0;

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    for(int j = i+1;  j < nums.Length; j++)
        //    {
        //        answer += nums[i] ^ nums[j];
        //    }
        //}

        //return answer;
        int or = 0;

        foreach (int num in nums)
        {
            or |= num;
        }
        return or << (nums.Length - 1);
        //return or << (nums.Length - 1);
        //int n = nums.Length;
        //int totalXORSum = 0;
        //int subsetCount = 1 << n; // 2^n

        //for (int i = 0; i < subsetCount; i++)
        //{
        //    int subsetXOR = 0;
        //    for (int j = 0; j < n; j++)
        //    {
        //        if ((i & (1 << j)) != 0)
        //        {
        //            subsetXOR ^= nums[j];
        //        }
        //    }
        //    totalXORSum += subsetXOR;
        //}

        //return totalXORSum;
    }

    #endregion
    #region NumIdenticalPairs
    public static int NumIdenticalPairs(int[] nums)
    {
        //Span<int> counts = stackalloc int[101];
        //var count = 0;
        //foreach (var n in nums)
        //    count += counts[n]++;
        //return count;

        int res = 0;

        for (int i = 0, j = i + 1; i < nums.Length; i++)
        {
            j = i + 1;
            while (j < nums.Length)
            {
                if (nums[i] == nums[j])
                    res++;
                j++;
            }
        }
        return res;

        //int res = 0;
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    for(int j = i+1; j < nums.Length; j++)
        //    {
        //        if (nums[i] == nums[j])
        //            res++;
        //    }
        //}
        //return res;
    }
    #endregion
    #endregion
    #endregion

    #region Medium
    #region Sorting
    public void SortColors(int[] nums)
    {
        int lo = 0;
        int mid = 0;
        int hi = nums.Length - 1;
        int tmp = 0;
        while (mid <= hi)
        {
            if (nums[mid] == 0)
            {
                tmp = nums[lo];
                nums[lo] = nums[mid];
                nums[mid] = tmp;

                mid++;
                lo++;
            }
            else if (nums[mid] == 2)
            {
                tmp = nums[hi];
                nums[hi] = nums[mid];
                nums[mid] = tmp;

                hi--;
            }
            else
            {
                mid++;
            }
        }
    }
    #endregion
    #region Arrays
    #region CanJump
    //Recursive CanJump
    //First check the number in the given index
    //If it does not exceed the length of the nums
    //Send the elements of the array starting from the element we jumped to
    //Repeat this procces until the element is bigger then the size

    //public static bool CanJump(int[] nums)
    //{
    //    int size = nums.Length;
    //    int element = nums.ElementAt(0);

    //    if (element < size)
    //    {
    //        CanJump(nums.ToList().TakeLast(size - element).ToArray());
    //    }

    //    return element == nums.ElementAt(size - 1);
    //}

    public static bool CanJump(int[] nums)
    {
        int maxReach = 0; // Initialize the maximum reachable position

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach)
            {
                return false; // Cannot reach the end
            }

            maxReach = Math.Max(maxReach, i + nums[i]); // Update maxReach
        }

        return true; // If the loop completes, it's possible to reach the end
    }
    #endregion
    #region FindDifferentBinaryString
    //public static string FindDifferentBinaryString(string[] nums)
    //{
    //    int n = nums.Length;
    //    var possible = Enumerable.Range(0, n + 1).Select(i => Convert.ToString(i, 2).PadLeft(n, '0')).ToHashSet();
    //    foreach (var s in nums)
    //        possible.Remove(s);
    //    return possible.First();
    //}

    public static string FindDifferentBinaryString(string[] nums)
    {
        int baseLength = nums.Length;
        char[] result = new char[baseLength];

        for (int i = 0; i < baseLength; i++)
        {
            result[i] = nums[i][i] == '0' ? '1' : '0';
        }

        return new string(result);
    }
    #endregion
    #region RangeBitwiseAnd
    public int RangeBitwiseAnd(int left, int right)
    {
        int shift = 0;

        while (left < right)
        {
            left >>= 1;
            right >>= 1;
            shift++;
        }

        return left << shift;
    }
    #endregion
    #region CheapestFlightsWithinKStops
    public int FindCheapestPrice1(int n, int[][] flights, int src, int dst, int k)
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
    #region ProductExceptSelf
    public int[] ProductExceptSelf(int[] nums)
    {
        List<int> answer = new List<int>();

        foreach (int i in nums)
        {
            List<int> list = new List<int> { i };
            var remainingElements = nums.Except(list);

            int product = 1;
            foreach (int element in remainingElements)
            {
                product *= element;
            }

            answer.Add(product);
        }
        return answer.ToArray();
    }
    #endregion
    #region TwoSumII
    //Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
    //Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    //Return the indices of the two numbers, index1 and index2, added by one as an integer array[index1, index2] of length 2.
    public static int[] TwoSumII(int[] numbers, int target)
    {
        if (target != 0)
        {
            int[] remaining = numbers.Where(x => x <= target || x == 0).ToArray();
            for (int i = 0, j = remaining.Length - 1; i <= j; i++, j--)
            {
                if (remaining[i] + remaining[j] == target)
                    return new int[2] { i + 1, j + 1 };
            }
        }
        else
        {
            int[] remaining = new int[numbers.Length];

            remaining = numbers;
        }


        return Array.Empty<int>();
    }
    #endregion
    #region MatrixScore
    public int MatrixScore(int[][] grid)
    {
        int rowNumber = grid.Length;
        int columnNumber = grid[0].Length;
        int result = rowNumber;

        for (var j = 1; j < columnNumber; j++)
        {
            var sum = 0;
            for (var i = 0; i < rowNumber; i++)
                sum += grid[i][j] ^ grid[i][0];

            result = (result << 1) + Math.Max(sum, rowNumber - sum);
        }
        return result;
    }
    #endregion
    #region Permute
    ////https://leetcode.com/problems/permutations/solutions/5013633/just-a-simple-backtracking/
    ////I dont have a single idea how this works, actually I do but I couldnt come up with it myself
    //public IList<IList<int>> Permute(int[] nums)
    //{
    //    IList<IList<int>> result = new List<IList<int>>();
    //    Backtrack(nums, new List<int>(), result);
    //    return result;

    //    static void Backtrack(int[] nums, List<int> path, IList<IList<int>> result)
    //    { 
    //        if (path.Count == nums.Length)
    //        {
    //            result.Add(new List<int>(path));
    //            return;
    //        }
    //        foreach (int num in nums)
    //        {
    //            if (path.Contains(num)) 
    //                continue;
    //            path.Add(num);
    //            Backtrack(nums, path, result);
    //            path.RemoveAt(path.Count - 1);
    //        }
    //    }
    //}
    #endregion
    #region SortJumbled
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        //foreach (int num in nums)
        //{
        //    Dictionary<char, int> map = new();
        //    string s = num.ToString();

        //    foreach (char digit in s)
        //    {
        //        if (!map.ContainsKey(digit))
        //        {
        //            int corresponding = mapping[digit];
        //            map.Add(digit, corresponding);
        //            s.Where(x => x == digit).Select(x => x == corresponding);
        //        }
        //    }
        //}

        //return new int[] { };
        Dictionary<int, long> mappedValues = new();

        foreach (int num in nums)
        {
            string s = num.ToString();
            char[] mappedChars = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                mappedChars[i] = (char)('0' + mapping[s[i] - '0']);
            }
            long mappedValue = long.Parse(new string(mappedChars));
            mappedValues[num] = mappedValue;
        }

        return nums.OrderBy(num => mappedValues[num]).ToArray();
    }
    #endregion
    #region GroupAnagrams
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> anagramGroups = new();

        foreach (string str in strs)
        {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new(charArray);

            if (!anagramGroups.TryGetValue(sortedStr, out var anagrams))
            {
                anagrams = new List<string>();
                anagramGroups[sortedStr] = anagrams; //Same as anagramGroups.Add(sortedStr, anagrams)
            }

            anagrams.Add(str);
        }

        return anagramGroups.Values.ToList<IList<string>>();
        //List<IList<string>> anagramGroup = new List<IList<string>>();

        //for (int i = 0; i < strs.Length; i++)
        //{
        //    if (strs[i] != null)
        //    {
        //        List<string> anagrams = new List<string> { strs[i] };
        //        for (int j = i + 1; j < strs.Length; j++)
        //        {
        //            if (strs[j] != null && IsAnagram(strs[i], strs[j]))
        //            {
        //                anagrams.Add(strs[j]);
        //                strs[j] = null; // Mark the checked string as null to skip it in future iterations
        //            }
        //        }
        //        anagramGroup.Add(anagrams);
        //    }
        //}

        //return anagramGroup;
        //bool IsAnagram(string s, string t)
        //{
        //    if (s.Length != t.Length)
        //    {
        //        return false;
        //    }
        //    char[] charArray1 = s.ToCharArray();
        //    char[] charArray2 = t.ToCharArray();

        //    Array.Sort(charArray1);
        //    Array.Sort(charArray2);

        //    return Enumerable.SequenceEqual(charArray1, charArray2);
        //}
    }
    #endregion
    #endregion

    #region SlidingWindow
    #region LengthOfLongestSubstring
    public static int LengthOfLongestSubstring(string s)
    {
        HashSet<char> list = new();
        int left = 0, right = 0, maxLength = 0;

        while (right < s.Length)
        {
            if (!list.Contains(s[right]))
            {
                list.Add(s[right]);
                right++;
                maxLength = Math.Max(maxLength, list.Count);
            }
            else
            {
                list.Remove(s[left]);
                left++;
            }
        }
        return maxLength;
    }
    #endregion
    #region LongestRepeatingCharacterReplacement
    public static bool CheckInclusion(string s1, string s2)
    {
        int l = 0, r = 0, i = 0;
        Dictionary<char, int> s1CharacterFrequencies = new();
        Dictionary<char, int> s2CharacterFrequencies = new();

        foreach (char c in s1)
        {
            if (s1CharacterFrequencies.ContainsKey(c))
                s1CharacterFrequencies[c]++;
            else s1CharacterFrequencies[c] = 1;
        }

        for (r = 0; r < s2.Length; r++)
        {
            if (!s2CharacterFrequencies.ContainsKey(s2[r]))
            {
                s2CharacterFrequencies.Add(s2[r], 1);
            }
            else
            {
                s2CharacterFrequencies[s2[r]] += 1;
            }
            while (r - l + 1 > s1.Length)
            {
                s2CharacterFrequencies[s2[l]] -= 1;
                l++;
            }

            if (r - l + 1 == s1.Length)
            {
                for (i = 0; i < s1.Length; i++)
                {
                    if (!s2CharacterFrequencies.ContainsKey(s1[i]) || s2CharacterFrequencies[s1[i]] != s1CharacterFrequencies[s1[i]])
                    {
                        break;
                    }
                }
                if (i == s1.Length)
                {
                    return true;
                }
            }
        }
        return false;
        //Dictionary<char, int> s2CharacterFrequencies = new();
        //foreach(char c in s2)
        //{
        //    if (s2CharacterFrequencies.ContainsKey(c))
        //        s2CharacterFrequencies[c]++;
        //    else s2CharacterFrequencies[c] = 1;
        //}
        //Dictionary<char, int> s1CharacterFrequencies = new();
        //foreach (char c in s1)
        //{
        //    if (s1CharacterFrequencies.ContainsKey(c))
        //        s1CharacterFrequencies[c]++;
        //    else s1CharacterFrequencies[c] = 1;
        //}

        //foreach(char c in s1CharacterFrequencies.Keys)
        //{
        //    if (s2CharacterFrequencies.ContainsKey(c) && s2CharacterFrequencies[c] == s1CharacterFrequencies[c])
        //        continue;
        //    else
        //        return false;
        //}
        //return true;
    }
    #endregion
    #region MinStack
    //public class MinStack
    //{
    //    private readonly Stack<KeyValuePair<int, int>> Stack = new();

    //    public MinStack()
    //    {
    //    }

    //    public void Push(int val)
    //    {
    //        int min = Stack.Count == 0 ? val : Math.Min(Stack.Peek().Value, val);

    //        Stack.Push(new KeyValuePair<int, int>(val, min));
    //    }

    //    public void Pop()
    //    {
    //        Stack.Pop();
    //    }

    //    public int Top()
    //    {
    //        return Stack.Peek().Key;
    //    }

    //    public int GetMin()
    //    {
    //        return Stack.Peek().Value;
    //    }
    //}
    #endregion
    #region Reverse Polish Notation
    public static int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int secondOperand = stack.Pop();
                int firstOperand = stack.Pop();
                int result = token switch
                {
                    "+" => firstOperand + secondOperand,
                    "-" => firstOperand - secondOperand,
                    "*" => firstOperand * secondOperand,
                    "/" => firstOperand / secondOperand,
                    _ => throw new ArgumentOutOfRangeException(nameof(token))
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
        //int result = 0;
        //Stack<string> stack = new();
        //for (int i = 0; i < tokens.Length - 1;)
        //{
        //    while (tokens[i] != "*" && tokens[i] != "+" && tokens[i] != "-" && tokens[i] != "/")
        //    {
        //        stack.Push(tokens[i]);
        //        i++;
        //    }
        //    string @operator = stack.Pop();
        //    string firstOperand = stack.Pop();
        //    string secondOperand = stack.Pop();
        //    switch (@operator)
        //    {
        //        case "*":
        //            result += int.Parse(firstOperand) * int.Parse(secondOperand);
        //            break;
        //        case "+":
        //            result += int.Parse(firstOperand) + int.Parse(secondOperand);
        //            break;
        //        case "-":
        //            result += int.Parse(firstOperand) - int.Parse(secondOperand);
        //            break;
        //        case "/":
        //            result += int.Parse(firstOperand) / int.Parse(secondOperand);
        //            break;
        //    }
        //}
        //return result;
    }
    #endregion
    #region ValidParantheses
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = new List<string>();
        GenerateValidParentheses(n, n, "", result);
        return result;
    }

    private static void GenerateValidParentheses(int openCount, int closeCount, string current, IList<string> result)
    {
        if (openCount == 0 && closeCount == 0)
        {
            result.Add(current);
            return;
        }

        if (openCount > 0)
        {
            GenerateValidParentheses(openCount - 1, closeCount, current + '(', result);
        }

        if (closeCount > openCount)
        {
            GenerateValidParentheses(openCount, closeCount - 1, current + ')', result);
        }
    }
    #endregion
    #region DailyTemperatures
    //public static int[] DailyTemperatures(int[] temperatures)
    //{
    //    Stack<int> stack = new();
    //    int[] array = new int[temperatures.Length];
    //    for (int i = temperatures.Length - 1; i >= 0; i--)
    //    {
    //        while (stack.Count > 0 && temperatures[stack.Peek()] <= temperatures[i])
    //            stack.Pop();
    //        if (stack.Count > 0)
    //            array[i] = stack.Peek() - i;
    //        stack.Push(i);
    //    }
    //    return array;
    //    //Dictionary<int, int> dict = new();
    //    //int j = 0;
    //    //for (int i = 0; i <= temperatures.Length - 1; i++)
    //    //{
    //    //    dict.Add(temperatures[i], 0);
    //    //    while (j < i)
    //    //    {
    //    //        if (dict.ElementAt(j).Key < temperatures[i])
    //    //        {
    //    //            dict[temperatures[j]] = i - j;
    //    //            j++;
    //    //        }
    //    //        else
    //    //        {
    //    //            break;
    //    //        }
    //    //    }
    //    //}

    //    //return dict.Values.ToArray();
    //}
    #endregion
    #region TurbulentArray
    public static int MaxTurbulenceSize(int[] arr)
    {
        //true '>'
        //false '<'
        //if (arr.Length == 1)
        //    return 1;
        //int res = 1;
        //bool currComp = arr[0] > arr[1];

        //for (int i = 1; i < arr.Length - 1; i++)
        //{
        //    int temp = 0;
        //    while (i < arr.Length - 1 && arr[i + 1] > arr[i] is bool comp && comp != currComp && arr[i + 1] != arr[i])
        //    {
        //        i++;
        //        currComp = comp;
        //        temp++;
        //    }
        //    res = temp > res ? temp + 1 : res;
        //    temp = 0;
        //    currComp = i < arr.Length - 1 ? arr[i + 1] > arr[i] : currComp;
        //}
        //return res;
        //if (arr.Length == 1)
        //    return 1;

        //int maxLen = 1;
        //int inc = 1, dec = 1;

        //for (int i = 1; i < arr.Length; i++)
        //{
        //    if (arr[i] > arr[i - 1])
        //    {
        //        inc = dec + 1;
        //        dec = 1;
        //    }
        //    else if (arr[i] < arr[i - 1])
        //    {
        //        dec = inc + 1;
        //        inc = 1;
        //    }
        //    else
        //    {
        //        inc = 1;
        //        dec = 1;
        //    }
        //    maxLen = Math.Max(maxLen, Math.Max(inc, dec));
        //}

        //return maxLen;
        int res = 1;
        int start = 0;
        int length = arr.Length;
        for (int i = 1; i < length; i++)
        {
            //_value > value = 1
            //_value < value = -1
            int leftComp = arr[i].CompareTo(arr[i - 1]);
            if (leftComp == 0)
                start = i;
            else if (i == length - 1 || leftComp != arr[i].CompareTo(arr[i + 1]))
            {
                res = Math.Max(res, i - start + 1);
                start = i;
            }
        }
        return res;
    }
    #endregion
    #endregion
    #region Binary Search and Linked Lists
    #region SearchMatrix
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        int index = 0;

        if (matrix.Length == 1 && matrix[0].Length == 1)
        {
            return matrix[0][0] == target;
        }

        while (index < matrix.Length)
        {
            if (!(matrix[index][0] <= target && target <= matrix[index][^1]))
            {
                index++;
                continue;
            }
            else
            {
                int left = 0, right = matrix[index].Length - 1;
                while (left <= right)
                {
                    int i = (left + right) / 2;
                    if (target > matrix[index][i])
                        left = i + 1;
                    else if (target < matrix[index][i])
                        right = i - 1;
                    else
                        return true;
                }
                return false;
            }
        }
        return false;
    }
    #endregion
    #region KokoEatingBananas
    public static int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int totalHours = CalculateTotalHours(piles, mid);

            if (totalHours > h)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
        static int CalculateTotalHours(int[] piles, int speed)
        {
            int totalHours = 0;

            foreach (int pile in piles)
            {
                totalHours += (int)Math.Ceiling((double)pile / speed);
            }

            return totalHours;
        }
        //int[] possibleKs = Enumerable.Range(1, piles.Max()).ToArray();
        //int res = h;

        //int left = 0, right = possibleKs.Length - 1;
        //while (left <= right)
        //{
        //    int index = (left + right) / 2;
        //    int currK = possibleKs[index];

        //    int totalHours = 0;
        //    foreach (int pile in piles)
        //    {
        //        totalHours += (int)Math.Ceiling((double)pile / currK);
        //    }

        //    if (totalHours <= h)
        //    {
        //        res = Math.Min(res, currK);
        //        right = index + 1;
        //    }
        //    else if(totalHours >= h)
        //    {
        //        left = index - 1;
        //    }
        //}
        //return res;
    }
    #endregion
    #region MergeTwoList
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new();
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        current.next = list1 != null ? list1 : list2;

        return dummy.next;
    }
    #endregion
    #region CriticalPointsBetweenNodes
    //static void Main(string[] args)
    //{
    //// Creating the linked list: 5 -> 3 -> 1 -> 2 -> 5 -> 1 -> 2
    //ListNode head = new ListNode(5);
    //head.next = new ListNode(3);
    //head.next.next = new ListNode(1);
    //head.next.next.next = new ListNode(2);
    //head.next.next.next.next = new ListNode(5);
    //head.next.next.next.next.next = new ListNode(1);
    //head.next.next.next.next.next.next = new ListNode(2);

    //// Calling the NodesBetweenCriticalPoints method
    //int[] result = NodesBetweenCriticalPoints(head);

    //// Printing the result
    //Console.WriteLine($"[{result[0]}, {result[1]}]");






    //// Creating the linked list: 1 -> 3 -> 2 -> 2 -> 3 -> 2 -> 2 -> 2 -> 7
    //ListNode head = new ListNode(1);
    //head.next = new ListNode(3);
    //head.next.next = new ListNode(2);
    //head.next.next.next = new ListNode(2);
    //head.next.next.next.next = new ListNode(3);
    //head.next.next.next.next.next = new ListNode(2);
    //head.next.next.next.next.next.next = new ListNode(2);
    //head.next.next.next.next.next.next.next = new ListNode(2);
    //head.next.next.next.next.next.next.next.next = new ListNode(7);

    //// Calling the NodesBetweenCriticalPoints method
    //int[] result = NodesBetweenCriticalPoints(head);

    //// Printing the result
    //Console.WriteLine($"[{result[0]}, {result[1]}]");






    //// Creating the linked list with the specified values
    //int[] values = new int[] {
    //    19, 35, 33, 43, 53, 85, 15, 27, 86, 23, 80, 30, 37, 86, 32, 59, 90, 99, 68, 44, 20, 68, 47, 15, 19, 23, 73, 30, 70, 74,
    //    68, 100, 42, 82, 82, 70, 27, 82, 32, 6, 47, 49, 97, 23, 63, 78, 94, 93, 22, 25, 52, 94
    //};

    //ListNode head = new ListNode(values[0]);
    //ListNode current = head;
    //for (int i = 1; i < values.Length; i++)
    //{
    //    current.next = new ListNode(values[i]);
    //    current = current.next;
    //}

    //// Calling the NodesBetweenCriticalPoints method
    //int[] result = NodesBetweenCriticalPoints(head);

    //// Printing the result
    //Console.WriteLine($"[{result[0]}, {result[1]}]");




    //// Creating the linked list with the specified values: 6 -> 8 -> 4 -> 1 -> 9 -> 6 -> 6 -> 10 -> 6
    //int[] values = new int[] { 6, 8, 4, 1, 9, 6, 6, 10, 6 };

    //ListNode head = new ListNode(values[0]);
    //ListNode current = head;
    //for (int i = 1; i < values.Length; i++)
    //{
    //    current.next = new ListNode(values[i]);
    //    current = current.next;
    //}

    //// Calling the NodesBetweenCriticalPoints method
    //int[] result = NodesBetweenCriticalPoints(head);

    //// Printing the result
    //Console.WriteLine($"[{result[0]}, {result[1]}]");
    //}
    public static int[] NodesBetweenCriticalPoints(ListNode head)
    {
        int[] res = new int[] { int.MaxValue, -1 };
        List<int> indexes = new();
        int prev = 0;
        int i = 1;

        do
        {
            if (head.next != null && prev != 0)
            {
                if (head.val > prev && head.val > head.next.val)
                {
                    res[0] = Math.Min(indexes.Count != 0 ? (i - indexes[^1]) : res[0], res[0]);
                    indexes.Add(i);
                }
                else if (head.val < prev && head.val < head.next.val)
                {
                    res[0] = Math.Min(indexes.Count != 0 ? (i - indexes[^1]) : res[0], res[0]);
                    indexes.Add(i);
                }
            }
            prev = head.val;
            i++;
            head = head.next;
        } while (head != null);

        if (indexes.Count >= 2)
        {
            if (indexes.Count == 2)
            {
                res[0] = indexes[^1] - indexes[0];
                res[1] = indexes[^1] - indexes[0];
            }
            else
            {
                res[1] = indexes[^1] - indexes[0];
            }
        }
        else
            res[0] = -1;

        return res;
    }


    //public static int[] NodesBetweenCriticalPoints(ListNode head)
    //{
    //    int[] res = new int[] { -1, -1 };
    //    List<int> indexes = new();
    //    int prev = 0;
    //    int i = 1;

    //    do
    //    {
    //        if (head.next != null && prev != 0)
    //        {
    //            if (head.val > prev && head.val > head.next.val)
    //                indexes.Add(i);
    //            else if (head.val < prev && head.val < head.next.val)
    //                indexes.Add(i);
    //        }
    //        prev = head.val;
    //        i++;
    //        head = head.next;
    //    } while (head != null);

    //    if (indexes.Count >= 2)
    //    {
    //        if (indexes.Count == 2)
    //        {
    //            res[0] = indexes[^1] - indexes[0];
    //            res[1] = indexes[^1] - indexes[0];
    //        }
    //        else
    //        {
    //            res[1] = indexes[^1] - indexes[0];
    //            res[0] = Math.Min(indexes[(indexes.Count / 2) + 1] - indexes[indexes.Count / 2], indexes[indexes.Count / 2] - indexes[(indexes.Count / 2) - 1]);
    //        }
    //    }
    //    return res;
    //}
    #endregion
    #endregion

    #region DetectCycle
    //public ListNode? DetectCycle(ListNode? head)
    //{
    //    HashSet<ListNode?> visited = new();
    //    while (head != null)
    //    {
    //        if (visited.Contains(head))
    //            return head;
    //        visited.Add(head);
    //        head = head.next;
    //    }
    //    return null;
    //    //ListNode fast = head;
    //    //ListNode slow = head;

    //    //while (fast != null && fast.next != null)
    //    //{
    //    //    fast = fast.next.next;
    //    //    slow = slow.next;

    //    //    if (fast == slow) break;
    //    //}
    //    //if (fast == null || fast.next == null) return null;

    //    //slow = head;
    //    //while(slow != fast)
    //    //{
    //    //    slow = slow.next;
    //    //    fast = fast.next;
    //    //}
    //    //return slow;
    //}
    #endregion
    #region Math
    public double MyPow(double x, int n)
    {
        long N = n;

        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }
        double result = 1.0;
        while (N > 0)
        {
            if ((N % 2) == 1)
            {
                result *= x;
            }

            x *= x;
            N /= 2;
        }
        return result;
    }
    #endregion
    #endregion
    #endregion

    #region NEETCODE

    #region Arrays and Hashing

    #region Easy

    #region hasDuplicate
    public bool hasDuplicate(int[] nums)
    {
        //Weel I thought the array is always sorted
        //for (int i = 1; i < nums.Length; i++){
        //    if(nums[i-1] == nums[i])
        //        return true;
        //}
        //return false;
        HashSet<int> set = new();
        foreach (int i in nums)
        {
            if (!set.Contains(i))
                set.Add(i);
            else
                return true;
        }
        return false;
    }
    #endregion
    #region IsAnagram
    public static bool IsAnagram(string s, string t)
    {
        int[] count1 = new int[256];
        int[] count2 = new int[256];
        int i;

        for (i = 0; i < s.Length && i < t.Length; i++)
        {
            count1[s[i]]++;
            count2[t[i]]++;
        }

        if (s.Length != t.Length)
        {
            return false;
        }

        for (i = 0; i < 256; i++)
        {
            if (count1[i] != count2[i])
                return false;

        }
        return true;
        //if (s.Length != t.Length)
        //    return false;

        //Dictionary<char, int> kv = new();

        //foreach(char c in s)
        //{
        //    if (!kv.ContainsKey(c))
        //        kv.Add(c, 1);
        //    else
        //        kv[c]++;
        //}
        //foreach(char c in t)
        //{
        //    if (!kv.ContainsKey(c))
        //        return false;
        //    else if (kv[c])
        //}
        //if (s.Length != t.Length)
        //    return false;

        //char[] chars1 = s.ToCharArray();
        //foreach(char ch in t)
        //{
        //    if(!chars1.Contains(ch))
        //        return false;
        //}
        //return true;
    }
    #endregion
    #region TwoSum
    public static int[] TwoSum(int[] nums, int target)
    {
        int j = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length)
            {
                int jIdx = Math.Abs(nums.Length - j);
                if (i != jIdx)
                {
                    if (nums[i] + nums[^j] == target)
                    {
                        return new int[] { Math.Min(i, jIdx), Math.Max(i, jIdx) };
                    }
                }
                j++;
            }
            j = 1;
        }

        return Array.Empty<int>();

        //Dictionary<int, int> valIdx = new();

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    int diff = target - nums[i];
        //    if (valIdx.ContainsKey(diff))
        //        return new int[] { valIdx[diff], i };
        //    valIdx[nums[i]] = i;
        //}

        //return default;
    }
    #endregion

    #endregion
    #region Medium

    #region GroupAnagrams
    public static List<List<string>> GroupAnaagrams(string[] strs)
    {
        if (strs.Length == 1)
        {
            return new() { new() { strs[0] } };
        }

        bool b = false;
        Dictionary<string, List<string>> kv = new() { { strs[0], new() { strs[0] } } };

        for (int i = 1; i < strs.Length; i++)
        {
            foreach (string str in kv.Keys)
            {
                if (IsAnagram(strs[i], str))
                {
                    kv[str].Add(strs[i]);
                    b = true;
                    break;
                }
                b = false;
            }
            if (!b)
                kv.Add(strs[i], new() { strs[i] });
        }

        List<List<string>> res = new();
        foreach (List<string> list in kv.Values)
        {
            res.Add(list);
        }

        return res;

        bool IsAnagram(string s, string t)
        {
            int[] count1 = new int[256];
            int[] count2 = new int[256];
            int i;

            for (i = 0; i < s.Length && i < t.Length; i++)
            {
                count1[s[i]]++;
                count2[t[i]]++;
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            for (i = 0; i < 256; i++)
            {
                if (count1[i] != count2[i])
                    return false;

            }
            return true;
        }
    }
    #endregion
    #region TopKFrequent
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> map = new();

        foreach (int i in nums)
        {
            if (map.ContainsKey(i))
                map[i]++;
            else
                map[i] = 1;
        }


        var res = map.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();

        return res;
    }
    #endregion
    #region ProductExceptSelf
    //public static int[] ProductExceptSelf(int[] nums)
    //{
    //    int product = nums.Aggregate((acc, value) => acc * value);
    //    bool hasMoreThanOneZero = nums.Count(x => x == 0) > 1;
    //    int productWoZero = -1;

    //    List<int> answer = new();
    //    foreach (int i in nums)
    //    {
    //        if (i != 0)
    //            answer.Add(product / i);
    //        else
    //        {
    //            if (hasMoreThanOneZero)
    //                answer.Add(0);
    //            else
    //            {
    //                if (productWoZero != -1)
    //                    answer.Add(productWoZero);
    //                else
    //                {
    //                    productWoZero = nums.Aggregate((acc, value) => value != i ? acc * value : acc);
    //                    answer.Add(productWoZero);
    //                }
    //            }
    //        }
    //    }

    //    return answer.ToArray();

    //    //Only works without zeros
    //    //foreach (int i in nums)
    //    //{
    //    //    List<int> list = new() { i };
    //    //    var remainingElements = nums.Except(list);

    //    //    int product = 1;
    //    //    foreach (int element in remainingElements)
    //    //    {
    //    //        product *= element;
    //    //    }

    //    //    answer.Add(product);
    //    //}
    //    //return answer.ToArray();
    //}
    #endregion
    #region ValidSudoku
    public bool IsValidSudoku(char[][] board)
    {
        for (int rowIdx = 0; rowIdx < 9; rowIdx++)
        {
            HashSet<char> rowSet = new();
            for (int colIdx = 0; colIdx < 9; colIdx++)
            {
                char val = board[rowIdx][colIdx];
                if (val != '.')
                {
                    if (!rowSet.Add(val))
                        return false;
                }
            }
        }
        for (int colIdx = 0; colIdx < 9; colIdx++)
        {
            HashSet<char> colSet = new();
            for (int rowIdx = 0; rowIdx < 9; rowIdx++)
            {
                char val = board[rowIdx][colIdx];
                if (val != '.')
                {
                    if (!colSet.Add(val))
                        return false;
                }
            }
        }
        for (int boxRow = 0; boxRow < 3; boxRow++)
        {
            for (int boxCol = 0; boxCol < 3; boxCol++)
            {
                HashSet<char> squareSet = new();

                for (int i = boxRow * 3; i < boxRow * 3 + 3; i++)
                {
                    for (int j = boxCol * 3; j < boxCol * 3 + 3; j++)
                    {
                        char current = board[i][j];
                        if (current != '.')
                        {
                            if (!squareSet.Add(current))
                                return false;
                        }
                    }
                }
            }
        }

        return true;
    }
    #endregion
    #region LongestConsecutive
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> map = new(nums);
        int longest = 0;

        foreach (int i in nums)
        {
            //To not start another sequence count for a number that is an element in a already calculated sequence
            if (!map.Contains(i - 1))
            {
                int seqLength = 1;
                while (map.Contains(i + seqLength))
                {
                    seqLength++;
                }
                longest = Math.Max(longest, seqLength);
            }
        }

        return longest;
    }
    #endregion
    #region EncodeDecode
    public static string Encode(List<string> strs)
    {
        return string.Concat(strs.SelectMany(s => $"{s.Length}#{s}"));
    }

    public static List<string> Decode(string input)
    {
        List<string> strings = new();
        int index = 0;
        while (index < input.Length)
        {
            string lengthStr = string.Empty;
            while (input[index] != '#')
            {
                lengthStr += input[index];
                index++;
            }
            index++;
            _ = int.TryParse(lengthStr, out int length);

            string decoded = input.Substring(index, length);
            strings.Add(decoded);
            index += length;
        }

        return strings;
    }

    #endregion

    #endregion

    #endregion
    #region Stack

    #region Easy
    #region Valid Parantheses
    //public bool IsValid(string s)
    //{
    //    Stack<char> stack = new();

    //    foreach (char c in s)
    //    {
    //        if (c == '(' || c == '[' || c == '{')
    //        {
    //            stack.Push(c);
    //        }
    //        else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
    //        {
    //            return false;
    //        }
    //        else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
    //        {
    //            return false;
    //        }
    //        else if (c == '}' && (stack.Count == 0 || stack.Pop() != '{'))
    //        {
    //            return false;
    //        }

    //    }
    //    return stack.Count == 0;
    //}
    #endregion
    #endregion
    #region Medium

    #region MinStack
    //public static void Main(string[] args)
    //{
    //    TestMinStack();
    //}
    //private static void TestMinStack()
    //{
    //    // Create a new MinStack with a capacity of 5
    //    var minStack = new MinStack(5);

    //    // Test the Push, Pop, Top, and GetMin operations
    //    Console.WriteLine("Pushing 5, 2, 3, 4, 1 to the stack...");
    //    minStack.Push(5);
    //    minStack.Push(2);
    //    minStack.Push(3);
    //    minStack.Push(4);
    //    minStack.Push(1);

    //    Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
    //    Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

    //    Console.WriteLine("Popping an element from the stack...");
    //    minStack.Pop();

    //    Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
    //    Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

    //    // Test the resizing functionality
    //    Console.WriteLine("Pushing 6, 7, 8 to the stack...");
    //    minStack.Push(6);
    //    minStack.Push(7);
    //    minStack.Push(8);

    //    Console.WriteLine($"The minimum element in the stack is: {minStack.GetMin()}");
    //    Console.WriteLine($"The top element in the stack is: {minStack.Top()}");

    //    Console.ReadLine();
    //}
    //public class MinStack
    //{
    //    private int[] _stack;
    //    private int _capacity;
    //    private int _length;

    //    public MinStack(int capacity)
    //    {
    //        _stack = new int[capacity];
    //        _capacity = capacity;
    //        _length = 0;
    //    }

    //    public void Push(int val)
    //    {
    //        if (!(_length + 1 >= _capacity))
    //        {
    //            _stack[_length] = val;
    //            _length += 1;
    //        }
    //        else
    //        {
    //            Console.WriteLine("STACK CAPACITY IS FULL.\r\nWOULD YOU LIKE TO RESIZE Y/N?");
    //            string? answer = Console.ReadLine();
    //            if (answer == "Y")
    //            {
    //                int[] newStack = new int[_capacity * 2];
    //                for (int i = 0; i < _length; i++)
    //                {
    //                    newStack[i] = _stack[i];
    //                }
    //                _stack = newStack;
    //                _capacity *= 2;
    //                _stack[_length] = val;
    //                _length += 1;
    //            }
    //        }
    //    }

    //    public void Pop()
    //    {
    //        if (_length != 0)
    //        {
    //            _stack[_length] = 0;
    //            _length -= 1;
    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Cannot pop from an empty stack.");
    //        }
    //    }

    //    public int Top()
    //    {
    //        if (_length != 0)
    //        {
    //            return _stack[_length];
    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Cannot retrieve the top element from an empty stack.");
    //        }
    //    }

    //    public int GetMin()
    //    {
    //        if (_length != 0)
    //        {
    //            IEnumerable<int> slice = _stack.Take(_length);
    //            return slice.Min();
    //        }
    //        return int.MaxValue;
    //    }

    //    //Stack<int> stack;
    //    //public MinStack()
    //    //{
    //    //    stack = new();
    //    //}

    //    //public void Push(int val)
    //    //{
    //    //    stack.Push(val);
    //    //}

    //    //public void Pop()
    //    //{
    //    //    stack.Pop();
    //    //}

    //    //public int Top()
    //    //{
    //    //    return stack.Peek();
    //    //}

    //    //public int GetMin()
    //    //{
    //    //    return stack.Min();
    //    //}
    //}
    #endregion
    #region RPN
    public static int EvalRPN1(string[] tokens)
    {
        Stack<int> stack = new();
        foreach (string token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int rightOperand = stack.Pop();
                int leftOperand = stack.Pop();
                int result = token switch
                {
                    "+" => leftOperand + rightOperand,
                    "-" => leftOperand - rightOperand,
                    "*" => leftOperand * rightOperand,
                    "/" => leftOperand / rightOperand,
                    _ => 0
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }
        return stack.Pop();
    }
    #endregion
    #region GenerateParentheses
    public static List<string> GenerateParenthesis1(int n)
    {
        //1 <= n <= 7
        //At most, n number of same parantheses can be stacked
        //if n is 3 "(((.." and the rest is the close parantheses
        //According to that
        List<string> result = new();
        Construct(n, 0, 0, "", result);
        return result;

        static void Construct(int n, int openParen, int closeParen, string currPattern, List<string> result)
        {
            //Base condition for recursion
            //as there should be n number of coherent parantheses 
            if (openParen == n && openParen == closeParen)
            {
                result.Add(currPattern);
                return;
            }

            //If we have less then required amount of parantheses
            if (openParen < n)
                Construct(n, openParen + 1, closeParen, currPattern + '(', result);


            if (closeParen < openParen)
                Construct(n, openParen, closeParen + 1, currPattern + ')', result);
        }
    }
    #endregion
    #region DailyTemperatures
    //public static int[] DailyTemperatures(int[] temperatures)
    //{
    //    int[] res = new int[temperatures.Length];

    //    int index = 0;
    //    while (index < temperatures.Length)
    //    {
    //        int currTemp = temperatures[index];
    //        Stack<int> offsetStack = new(temperatures.Skip(index + 1).Reverse());
    //        int dayCount = 0;

    //        while (offsetStack.Count != 0)
    //        {
    //            int nextTemp = offsetStack.Pop();
    //            //What about equal?
    //            if (nextTemp > currTemp)
    //            {
    //                dayCount++;
    //                res[index] = dayCount;
    //                break;
    //            }
    //            else
    //            {
    //                if (offsetStack.Count == 0)
    //                    dayCount = 0;
    //                else
    //                    dayCount++;
    //                continue;
    //            }
    //        }

    //        res[index] = dayCount;
    //        index++;
    //    }

    //    return res;
    //    //Fernando(Queue) is faster than you Stack.
    //    //int[] res = new int[temperatures.Length];

    //    //int index = 0;
    //    //while (index < temperatures.Length)
    //    //{
    //    //    int currTemp = temperatures[index];
    //    //    Queue<int> offsetStack = new(temperatures.Skip(index + 1));
    //    //    int dayCount = 0;

    //    //    while (offsetStack.Count != 0)
    //    //    {
    //    //        int nextTemp = offsetStack.Dequeue();
    //    //        //What about equal?
    //    //        if (nextTemp > currTemp)
    //    //        {
    //    //            dayCount++;
    //    //            res[index] = dayCount;
    //    //            break;
    //    //        }
    //    //        else
    //    //        {
    //    //            if (offsetStack.Count == 0)
    //    //                dayCount = 0;
    //    //            else
    //    //                dayCount++;
    //    //            continue;
    //    //        }
    //    //    }

    //    //    res[index] = dayCount;
    //    //    index++;
    //    //}

    //    //return res;
    //}
    #endregion
    #region CarFleet
    public static int CarFleet(int target, int[] position, int[] speed)
    {
        //This is practically a linear equation problem.
        //We should check if cars intersect before or at <target>
        //If any of the cars time to reach is smaller or equal to another they become a fleet.

        //Created a jagged array to store position and speed of cars
        int n = position.Length;
        double[][] carParams = new double[n][];
        for (int i = 0; i < n; i++)
        {
            carParams[i] = new double[] { position[i], speed[i] };
        }

        //Sort cars according to their position
        carParams = carParams.OrderByDescending(arr => arr[0]).ToArray();

        int res = 0;
        double[] timeToReach = new double[n];
        for (int i = 0; i < n; i++)
        {
            //Calculate time to reach of each car
            //by subtracting its position from target and diving it by its speed
            //Ex: target = 10, position = 7, speed = 1 => timetoReach = 3
            //Ex: target = 10, position = 4, speed = 3 => timetoReach = 2
            timeToReach[i] = (target - carParams[i][0]) / carParams[i][1];

            //If any previous car's time to reach is calculated AND
            //Refer to the 3rd line in the beginning comments
            if (i > 0 && timeToReach[i] <= timeToReach[i - 1])
                timeToReach[i] = timeToReach[i - 1];
            else
                res++;
        }

        return res;

        #region Dictionary implementation
        //I'm not sure as to why Dictionary implementation does not work
        //I sense it has somehting to do with indexing
        //int n = position.Length;
        //Dictionary<int, double[]> carParamss = new();
        //for (int i = 0; i < n; i++)
        //{
        //    carParamss[i] = new double[] { position[i], speed[i] };
        //}

        //carParamss = carParamss
        //    .OrderByDescending(kv => kv.Value[0])
        //    .ToDictionary(kv => kv.Key, kv => kv.Value);

        //int res = 0;
        //double[] timeToReach = new double[n];
        //for (int i = 0; i < n; i++)
        //{
        //    timeToReach[i] = (target - carParamss[i][0]) / carParamss[i][1];
        //    if (i > 0 && timeToReach[i] <= timeToReach[i - 1])
        //        timeToReach[i] = timeToReach[i - 1];
        //    else
        //        res++;
        //}

        //return res;
        #endregion
    }

    #endregion

    #endregion
    #region Hard

    #region LargestRectangleArea
    //public static void Main(string[] args)
    //{
    //    Console.WriteLine(LargestRectangleArea(new int[] { 5, 4, 14, 9, 34, 14, 4, 23, 5, 5 }));
    //}
    //public static int LargestRectangleArea(int[] heights)
    //{
    //    //You are given an array of integers heights where heights[i] represents the height of a bar. The width of each bar is 1.
    //    //Return the area of the largest rectangle that can be formed among the bars.
    //    //Input: heights = [7, 1, 7, 2, 2, 4]
    //    //Output: 8

    //    int result = 0;
    //    //We use int array to keep a second parameter as index to keep track of the width(since every bar is 1 cm index is also equal to the total width at that point starting from the currBar)
    //    Stack<int[]> stack = new();

    //    for (int i = 0; i < heights.Length; i++)
    //    {
    //        //A second parameter that will determine the index value of a bar that is shorter than the bar after
    //        int offSet = i;

    //        while (stack.Count > 0 && stack.Peek()[1] > heights[i])
    //        {
    //            //We pop the item here since we encountered a shorter bar
    //            int[] currBar = stack.Pop();
    //            //height          //index(width)
    //            //↓↓↓↓            //↓↓↓↓
    //            result = Math.Max(result, currBar[1] * (i - currBar[0]));

    //            //We set the offset to the index of the current bar since we've checked that the height of the currBar is higher than the bar we've chekched from the heights
    //            //we should start it from the index of currBar.
    //            offSet = currBar[0];
    //        }
    //        stack.Push(new int[] { offSet, heights[i] });
    //    }

    //    //This last foreach is for the bars that are not popped as they are not bigger than the bar after them
    //    foreach (int[] bar in stack)
    //    {
    //        result = Math.Max(result, bar[1] * (heights.Length - bar[0]));
    //    }

    //    return result;
    //}
    #endregion
    #endregion

    #endregion
    #region TwoPointer

    #region IsPalindrome
    public static bool IsPalindrome(string s)
    {
        //string normalStr = new(s.Where(char.IsLetterOrDigit).ToArray());
        //string revStr = new(s.Where(char.IsLetterOrDigit).Reverse().ToArray());

        //return string.Equals(normalStr, revStr, StringComparison.OrdinalIgnoreCase);

        int i = 0, j = s.Length - 1;
        while (i < j)
        {
            while (!AlphaNum(s[i]) && i < j)
            {
                i++;
            }
            while (!AlphaNum(s[j]) && j > i)
            {
                j--;
            }

            if (char.ToLower(s[i]) != char.ToLower(s[j]))
                return false;
            i++;
            j--;
        }
        return true;

        static bool AlphaNum(char c)
        {
            return (c >= 'A' && c <= 'Z' ||
                    c >= 'a' && c <= 'z' ||
                    c >= '0' && c <= '9');
        }
    }
    #endregion
    #region TwoSum
    //public static int[] TwoSum(int[] numbers, int target)
    //{
    //    int leftIdx = 0, rightIdx = 0;

    //    while (leftIdx < numbers.Length - 1)
    //    {
    //        int leftVal = numbers[leftIdx];
    //        rightIdx = leftIdx + 1;
    //        while (rightIdx < numbers.Length)
    //        {
    //            int rightVal = numbers[rightIdx];
    //            if (leftVal + rightVal == target)
    //                return new int[] { leftIdx + 1, rightIdx + 1 };
    //            rightIdx++;
    //        }
    //        leftIdx++;
    //    }

    //    return Array.Empty<int>();
    //}
    #endregion

    #endregion

    #endregion
}