namespace Codewars.AlgoQuestions
{
    internal class AlgoQuestions
    {
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
}
