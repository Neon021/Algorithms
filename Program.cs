namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
        public List<int> prevSmaller(List<int> A)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (A[j] < A[i])
                        result.Add(j);
                }

                result.Add(-1);
            }

            return result;

        }
    }
}