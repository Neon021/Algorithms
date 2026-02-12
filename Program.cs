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
            List<int> list = new();
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            for (int i = 1; i < list.Count; i++)
            {
                int j = i;
                while (0 < j && list[j] < list[j - 1])
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                    j--;
                }
            }

            ListNode head2 = new();
            ListNode dummy = new();
            dummy.next = head2;
            for (int i = 0; i < list.Count; i++)
            {
                head2 ??= new();
                head2.val = list[i];
                if (i != list.Count - 1)
                    head2.next = new();
                head2 = head2.next;
            }

            return dummy.next;
        }
        public static int[] InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int j = i;
                while (j > 0 && nums[j] < nums[j - 1])
                {
                    int tmp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = tmp;

                    j -= 1;
                }
            }
            return nums;
        }
    }


}