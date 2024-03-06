using Microsoft.VisualBasic;
using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {

    }
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public ListNode? DetectCycle(ListNode? head)
    {
        HashSet<ListNode?> visited = new();
        while (head != null)
        {
            if (visited.Contains(head))
                return head;
            visited.Add(head);
            head = head.next;
        }
        return null;
        //ListNode fast = head;
        //ListNode slow = head;

        //while (fast != null && fast.next != null)
        //{
        //    fast = fast.next.next;
        //    slow = slow.next;

        //    if (fast == slow) break;
        //}
        //if (fast == null || fast.next == null) return null;

        //slow = head;
        //while(slow != fast)
        //{
        //    slow = slow.next;
        //    fast = fast.next;
        //}
        //return slow;
    }

    public bool HasCycle(ListNode? head)
    {
        HashSet<ListNode?> visited = new();
        while (head != null)
        {
            if (visited.Contains(head))
            {
                return true;
            }
            visited.Add(head);
            head = head.next;
        }
        return false;
        //if (head == null) return false;

        //ListNode fast = head;
        //ListNode slow = head;

        //while (fast.next != null && fast.next.next != null)
        //{
        //    fast = fast.next.next;
        //    slow = slow.next;

        //    if(fast == slow) return true;
        //}
        //return false;
    }
}