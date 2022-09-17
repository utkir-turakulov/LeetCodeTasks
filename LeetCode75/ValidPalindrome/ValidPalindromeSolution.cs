using System;
using System.Linq;

namespace LeetCode75.ValidPalindrome
{
    //https://leetcode.com/problems/valid-palindrome/
    public static class ValidPalindromeSolution
    {
        public static bool IsPalindrome(string s)
        {
            var str = string.Concat(s.Where(char.IsLetterOrDigit)).ToLower();
            
            //Console.WriteLine(s);

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != str[^(i+1)]) // ^i индексатор с конца
                {
                    return false;
                }
            }

            return true;
        }

        public static void Run()
        {
            var str = "A man, a plan, a canal: Panama";
            var isValid = IsPalindrome(str);
            
            Console.WriteLine($"[{str}] should be a valid palindrome {isValid}");
        }
    }
}