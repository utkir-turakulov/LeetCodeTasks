using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LeetCode75.InvertBinaryTree
{
    public static class InvertBinaryTreeSolution
    {
        /// <summary>
        /// Recursive invert tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            (root.left, root.right) = (root.right, root.left);

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        public static void Run()
        {
            var list1 = Enumerable.Range(1, 100).Select(x => new Random().Next(1, 100)).ToArray();
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
            var invertedTree = InvertTree(node);
            
            Print(invertedTree);
        }

        /// <summary>
        /// Вывод КЛП отсортированный список
        /// </summary>
        /// <param name="node"></param>
        public static void Print(TreeNode node, string space = "-")
        {
            if(node == null)
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