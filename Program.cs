namespace Main
{
    public class Program
    {
        public static void Main()
        {
            int[] example = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(MaxArea(example));
        }
        public static int MaxArea(int[] height)
        {
            //height.Length n
            //there are n vertical lines
            //each of these vertical lines at ith index are (i, 0)[starting point] and (i, height[i])[length]
            //For example
            //int[] LineAtithStartingPoint = new int[] { i, 0 };
            //int[] LineAtithEndpoint = new int[] { i, height[i] };
            //
            //int[] LineAtjthStartingPoint = new int[] { j, 0 };
            //int[] LineAtjthEndpoint = new int[] { j, height[j] };

            int maxSurfaceArea = 0;
            int i = 0, j = height.Length - 1;

            while (i < j)
            {
                int diff = j - i;//difference on X axis
                int surface = diff * Math.Min(height[j], height[i]);
                maxSurfaceArea = Math.Max(maxSurfaceArea, surface);

                if (height[j] > height[i])
                    i++;
                else
                    j--;
            }

            return maxSurfaceArea;

            //This one does not work as expected because we increase i and decrease j at EACH STEP which unables us to retain on the biggest line we have
            //The working version compares the height of th
            //int maxSurfaceArea = 0;

            //for (int i = 0, j = height.Length - 1; i < j && j > i; i++, j--)
            //{
            //    int diff = j - i;//difference on X axis
            //    int surface = diff * Math.Min(height[j], height[i]);

            //    Console.WriteLine($"i = {i}, j ={j}\r\ndiff={diff}, surface={surface}, maxSurface={maxSurfaceArea}");

            //    maxSurfaceArea = Math.Max(maxSurfaceArea, surface);
            //}

            //return maxSurfaceArea;
        }
    }
}