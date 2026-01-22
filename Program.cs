namespace Main
{
    public class Program
    {
        public static void Main()
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine(RemoveDuplicates(nums));

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;

            //nums is in ascending order
            //So duplicate numbers must be side-by-side
            //It looks like a two-pointer since we operate on a sorted array to compare 2 elements

            //The first k element must be unique elements in ascending order
            //So, what we need to do is compare two pointers at each step
            //When elements at i and j are equal, increase j by one
            //when you stumble on a different element, place the element at j to i + 1 e.g nums[i + 1] = nums[j]
            //continue doing this until j < nums.length
            //also the answer is index i

            int i = 0;
            int j = 1;
            while (j < nums.Length)
            {
                if (nums[i] != nums[j])
                {
                    nums[i + 1] = nums[j];
                    i++;
                }
                j++;
            }

            return i += 1;
        }
    }
}