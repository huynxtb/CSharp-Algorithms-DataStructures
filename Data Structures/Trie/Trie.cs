using System.Collections.Generic;

public class Trie
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
        public bool IsWordEnd { get; set; }
    }

    private readonly TrieNode _root = new TrieNode();

    /// <summary>
    /// Inserts a word into the Trie.
    /// </summary>
    /// <param name="word">The lowercase English word to insert.</param>
    public void Insert(string word)
    {
        var node = _root;
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
            {
                node.Children[ch] = new TrieNode();
            }
            node = node.Children[ch];
        }
        node.IsWordEnd = true;
    }

    /// <summary>
    /// Determines if a full word exists in the Trie.
    /// </summary>
    /// <param name="word">The word to search.</param>
    /// <returns>True if the word exists, otherwise false.</returns>
    public bool Search(string word)
    {
        var node = _root;
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
                return false;
            node = node.Children[ch];
        }
        return node.IsWordEnd;
    }

    /// <summary>
    /// Checks if there exists any word in the Trie that starts with the given prefix.
    /// </summary>
    /// <param name="prefix">The prefix to check.</param>
    /// <returns>True if any word starts with the prefix, otherwise false.</returns>
    public bool StartsWith(string prefix)
    {
        var node = _root;
        foreach (var ch in prefix)
        {
            if (!node.Children.ContainsKey(ch))
                return false;
            node = node.Children[ch];
        }
        return true;
    }
}