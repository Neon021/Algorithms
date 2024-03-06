﻿using System.Text;
using static Codewars;

public class Algorithms
{
    #region Last Algorithms Course
    //Front End Masters The Primeagen(THE MYTH THE LEGEND HIMSELF) Algorithms course

    //Search algorithms
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
        public T? Deque<T>() where T : class
        {
            if (this.Head == null)
            {
                return null;
            }

            this.Length--;

            var head = this.Head;
            this.Head = this.Head.Next;

            // free
            head.Next = null;

            if (this.Length == 0)
            {
                this.Tail = null;
            }

            return head.Data as T;
        }

        public T? Peek<T>() where T : class
        {
            return this.Head is not null ? this.Head.Data as T : null;
        }
    }


    //Stack

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
                Node<T>? head0 = this.Head as Node<T>;
                this.Head = null;
                return head0.Data;
            }

            Node<T>? head = this.Head as Node<T>;
            this.Head = head.Prev;

            return head.Data;
        }

        public T? Peek<T>() where T : class
        {
            return this.Head is not null ? this.Head.Data as T : null;
        }
    }




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


    //ACKERMANN'S FUNCTION:

    class GFG
    {
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



    #region CODEWARS
    public static string Likes(string[] names)
    {
        int count = names.Length;
        switch (count)
        {
            case 0:
                return "no one likes this";
                break;

            case 1:
                return $"{names[0]} likes this";
                break;

            case 2:
                return $"{names[0]} and {names[1]} like this";
                break;

            case 3:
                return $"{names[0]}, {names[1]} and {names[2]} like this";

            default:
                return $"{names[0]}, {names[1]} and {count - 2} others like this";
                break;
        }
    }


    public static int CountBits(int n)
    {
        char[] c = Convert.ToString(n, 2).ToCharArray();

        int answer = 0;
        foreach (char bin in c)
        {
            if (bin.Equals('1'))
            {
                answer += 1; //? bin.Equals('1) : return;
            }
        }
        return answer;
    }


    public static int CountBits_OneLiner(int n)
    {
        return Convert.ToString(n, 2).Count(x => x == '1');
    }


    //MySolution
    public static string DuplicateEncode(string word)
    {
        word = word.ToLower();
        string result = "";
        for (int i = 0; i < word.Length; i++)
        {
            char ch = word[i];
            result += word.LastIndexOf(ch) == word.IndexOf(ch) ? '(' : ')';
        }
        return result;
    }

    //Refactored after a year or so
    public static string DuplicateEncode_Refactored(string word)
    {
        word = word.ToLower();
        string result = "";
        foreach (char ch in word)
        {
            result += word.LastIndexOf(ch) == word.IndexOf(ch) ? '(' : ')';
        }
        return result;
    }


    //BestPractice (yersen)
    public static string DuplicateEncode_BestPractice(string word)
    {
        var disct = word.ToUpper().Distinct();
        Dictionary<char, int> counts = new();

        foreach (var c in word.ToUpper())
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts.Add(c, 1);
        }

        StringBuilder builder = new();
        foreach (var c in word.ToUpper())
        {
            if (counts[c] == 1)
                builder.Append('(');
            else
                builder.Append(')');
        }

        return builder.ToString();
    }





    public static int[] ArrayDiff_Obvious(int[] a, int[] b)
    {
        return a.Except(b).ToArray();
    }

    public static int[] ArrayDiff(int[] a, int[] b)
    {
        return a.Where(m => b.Contains(m)).ToArray();
    }




    public static int[,] MultiplicationTable(int size)
    {
        int[,] table = new int[size, size];
        //for loop will break if the size variable is 0. Apperantly for loop 
        //incorporates some sort of while logic as well.
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                table[i, j] = (i + 1) * (j + 1);
            }
        }
        return table;
    }



    //Bu da C++
    //#include <vector>
    //#include <iostream>
    //using namespace std;
    //vector<vector<int>> multiplication_table(int n)
    //{
    //    vector<vector<int>> res;
    //    for (int i = 1; i <= n; i++)
    //    {
    //        vector<int> tmp;
    //        for (int j = 1; j <= n; j++)
    //        {
    //            tmp.push_back(i * j);
    //        }
    //        res.push_back(tmp);
    //    }
    //    return res;
    //}




    //Tatsız olan (ama tek attım)
    public static int Multipleof3or5(int value)
    {
        while (value! <= 0 /*value * -1 != +value && value != 0*/)
        {
            int sum = 0;

            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    sum += i;
                }
                else if (i % 3 == 0)
                {
                    sum += i;
                }
                else if (i % 5 == 0)
                {
                    sum += i;
                }
                else
                    continue;
            }
            return sum;
        }

        return 0;
    }


    //Refactored one
    public static int Multipleof3or5_Refactored(int value)
    {
        while (value! <= 0 /*value * -1 != +value && value != 0*/)
        {
            int sum = 0;

            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
                else
                    continue;
            }
            return sum;
        }
        return 0;
    }



    //Yine tek attım (https://www.youtube.com/watch?v=OjZcboiOjX4&ab_channel=Aleskut)
    public static int FindMissing(List<int> list)
    {
        int difference = list[1] - list[0];
        // int answer = 0;
        // for(int i = 1; i < list.Count(); i++){
        //     if(list[i] - list[i - 1] != difference){
        //        return answer = list[i] - difference;
        //     }
        //     else
        //         continue;
        // } 
        // return answer;
        return list.First(x => !list.Contains(x - (x - difference)));
    }


    public static bool IsPrime(int n)
    {
        if (n >= 0)
        {
            if (n == 1 || n == 0)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
        }
        else
        {
            if (n == -1 || n == 0 || n == -2)
                return false;

            n = n * -1;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
        }

        return true;
    }


    //Better solution
    public static bool IsPrime_OneLiner(int n)
    {
        return n > 1 && Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
    }



    public static bool Narcissistic(int input)
    {
        //Digits
        List<int> list = input.ToString().Select(x => (int)char.GetNumericValue(x)).ToList();

        //Sum of digits
        double sum = 0;
        list.ForEach(x =>
        {
            sum += Math.Pow(x, list.Count);
        });

        return sum == input;
    }



    public static string PascalCaseToSnakeCase(string input)
    {
        List<char> list = input.ToList();

        for (int i = 0; i < list.Count; i++)
        {
            char c = list[i];
            if (char.IsUpper(c) && i != 0)
            {
                list.Insert(i, '_');
                list[i + 1] = char.ToLower(c);
            }
            else
            {
                list[i] = char.ToLower(c);
            }
        }

        return string.Join("", list);
    }



    //çalışmıyor (divide by zero and overflow errors) :(
    public static double Going(int n)
    {
        int factorial = Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);
        decimal fraction = decimal.Divide(1, factorial);

        List<int> ints = new();

        for (int i = 1; i <= n; i++)
        {
            int result = Enumerable.Range(1, i).Aggregate(1, (p, item) => p * item);
            ints.Add(result);
        }

        return (double)fraction * ints.Sum();
    }


    //this...this is art f@!?ing beautiful
    public static double Going_ButArt(int n)
    {
        double result = 0;
        double denominator = 1;
        for (int i = n; i > 0; i--)
        {
            result += 1 / denominator;
            denominator *= i;
        }
        return Math.Round(result, 6);
    }



    //gene olmadı :(  (4kyu'lar zorlardı biraz)
    //IndexOutOfRangeException
    public static int DblLinear(int n)
    {
        List<int> ints = new();

        int index = -1;
        for (int multiplier = 1; multiplier <= n; multiplier = ints[index])
        {
            ints.Add(2 * multiplier + 1);
            ints.Add(3 * multiplier + 1);
            ints.Sort((x, y) => x.CompareTo(y));
            index++;
        }

        return ints.ElementAt(n - 1);
    }



    public static int DblLinear_Better(int n)
    {
        SortedSet<int> answer = new() { 1 };

        while (n > 0)
        {
            answer.Add(2 * answer.Min + 1);
            answer.Add(3 * answer.Min + 1);

            answer.Remove(answer.Min);
            n--;
        }

        return answer.Min;
    }


    int IsHappynumber(int n)
    {
        if (n == 1 || n == 7)
            return 1;
        int sum = n, x = n;

        while (sum > 9)
        {
            sum = 0;
            while (x > 0)
            {
                int d = x % 10;
                sum += d * d;
                x /= 10;
            }
            if (sum == 1)
                return 1;

            x = sum;
        }
        if (sum == 7)
            return 1;

        return 0;
    }
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
    #endregion

    #region

    #endregion
    #region Medium

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
    public static int[] TwoSum(int[] numbers, int target)
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
    #endregion
    #endregion
    #endregion
}