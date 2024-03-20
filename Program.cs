public class Codewars
{
    public static void Main(string[] args)
    {
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);

        Console.WriteLine("Original List:");
        PrintList(head);

        // Reversing the linked list
        ListNode reversedHead = ReverseList(head);

        Console.WriteLine("\nReversed List:");
        PrintList(reversedHead);
    }
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

    public static ListNode ReverseList(ListNode head)
    {
        ListNode previousNode = null;
        while (head != null)
        {
            ListNode currNext = head.next;
            head.next = previousNode;
            previousNode = head;
            head = currNext;
        }
        return previousNode;
        //ListNode previous = null;
        //ListNode curr = head;
        //while(curr != null)
        //{
        //    ListNode next = curr.next;
        //    curr.next = previous;
        //    previous = curr;
        //    curr = next;
        //}
        //return previous;
    }

    public static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " -> ");
            head = head.next;
        }
        Console.WriteLine("null");
    }
}