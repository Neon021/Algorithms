using System.Reflection.Metadata.Ecma335;

public class Codewars
{
    public static void Main(string[] args)
    {
        int[] ints = new int[] { -1, 0, 1, 2, 3 };
        var res = ProductExceptSelf(ints);

        foreach (int i in res)
        {
            Console.WriteLine(i);
        }
    }
    public static int[] ProductExceptSelf(int[] nums)
    {
        int product = nums.Aggregate((acc, value) => acc * value);
        bool hasMoreThanOneZero = nums.Count(x => x == 0) > 1;
        int productWoZero = -1;

        List<int> answer = new();
        foreach (int i in nums)
        {
            if (i != 0)
                answer.Add(product / i);
            else
            {
                if (hasMoreThanOneZero)
                    answer.Add(0);
                else
                {
                    if (productWoZero != -1)
                        answer.Add(productWoZero);
                    else
                    {
                        productWoZero = nums.Aggregate((acc, value) => value != i ? acc * value : acc);
                        answer.Add(productWoZero);
                    }
                }
            }
        }

        return answer.ToArray();

        //Only works without zeros
        //foreach (int i in nums)
        //{
        //    List<int> list = new() { i };
        //    var remainingElements = nums.Except(list);

        //    int product = 1;
        //    foreach (int element in remainingElements)
        //    {
        //        product *= element;
        //    }

        //    answer.Add(product);
        //}
        //return answer.ToArray();
    }
}