public class Codewars
{
    static void Main(string[] args)
    {
        //Console.WriteLine(SubsetXORSum(new int[] { 5,1,6}));
    }
    public static bool IsEven(int input)
    {
        return (input & 1) == 0;
    }
    public static int SubsetXORSum(int[] nums)
    {
        //int answer = 0;

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    for(int j = i+1;  j < nums.Length; j++)
        //    {
        //        answer += nums[i] ^ nums[j];
        //    }
        //}

        //return answer;
        int or = 0;

        foreach (int num in nums)
        {
            or |= num;
        }
        return or << (nums.Length - 1);
        //return or << (nums.Length - 1);
        //int n = nums.Length;
        //int totalXORSum = 0;
        //int subsetCount = 1 << n; // 2^n

        //for (int i = 0; i < subsetCount; i++)
        //{
        //    int subsetXOR = 0;
        //    for (int j = 0; j < n; j++)
        //    {
        //        if ((i & (1 << j)) != 0)
        //        {
        //            subsetXOR ^= nums[j];
        //        }
        //    }
        //    totalXORSum += subsetXOR;
        //}

        //return totalXORSum;
    }
}