using System.Text;

public class Algorithms
{
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












    //////////////////////////////////////////////////////////////////////////////////















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












    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Algorithms following are from Codewars




















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





    //LEETCODE

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
}