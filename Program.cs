using System.Diagnostics.Metrics;

public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] res = new int[temperatures.Length];

        int index = 0;
        while (index < temperatures.Length)
        {
            int currTemp = temperatures[index];
            Stack<int> offsetStack = new(temperatures.Skip(index + 1).Reverse());
            int dayCount = 0;

            while (offsetStack.Count != 0)
            {
                int nextTemp = offsetStack.Pop();
                //What about equal?
                if (nextTemp > currTemp)
                {
                    dayCount++;
                    res[index] = dayCount;
                    break;
                }
                else
                {
                    if (offsetStack.Count == 0)
                        dayCount = 0;
                    else
                        dayCount++;
                    continue;
                }
            }

            res[index] = dayCount;
            index++;
        }

        return res;
        //Fernando(Queue) is faster than you Stack.
        //int[] res = new int[temperatures.Length];

        //int index = 0;
        //while (index < temperatures.Length)
        //{
        //    int currTemp = temperatures[index];
        //    Queue<int> offsetStack = new(temperatures.Skip(index + 1));
        //    int dayCount = 0;

        //    while (offsetStack.Count != 0)
        //    {
        //        int nextTemp = offsetStack.Dequeue();
        //        //What about equal?
        //        if (nextTemp > currTemp)
        //        {
        //            dayCount++;
        //            res[index] = dayCount;
        //            break;
        //        }
        //        else
        //        {
        //            if (offsetStack.Count == 0)
        //                dayCount = 0;
        //            else
        //                dayCount++;
        //            continue;
        //        }
        //    }

        //    res[index] = dayCount;
        //    index++;
        //}

        //return res;
    }
}