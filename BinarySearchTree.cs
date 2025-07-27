namespace Algorithm;

public sealed class BinarySearchTree<T> where T : IComparable<T>
{
  private Node? _root;

  public int Count { get; private set; }

  static Node GetMinRecursively(Node node)
  {
    if (node.Left is null)
      return node;
    else
      return GetMinRecursively(node.Left);
  }

  static Node GetMaxRecursively(Node node)
  {
    if (node.Right is null)
      return node;
    else
      return GetMaxRecursively(node.Right);
  }

  public T GetMin()
  {
    if (_root is null)
      throw new InvalidOperationException("The tree is empty.");

    return GetMinRecursively(_root).Value;
  }

  public T GetMax()
  {
    if (_root is null)
      throw new InvalidOperationException("The tree is empty.");

    return GetMaxRecursively(_root).Value;
  }

  public bool Contains(T value)
  {
    if (_root is null)
      return false;

    static bool ContainsRecursively(Node node, T value)
    {
      if (node.Value.Equals(value))
        return true;

      if (value.CompareTo(node.Value) < 0)
      {
        if (node.Left is null)
          return false;

        return ContainsRecursively(node.Left, value);
      }
      else
      {
        if (node.Right is null)
          return false;

        return ContainsRecursively(node.Right, value);
      }
    }

    return ContainsRecursively(_root, value);
  }

  public void Add(T value)
  {
    if (_root is null)
    {
      _root = new Node(value);
      Count++;
      return;
    }
    else
    {
      static void AddRecursively(Node node, T value, ref int count)
      {
        if (node.Value.Equals(value))
          return;

        if (value.CompareTo(node.Value) < 0)
        {
          if (node.Left is null)
          {
            node.Left = new Node(value);
            count++;
          }
          else
          {
            AddRecursively(node.Left, value, ref count);
          }
        }
        else
        {
          if (node.Right is null)
          {
            node.Right = new Node(value);
            count++;
          }
          else
          {
            AddRecursively(node.Right, value, ref count);
          }
        }
      }

      int count = Count;
      AddRecursively(_root, value, ref count);
      Count = count;
    }
  }

  public bool Remove(T value)
  {
    if (_root is null)
      return false;

    static bool RemoveRecursively(ref Node? node, T value)
    {
      if (node is null)
        return false;

      if (value.Equals(node.Value))
      {
        if (node.Left is null && node.Right is null)
        {
          node = null;
          return true;
        }
        else if (node.Left is not null && node.Right is null)
        {
          node = node.Left;
          return true;
        }
        else if (node.Right is not null && node.Left is null)
        {
          node = node.Right;
          return true;
        }
        else
        {
          var minNode = GetMinRecursively(node.Right!);

          var rightNode = node.Right;
          RemoveRecursively(ref rightNode, minNode.Value);

          node = new Node(minNode.Value)
          {
            Left = node.Left,
            Right = rightNode
          };
          return true;
        }
      }
      else if (value.CompareTo(node.Value) < 0)
      {
        if (node.Left is null)
          return false;

        var leftNode = node.Left;
        var isDeleted = RemoveRecursively(ref leftNode, value);

        if (isDeleted)
        {
          node.Left = leftNode;
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        if (node.Right is null)
          return false;

        var rightNode = node.Right;

        var isDeleted = RemoveRecursively(ref rightNode, value);
        if (isDeleted)
        {
          node.Right = rightNode;
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    if (RemoveRecursively(ref _root, value))
    {
      Count--;
      return true;
    }

    return false;
  }

  public sealed class Node(T value)
  {
    public T Value => value;
    public Node? Left { get; set; }
    public Node? Right { get; set; }
  }
}