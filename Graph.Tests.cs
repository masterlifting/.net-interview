using Xunit;

namespace AlghorithmStrutures.Tests;

public sealed class GraphTests
{
  [Fact]
  public void AddVertex_NewValue_AddsVertexToGraph()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("test");

    Assert.NotNull(vertex);
    Assert.Equal("test", vertex.Value);
  }

  [Fact]
  public void AddVertex_DuplicateValue_ReturnsSameVertex()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("test");
    var vertex2 = graph.AddVertex("test");

    Assert.Same(vertex1, vertex2);
    Assert.Equal("test", vertex1.Value);
  }

  [Fact]
  public void AddVertex_MultipleUniqueValues_CreatesMultipleVertices()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("first");
    var vertex2 = graph.AddVertex("second");
    var vertex3 = graph.AddVertex("third");

    Assert.NotSame(vertex1, vertex2);
    Assert.NotSame(vertex2, vertex3);
    Assert.Equal("first", vertex1.Value);
    Assert.Equal("second", vertex2.Value);
    Assert.Equal("third", vertex3.Value);
  }

  [Fact]
  public void Vertex_ConnectsVertices_CreatesBidirectionalConnection()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("first");
    var vertex2 = graph.AddVertex("second");
    
    vertex1.Connect(vertex2);
    
    Assert.Contains(vertex2, vertex1.Vertices);
    Assert.Contains(vertex1, vertex2.Vertices);
  }

  [Fact]
  public void Vertex_DuplicateConnections_AreHandledGracefully()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("first");
    var vertex2 = graph.AddVertex("second");
    
    vertex1.Connect(vertex2);
    vertex1.Connect(vertex2);
    
    Assert.Single(vertex1.Vertices);
    Assert.Single(vertex2.Vertices);
  }

  [Fact]
  public void GetConnected_DFS_ReturnsConnectedVertices()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");
    
    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    
    var connected = graph.GetConnected_DFS().ToList();
    
    Assert.Equal(3, connected.Count);
    Assert.Contains(vertex1, connected);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void GetConnected_BFS_ReturnsConnectedVertices()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");
    
    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    
    var connected = graph.GetConnected_BFS().ToList();
    
    Assert.Equal(3, connected.Count);
    Assert.Contains(vertex1, connected);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void VertexDFS_ReturnsConnectedComponents()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("center");
    var vertex2 = graph.AddVertex("A");
    var vertex3 = graph.AddVertex("B");
    
    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);
    
    var connected = vertex1.GetConnected_DFS().ToList();
    
    Assert.Equal(3, connected.Count);
    Assert.Contains(vertex1, connected);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void VertexBFS_ReturnsConnectedComponents()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("center");
    var vertex2 = graph.AddVertex("A");
    var vertex3 = graph.AddVertex("B");
    
    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);
    
    var connected = vertex1.GetConnected_BFS().ToList();
    
    Assert.Equal(3, connected.Count);
    Assert.Contains(vertex1, connected);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void ComplexGraph_BothTraversalMethodsReturnSameComponents()
  {
    var graph = new Graph<string>();
    
    var v1 = graph.AddVertex("Node1");
    var v2 = graph.AddVertex("Node2");
    var v3 = graph.AddVertex("Node3");
    
    v1.Connect(v2);
    v2.Connect(v3);
    
    var dfs = graph.GetConnected_DFS().ToList();
    var bfs = graph.GetConnected_BFS().ToList();
    
    Assert.Equal(3, dfs.Count);
    Assert.Equal(3, bfs.Count);
    Assert.All(dfs, vertex => Assert.Contains(vertex, bfs));
  }

  [Fact]
  public void Vertex_GetConnected_DFS_AvoidsCycles()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");

    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    vertex3.Connect(vertex1);

    var connected = vertex1.GetConnected_DFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void Vertex_GetConnected_BFS_AvoidsCycles()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");

    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    vertex3.Connect(vertex1);

    var connected = vertex1.GetConnected_BFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]);
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void Graph_BidirectionalConnections_WorkCorrectly()
  {
    var graph = new Graph<string>();
    var v1 = graph.AddVertex("A");
    var v2 = graph.AddVertex("B");

    v1.Connect(v2);

    Assert.Contains(v2, v1.Vertices);
    Assert.Contains(v1, v2.Vertices);

    var dfsFromV1 = v1.GetConnected_DFS().ToList();
    var dfsFromV2 = v2.GetConnected_DFS().ToList();

    Assert.Equal(2, dfsFromV1.Count);
    Assert.Contains(v2, dfsFromV1);

    Assert.Equal(2, dfsFromV2.Count);
    Assert.Contains(v1, dfsFromV2);
  }
}
