public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public static int CarFleet(int target, int[] position, int[] speed)
    {
        //This is practically a linear equation problem.
        //We should check if cars intersect before or at <target>
        //If any of the cars time to reach is smaller or equal to another they become a fleet.

        //Created a jagged array to store position and speed of cars
        int n = position.Length;
        double[][] carParams = new double[n][];
        for (int i = 0; i < n; i++)
        {
            carParams[i] = new double[] { position[i], speed[i] };
        }

        //Sort cars according to their position
        carParams = carParams.OrderByDescending(arr => arr[0]).ToArray();

        int res = 0;
        double[] timeToReach = new double[n];
        for (int i = 0; i < n; i++)
        {
            //Calculate time to reach of each car
            //by subtracting its position from target and diving it by its speed
            //Ex: target = 10, position = 7, speed = 1 => timetoReach = 3
            //Ex: target = 10, position = 4, speed = 3 => timetoReach = 2
            timeToReach[i] = (target - carParams[i][0]) / carParams[i][1];

            //If any previous car's time to reach is calculated AND
            //Refer to the 3rd line in the beginning comments
            if (i > 0 && timeToReach[i] <= timeToReach[i - 1])
                timeToReach[i] = timeToReach[i - 1];
            else
                res++;
        }

        return res;

        //I'm not sure as to why Dictionary implementation does not work
        //I sense it has somehting to do with indexing
        //int n = position.Length;
        //Dictionary<int, double[]> carParamss = new();
        //for (int i = 0; i < n; i++)
        //{
        //    carParamss[i] = new double[] { position[i], speed[i] };
        //}

        //carParamss = carParamss
        //    .OrderByDescending(kv => kv.Value[0])
        //    .ToDictionary(kv => kv.Key, kv => kv.Value);

        //int res = 0;
        //double[] timeToReach = new double[n];
        //for (int i = 0; i < n; i++)
        //{
        //    timeToReach[i] = (target - carParamss[i][0]) / carParamss[i][1];
        //    if (i > 0 && timeToReach[i] <= timeToReach[i - 1])
        //        timeToReach[i] = timeToReach[i - 1];
        //    else
        //        res++;
        //}

        //return res;
    }
}