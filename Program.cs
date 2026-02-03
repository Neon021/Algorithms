
namespace Main
{
    public class Program
    {
        public static void Main()
        {
            //headA = [2][6][4]
            //headB = [1][5]
            ListNode headA = new ListNode(2);
            headA.next = new ListNode(6);
            headA.next.next = new ListNode(4);
            ListNode headB = new ListNode(1);
            headB.next = new ListNode(5);
            ListNode intersectionNode = Solution.GetIntersectionNode(headA, headB);
            if (intersectionNode != null)
            {
                System.Console.WriteLine("Intersection at node with value: " + intersectionNode.val);
            }
            else
            {
                System.Console.WriteLine("No intersection.");
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
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode ptrOfFirstList = headA;
            ListNode ptrOfSecondList = headB;

            while (ptrOfFirstList != ptrOfSecondList)
            {
                ptrOfFirstList = ptrOfFirstList == null ? headB : ptrOfFirstList.next;
                ptrOfSecondList = ptrOfSecondList == null ? headA : ptrOfSecondList.next;
            }

            return ptrOfFirstList;
        }
    }
}