using System.Collections.Generic;

public class KmpStringMatcher
{
    public List<int> Search(string text, string pattern)
    {
        var result = new List<int>();
        if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(text) || pattern.Length > text.Length)
        {
            return result;
        }

        int[] prefixTable = ComputePrefixTable(pattern);
        int j = 0; // index for pattern

        for (int i = 0; i < text.Length; i++)
        {
            while (j > 0 && text[i] != pattern[j])
            {
                j = prefixTable[j - 1];
            }

            if (text[i] == pattern[j])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                result.Add(i - j + 1);
                j = prefixTable[j - 1];
            }
        }

        return result;
    }

    private int[] ComputePrefixTable(string pattern)
    {
        int[] prefixTable = new int[pattern.Length];
        int length = 0; // length of the previous longest prefix suffix
        prefixTable[0] = 0;

        for (int i = 1; i < pattern.Length; i++)
        {
            while (length > 0 && pattern[i] != pattern[length])
            {
                length = prefixTable[length - 1];
            }

            if (pattern[i] == pattern[length])
            {
                length++;
            }

            prefixTable[i] = length;
        }

        return prefixTable;
    }
}