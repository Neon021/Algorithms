namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.CountingSort(new int[] { 5, 1, 1, 2, 0, 0 }))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public static int[] CountingSort(int[] nums)
        {
            Dictionary<int, int> freqMap = new();
            foreach (int key in nums)
            {
                if (freqMap.ContainsKey(key))
                    freqMap[key]++;
                else
                    freqMap.Add(key, 1);
            }

            List<int> sortedKeys = freqMap.Keys.OrderBy(k => k).ToList();
            int currSum = 0;
            foreach (var key in sortedKeys)
            {
                currSum += freqMap[key];
                freqMap[key] = currSum;
            }


            int[] res = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int val = nums[i];
                int pos = freqMap[val] - 1;
                res[pos] = val;
                freqMap[val]--;
            }

            return res;
        }
    }
}
