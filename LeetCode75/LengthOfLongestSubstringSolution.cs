using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode75
{
    public class LengthOfLongestSubstringSolution
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        public static int LengthOfLongestSubstring(string s) {
            Dictionary<char, int> table = new Dictionary<char, int> ();
            int longestSubstring =0;
            
            int i = 0;
            
            for(int j=0; j< s.Length; j++)
            {
                if (table.ContainsKey(s[j]))
                {
                    i = Math.Max(table[s[j]], i);
                }

                longestSubstring = Math.Max(longestSubstring, j - i + 1);
                table[s[j]] = j + 1;
            }

            return longestSubstring;
        }
    }
}