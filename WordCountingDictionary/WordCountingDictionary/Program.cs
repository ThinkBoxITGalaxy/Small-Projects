using System;
using System.Collections.Generic;
public class Program
{
    private static readonly string Text = "Mary had a little lamb " + "little Lamb, little Lamb, " + "Mary had a Little lamb, " + "whose fleece were white as snow.";
    public static void Main()
    {
        IDictionary<String, int> wordOccurrenceMap = GetWordOccurrenceMap(Text);
        PrintWordOccurrenceCount(wordOccurrenceMap);
        Console.Read();
    }
    private static IDictionary<string, int> GetWordOccurrenceMap(string text)
    {
        string[] tokens = text.Split(' ', '.', ',', '-', '?', '!');
        IDictionary<string, int> words = new SortedDictionary<string, int>();
        foreach (string word in tokens)
        {
            if (!string.IsNullOrEmpty(word.Trim()))
            {
                int count;
                if (!words.TryGetValue(word, out count))
                {
                    count = 0;
                }
                words[word] = count + 1;
            }
        }
        return words;
    }
    private static void PrintWordOccurrenceCount(IDictionary<string, int> wordOccurenceMap)
    {
        foreach (var wordEntry in wordOccurenceMap)
        {
            Console.WriteLine("Word '{0}' occurs {1} time(s) in the text", wordEntry.Key, wordEntry.Value);
        }
    }
}