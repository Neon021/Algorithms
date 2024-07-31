public class Codewars
{
    public static void Main(string[] args)
    {
    }
    public bool hasDuplicate(int[] nums)
    {
        //Weel I thought the array is always sorted
        //for (int i = 1; i < nums.Length; i++){
        //    if(nums[i-1] == nums[i])
        //        return true;
        //}
        //return false;
        HashSet<int> set = new();
        foreach(int i in nums)
        {
            if (!set.Contains(i))
                set.Add(i);
            else
                return true;
        }
        return false;
    }
}