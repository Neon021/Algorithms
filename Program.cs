public class Codewars
{
    public static void Main(string[] args)
    {
        bool[] bools = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, };
        Console.WriteLine(TwoCrystalBalls(bools));
    }

    public static int TwoCrystalBalls(bool[] breaks)
    {
        double jmpAmount = Math.Floor(Math.Sqrt(breaks.Length));

        double i = jmpAmount;
        for (; i < breaks.Length; i += jmpAmount)
        {
            if (breaks[(int)i])
            {
                break;
            }
        }

        i -= jmpAmount;
        for (int j = 0; j <= jmpAmount && i < breaks.Length; ++j, ++i)
        {
            if (breaks[(int)i])
            {
                return (int)i;
            }
        }
        return -1;
    }
}
