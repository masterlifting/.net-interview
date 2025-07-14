namespace AlghorithmStrutures;

public sealed class Trie
{
  private Node _root = new('\0');

  public void Add(string word)
  {
    if (string.IsNullOrEmpty(word))
      throw new ArgumentException("Word cannot be null or empty.", nameof(word));

    static void AddRecursivelly(ref Node node, string word)
    {
      if (string.IsNullOrEmpty(word))
      {
        node.IsComplete = true;
        return;
      }
      else
      {
        var firstChar = word[0];

        if (node.Children.TryGetValue(firstChar, out var child))
        {
          AddRecursivelly(ref child, word[1..]);
        }
        else
        {
          child = new Node(firstChar);
          node.Children[firstChar] = child;
          AddRecursivelly(ref child, word[1..]);
        }
      }
    }

    AddRecursivelly(ref _root, word);
  }

  private Node? GetNode(string word)
  {
    static Node? GetNodeRecursively(Node node, string word)
    {
      if (string.IsNullOrEmpty(word))
        return node;

      var firstChar = word[0];

      if (node.Children.TryGetValue(firstChar, out var child))
      {
        return GetNodeRecursively(child, word[1..]);
      }
      else
      {
        return null;
      }
    }

    return GetNodeRecursively(_root, word);
  }

  public bool Contains(string word)
  {
    static bool ContainsRecursively(Node node, string w)
    {
      if (string.IsNullOrEmpty(w))
      {
        return node.IsComplete;
      }

      var firstChar = w[0];

      if (node.Children.TryGetValue(firstChar, out var child))
      {
        return ContainsRecursively(child, w[1..]);
      }
      else
      {
        return false;
      }
    }

    return ContainsRecursively(_root, word);
  }

  public IEnumerable<string> Search(string prefix)
  {
    if (string.IsNullOrEmpty(prefix))
      throw new ArgumentException("Prefix cannot be null or empty.", nameof(prefix));

    var node = GetNode(prefix);

    if (node is null)
      return [];

    static void SearchRecursively(Node node, string word, in List<string> results)
    {
      if(node.IsComplete)
      {
        results.Add(word);
      }

      foreach (var (c, child) in node.Children)
      {
        SearchRecursively(child, word + c, results);
      }
    }

    var results = new List<string>();

    SearchRecursively(node, prefix, results);

    return results;
  }

  public sealed class Node(char value)
  {
    public char Value => value;
    public bool IsComplete { get; set; }
    public Dictionary<char, Node> Children { get; set; } = new();
  }
}