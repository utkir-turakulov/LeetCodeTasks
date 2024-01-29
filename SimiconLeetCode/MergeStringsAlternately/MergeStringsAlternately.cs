namespace SimiconLeetCode.MergeStringsAlternately;

public static class MergeStringsAlternately
{
    public static string MergeAlternately(string word1, string word2) {

        if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
        {
            return null;
        }
        
        if (string.IsNullOrEmpty(word1))
        {
            return word2;
        }
        
        if (string.IsNullOrEmpty(word2))
        {
            return word2;
        }
        
        var result = string.Empty;

        var maxLength = Math.Max(word1.Length, word2.Length);

        for (int i = 0; i < maxLength; i++)
        {
            if (word1.Length > i)
            {
                result += word1[i];
            }

            if (word2.Length > i)
            {
                result += word2[i];
            }
        }

        return result;
    }
}