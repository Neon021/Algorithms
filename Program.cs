namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.FindKthLargest(new int[] { 2, 1 }, 2));
        }
    }

    public static class Solution
    {
        public static int FindKthLargest(int[] nums, int k)
        {
            //insert all elements into the maxHeap
            MaxHeap maxHeap = new(nums.Length);

            //int lastAdded = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                //if (nums[i] < lastAdded && !(nums.Length == k))
                //{
                //    lastAdded = int.MinValue;
                //    continue;
                //}
                //else
                //{
                maxHeap.Insert(nums[i]);
                //lastAdded = nums[i];
                //}
            }

            int res = -1;
            while (k != 0)
            {
                res = maxHeap.ExtractMax();
                k--;
            }

            return res;
        }

        public class MaxHeap
        {
            private int[] _heap;
            private int _size;
            private int _capacity;

            public MaxHeap(int capacity)
            {
                _capacity = capacity;
                _heap = new int[_capacity];
            }

            private static int Left(int index) => (index * 2) + 1;
            private static int Right(int index) => (index * 2) + 2;
            private static int Parent(int index) => (index - 1) / 2;
            private static void Swap(ref int l, ref int r)
            {
                int tmp = l;
                l = r;
                r = tmp;
            }

            public void Insert(int value)
            {
                if (_size == _capacity) return;

                int index = _size;
                _heap[index] = value;
                _size++;

                while (index != 0 && _heap[index] > _heap[Parent(index)])
                {
                    Swap(ref _heap[index], ref _heap[Parent(index)]);
                    index = Parent(index);
                }
            }

            public int ExtractMax()
            {
                if (_size == 1)
                {
                    _size--;
                    return _heap[_size];
                }

                int min = _heap[0];
                _heap[0] = _heap[_size - 1];
                _size--;

                MaxHeapify(0);
                return min;
            }

            private void MaxHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int largest = index;

                if (left < _size && _heap[left] > _heap[largest])
                    largest = left;
                if (right < _size && _heap[right] > _heap[largest])
                    largest = right;

                if (largest != index)//we found a new largest!
                {
                    Swap(ref _heap[largest], ref _heap[index]);
                    MaxHeapify(largest);
                }
            }

        }
    }
}