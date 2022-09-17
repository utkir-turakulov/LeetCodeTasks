using System;

namespace LeetCode75.ValidAnagram
{
    public static class ValidAnagramSolution
    {
        public static void Run()
        {
            string s = "anagram";
            string t = "nagaram";
            
            Console.WriteLine($"Word {s}");
            Console.WriteLine($"Anagram {t}");
            Console.WriteLine($"Result {IsAnagram(s, t)}");
        }
        
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            
            // так как в задаче указаны только английские символы считаем что за 26 символов не выйдем
            var letterCount = new int[26];
            var anagramLetterCount = new int[26];
            const char a = 'a';

            foreach (var letter in s)
            {
                letterCount[letter - a] += 1; // берем символ и от него отнимаем символ a и считаем повторения
            }
            
            foreach (var letter in t)
            {
                anagramLetterCount[letter - a] += 1; // тут так же 
            }

            for (int i = 0; i < 26; i++)
            {
                if (letterCount[i] != anagramLetterCount[i]) // тут проходим по массивам и сравниваем
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}