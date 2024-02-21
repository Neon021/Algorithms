public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public int[] ProductExceptSelf(int[] nums)
    {
        List<int> answer = new List<int>();

        foreach (int i in nums)
        {
            List<int> list = new List<int> { i };
            var remainingElements = nums.Except(list);

            int product = 1;
            foreach (int element in remainingElements)
            {
                product *= element;
            }

            answer.Add(product);
        }
        return answer.ToArray();
    }
}