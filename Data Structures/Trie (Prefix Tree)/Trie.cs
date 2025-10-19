public class Trie
{
    private class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsEndOfWord;
    }

    private readonly TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        var node = root;
        foreach (char ch in word)
        {
            int index = ch - 'a';
            if (node.Children[index] == null)
                node.Children[index] = new TrieNode();
            node = node.Children[index];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = root;
        foreach (char ch in word)
        {
            int index = ch - 'a';
            if (node.Children[index] == null)
                return false;
            node = node.Children[index];
        }
        return node.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var node = root;
        foreach (char ch in prefix)
        {
            int index = ch - 'a';
            if (node.Children[index] == null)
                return false;
            node = node.Children[index];
        }
        return true;
    }
}