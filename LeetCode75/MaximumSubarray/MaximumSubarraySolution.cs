using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace LeetCode75.MaximumSubarray
{
    public static class MaximumSubarraySolution
    {
        public static void Run()
        {
            List<long> ar = new List<long>();
            List<long> ar2 = null;

            var rr = ar.Select(x => x + 1).ToArray();
            var rr2 = ar2?.Any() == true
                ? ar2.Select(x => x + 1).ToArray()
                : Array.Empty<long>();

            Print(rr);
            Print(rr2);
        }


        private static void Print(IEnumerable<long> arr)
        {
            foreach (var it in arr)
            {
                Console.WriteLine(it);
            }
        }

        public static int MaxSubArray(int[] nums)
        {
            Array.Sort(nums);

            //var summ = ;

            foreach (var num in nums)
            {
            }

            return 0;
        }
    }
}