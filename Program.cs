public class Codewars
{
    public static void Main(string[] args)
    {
        Console.WriteLine(CanJump(new int[] { 2, 3, 1, 1, 4 }));
    }

    //Recursive CanJump
    //First check the number in the given index
    //If it does not exceed the length of the nums
    //Send the elements of the array starting from the element we jumped to
    //Repeat this procces until the element is bigger then the size

    //public static bool CanJump(int[] nums)
    //{
    //    int size = nums.Length;
    //    int element = nums.ElementAt(0);

    //    if (element < size)
    //    {
    //        CanJump(nums.ToList().TakeLast(size - element).ToArray());
    //    }

    //    return element == nums.ElementAt(size - 1);
    //}

    public static bool CanJump(int[] nums)
    {
        int maxReach = 0; // Initialize the maximum reachable position

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach)
            {
                return false; // Cannot reach the end
            }

            maxReach = Math.Max(maxReach, i + nums[i]); // Update maxReach
        }

        return true; // If the loop completes, it's possible to reach the end
    }
}
