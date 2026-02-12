using System.Collections.Generic;

namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Solution.ListNode listNode = new(-1, new(5, new(3, new(4, new(0)))));
            Solution.ListNode result = Solution.InsertionSortList(listNode);
            while (result != null)
            {
                System.Console.WriteLine(result.val);
                result = result.next;
            }
        }
    }

    public static class Solution
    {
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
        public static ListNode InsertionSortList(ListNode head)
        {
            ListNode dummy = new(0);
            ListNode prev = dummy;
            while (head != null)
            {
                ListNode next = head.next;
                if (prev.val >= head.val)
                {
                    prev = dummy;
                }
                while (prev.next != null && prev.next.val < head.val)
                {
                    prev = prev.next;
                }
                head.next = prev.next;
                prev.next = head;
                head = next;
            }
            return dummy.next;
        }
    }
}