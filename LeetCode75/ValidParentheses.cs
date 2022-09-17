using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LeetCode75
{
    public class ValidParentheses
    {
        // test data
        /*Console.WriteLine("false " + ValidParentheses.IsValid("(["));// false
             Console.WriteLine("false " + ValidParentheses.IsValid("([(("));// false
             Console.WriteLine("false " +ValidParentheses.IsValid("))"));// false
             Console.WriteLine("false " +ValidParentheses.IsValid(")))"));// false
             Console.WriteLine("true " +ValidParentheses.IsValid("()")); // true
             Console.WriteLine("true " +ValidParentheses.IsValid("[()]")); //true
             Console.WriteLine("false " +ValidParentheses.IsValid("[(})]")); //false
             Console.WriteLine("false " +ValidParentheses.IsValid("[(})]")); //false
             Console.WriteLine("false " +ValidParentheses.IsValid("([]){")); //false*/

        
        public static bool IsValid(string s) {
            Stack<char> brackets = new Stack<char>();

            if (s.Length is 1 or 0)
            {
                return false;
            }
            
            for (int i = 0; i < s.Length; i++)
            {
                if (brackets.TryPeek(out var bracket) && IsOpenBracket(bracket) && IsOpenBracket(s[i]))
                {
                    brackets.Push(s[i]);
                }

                if (brackets.TryPeek(out bracket) && IsOpenBracket(bracket) && IsClosingBracket(s[i]) && GetClosingBracket(bracket) == s[i])
                {
                    brackets.Pop();
                    continue;
                }

                if (brackets.TryPeek(out bracket) && IsOpenBracket(bracket) && IsClosingBracket(s[i]) &&
                    GetClosingBracket(bracket) != s[i])
                {
                    return false;
                }

                if (!brackets.TryPeek(out bracket))
                {
                    brackets.Push(s[i]);
                }
            }

            return brackets.Count == 0;
        }

        public static char? GetClosingBracket (char c){
            switch(c)
            {
                case '{': 
                    return '}';

                case '[': 
                    return ']';

                case '(': 
                    return ')';

            }

            return null;
        }
        
        public static bool IsOpenBracket(char c)
        {
            switch(c)
            {
                case '{': 
                    return true;

                case '[': 
                    return true;

                case '(': 
                    return true;
            }

            return false;
        }
        
        public static bool IsClosingBracket(char c)
        {
            switch(c)
            {
                case '}': 
                    return true;

                case ']': 
                    return true;

                case ')': 
                    return true;
            }

            return false;
        }
    }
}