namespace DataStructure;

public sealed class Trie
{
    private readonly Node root = new('\0');

    public void Add(string word)
    {
        if (word.Length == 0)
            return;

        var current = root;

        foreach (var c in word)
        {
            if (!current.Edges.ContainsKey(c))
                current.Edges[c] = new(c);

            current = current.Edges[c];
        }

        current.IsWord = true;
    }

    public bool Contains(string word)
    {
        var current = root;

        foreach (var c in word)
        {
            if (!current.Edges.TryGetValue(c, out var value))
                return false;

            current = value;
        }

        return current.IsWord;
    }

    private IEnumerable<string> GetWords(Node node, string prefix)
    {
        if (node.IsWord)
            yield return prefix;

        foreach (var edge in node.Edges)
        {
            foreach (var word in GetWords(edge.Value, prefix + edge.Key))
            {
                yield return word;
            }
        }
    }

    public IEnumerable<string> Search(string prefix)
    {
        var current = root;

        foreach (var c in prefix)
        {
            if (!current.Edges.TryGetValue(c, out var value))
                yield break;

            current = value;
        }

        foreach (var word in GetWords(current, prefix))
        {
            yield return word;
        }
    }

    public sealed class Node(char value)
    {
        public char Value => value;
        public bool IsWord { get; set; }
        public Dictionary<char, Node> Edges { get; set; } = [];
    }
}
