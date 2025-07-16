namespace Algorithm;

public sealed class SinglyLinkedList<T>
{
  private Node? _head, _tail;
  public int Count { get; private set; }

  public T? Get(int index)
  {
    if(index < 0 || index >= Count)
      return default;

    if (_head is null)
      return default;

    var current = _head;

    for (var i = 0; i < index; i++)
    {
      current = current!.Next;
    }

    return current!.Value;
  }

  public void Add(T value)
  {
    var node = new Node(value, _head);

    _head = node;
    _tail ??= _head;

    Count++;
  }

  public bool Contains(T value)
  {
    var current = _head;

    while (current is not null)
    {
      if (current.Value!.Equals(value))
        return true;

      current = current.Next;
    }
    
    return false;
  }

  public bool Remove(T value)
  {
    if(_head is null)
      return false;

    var current = _head;
    var index = 0;

    if(_head.Value!.Equals(value))
    {
      _head = _head.Next;
      Count--;
      return true;
    }

    while (current is not null)
    {
      if(current.Value!.Equals(value))
        break;

      current = current.Next;
      index++;
    }

    if (current is null)
      return false;

    // we should stop at the node before the one we want to remove
    for (var i = 0; i < index - 1; i++)
      _head = _head!.Next;

    _head!.Next = _head?.Next?.Next;
    Count--;

    return true;
  }

  public void Reverse()
  {
    if (_head?.Next is null)
      return;
    
    _tail = new Node(_head.Value, null);

    Node? reversed = null;

    while (_head is not null)
    {
      var headNext = _head.Next;
      _head.Next = reversed;
      reversed = _head;
      _head = headNext;
    }

    _head = reversed;
  }

  private sealed class Node(T value, Node? next)
  {
    public T Value { get; } = value;
    public Node? Next { get; set; } = next;
  }
}