namespace Main
{
    public class Program
    {
        public static void Main()
        {
            foreach (var item in Solution.RelativeSortArray(new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new int[] { 2, 1, 4, 3, 9, 6 }))
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class Solution
    {
        public static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            //Example 1:
            //Input: arr1 = [2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19], arr2 = [2, 1, 4, 3, 9, 6]
            //Output: [2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19]


            //Iterate over arr2 to create a dictionary that will have the key as the integer value and the value as the index of the integer in arr2.
            //Then, iterate on the arr1 and sort the elements based on the index of the integer in arr2 in a separate list. If the integer is not in arr2, then we put it in another list also
            //Then we sort the list of remaining numbers
            //And add it to the end of the list that we created from arr1.
            //Finally, we return the list as an array.

            //Dry run
            //arr1 = [2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19]
            //arr2 = [2, 1, 4, 3, 9, 6]
            //idxMap = [2: 0, 1: 1, 4: 2, 3: 3, 9: 4, 6: 5]
            //listFromArr1 = [2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19]

            //Dry run wit another input
            //arr1 = [28, 6, 22, 8, 44, 17]
            //arr2 = [22, 28, 8, 6]
            //idxMap = [22: 0, 28: 1, 8: 2, 6: 3]
            //listFromArr1 = [22, 28, 8, 6]
            //remainingNumbers = [44, 17]
            //sortedRemainingNumbers = [17, 44]
            //res = listFromArr1 + sortedRemainingNumbers = [22, 28, 8, 6, 17, 44]

            //Dry run with another input
            //arr1 = [2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 ]
            //arr2 = [2, 1, 4, 3, 9, 6]
            //idxMap = [2: 0, 1: 1, 4: 2, 3: 3, 9: 4, 6: 5]
            //listFromArr1 = [2, 2, 2, 3, 9, 6, 0, 0, 0] This happens because we don't update the index of subsequent elements accordingly if we encounter more than one element for a previous value. We'd need yet another dictionary to act as a frequency map to keep track of the number of times we have encountered a value in arr1 and update the index accordingly.

            //Let's use counting sort instead

            int maxElement = arr1.Max();
            int[] count = new int[maxElement + 1];

            foreach (int i in arr1)
                count[i]++;

            List<int> result = new();
            foreach (int i in arr2)//It is ensured that each element in arr2 exists in arr1
            {
                while (count[i] > 0)
                {
                    result.Add(i);
                    count[i]--;
                }
            }

            //So, the remaining values in count are the values that are not in arr2. We need to add them to the end of the result list in sorted order.
            //Also since the count array is already sorted, we can just iterate over it and add the remaining values to the result list.
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    result.Add(i);
                    count[i]--;
                }
            }

            return result.ToArray();
        }
    }
}
