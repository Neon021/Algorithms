namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] evenlyDuplicateNumbers = new int[] { 2, 3, 5, 3, 4, 5, 2, 5, 3, 2 };

            int result = 0;
            foreach(int number in evenlyDuplicateNumbers)
            {
                result ^= number;
            }
            foreach (int number in evenlyDuplicateNumbers)
            {
                result ^= number;
            }

            Console.WriteLine(result);
        }

        public bool IsPowerOfTwo(int n)
        {
            int k = n - 1;
            int res = n & k;
            return res == 0;
        }
    }
}
