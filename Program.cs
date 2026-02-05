namespace Main
{
    public class Program
    {
        public static void Main()
        {
            int[] nums1 = new int[] { -15, 20, 45, 117, 223 };
            int[] nums2 = new int[] { -15, 20, 45, 117, 223, 546, 663, 714, 749, 801 };
            IList<IList<int>> res = Solution.KSmallestPairs(nums1, nums2, 2);
            foreach(var list in res)
            {
                foreach(var item in list)
                    Console.WriteLine(item);
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

            MinHeap heap = new MinHeap(nums1.Length);

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    int sum = nums1[i] + nums2[j];
                    List<int> currPair = new() { nums1[i], nums2[j] };
                    heap.Insert(sum, currPair);
                }
            }

            IList<IList<int>> result = heap.GetPairs(k);

            return result;
        }



        public class MinHeap
        {
            private int[] _heap;
            private int _size;
            private int _capacity;
            private Dictionary<int, List<IList<int>>> _pairResults = new();

            public MinHeap(int capacity)
            {
                _capacity = capacity;
                _heap = new int[_capacity];
            }

            private int Parent(int index) => (index - 1) / 2;
            private int Left(int index) => (index * 2) + 1;
            private int Right(int index) => (index * 2) + 2;
            private void Swap(ref int left, ref int right)
            {
                int tmp = left;
                left = right;
                right = tmp;
            }

            public void Insert(int value, List<int> pair)
            {
                if (_size == _capacity) return;

                int index = _size;
                int parentIndex = Parent(index);
                _heap[index] = value;
                _size++;
                _pairResults.TryGetValue(value, out List<IList<int>>? list);
                if (list != null)
                    list.Add(pair);
                else
                    _pairResults.TryAdd(value, new List<IList<int>>() { pair });
                //bubble up
                while (index != 0 && _heap[index] < _heap[parentIndex])
                {
                    Swap(ref _heap[index], ref _heap[parentIndex]);
                    index = parentIndex;
                    parentIndex = Parent(index);
                }
            }

            public IList<IList<int>> GetPairs(int k)
            {
                IList<IList<int>> result = new List<IList<int>>();
                while (_size >= 0 && k > 0)
                {
                    int smallest = ExtractMin();
                    _pairResults.TryGetValue(smallest, out List<IList<int>>? pair);
                    if (pair != null)
                    {
                        result.Add(pair[0]);
                        pair.RemoveAt(0);
                    }
                    k--;
                }

                return result;
            }

            private int ExtractMin()
            {
                if (_size <= 0)
                    return int.MaxValue;

                if (_size == 1)
                {
                    _size--;
                    return _heap[_size];
                }

                int min = _heap[0];
                _heap[0] = _heap[_size - 1];
                _size--;

                MinHeapify(0);

                return min;
            }

            private void MinHeapify(int index)
            {
                int left = Left(index);
                int right = Right(index);
                int root = index;

                if (left < _size && _heap[left] < _heap[root])
                    root = left;
                if (right < _size && _heap[right] < _heap[root])
                    root = right;

                if (root != index)//if we actually changed our root
                {
                    Swap(ref _heap[index], ref _heap[root]);
                    index = root;
                    MinHeapify(index);
                }
            }
        }
    }
}