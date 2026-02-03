namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("--- Testing MergeKLists ---\n");

            // Test Case 1: Standard Example
            // [[1,4,5],[1,3,4],[2,6]] -> [1,1,2,3,4,4,5,6]
            int[][] input1 = new int[][]
            {
                new int[] { 1, 4, 5 },
                new int[] { 1, 3, 4 },
                new int[] { 2, 6 }
            };
            RunTest("Example 1", input1, new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });

            // Test Case 2: Empty Input
            // [] -> []
            int[][] input2 = new int[][] { };
            RunTest("Example 2 (Empty)", input2, new int[] { });

            // Test Case 3: List of Empty Lists
            // [[]] -> []
            int[][] input3 = new int[][]
            {
                new int[] { }
            };
            RunTest("Example 3 (Inner Empty)", input3, new int[] { });

            // Test Case 4: Single List
            // [[1, 2, 3]] -> [1, 2, 3]
            int[][] input4 = new int[][]
            {
                new int[] { 1, 2, 3 }
            };
            RunTest("Single List", input4, new int[] { 1, 2, 3 });
        }

        // --- Helper Methods to Run Tests ---

        public static void RunTest(string testName, int[][] inputArrays, int[] expected)
        {
            // 1. Arrange: Convert int[][] arrays to ListNode[]
            var lists = new Solution.ListNode[inputArrays.Length];
            for (int i = 0; i < inputArrays.Length; i++)
            {
                lists[i] = ArrayToList(inputArrays[i]);
            }

            Console.WriteLine($"Test: {testName}");
            Console.WriteLine($"   Input: {FormatInput(inputArrays)}");

            try
            {
                // 2. Act: Run your solution
                Solution.ListNode resultNode = Solution.MergeKLists(lists);
                int[] actual = ListToArray(resultNode);

                // 3. Assert
                bool pass = Enumerable.SequenceEqual(actual, expected);

                if (pass)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   [PASS]");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   [FAIL]");
                    Console.WriteLine($"   Expected: [{string.Join(",", expected)}]");
                    Console.WriteLine($"   Actual:   [{string.Join(",", actual)}]");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   [CRASH] {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        // Helper to convert array to Linked List
        public static Solution.ListNode ArrayToList(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;
            Solution.ListNode dummy = new Solution.ListNode(0);
            Solution.ListNode current = dummy;
            foreach (int val in arr)
            {
                current.next = new Solution.ListNode(val);
                current = current.next;
            }
            return dummy.next;
        }

        // Helper to convert Linked List back to array
        public static int[] ListToArray(Solution.ListNode head)
        {
            List<int> result = new List<int>();
            while (head != null)
            {
                result.Add(head.val);
                head = head.next;
            }
            return result.ToArray();
        }

        // Helper to format input for display
        public static string FormatInput(int[][] inputs)
        {
            if (inputs.Length == 0) return "[]";
            List<string> parts = new List<string>();
            foreach (var arr in inputs)
            {
                parts.Add($"[{string.Join(",", arr)}]");
            }
            return $"[{string.Join(", ", parts)}]";
        }
    }
}
public static class Solution
{
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

    public static ListNode MergeKLists(ListNode[] lists)
    {
        MinHeap minHeap = new(lists.Length * 10);

        for (int i = 0; i < lists.Length; i++)
        {
            ListNode? currNode = lists[i];
            while (currNode != null)
            {
                minHeap.Insert(currNode.val);
                currNode = currNode.next;
            }
        }

        return minHeap.GetMergedList();
    }

    public class MinHeap
    {
        private int[] _heapArray;
        private int _capacity;
        private int _size;

        public MinHeap(int capacity)
        {
            _capacity = capacity;
            _heapArray = new int[_capacity];
            _size = 0;
        }

        public static int Parent(int index) => (index - 1) / 2;
        public static int Left(int index) => index * 2 + 1;
        public static int Right(int index) => index * 2 + 2;
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        public bool Insert(int key)
        {
            if (_size == _capacity)
            {
                _capacity = _capacity == 0 ? 10 : _capacity * 2;
                Array.Resize(ref _heapArray, _capacity);
            }
            int index = _size;
            _heapArray[index] = key;
            _size++;
            while (index != 0 && _heapArray[index] < _heapArray[Parent(index)])
            {
                Swap(ref _heapArray[index], ref _heapArray[Parent(index)]);
                index = Parent(index);
            }

            return true;
        }
        public int ExtractMin()
        {
            if (_size <= 0) return int.MaxValue;

            if (_size == 1)
            {
                _size--;
                return _heapArray[_size];
            }

            int min = _heapArray[0];
            _heapArray[0] = _heapArray[_size - 1];
            _size--;

            MinHeapify(0);
            return min;
        }
        public void MinHeapify(int index)
        {
            int left = Left(index);
            int right = Right(index);
            int root = index;

            if (left < _size && _heapArray[left] < _heapArray[root])
                root = left;
            if (right < _size && _heapArray[right] < _heapArray[root])
                root = right;

            if (root != index) // did we change the index?
            {
                Swap(ref _heapArray[index], ref _heapArray[root]);
                MinHeapify(root);// redo heapify starting from new root
            }
        }
        public ListNode GetMergedList()
        {
            ListNode dummy = new(0);
            ListNode current = dummy;

            while (_size > 0)
            {
                int minVal = ExtractMin();

                current.next = new ListNode(minVal);
                current = current.next;
            }

            return dummy.next;
        }
    }
}