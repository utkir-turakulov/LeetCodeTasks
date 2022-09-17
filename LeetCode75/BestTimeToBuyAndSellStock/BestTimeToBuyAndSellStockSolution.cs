using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LeetCode75.BestTimeToBuyAndSellStock
{
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public static class BestTimeToBuyAndSellStockSolution
    {
        public static int MaxProfit(int[] prices)
        {
            // [7,1,5,3,6,4]
            
            int maxProfit = 0;
            int buy = prices[0];
            
            for (int i = 0; i < prices.Length; i++)
            {
                if (buy > prices[i])
                {
                    buy = prices[i];
                }
                else if (prices[i] - buy > maxProfit)
                {
                    maxProfit = prices[i] - buy;
                }
            }
            
            return maxProfit;
        }

        public static void Run()
        {
            var res = Enumerable.Range(1, 300000).Select(x => new Random().Next(1, 300000)).ToArray();

            var timer = Stopwatch.StartNew();
            timer.Start();
            var maxProfit = BestTimeToBuyAndSellStockSolution.MaxProfit(res);
            Console.WriteLine($"Time passed: {timer.Elapsed.Milliseconds}");
            Console.WriteLine(maxProfit);
        }
    }
}