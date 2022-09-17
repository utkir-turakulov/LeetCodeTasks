using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode75.InvertBinaryTree;

namespace LeetCode75.SumOfLeftLeaves
{
    public static class SumOfLeftLeavesSolution
    {
        public static void Run()
        {
            //var list1 = Enumerable.Range(1, 4).Select(x => new Random().Next(1, 5)).ToArray();
            var list1 = new[]
            {
                1,2,3,4,5
            };
            
            TreeNode node = null;

            Console.Write("List: ");
            for (int i = 0; i < list1.Length; i++)
            {
                Console.Write(list1[i] + " ");
            }

            Console.WriteLine();

            Console.Write("Tree: ");
            for (int i = 0; i < list1.Length; i++)
            {
                Fill(ref node, list1[i]);
            }

            Print(node);
            Console.WriteLine();

            Console.Write("Inverted Tree: ");
            var sum = SumOfLeftLeaves(node);

            Console.WriteLine(sum);
        }

        public static int SumOfLeftLeaves(TreeNode root)
        {
            int val = 0;

            
            //return CountTree(root, val);
            helper(root);

            return sum;
        }

        private static int sum = 0;
        public static void helper(TreeNode root){
            if(root != null){
                if(root.left != null && root.left.left == null && root.left.right == null){
                    sum = sum + root.left.val;
                }
                helper(root.left);
                helper(root.right);
            }
        }

        public static int CountTree(TreeNode root, int val)
        {
            if (root == null)
            {
                return 0;
            }

            /*if (root.left is { left: null, right: null })
            {
                val += (root.left?.val ?? 0);
            }

            CountTree(root.left, val);
            CountTree(root.right, val);*/

            val += (root.left?.val ?? 0) +
                   CountTree(root.left, val) + CountTree(root.right, val);

            return val;
        }

        /// <summary>
        /// Вывод КЛП отсортированный список
        /// </summary>
        /// <param name="node"></param>
        public static void Print(TreeNode node, string space = "-")
        {
            if (node == null)
                return;

            Print(node.left, (space + "-"));
            Console.WriteLine(space + " " + node.val + " ");
            Print(node.right, (space + "-"));
        }

        public static void Fill(ref TreeNode root, int value)
        {
            TreeNode newNode = new TreeNode(value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    parent = current;

                    if (value < parent.val)
                    {
                        current = current.left;

                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
    }
}