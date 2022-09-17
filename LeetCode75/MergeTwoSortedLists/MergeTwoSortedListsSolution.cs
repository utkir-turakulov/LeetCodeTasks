using System;
using System.Linq;

namespace LeetCode75.MergeTwoSortedLists
{
    //https://leetcode.com/problems/merge-two-sorted-lists/
    public class MergeTwoSortedListsSolution
    {
        /// <summary>
        /// Обычное слияение списков
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode(0);;
            ListNode current = head;

            if (list1 == null)
            {
                return list2;
            }

            if (list2 == null)
            {
                return list1;
            }
            
            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    current.next = list1;
                    current = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    current = list2;
                    list2 = list2.next;
                }
            }

            current.next = list1 ?? list2;

            return head.next;
        }

        private static ListNode FillList(ListNode listNode, int val)
        {
            var next = new ListNode(val);
            listNode.next = next;
        
            return next;
        }

        private static void Print(ListNode listNode)
        {
            if (listNode == null)
            {
                Console.WriteLine("Linked list is empty");
            }

            var head = listNode;

            while (head != null)
            {
                Console.Write(head.val + ", ");
                head = head.next;
            }
        }
        
        public static void Run()
        {
            var list1 = Enumerable.Range(1, 5).Select(x => new Random().Next(1,15)).ToArray();
            var list2 = Enumerable.Range(1, 5).Select(x => new Random().Next(1, 15)).ToArray();

            var listNode1 = new ListNode(list1[0]);
            var listNode2 = new ListNode(list2[0]);

            var head = listNode1;
            for (int i =1; i< list1.Count(); i++)
            {
                head = FillList(head, list1[i]);
            }
            
            head = listNode2;
            for (int i =1; i< list2.Count(); i++)
            {
                head = FillList(head, list2[i]);
            }

            Console.Write("List1 :");
            Print(listNode1);
            
            Console.WriteLine();
            Console.Write("List1 :");
            Print(listNode2);

            var sort = MergeTwoLists(listNode1, listNode2);
            Console.WriteLine();
            Console.Write("Sorted merged list :");
            Print(sort);
        }
    }
}