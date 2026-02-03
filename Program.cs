
namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("--- Running Tests ---\n");

            // Case 0: Empty List
            RunTest("Empty List",
                input: new int[] { },
                expected: new int[] { });

            // Case 1: Mixed duplicates
            RunTest("Mixed Duplicates",
                input: new int[] { -3, -1, 0, 0, 0, 3, 3 },
                expected: new int[] { -3, -1 });

            // Case 2: All duplicates (Should return empty)
            RunTest("All Duplicates",
                input: new int[] { 1, 1 },
                expected: new int[] { });

            // Case 3: Duplicates at start
            RunTest("Start Duplicates",
                input: new int[] { 1, 1, 2 },
                expected: new int[] { 2 });

            // Case 4: Duplicates at end
            RunTest("End Duplicates",
                input: new int[] { 1, 2, 2 },
                expected: new int[] { 1 });

            // Case 5: Complex
            RunTest("Complex 1",
                input: new int[] { 1, 2, 3, 3, 4, 4, 5 },
                expected: new int[] { 1, 2, 5 });

            // Case 6: Consecutive duplicates
            RunTest("Complex 2",
                input: new int[] { 1, 1, 1, 2, 3 },
                expected: new int[] { 2, 3 });
        }

        // --- Test Helper Method ---
        public static void RunTest(string testName, int[] input, int[] expected)
        {
            // 1. Arrange: Build the linked list from array
            ListNode head = Solution.BuildList(input);

            // 2. Act: Run your algorithm
            // Note: We wrap in try-catch to catch the NullReferenceException if the bug exists
            try
            {
                ListNode resultNode = Solution.DeleteDuplicates(head);
                int[] actual = Solution.ListToArray(resultNode);

                // 3. Assert: Compare arrays
                bool pass = Enumerable.SequenceEqual(actual, expected);

                // 4. Output Result
                Console.ForegroundColor = pass ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(pass ? "[PASS] " : "[FAIL] ");
                Console.ResetColor();
                Console.WriteLine($"{testName}");

                if (!pass)
                {
                    Console.WriteLine($"   Expected: [{string.Join(", ", expected)}]");
                    Console.WriteLine($"   Actual:   [{string.Join(", ", actual)}]");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[FAIL] ");
                Console.ResetColor();
                Console.WriteLine($"{testName} - Threw Exception: {ex.Message}");
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class Solution
    {
        // --- Helper: Build List from Array ---
        public static ListNode BuildList(int[] values)
        {
            if (values == null || values.Length == 0) return null;
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            foreach (int val in values)
            {
                current.next = new ListNode(val);
                current = current.next;
            }
            return dummy.next;
        }

        // --- Helper: Convert List to Array (for printing/asserting) ---
        public static int[] ListToArray(ListNode head)
        {
            List<int> result = new List<int>();
            while (head != null)
            {
                result.Add(head.val);
                head = head.next;
            }
            return result.ToArray();
        }
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode nodeBeforeSlow = head;
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != null && fast != null)
            {
                if (slow.val == fast.val)
                {
                    while (fast != null && fast.val == slow.val)
                    {
                        fast = fast.next;
                    }
                    if (nodeBeforeSlow.val == head.val && slow.val == head.val)
                    {
                        head = fast;
                        nodeBeforeSlow = fast;
                    }
                    else
                        nodeBeforeSlow.next = fast;
                    slow = fast;
                    if (fast != null) fast = fast.next;
                }
                else
                {
                    nodeBeforeSlow = slow;
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            return head;
        }
    }
}