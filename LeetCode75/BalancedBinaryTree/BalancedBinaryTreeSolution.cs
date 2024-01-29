using System;
using LeetCode75.InvertBinaryTree;

namespace LeetCode75.BalancedBinaryTree;

/// <summary>
/// https://leetcode.com/problems/balanced-binary-tree/
/// </summary>
public static class BalancedBinaryTreeSolution
{
    public static void Run()
    {
        int[] list1 = new[]
        {
            3,9,20,15,7
        };//Enumerable.Range(1, 100).Select(x => new Random().Next(1, 100)).ToArray();
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
        
        Console.WriteLine($"Is balanced: {IsBalanced(node)}");
    }
    
    public static bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        var leftHeight = Height(root.left);
        var rightHeight = Height(root.right);

        if(Math.Abs(leftHeight - rightHeight) > 1)
            return false;
        
        return IsBalanced(root.left) && IsBalanced(root.right);
    }
    
    private static int Height(TreeNode root)
    {
         if (root == null)
         {
             return 0;
         }

         return 1 + Math.Max(Height(root.left), Height(root.right));
    }

    /// <summary>
    /// Вывод КЛП отсортированный список
    /// </summary>
    /// <param name="node"></param>
    public static void Print(TreeNode node, string space = "")
    {
        if (node == null)
            return;

        Print(node.left, (space + "-"));
        Console.WriteLine(space + " " + node.val + " ");
        Print(node.right, (space + "-"));
    }

    public static void Fill(ref TreeNode root, int value)
    {
        var newNode = new TreeNode(value);

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            var current = root;

            while (true)
            {
                var parent = current;

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