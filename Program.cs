using System.Collections.Generic;

namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Solution.ListNode listNode = new(1, new(1));
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
            for (ListNode i = head; i != null; i = i.next)
            {
                for (ListNode j = head; j != i; j = j.next)
                {
                    if (i.val < j.val)
                    {
                        (i.val, j.val) = (j.val, i.val);
                    }
                }
            }
            return head;
        }
    }
}