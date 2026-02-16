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
            int[][] sortedPoints = QuickSelect(points, 0, points.Length - 1, k);
            return sortedPoints.Take(k).ToArray();
        }

        private static int[][] QuickSelect(int[][] points, int left, int right, int k)
        {
            if (left >= right)
                return points;

            int pivot = Partition(points, left, right);

            if (k == pivot)
                return points;
            else if (k < pivot)
                return QuickSelect(points, left, pivot - 1, k);
            else
                return QuickSelect(points, pivot + 1, right, k);
        }

        private static int Partition(int[][] points, int left, int right)
        {
            int[] pivot = points[left];
            int low = left, high = right;

            while (low < high)
            {
                double pivotDistance = DistanceToOrigin(pivot);

                while (high > left && DistanceToOrigin(points[high]) > pivotDistance)
                    high--;
                while (low < right && DistanceToOrigin(points[low]) <= pivotDistance)
                    low++;

                if (low < high)
                    (points[low], points[high]) = (points[high], points[low]);
            }

            (points[left], points[high]) = (points[high], points[left]);

            return high;
        }

        private static double DistanceToOrigin(int[] p1) => Math.Sqrt(Math.Pow((p1[0] - _origin[0]), 2) + Math.Pow((p1[1] - _origin[1]), 2));
    }
}
