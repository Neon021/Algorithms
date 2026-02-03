namespace Main
{
    public class Program
    {
        public static void Main()
        {
            MinHeap h = new MinHeap(11);
            h.Insert(3);
            h.Insert(2);
            h.DeleteRoot();
            h.Insert(15);
            h.Insert(5);
            h.Insert(4);
            h.Insert(45);

            Console.Write(h.ExtractMin() + " ");
            Console.Write(h.GetMin() + " ");
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

        public static int Parent(int index) => (index - 1) / 2;
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
        public void DeleteRoot()
        {
            if (_size == 0) return;
            if (_size == 1)
            {
                _heapArray[0] = 0;
                _size--;
                return;
            }

            int min = _heapArray[0];
            _heapArray[0] = _heapArray[_size - 1];
            _size--;

            //heap sort
            //if (_size != _capacity)
            //{
            //    int diff = _capacity - _size;
            //    _heapArray[^(diff - 1)] = min;
            //}

            MinHeapify(0);// heapify root
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
    }
}