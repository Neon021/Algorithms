public class Codewars
{
    public static void Main(string[] args)
    {
        Console.WriteLine(LargestRectangleArea(new int[] { 7, 1, 7, 2, 2, 4 }));
    }
    public static int LargestRectangleArea(int[] heights)
    {
        //You are given an array of integers heights where heights[i] represents the height of a bar. The width of each bar is 1.
        //Return the area of the largest rectangle that can be formed among the bars.
        //Input: heights = [7, 1, 7, 2, 2, 4]
        //Output: 8
        int result = 0;
        Stack<int[]> stack = new();

        for (int i = 0; i < heights.Length; i++)
        {
            //A second index to start from the current bar on the stack
            //And iterate on the height array until it encounters a higher bar
            //Or stack is emptide
            int offSet = i;
            //we do not have the index data as a parameter for that we utilize offset.
            //And as we use index to keep track of the width(since every bar is 1 cm index is also equal to the total width at that point starting from the currBar)

            while (stack.Count > 0 && stack.Peek()[1] > heights[i])
            {
                //We pop the item here because we are iterating until we hit a higher bar or the stack is empty
                //So we do not need any prior bar item since we already checked them
                int[] currBar = stack.Pop();
                                        //height            //index(width)
                                        //↓↓↓↓              //↓↓↓↓
                result = Math.Max(result, currBar[1] * (i - currBar[0]));

                //We set the offset to the index of the current bar since we've checked that the height of the currBar is higher than the bar we've chekched from the heights
                //we should start it from the index of currBar.
                offSet = currBar[0];
            }
            stack.Push(new int[] { offSet, heights[i] });
        }

        //This last foreach is for the bars that are not popped as they are not bigger than the bar after them
        foreach (int[] bar in stack)
        {
            result = Math.Max(result, bar[1] * (heights.Length - bar[0]));
        }

        return result;
    }
}