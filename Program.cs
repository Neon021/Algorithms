
namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

        public class Solution
        {
            public ListNode? DeleteDuplicates(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;

                ListNode tmp = head;
                while (tmp != null && tmp.next != null)
                {
                    if (tmp.val == tmp.next.val)
                        tmp.next = tmp.next.next;
                    else
                        tmp = tmp.next;
                }

                return head;
            }
        }
    }
}