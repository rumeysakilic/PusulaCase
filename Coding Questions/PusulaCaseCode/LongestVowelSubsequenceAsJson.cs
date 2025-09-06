using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class LongestVowelSubsequenceAsJson
{
  private static readonly HashSet<char> Vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

    public static string FindVowel(List<string> words)
    {
        if (words == null || words.Count == 0)
            return "[]";

        var results = new List<object>();

        foreach (var word in words)
        {
            string longestSeq = "";
            string currentSeq = "";

            foreach (var ch in word.ToLower())
            {
                if (Vowels.Contains(ch))
                {
                    currentSeq += ch;
                    if (currentSeq.Length > longestSeq.Length)
                        longestSeq = currentSeq;
                }
                else
                {
                    currentSeq = "";
                }
            }

            results.Add(new
            {
                word = word,
                sequence = longestSeq,
                length = longestSeq.Length
            });
        }

        return JsonSerializer.Serialize(results);
    }        
}
