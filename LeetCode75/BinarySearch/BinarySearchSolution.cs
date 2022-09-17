using System;

namespace LeetCode75.BinarySearch
{
    /// <summary>
    /// https://leetcode.com/problems/binary-search/
    /// </summary>
    public static class BinarySearchSolution
    {
        public static void Run()
        {
            /*
            var nums = new int[] {-1, 0, 3, 5, 9, 12};
            Print(nums, 9);

            var nums2 = new int[] {-1, 0, 3, };
            Print(nums2, 3);

            var nums3 = new int[] {-1,0,3,5,9,12};
            Print(nums3, 2);

            var nums4 = new int[] {5};
            Print(nums4, 5);
            */
            
            var nums5 = new int[] {2, 5};
            Print(nums5, 0);
        }
        
        public static void Print(int[] nums, int target)
        {
            Console.WriteLine("Nums: ");
            foreach (var num in nums)
            {
                Console.Write(num + ", ");
            }
            Console.Write("");
            Console.WriteLine($"Target searching number is {target}");
            
            Console.WriteLine("Result index is :"+ Search(nums, target));
        }
        
        /// <summary>
        /// Linear binary search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            if (nums == null)
            {
                return -1;
            }

            if (nums.Length == 1 && nums[0] == target) // if 1 element in array
            {
                return 0;
            }

            var left = 0;
            var right = nums.Length -1;

            const int notFoundIndex = -1;

            while (right > left)
            {
                var center = (right + left) / 2;

                if (center == 0) // could be if array length is 2
                {
                    if (nums[right] == target)
                    {
                        return right;
                    }

                    return nums[left] == target
                        ? left
                        : notFoundIndex;
                }

                if (nums[center] == target)
                {
                    return center;
                }

                if (nums[center] > target)
                {
                    right = center -1 ;
                }
                else if(nums[center] < target)
                {
                    left = center + 1;
                }

                if (nums[left] == target)
                {
                    return left;
                }
                
                if (nums[right] == target)
                {
                    return right;
                }
            }

            return notFoundIndex;
        }
    }
}