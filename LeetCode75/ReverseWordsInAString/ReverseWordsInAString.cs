using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode75.ReverseWordsInAString;

public static class ReverseWordsInAString
{
    public static void Run()
    {
        Console.WriteLine(ReverseWords("the sky is blue"));
        Console.WriteLine(ReverseWords("  hello world  "));
        Console.WriteLine(ReverseWords("a good   example"));
    }


    public static string ReverseWords(string s)
    {
        s = s.Trim();

        var array = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return string.Join(" ", array.Reverse());
    }
}