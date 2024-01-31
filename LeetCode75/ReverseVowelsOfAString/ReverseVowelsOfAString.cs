using System.Collections.Generic;
using System.Linq;

namespace LeetCode75.ReverseVowelsOfAString;

public static class ReverseVowelsOfAString
{
    public static string ReverseVowels(string s)
    {
        var set = new HashSet<char>()
        {
            'a',
            'e',
            'i',
            'o',
            'u',
            'A',
            'E',
            'I',
            'O',
            'U',
        };

        var arr = s.ToCharArray();

        var leftIndex = 0;
        var rightIndex = s.Length - 1;
        
        while(rightIndex > leftIndex )
        {
            var leftSymbol = s[leftIndex];
            var rightSymbol = s[rightIndex];
            
            if (!set.Contains(leftSymbol))
            {
                leftIndex++;
            }
            
            if (!set.Contains(rightSymbol))
            {
                rightIndex--;
            }

            if (set.Contains(rightSymbol) && set.Contains(leftSymbol))
            {
                (arr[leftIndex], arr[rightIndex]) = (arr[rightIndex], arr[leftIndex]);
                
                leftIndex++;
                rightIndex--;
            }
        }

        return new string(arr);
    }
}
