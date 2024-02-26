using System;

public class Codewars
{
    public static void Main(string[] args)

    {
        int[] prices = { 7, 1, 5, 3, 6, 4 };
        int resıu = MaxProfit(prices);
    }
    public static int MaxProfit(int[] prices)
    {
        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
        }

        return maxProfit;
        //int result = 0;
        //int i = 0;
        //int j = 1;

        //while (j < prices.Length)
        //{
        //    if (prices[i] >= prices[j])
        //    {
        //        i = j;
        //        j++;
        //    }
        //    else if (prices[i] < prices[j])
        //    {
        //        if (prices[j] - prices[i] > result) result = prices[j] - prices[i];
        //        j++;
        //    }
        //}
        //return result;
    }
}