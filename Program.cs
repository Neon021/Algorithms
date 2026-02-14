namespace Main
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Solution.FurthestBuilding(new int[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
        }
    }

    public static class Solution
    {
        public static int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> minHeap = new();

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int jmp = heights[i + 1] - heights[i];

                if (jmp <= 0)
                    continue;
                
                minHeap.Enqueue(jmp, jmp); //we jumped using ladders and insert it into the heap

                if (minHeap.Count > ladders) //if we suprassed the ladders we change the smallest amount of ladder jump with brick jump
                {
                    int smallestJmp = minHeap.Dequeue();
                    bricks -= smallestJmp;
                }

                if (bricks < 0) return i; //If bricks is negative we can't jump ahead, return current index
            }

            return heights.Length - 1; //We jumped till the end!!


            ///<summary>
            ///This whole solution is wrong at its heart because it doesn't allow us to later swap ladders and bricks if a smaller jump appears
            ///</summary>
            for (int i = 0; i < heights.Length; i++)
            {
                if (i == heights.Length - 1)
                    return i;

                if (heights[i] >= heights[i + 1])
                    continue;

                if (bricks != 0 && heights[i + 1] - heights[i] <= Math.Ceiling((decimal)bricks / 2))
                    bricks -= heights[i + 1] - heights[i];
                else if (ladders != 0)
                    ladders--;
                else if (ladders == 0 && heights[i + 1] - heights[i] <= bricks)
                    bricks -= heights[i + 1] - heights[i];
                else
                    return i;
            }

            return -1;

            // //          Input: heights = [4, 2, 7, 6, 9, 14, 12], bricks = 5, ladders = 1
            // //          Output: 4
            // //          Explanation: Starting at building 0, you can follow these steps:
            // //            -Go to building 1 without using ladders nor bricks since 4 >= 2.
            // //            - Go to building 2 using 5 bricks.You must use either bricks or ladders because 2 < 7.
            // //            - Go to building 3 without using ladders nor bricks since 7 >= 6.
            // //            - Go to building 4 using your only ladder.You must use either bricks or ladders because 6 < 9.
            // //            It is impossible to go beyond building 4 because you do not have any more bricks or ladders.


            // [4, 2, 7, 6, 9, 14, 12]
            // [2, 7, 6, 9, 14, 12]
            // [7, 6, 9, 14, 12] //bricks = 5, ladder = 0
            // [6, 9, 14, 12] //bricks = 5, ladder = 0
            // [9, 14, 12] //bricks = 2, ladder = 0


            // //heights = [4, 12, 2, 7, 3, 18, 20, 3, 19], bricks = 10, ladders = 2
            // [4, 12, 2, 7, 3, 18, 20, 3, 19] //12 - 4 = 8 and 10 / 2 < 8 use ladder
            // [12, 2, 7, 3, 18, 20, 3, 19] //bricks = 10, ladders = 1
            // [2, 7, 3, 18, 20, 3, 19] //7 - 2 = 5 and 5 <= 10 / 2 use bricks
            // [7, 3, 18, 20, 3, 19] //bricks = 5, ladders = 1
            // [3, 18, 20, 3, 19] //18 - 3 = 15 and 15 / 2 < 15 use ladder
            // [18, 20, 3, 19] //bricks = 5, ladders = 0
            // [20, 3, 19] //bricks = 3, ladders = 0
            // [3, 19] //bricks = 3, ladders = 0


            ////heights = [14,3,19,3], bricks = 17, ladders = 0
            //[14,3,19,3] // bricks = 17 ladders = 0
            //[3,19,3] // İF (ladders == 0 || 19 - 3 = 16 <= 17 / 2)
            //[19,3] // bricks = 1
            //[3] // bricks = 1
        }
    }
}
