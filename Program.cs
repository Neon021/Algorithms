namespace Main
{
    public static void Main()
    {
        Console.WriteLine(CountStudents(new int[] { 1, 1, 0, 0 }, new int[] { 0, 1, 0, 1 }));
    }
    public static int CountStudents(int[] students, int[] sandwiches)
    {
        Queue<int> studentQueue = new Queue<int>(students);
        Stack<int> sandwichStack = new Stack<int>(sandwiches);

        while (sandwichStack.Count != 0)
        {
            int currStudent = studentQueue.Peek();
            int currSandwich = sandwichStack.Peek();

            if (currStudent == currSandwich)
            {
                studentQueue.Dequeue();
                sandwichStack.Pop();
            }
            else
            {
                int student = studentQueue.Dequeue();
                studentQueue.Enqueue(student);
            }
        }

        return studentQueue.Count;
        //students in queue
        //sandwiches in stack
        //sandwiches either type of 1 or 0
        //students either type of 1 or 0. 1 doesn't take the sandwich of type 0. 
        //0 doesn't take take the sandwich of tyope 0 
        //if(stuudent[i] == 1)
        //goes to the end of the queue
        //students.Length == sandwiches.Length

        //while(sandwiches.Length != 0)



        //students = [1,1,1,0,0,1], sandwiches = [1,0,0,0,1,1]
        //students = [1,1,0,0,1], sandwiches = [0,0,0,1,1]
        //students = [1,0,0,1,1], sandwiches = [0,0,0,1,1]
        //students = [0,0,1,1,1], sandwiches = [0,0,0,1,1]
        //students = [0,1,1,1], sandwiches = [0,0,1,1]
        //students = [1,1,1], sandwiches = [0,1,1]
        //students = [1,1,1], sandwiches = [0,1,1]
    }
}
public static class Solution
{
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