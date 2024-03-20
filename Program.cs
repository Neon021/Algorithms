public class Codewars
{
    static void Main(string[] args)
    {
        // Test cases
        ListNode list1 = new ListNode(1);
        list1.next = new ListNode(2);
        list1.next.next = new ListNode(4);

        ListNode list2 = new ListNode(1);
        list2.next = new ListNode(3);
        list2.next.next = new ListNode(4);

        Console.WriteLine("Input List 1:");
        PrintList(list1);
        Console.WriteLine("Input List 2:");
        PrintList(list2);

        ListNode mergedList = MergeTwoLists(list1, list2);
        Console.WriteLine("Merged List:");
        PrintList(mergedList);

        // Additional test cases
        ListNode emptyList1 = null;
        ListNode emptyList2 = null;

        ListNode mergedEmptyLists = MergeTwoLists(emptyList1, emptyList2);
        Console.WriteLine("Merged Empty Lists:");
        PrintList(mergedEmptyLists);

        ListNode emptyList3 = null;
        ListNode list3 = new ListNode(0);

        ListNode mergedListWithEmpty = MergeTwoLists(emptyList3, list3);
        Console.WriteLine("Merged List With Empty:");
        PrintList(mergedListWithEmpty);
    }

    static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
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
}