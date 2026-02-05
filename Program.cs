namespace Main
{
    public class Program
    {
        public static void Main()
        {
            int[] nums1 = new int[] { -15, 20, 45, 117, 223 };
            int[] nums2 = new int[] { -15, 20, 45, 117, 223, 546, 663, 714, 749, 801 };

            var res = Solution.KSmallestPairs(nums1, nums2, 10);

            foreach (var list in res)
            {
                Console.WriteLine($"[{list[0]}, {list[1]}] (Sum: {list[0] + list[1]})");
            }
        }
    }

    public static class Solution
    {
        public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            //nums1 and nums2 are sorted in ascending order
            //we need pair of (nums1i, nums2i) with the smallest sums
            //For that, we need to store the result of their sum in our MinHeap
            //But at the end we need to return the pairs not the results
            //We can use a dictionary to have pairs as the value and the sum as the key
            //After we iterate over all possible elements in num one and num two
            //we put the results in the minHeap
            //Then we can extractMin from the heap and use it to access our dictionary to get the related pair.

            var result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0 || k == 0) return result;

            MinHeap heap = new(nums1.Length);

            // 1. Initialize Heap with the first column (i, 0)
            // This treats every item in nums1 as the "head" of a potential sorted list
            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                // We store the Sum, plus the indices i and j
                heap.Insert(nums1[i] + nums2[0], i, 0);
            }

            // 2. Extract min and push the neighbor
            while (k > 0 && !heap.IsEmpty())
            {
                MinHeap.HeapNode minNode = heap.ExtractMin();

                int i = minNode.Index1;
                int j = minNode.Index2;

                // Add to result
                result.Add(new List<int> { nums1[i], nums2[j] });

                // 3. Push the NEXT element from the same "row" (i, j+1)
                // If there is a next number in nums2...
                if (j + 1 < nums2.Length)
                {
                    int nextSum = nums1[i] + nums2[j + 1];
                    heap.Insert(nextSum, i, j + 1);
                }

                k--;
            }

            return result;
        }

        public class MinHeap
        {
            public struct HeapNode
            {
                public int Sum;
                public int Index1; // Index in nums1
                public int Index2; // Index in nums2
            }

            private HeapNode[] _heap;
            private int _size;
            private int _capacity;

            public MinHeap(int capacity)
            {
                _capacity = capacity;
                _heap = new int[_capacity];
            }

            public bool IsEmpty() => _size == 0;

            private int Parent(int index) => (index - 1) / 2;
            private int Left(int index) => (index * 2) + 1;
            private int Right(int index) => (index * 2) + 2;

            private void Swap(int i, int j)
            {
                HeapNode temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }

            public void Insert(int sum, int index1, int index2)
            {
                if (_size == _capacity) return;

                int index = _size;
                _heap[index] = new HeapNode { Sum = sum, Index1 = index1, Index2 = index2 };
                _size++;

                // Bubble Up
                while (index != 0 && _heap[index].Sum < _heap[Parent(index)].Sum)
                {
                    Swap(index, Parent(index));
                    index = Parent(index);
                }
            }

            public HeapNode ExtractMin()
            {
                // Assuming caller checks IsEmpty()
                HeapNode min = _heap[0];

                _heap[0] = _heap[_size - 1];
                _size--;

                if (_size > 0)
                {
                    MinHeapify(0);
                }

                return min;
            }

            private void MinHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int smallest = index;

                if (left < _size && _heap[left].Sum < _heap[smallest].Sum)
                    smallest = left;

                if (right < _size && _heap[right].Sum < _heap[smallest].Sum)
                    smallest = right;

                if (smallest != index)
                {
                    Swap(index, smallest);
                    MinHeapify(smallest);
                }
            }
        }
    }
}