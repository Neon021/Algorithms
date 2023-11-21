public class Codewars
{
    public static void Main(string[] args)
    {
        int[] numbers = { 5, 1, 92, 2828213, 2835, 8235, 23, 25, 823, 12, 9 };
        BubbleSort(numbers);
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    public static void BubbleSort(int[] numbers)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            for(int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    (numbers[j + 1], numbers[j]) = (numbers[j], numbers[j + 1]);
                }

            }
        }
    }
}
