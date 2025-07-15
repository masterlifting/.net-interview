using Xunit;

namespace AlghorithmStrutures.Tests;

public sealed class GraphTests
{
  // ==== GRAPH ADDVERTEX TESTS ====

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
    Assert.Equal("test", vertex2.Value);
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
    Assert.NotSame(vertex1, vertex3);

    Assert.Equal("first", vertex1.Value);
    Assert.Equal("second", vertex2.Value);
    Assert.Equal("third", vertex3.Value);
  }

  [Fact]
  public void AddVertex_NullValue_HandlesCorrectly()
  {
    var graph = new Graph<string>();

    var vertex = graph.AddVertex(null!);

    Assert.NotNull(vertex);
    Assert.Null(vertex.Value);
  }

  [Fact]
  public void AddVertex_EmptyString_HandlesCorrectly()
  {
    var graph = new Graph<string>();

    var vertex = graph.AddVertex("");

    Assert.NotNull(vertex);
    Assert.Equal("", vertex.Value);
  }

  [Fact]
  public void AddVertex_IntegerValues_WorksCorrectly()
  {
    var graph = new Graph<int>();

    var vertex1 = graph.AddVertex(1);
    var vertex2 = graph.AddVertex(2);
    var vertex3 = graph.AddVertex(1); // Duplicate

    Assert.NotSame(vertex1, vertex2);
    Assert.Same(vertex1, vertex3);

    Assert.Equal(1, vertex1.Value);
    Assert.Equal(2, vertex2.Value);
    Assert.Equal(1, vertex3.Value);
  }

  // ==== GRAPH DFS TESTS ====

  [Fact]
  public void GetConnected_DFS_EmptyGraph_ReturnsEmpty()
  {
    var graph = new Graph<string>();

    var connected = graph.GetConnected_DFS().ToList();

    Assert.Empty(connected);
  }

  [Fact]
  public void GetConnected_DFS_SingleVertexWithoutConnections_ReturnsEmpty()
  {
    var graph = new Graph<string>();
    graph.AddVertex("test");

    var connected = graph.GetConnected_DFS().ToList();

    Assert.Empty(connected);
  }

  [Fact]
  public void GetConnected_DFS_ConnectedVertices_ReturnsAllConnected()
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
  public void GetConnected_DFS_DisconnectedComponents_ReturnsAll()
  {
    var graph = new Graph<string>();

    // First component
    var v1 = graph.AddVertex("A");
    var v2 = graph.AddVertex("B");
    v1.Connect(v2);

    // Second disconnected component
    var v3 = graph.AddVertex("C");
    var v4 = graph.AddVertex("D");
    v3.Connect(v4);

    // Isolated vertex
    var v5 = graph.AddVertex("E");

    var connected = graph.GetConnected_DFS().ToList();

    Assert.Equal(4, connected.Count); // Only connected vertices, not isolated
    Assert.Contains(v1, connected);
    Assert.Contains(v2, connected);
    Assert.Contains(v3, connected);
    Assert.Contains(v4, connected);
    Assert.DoesNotContain(v5, connected);
  }

  // ==== GRAPH BFS TESTS ====

  [Fact]
  public void GetConnected_BFS_EmptyGraph_ReturnsEmpty()
  {
    var graph = new Graph<string>();

    var connected = graph.GetConnected_BFS().ToList();

    Assert.Empty(connected);
  }

  [Fact]
  public void GetConnected_BFS_SingleVertexWithoutConnections_ReturnsSingleVertex()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("test");

    var connected = graph.GetConnected_BFS().ToList();

    Assert.Single(connected);
    Assert.Equal(vertex, connected[0]);
  }

  [Fact]
  public void GetConnected_BFS_ConnectedVertices_ReturnsAllInBFSOrder()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);

    var connected = graph.GetConnected_BFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // BFS starts with the first vertex
    // vertex2 and vertex3 should come after vertex1
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void GetConnected_BFS_DisconnectedComponents_ReturnsAllVertices()
  {
    var graph = new Graph<string>();

    // First component
    var v1 = graph.AddVertex("A");
    var v2 = graph.AddVertex("B");
    v1.Connect(v2);

    // Second disconnected component
    var v3 = graph.AddVertex("C");
    var v4 = graph.AddVertex("D");
    v3.Connect(v4);

    // Isolated vertex
    var v5 = graph.AddVertex("E");

    var connected = graph.GetConnected_BFS().ToList();

    Assert.Equal(5, connected.Count); // All vertices including isolated ones
    Assert.Contains(v1, connected);
    Assert.Contains(v2, connected);
    Assert.Contains(v3, connected);
    Assert.Contains(v4, connected);
    Assert.Contains(v5, connected);
  }

  // ==== VERTEX TESTS ====

  [Fact]
  public void Vertex_Constructor_SetsValueCorrectly()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("test");

    Assert.Equal("test", vertex.Value);
    Assert.Empty(vertex.Vertices);
  }

  [Fact]
  public void Vertex_Connect_CreatesConnection()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("first");
    var vertex2 = graph.AddVertex("second");

    vertex1.Connect(vertex2);

    Assert.Contains(vertex2, vertex1.Vertices);
    Assert.Contains(vertex1, vertex2.Vertices); // Bidirectional
  }

  [Fact]
  public void Vertex_Connect_DuplicateConnection_DoesNotAddTwice()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("first");
    var vertex2 = graph.AddVertex("second");

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex2); // Connect again

    Assert.Single(vertex1.Vertices);
    Assert.Single(vertex2.Vertices);
    Assert.Contains(vertex2, vertex1.Vertices);
    Assert.Contains(vertex1, vertex2.Vertices);
  }

  [Fact]
  public void Vertex_Connect_SelfConnection_HandlesCorrectly()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("self");

    vertex.Connect(vertex);

    // Should handle self-connection gracefully
    Assert.Contains(vertex, vertex.Vertices);
  }

  [Fact]
  public void Vertex_Connect_MultipleConnections_AllAdded()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("center");
    var vertex2 = graph.AddVertex("first");
    var vertex3 = graph.AddVertex("second");
    var vertex4 = graph.AddVertex("third");

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);
    vertex1.Connect(vertex4);

    Assert.Equal(3, vertex1.Vertices.Count);
    Assert.Contains(vertex2, vertex1.Vertices);
    Assert.Contains(vertex3, vertex1.Vertices);
    Assert.Contains(vertex4, vertex1.Vertices);

    // All should be bidirectionally connected
    Assert.Contains(vertex1, vertex2.Vertices);
    Assert.Contains(vertex1, vertex3.Vertices);
    Assert.Contains(vertex1, vertex4.Vertices);
  }

  [Fact]
  public void Vertex_Connect_DuplicateValueHandling_WorksCorrectly()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("B"); // Same value as vertex2

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3); // Should not create duplicate connection

    // vertex2 and vertex3 are the same instance due to duplicate value handling in AddVertex
    Assert.Same(vertex2, vertex3);
    Assert.Single(vertex1.Vertices);
    Assert.Contains(vertex2, vertex1.Vertices);
  }

  // ==== VERTEX DFS TESTS ====

  [Fact]
  public void Vertex_GetConnected_DFS_WithoutConnections_ReturnsSelf()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("isolated");

    var connected = vertex.GetConnected_DFS().ToList();

    // DFS from vertex returns self first
    Assert.Single(connected);
    Assert.Equal(vertex, connected[0]);
  }

  [Fact]
  public void Vertex_GetConnected_DFS_WithDirectConnections_ReturnsAllConnected()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("center");
    var vertex2 = graph.AddVertex("A");
    var vertex3 = graph.AddVertex("B");

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);

    var connected = vertex1.GetConnected_DFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // Self first
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void Vertex_GetConnected_DFS_WithChainConnections_ReturnsAllInChain()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("start");
    var vertex2 = graph.AddVertex("middle");
    var vertex3 = graph.AddVertex("end");

    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);

    var connected = vertex1.GetConnected_DFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // Self first
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void Vertex_GetConnected_DFS_AvoidsCycles()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");

    // Create a cycle: v1 -> v2 -> v3 -> v1
    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    vertex3.Connect(vertex1);

    var connected = vertex1.GetConnected_DFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // Self first
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  // ==== VERTEX BFS TESTS ====

  [Fact]
  public void Vertex_GetConnected_BFS_WithoutConnections_ReturnsSelf()
  {
    var graph = new Graph<string>();
    var vertex = graph.AddVertex("isolated");

    var connected = vertex.GetConnected_BFS().ToList();

    Assert.Single(connected);
    Assert.Equal(vertex, connected[0]);
  }

  [Fact]
  public void Vertex_GetConnected_BFS_WithDirectConnections_ReturnsInBFSOrder()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("center");
    var vertex2 = graph.AddVertex("A");
    var vertex3 = graph.AddVertex("B");

    vertex1.Connect(vertex2);
    vertex1.Connect(vertex3);

    var connected = vertex1.GetConnected_BFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // BFS returns self first
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  [Fact]
  public void Vertex_GetConnected_BFS_WithChainConnections_ReturnsAllInBFSOrder()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("start");
    var vertex2 = graph.AddVertex("middle");
    var vertex3 = graph.AddVertex("end");

    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);

    var connected = vertex1.GetConnected_BFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // BFS returns self first
    Assert.Equal(vertex2, connected[1]); // Direct connection comes next
    Assert.Equal(vertex3, connected[2]); // Indirect connection comes last
  }

  [Fact]
  public void Vertex_GetConnected_BFS_AvoidsCycles()
  {
    var graph = new Graph<string>();
    var vertex1 = graph.AddVertex("A");
    var vertex2 = graph.AddVertex("B");
    var vertex3 = graph.AddVertex("C");

    // Create a cycle: v1 -> v2 -> v3 -> v1
    vertex1.Connect(vertex2);
    vertex2.Connect(vertex3);
    vertex3.Connect(vertex1);

    var connected = vertex1.GetConnected_BFS().ToList();

    Assert.Equal(3, connected.Count);
    Assert.Equal(vertex1, connected[0]); // Self first
    Assert.Contains(vertex2, connected);
    Assert.Contains(vertex3, connected);
  }

  // ==== INTEGRATION TESTS ====

  [Fact]
  public void Graph_ComplexScenario_BothTraversalMethodsWork()
  {
    var graph = new Graph<string>();

    // Create a complex graph structure
    var v1 = graph.AddVertex("Node1");
    var v2 = graph.AddVertex("Node2");
    var v3 = graph.AddVertex("Node3");
    var v4 = graph.AddVertex("Node1"); // Duplicate value
    var v5 = graph.AddVertex("Node4");

    // Create connections
    v1.Connect(v2);
    v1.Connect(v3);
    v1.Connect(v5);

    // v1 and v4 should be the same vertex
    Assert.Same(v1, v4);

    // Test DFS traversal
    var connectedDFS = graph.GetConnected_DFS().ToList();
    Assert.Equal(4, connectedDFS.Count);

    // Test BFS traversal
    var connectedBFS = graph.GetConnected_BFS().ToList();
    Assert.Equal(4, connectedBFS.Count);

    // Both should contain the same vertices (different order is okay)
    Assert.Contains(v1, connectedDFS);
    Assert.Contains(v2, connectedDFS);
    Assert.Contains(v3, connectedDFS);
    Assert.Contains(v5, connectedDFS);

    Assert.Contains(v1, connectedBFS);
    Assert.Contains(v2, connectedBFS);
    Assert.Contains(v3, connectedBFS);
    Assert.Contains(v5, connectedBFS);
  }

  [Fact]
  public void Graph_LargeGraph_PerformanceTest()
  {
    var graph = new Graph<int>();
    const int nodeCount = 100;

    // Create many vertices
    var vertices = new List<Graph<int>.Vertex>();
    for (int i = 0; i < nodeCount; i++)
    {
      vertices.Add(graph.AddVertex(i));
    }

    // Connect the first vertex to all others (star pattern)
    for (int i = 1; i < nodeCount; i++)
    {
      vertices[0].Connect(vertices[i]);
    }

    // Test DFS traversal from graph
    var connectedDFS = graph.GetConnected_DFS().ToList();
    Assert.Equal(nodeCount, connectedDFS.Count);

    // Test BFS traversal from graph
    var connectedBFS = graph.GetConnected_BFS().ToList();
    Assert.Equal(nodeCount, connectedBFS.Count);

    // Test DFS from vertex
    var vertexDFS = vertices[0].GetConnected_DFS().ToList();
    Assert.Equal(nodeCount - 1, vertexDFS.Count); // Excluding self

    // Test BFS from vertex
    var vertexBFS = vertices[0].GetConnected_BFS().ToList();
    Assert.Equal(nodeCount, vertexBFS.Count); // Including self
  }

  [Theory]
  [InlineData("apple")]
  [InlineData("banana")]
  [InlineData("cherry")]
  public void Graph_TheoryTest_IsolatedVertices(string value)
  {
    var graph = new Graph<string>();

    var vertex = graph.AddVertex(value);
    var connectedDFS = graph.GetConnected_DFS().ToList();
    var connectedBFS = graph.GetConnected_BFS().ToList();

    // DFS returns empty for isolated vertices
    Assert.Empty(connectedDFS);

    // BFS returns the isolated vertex
    Assert.Single(connectedBFS);
    Assert.Equal(vertex, connectedBFS[0]);
  }

  [Fact]
  public void Graph_BidirectionalConnections_WorkCorrectly()
  {
    var graph = new Graph<string>();
    var v1 = graph.AddVertex("A");
    var v2 = graph.AddVertex("B");

    // Connect v1 to v2
    v1.Connect(v2);

    // Both should be in each other's vertex lists
    Assert.Contains(v2, v1.Vertices);
    Assert.Contains(v1, v2.Vertices);

    // Test traversals from both vertices
    var dfsFromV1 = v1.GetConnected_DFS().ToList();
    var dfsFromV2 = v2.GetConnected_DFS().ToList();

    Assert.Single(dfsFromV1);
    Assert.Equal(v2, dfsFromV1[0]);

    Assert.Single(dfsFromV2);
    Assert.Equal(v1, dfsFromV2[0]);
  }
}
