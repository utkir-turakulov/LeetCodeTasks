using System;
using System.Diagnostics;
using LeetCode75.InvertBinaryTree;

namespace LeetCode75.LowestCommonAncestor;

public class LowestCommonAncestorSolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }

        var startRoot = root;

        var height1 = GetNodeDepth(startRoot, p);
        var height2 = GetNodeDepth(startRoot, q);

        while (height1 != height2)
        {
            if (height1 > height2)
            {
                p = GetNodeRoot(root, p);
                height1 -= 1;
            }
            else
            {
                q = GetNodeRoot(root, q);
                height2 -= 1;
            }
        }

        while (p?.val != q?.val)
        {
            p = GetNodeRoot(root, p);
            q = GetNodeRoot(root, q);
        }

        return p;
    }

    /// <summary>
    /// Better solution (Memory O(n)  Complexity O(1))
    /// </summary>
    /// <param name="root"></param>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) {
            return null;
        } else if (p.val < root.val && q.val < root.val) { // if current root value is greater than both p and q value that means root is in left of current root
            return LowestCommonAncestor2(root.left, p, q); 
        } else if (p.val > root.val && q.val > root.val) { // if current root value is lesser than both p and q value that means root is in right of current root
            return LowestCommonAncestor2(root.right, p, q);
        } else {
            return root; // if root value is between both left and right of the root then we got the least common ancestor
        }
    }
    
    public int GetNodeDepth(TreeNode node, TreeNode p)
    {
        int depth = 0;
        
        while (node?.val != null)
        {
            if (node.val == p.val)
            {
                return depth;
            }

            depth++;
            node = node.val >= p.val ? node.left : node.right;
        }

        return depth;
    }

    private TreeNode _root;
    
    public TreeNode GetNodeRoot(TreeNode node, TreeNode p)
    {
        if (node == null)
        {
            return null;
        }

        if (node?.left?.val == p.val || node?.right?.val == p.val)
        {
            _root = node;
        }
        
        GetNodeRoot(node?.left, p);
        GetNodeRoot(node?.right, p);

        return _root;
    }

    /// <summary>
    /// Вывод КЛП отсортированный список
    /// </summary>
    /// <param name="node"></param>
    public void Print(TreeNode node, string space = "-")
    {
        if (node == null)
            return;

        Print(node.left, (space + "-"));
        Console.WriteLine(space + " " + node.val + " ");
        Print(node.right, (space + "-"));
    }

    public void Fill(ref TreeNode root, int value)
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
    
    public void Run()
    {
        var list1 = new[]
        {
            6,2,8,0,4,7,9,3,5
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

        var nodeRoot = GetNodeRoot(node, new TreeNode(5));
        
        Console.WriteLine(nodeRoot.val);

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var lowest = LowestCommonAncestor(node, new TreeNode(2), new TreeNode(8));
        
        Console.WriteLine($"Ancestor1: {lowest.val}, Elapsed time: {stopWatch.Elapsed}");
        
        stopWatch.Restart();
        var lowest2 = LowestCommonAncestor2(node, new TreeNode(2), new TreeNode(8));
        
        Console.WriteLine($"Ancestor2: {lowest2.val}, Elapsed time: {stopWatch.Elapsed}");
    }
}