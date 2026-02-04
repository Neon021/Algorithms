namespace Main
{
    public static void Main()
    {

    }

    public static class Solution
    {
        public static ListNode InsertGreatestCommonDivisors(ListNode head)
        {
            ListNode dummy = new(-1)
            {
                next = head
            };

            while (head != null && head.next != null)
            {
                int gdc = GCD(head.val, head.next.val);
                ListNode newHead = head.next;
                ListNode newNode = new ListNode(gdc);
                head.next = newNode;
                newNode.next = newHead;
                head = newHead;
            }

            return dummy.next;
        }

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }
            return a;
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

        public static ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap minHeap = new(lists.Length * 10);

            for (int i = 0; i < lists.Length; i++)
            {
                ListNode? currNode = lists[i];
                while (currNode != null)
                {
                    minHeap.Insert(currNode.val);
                    currNode = currNode.next;
                }
            }

            return minHeap.GetMergedList();
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

            public static int Parent(int index) => (index - 1) / 2;
            public static int Left(int index) => index * 2 + 1;
            public static int Right(int index) => index * 2 + 2;
            public static void Swap<T>(ref T left, ref T right)
            {
                T temp = left;
                left = right;
                right = temp;
            }

            public bool Insert(int key)
            {
                if (_size == _capacity)
                {
                    _capacity *= 2;
                    Array.Resize(ref _heapArray, _capacity);
                }
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
            public int ExtractMin()
            {
                if (_size <= 0) return int.MaxValue;

                if (_size == 1)
                {
                    _size--;
                    return _heapArray[_size];
                }

                int min = _heapArray[0];
                _heapArray[0] = _heapArray[_size - 1];
                _size--;

                MinHeapify(0);
                return min;
            }
            public void MinHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int root = index;

                if (left < _size && _heapArray[left] < _heapArray[root])
                    root = left;
                if (right < _size && _heapArray[right] < _heapArray[root])
                    root = right;

                if (root != index) // did we change the index?
                {
                    Swap(ref _heapArray[index], ref _heapArray[root]);
                    MinHeapify(root);// redo heapify starting from new root
                }
            }
            public ListNode GetMergedList()
            {
                ListNode dummy = new(0);
                ListNode current = dummy;

                while (_size > 0)
                {
                    int minVal = ExtractMin();

                    current.next = new ListNode(minVal);
                    current = current.next;
                }

                return dummy.next;
            }
        }
    }
}