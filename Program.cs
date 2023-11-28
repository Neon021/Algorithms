public class Codewars
{
    public static void Main(string[] args)
    {
        Console.WriteLine(PartUp(1000, 1));
        Console.WriteLine(PartUp(1000, 2));
        Console.WriteLine(PartUp(1000, 3));
        Console.WriteLine(PartUp(1000, 4));
    }

    //Write an alogirhtm that'll output the how many time you can parition m objects into groups of maximum of n elements
    //n and m are real positive numbers
    public static int PartUp(int n, int m)
    {
        if (n == 0 || m == 1)
            return 1;

        else if (m == 0 || n < 0)
            return 0;

        else
            return (n - m) + PartUp(n, m - 1);
    }
}