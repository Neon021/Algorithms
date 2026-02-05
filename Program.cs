namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.NthUglyNumber(10));
        }
    }

    public static class Solution
    {
        public static int NthUglyNumber(int n)
        {
            //we start the heap with the number 1. Because we are certain its an ugly number
            MinHeap heap = new(n);
            heap.Insert(1);

            int uglyCount = 0;
            long lastUgly = 0;

            while (true)
            {
                //Next we extract the minimum from the heap
                long currUgly = heap.ExtractMin();

                //Check if its equal to the last ugly number
                if (currUgly == lastUgly)
                    continue;

                lastUgly = currUgly;
                uglyCount++;

                if (uglyCount == n)
                    return (int)currUgly;

                //how to accomodate for previously calculated ugly number?
                //use List instead of int[] in the heap and use Any?
                //Something smarter
                heap.Insert(currUgly * 2);
                heap.Insert(currUgly * 3);
                heap.Insert(currUgly * 5);
            }
        }

        public class MinHeap
        {
            private long[] _heap;
            private int _size;
            private int _capacity;

            public MinHeap(int capacity)
            {
                _capacity = capacity;
                _heap = new long[_capacity];
            }

            public bool IsEmpty() => _size == 0;
            private int Parent(int index) => (index - 1) / 2;
            private int Left(int index) => (index * 2) + 1;
            private int Right(int index) => (index * 2) + 2;
            private void Swap(int i, int j)
            {
                long temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }

            public void Insert(long value)
            {
                if (_size == _capacity) return;

                int index = _size;
                _heap[index] = value;
                _size++;

                while (index != 0 && _heap[index] < _heap[Parent(index)])
                {
                    Swap(index, Parent(index));
                    index = Parent(index);
                }
            }

            public long ExtractMin()
            {
                if (_size == 1)
                {
                    _size--;
                    return _heap[_size];
                }

                long min = _heap[0];
                _heap[0] = _heap[_size - 1];
                _size--;

                MinHeapify(0);
                return min;
            }

            private void MinHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int smallest = index;

                if (left < _size && _heap[left] < _heap[smallest])
                    smallest = left;
                if (right < _size && _heap[right] < _heap[smallest])
                    smallest = right;

                if (smallest != index)//we found a new smallest!
                {
                    Swap(smallest, index);
                    MinHeapify(smallest);
                }
            }
        }
    }
}