namespace Main
{
    public class Program
    {
        public static void Main()
        {
        }
    }

    public static class Solution
    {
        public static IList<IList<string>> Partition(string s)
        {
            List<IList<string>> result = new();
            Backtracking(s, 0, new List<string>(), result);
            return result;
        }

        private static void Backtracking(string s, int start, List<string> currPartition, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(currPartition);
                return;
            }

            for (int end = start; end < s.Length; end++)
            {
                if (IsPalindrome(start, end))
                    currPartition.Add(s[start..end]);

                Backtracking(s, end + 1, currPartition, result);
            }

            bool IsPalindrome(int start, int end)
            {
                while (start < end && end > start) 
                {
                    if (s[start] != s[end]) return false;
                    start++;
                    end--;
                }

                return true;
            }
        }
        public static int MaxConsecutive(int[] nums)
        {
            int result = 0;
            int left = 0;
            int zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                    zeroCount++;

                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                        zeroCount--;
                    left++;
                }

                result = Math.Max(result, right - left + zeroCount);
            }

            return result;
        }
    }
}
