using System.Numerics;

namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.QuickSort(new int[] { 5, 2, 9, 1, 5, 6 }, 0, 5))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public int MinStoneSum(int[] piles, int k)
        {
            MaxHeap maxHeap = new MaxHeap(piles.Length);
            int minStones = 0;

            foreach (var item in piles)
            {
                minStones += item;
                maxHeap.Insert(item);
            }

            while (k != 0)
            {
                int maxPile = maxHeap.ExtractMax();
                double newPile = Math.Ceiling((double)maxPile / 2);
                minStones -= maxPile - (int)newPile;
                maxHeap.Insert((int)newPile);
                k--;
            }

            return minStones;
        }
        public class MaxHeap
        {
            private int[] _heapArray;
            private int _capacity;
            private int _size;

            public MaxHeap(int capacity)
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
                while (index != 0 && _heapArray[index] > _heapArray[Parent(index)])
                {
                    Swap(ref _heapArray[index], ref _heapArray[Parent(index)]);
                    index = Parent(index);
                }

                return true;
            }
            public int ExtractMax()
            {
                if (_size <= 0) return int.MinValue;

                if (_size == 1)
                {
                    _size--;
                    return _heapArray[_size];
                }

                int min = _heapArray[0];
                _heapArray[0] = _heapArray[_size - 1];
                _size--;

                MaxHeapify(0);
                return min;
            }
            public void MaxHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int root = index;

                if (left < _size && _heapArray[left] > _heapArray[root])
                    root = left;
                if (right < _size && _heapArray[right] > _heapArray[root])
                    root = right;

                if (root != index) // did we change the index?
                {
                    Swap(ref _heapArray[index], ref _heapArray[root]);
                    MaxHeapify(root);// redo heapify starting from new root
                }
            }
        }

        public static int[] QuickSort(int[] nums, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(nums, low, high);
                QuickSort(nums, low, pivot - 1); //Exclude pivot as its already in the correct position
                QuickSort(nums, pivot + 1, high);
            }

            return nums;
        }

        private static int Partition(int[] nums, int low, int high)
        {
            int pivot = nums[low];
            int i = low, j = high;

            while (i < j)
            {
                while (nums[j] > pivot && j > low)
                    j--;

                while (nums[i] <= pivot && i < high)
                    i++;


                if (i < j)
                    (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            //swap pivot with the element at j which will put pivot in the center of the nums
            (nums[low], nums[j]) = (nums[j], nums[low]);

            //return the partition position
            return j;
        }
        //private static int Partition(int[] nums, int low, int high)
        //{
        //    int pivot = nums[low];
        //    int leftWall = low;

        //    for (int i = low + 1; i < high; i++)
        //    {
        //        if (nums[i] < pivot)
        //        {
        //            (nums[i], nums[leftWall]) = (nums[leftWall], nums[i]);
        //            leftWall++;
        //        }
        //    }

        //    int newPivotIdx = Array.IndexOf(nums, pivot);
        //    (nums[newPivotIdx], nums[leftWall]) = (nums[leftWall], nums[newPivotIdx]);

        //    return leftWall;
        //}
    }
}
