public class Codewars
{
    public static void Main(string[] args)
    {
        int[] haystack = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
        Console.WriteLine(BinarySearch(haystack, 10));
    }

    public static bool BinarySearch(int[] haystack, int needle)
    {
        int low = 0;
        int high = haystack.Length;
        do
        {
            int index = low + ((high - low) / 2);
            int value = haystack[index];

            if (value == needle)
                return true;
            else if(value > needle) 
                high = index;
            else
                low = index + 1;

        } while (low < high);

        return false;
    }
}
