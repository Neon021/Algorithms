using System.Globalization;
using System.Text;
using static Algorithms;

public class Codewars
{
    static void Main(string[] args)
    {
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




        // Creating the linked list with the specified values: 6 -> 8 -> 4 -> 1 -> 9 -> 6 -> 6 -> 10 -> 6
        int[] values = new int[] { 6, 8, 4, 1, 9, 6, 6, 10, 6 };

        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        // Calling the NodesBetweenCriticalPoints method
        int[] result = NodesBetweenCriticalPoints(head);

        // Printing the result
        Console.WriteLine($"[{result[0]}, {result[1]}]");
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
}