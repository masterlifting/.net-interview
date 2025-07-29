namespace Algorithm;

public sealed class Graph<T> where T : IComparable<T>
{
  private readonly List<Vertex> _vertices = [];

  public Vertex AddVertex(T value)
  {
    var fod = _vertices.FirstOrDefault(v => v.Value.Equals(value));

    if (fod is not null)
      return fod;

    var vertex = new Vertex(value);
    _vertices.Add(vertex);
    return vertex;
  }

  public IEnumerable<Vertex> GetConnected_DFS()
  {
    static IEnumerable<Vertex> GetConnectedRecursively(Vertex vertex, HashSet<Vertex> visited)
    {
      visited.Add(vertex);

      yield return vertex;

      foreach (var v in vertex.Vertices)
      {
        if (!visited.Contains(v))
        {
          foreach (var connected in GetConnectedRecursively(v, visited))
          {
            yield return connected;
          }
        }
      }
    }

    var visited = new HashSet<Vertex>();

    foreach (var vertex in _vertices)
    {
      if (!visited.Contains(vertex))
      {
        foreach (var connected in GetConnectedRecursively(vertex, visited))
        {
          yield return connected;
        }
      }
    }
  }

  public IEnumerable<Vertex> GetConnected_BFS()
  {
    var visited = new HashSet<Vertex>();
    var queue = new Queue<Vertex>();

    foreach (var vertex in _vertices)
    {
      if (!visited.Contains(vertex))
      {
        queue.Enqueue(vertex);
        visited.Add(vertex);

        while (queue.Count > 0)
        {
          var current = queue.Dequeue();
          yield return current;

          foreach (var connected in current.Vertices)
          {
            if (!visited.Contains(connected))
            {
              visited.Add(connected);
              queue.Enqueue(connected);
            }
          }
        }
      }
    }
  }

  public sealed class Vertex(T value)
  {
    public T Value => value;
    public IList<Vertex> Vertices { get; } = [];

    public void Connect(Vertex vertex)
    {
      if (Vertices.Any(v => v.Value.Equals(vertex.Value)))
        return;

      Vertices.Add(vertex);

      if (!vertex.Vertices.Any(v => v.Value.Equals(Value)))
        vertex.Vertices.Add(this);
    }

    public IEnumerable<Vertex> GetConnected_DFS()
    {
      static IEnumerable<Vertex> GetConnectedRecursively(Vertex vertex, HashSet<Vertex> visited)
      {
        visited.Add(vertex);

        yield return vertex;

        foreach (var v in vertex.Vertices)
        {
          if (!visited.Contains(v))
          {
            foreach (var connected in GetConnectedRecursively(v, visited))
            {
              yield return connected;
            }
          }
        }
      }

      var visited = new HashSet<Vertex>();

      return GetConnectedRecursively(this, visited);
    }

    public IEnumerable<Vertex> GetConnected_BFS()
    {
      var queue = new Queue<Vertex>();
      queue.Enqueue(this);

      var visited = new HashSet<Vertex>
      {
        this
      };

      while (queue.Count > 0)
      {
        var current = queue.Dequeue();

        yield return current;

        foreach (var vertex in current.Vertices)
          if (visited.Add(vertex))
            queue.Enqueue(vertex);
      }
    }
  }
}