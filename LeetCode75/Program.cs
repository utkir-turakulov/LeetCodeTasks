using System;
using LeetCode75.CanPlaceFlowers;
using LeetCode75.LowestCommonAncestor;
using LeetCode75.ValidPalindrome;

namespace LeetCode75
{
    class Program
    {
        static void Main(string[] args)
        {
            //InvertBinaryTree.InvertBinaryTreeSolution.Run();

            var result = CanPlaceFlowersSolution.CanPlaceFlowers(new[] {0,0,0,0,0,1,0,0}, 2);
            
            Console.Write(result);
        }

        private static long Get(long age = 0, int people = 2)
        {
            if (age == 400)
            {
                return people;
            }

            age += 20;

            return Get(age, people * 2);
        }
    }
}