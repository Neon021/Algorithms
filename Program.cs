namespace Main
{
    public class Program
    {
        public static void Main()
        {
            int[][] points = Solution.KClosest(new int[][] { new int[] { 3, 3 }, new int[] { 5, -1 }, new int[] { -2, 4 } }, 2);
            foreach (var item in points)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + " ");
                }
            }
        }
    }

    public class Solution
    {
        private static int[] _origin = new int[2] { 0, 0 };
        public static int[][] KClosest(int[][] points, int k)
        {
            MinHeap pq = new(points.Length);
            foreach (int[] point in points)
            {
                pq.Insert(point);
            }
            int[][] res = new int[k][];

            while(k != 0)
            {
                var closest = pq.ExtractMin();
                res[k - 1] = closest.Point;
                k--;
            }

            return res;
            //int[][] sortedPoints = QuickSelect(points, 0, points.Length - 1, k);
            //return sortedPoints.Take(k).ToArray();
        }

        public class MinHeapNode
        {
            public double Distance { get; set; }
            public int[] Point { get; set; }
        }

        public class MinHeap
        {
            private MinHeapNode[] _heap;
            private int _size;
            private int _capacity;

            public MinHeap(int capacity)
            {
                _capacity = capacity;
                _heap = new MinHeapNode[_capacity];
            }

            public bool IsEmpty() => _size == 0;
            private int Parent(int index) => (index - 1) / 2;
            private int Left(int index) => (index * 2) + 1;
            private int Right(int index) => (index * 2) + 2;
            private void Swap(int i, int j)
            {
                MinHeapNode temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }

            public void Insert(int[] value)
            {
                if (_size == _capacity) return;

                int index = _size;
                _heap[index] = new MinHeapNode
                {
                    Point = value,
                    Distance = DistanceToOrigin(value)
                };
                _size++;

                while (index != 0 && _heap[index].Distance < _heap[Parent(index)].Distance)
                {
                    Swap(index, Parent(index));
                    index = Parent(index);
                }
            }

            public MinHeapNode ExtractMin()
            {
                if (_size == 1)
                {
                    _size--;
                    return _heap[_size];
                }

                MinHeapNode min = _heap[0];
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

                if (left < _size && _heap[left].Distance < _heap[smallest].Distance)
                    smallest = left;
                if (right < _size && _heap[right].Distance < _heap[smallest].Distance)
                    smallest = right;

                if (smallest != index)//we found a new smallest!
                {
                    Swap(smallest, index);
                    MinHeapify(smallest);
                }
            }
        }


        //private static int[][] QuickSelect(int[][] points, int left, int right, int k)
        //{
        //    if (left >= right)
        //        return points;

        //    int pivot = Partition(points, left, right);

        //    if (k == pivot)
        //        return points;
        //    else if (k < pivot)
        //        return QuickSelect(points, left, pivot - 1, k);
        //    else
        //        return QuickSelect(points, pivot + 1, right, k);
        //}

        //private static int Partition(int[][] points, int left, int right)
        //{
        //    int[] pivot = points[left];
        //    int low = left, high = right;

        //    while (low < high)
        //    {
        //        double pivotDistance = DistanceToOrigin(pivot);

        //        while (high > left && DistanceToOrigin(points[high]) > pivotDistance)
        //            high--;
        //        while (low < right && DistanceToOrigin(points[low]) <= pivotDistance)
        //            low++;

        //        if (low < high)
        //            (points[low], points[high]) = (points[high], points[low]);
        //    }

        //    (points[left], points[high]) = (points[high], points[left]);

        //    return high;
        //}

        private static double DistanceToOrigin(int[] p1) => Math.Sqrt(Math.Pow((p1[0] - _origin[0]), 2) + Math.Pow((p1[1] - _origin[1]), 2));
    }
}
