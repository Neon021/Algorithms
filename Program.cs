namespace Main
{
    public class Program
    {
        public static void Main()
        {
            MinHeap h = new MinHeap(11);
            h.Insert(3);
            h.Insert(2);
            h.Delete(1);
            h.Insert(15);
            h.Insert(5);
            h.Insert(4);
            h.Insert(45);

        }
    }

    public class MinHeap
    {
        private int[] _heapArray;
        private int _capacity;
        private int _size;

        public MinHeap(int capacity)
        {
            _capacity = capacity;
            _heapArray = new int[_capacity];
            _size = 0;
        }


        public static int Parent(int index) => (int)Math.Floor((decimal)((index - 1) / 2));
        public static int Left(int index) => index * 2 + 1;
        public static int Right(int index) => index * 2 + 2;
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
        public int GetMin() => _size > 0 ? _heapArray[0] : int.MaxValue;

        public bool Insert(int key)
        {
            if (_size == _capacity)
                return false;

            int index = _size;
            _heapArray[index] = key;
            _size++;
            while (index != 0 && _heapArray[index] < _heapArray[Parent(index)])
            {
                Swap(ref _heapArray[index], ref _heapArray[Parent(index)]);
                index = Parent(index);
            }

            return true;
        }
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